using System.Collections.ObjectModel;

namespace SmokeNoMore.Models
{
    public class PoisonType
    {
        public const string TABLE = "PoisonType";
        public const string Id_COLUMN = $"{TABLE}.Id";
        public const string Name_COLUMN = $"{TABLE}.Name";
        public const string Warning_COLUMN = $"{TABLE}.Warning";
        public static readonly IEnumerable<string> ALL_COLUMNS =
            new ReadOnlyCollection<string>(new string[] { Id_COLUMN, Name_COLUMN, Warning_COLUMN });

        public string Id { get; set; }
        public string Name { get; set; }
        public string Warning { get; set; }
    }
}
