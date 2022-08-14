using Dapper;
using SmokeNoMore.Models;
using SmokeNoMore.Models.Misc;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeNoMore.Domain
{
    public static class AppDomain
    {
        private static DateTime GetFirstDayOfWeek(DateTime day)
            => day.Date.AddDays(-(((int)day.DayOfWeek + 6) % 7));
            

        public static Settings GetSettings(DbConnection connection, Compiler compiler)
        {
            var query = compiler.Compile(new Query()
                .Select(Settings.ALL_COLUMNS.ToArray())
                .From(Settings.TABLE));
            var settings = connection.Query<Settings>(query.Sql, query.NamedBindings)
                .FirstOrDefault();
            return settings;
        }

        public static void UpdateSettings(DbConnection connection, Compiler compiler, 
            Settings settings)
        {
            var query = compiler.Compile(new Query(Settings.TABLE).AsUpdate(settings));
            connection.Execute(query.Sql, query.NamedBindings);
        }

        public static IEnumerable<Poison> GetPoisons(DbConnection connection, Compiler compiler, 
            params (string, object)[] where)
        {
            var rawQuery = new Query()
                .Select(Poison.ALL_COLUMNS.ToArray())
                .Select(PoisonType.ALL_COLUMNS.ToArray())
                .From(Poison.TABLE)
                .Join(PoisonType.TABLE, PoisonType.Id_COLUMN, Poison.TypeId_COLUMN);
            foreach(var item in where)
                rawQuery = rawQuery.Where(item.Item1, item.Item2);

            var query = compiler.Compile(rawQuery);
            var poisons = connection.Query<Poison, PoisonType, Poison>(
                query.Sql, (poison, type) =>
                {
                    poison.Type = type;
                    return poison;
                }, param: query.NamedBindings, splitOn: "Id");
            return poisons;
        }

        public static void ConsumePoison(DbConnection connection, Compiler compiler, 
            Poison poison)
        {
            var consumption = new Consumption()
            {
                TakenAt = DateTime.Now,
                PoisonId = poison.Id
            };
            var query = compiler.Compile(new Query(Consumption.TABLE)
                .AsInsert(consumption));
            connection.Execute(query.Sql, query.NamedBindings);
        }

        public static int GetCunsumptionsCount(DbConnection connection, Compiler compiler,
            DateTime begin, DateTime end, Poison poison)
        {
            var query = compiler.Compile(new Query()
                .Select(Consumption.Id_COLUMN)
                .From(Consumption.TABLE)
                .WhereBetween(Consumption.TakenAt_COLUMN, begin, end)
                .Where(Consumption.PoisonId_COLUMN, poison.Id)
                .AsCount());
            var count = connection.ExecuteScalar<int>(query.Sql, query.NamedBindings);
            return count;
        }

        public static IEnumerable<StatsModel> GetStatsForPoison(DbConnection connection, Compiler compiler,
            DateTime begin, DateTime end, Poison poison)
        {   
            var query = compiler.Compile(new Query()
                .SelectRaw($"count({Consumption.Id_COLUMN}) as Count")
                .SelectRaw($"date({Consumption.TakenAt_COLUMN}) as Date")
                .From(Consumption.TABLE)
                .WhereBetween(Consumption.TakenAt_COLUMN, begin.Date, end.Date)
                .Where(Consumption.PoisonId_COLUMN, poison.Id)
                .GroupBy("Date"));
            var result = connection.Query<StatsModel>(query.Sql, query.NamedBindings);
            var results = Enumerable.Range(0, (end.Date - begin.Date).Days)
                .Select(a => begin.Date.AddDays(a))
                .Select(a => result.FirstOrDefault(b => b.Date == a.Date)
                    ?? new StatsModel() { Date = a });
            return results;
        }

        public static StatsModel GetDayStatsForPoison(DbConnection connection, Compiler compiler,
            DateTime day, Poison poison)
            => GetStatsForPoison(connection, compiler,
                day.Date, day.Date.AddDays(1), poison).First();

        public static int GetWeekStatsForPoison(DbConnection connection, Compiler compiler,
            DateTime dayInWeek, Poison poison)
            => GetStatsForPoison(connection, compiler,
                GetFirstDayOfWeek(dayInWeek),
                GetFirstDayOfWeek(dayInWeek).AddDays(7),
                poison).Select(a => a.Count).Sum();
    }
}
