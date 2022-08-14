using SqlKata;
using System.Collections.ObjectModel;

namespace SmokeNoMore.Models
{
    public class Poison
    {
        public const string TABLE = "Poison";
        public const string Id_COLUMN = $"{TABLE}.Id";
        public const string Name_COLUMN = $"{TABLE}.Name";
        public const string TypeId_COLUMN = $"{TABLE}.TypeId";
        public const string Price_COLUMN = $"{TABLE}.Price";
        public const string Quantity_COLUMN = $"{TABLE}.Quantity";
        public const string ItemName_COLUMN = $"{TABLE}.ItemName";
        public static readonly IEnumerable<string> ALL_COLUMNS =
            new ReadOnlyCollection<string>(new string[] { Id_COLUMN, Name_COLUMN, TypeId_COLUMN, Price_COLUMN, Quantity_COLUMN, ItemName_COLUMN });

        public string Id { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }

        [Ignore]
        public PoisonType Type { get; set; }
        [Ignore]
        public decimal ActualPrice => ((decimal)Price) / 100m;
    }
}
