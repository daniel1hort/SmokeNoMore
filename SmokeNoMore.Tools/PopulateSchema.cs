using Dapper;
using SmokeNoMore.Core;
using SmokeNoMore.Models;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeNoMore.Tools
{
    public class PopulateSchema : IToolProcess
    {
        private readonly DbConnection connection;
        private readonly Compiler compiler;

        public PopulateSchema(DbConnection connection, Compiler compiler)
        {
            this.connection = connection;
            this.compiler = compiler;
        }

        public void Execute()
        {
            PopulateSettings();
            PopulatePoisonTypes();
            PopulatePoison();
        }

        private void PopulateSettings()
        {
            var insertSettingsQuery = compiler.Compile(new Query(Settings.TABLE)
                .AsInsert(new Settings()
                {
                    Username = "Vlad",
                    MorningReport = true,
                    RunAtStartup = true
                }));
            connection.Execute(insertSettingsQuery.Sql, insertSettingsQuery.NamedBindings);
        }

        private void PopulatePoisonTypes()
        {
            var insertCigarettsQuery = compiler.Compile(new Query(PoisonType.TABLE)
                .AsInsert(new PoisonType()
                {
                    Name = "Cigarettes",
                    Warning = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed nunc dui, pellentesque sit amet mattis id, pulvinar nec justo. Donec semper ipsum erat, nec interdum justo aliquam vel. Mauris vitae convallis lectus. Sed nunc dui, porta id erat a, tincidunt vehicula ante. Fusce efficitur eros ac sem auctor interdum. Ut eu tellus nec odio blandit rhoncus id sed ante. Aliquam erat volutpat. Ut purus mauris, sollicitudin vel augue vulputate, egestas blandit velit. Nam volutpat tortor nec purus tincidunt vulputate. Curabitur at tristique lorem. Duis semper libero leo, ut ornare dui finibus in."
                }));
            connection.Execute(insertCigarettsQuery.Sql, insertCigarettsQuery.NamedBindings);
        }

        private void PopulatePoison()
        {
            var getTypeQuery = compiler.Compile(new Query()
                .From(PoisonType.TABLE)
                .Select(PoisonType.Id_COLUMN)
                .Where(PoisonType.Name_COLUMN, "Cigarettes"));
            var type = connection.QueryFirst<PoisonType>(getTypeQuery.Sql, getTypeQuery.NamedBindings);

            var insertPoisonsQuery = compiler.Compile(new Query(Poison.TABLE)
                .AsInsert(new Poison()
                {
                    Name = "Dunhill",
                    TypeId = type.Id,
                    ItemName = "cig",
                    Price = 2400,
                    Quantity = 20
                }));
            connection.Execute(insertPoisonsQuery.Sql, insertPoisonsQuery.NamedBindings);
        }
    }
}
