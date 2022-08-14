using System.Collections.ObjectModel;

namespace SmokeNoMore.Models
{
    public class Settings
    {
        public const string TABLE = "Settings";
        public const string UserName_COLUMN = $"{TABLE}.Username";
        public const string LastAccess_COLUMN = $"{TABLE}.LastAccess";
        public const string RunAtStartup_COLUMN = $"{TABLE}.RunAtStartup";
        public const string MorningReport_COLUMN = $"{TABLE}.MorningReport";
        public static readonly IEnumerable<string> ALL_COLUMNS =
            new ReadOnlyCollection<string>(new string[] { UserName_COLUMN, LastAccess_COLUMN, RunAtStartup_COLUMN, MorningReport_COLUMN });

        public string Username { get; set; }
        public DateTime? LastAccess { get; set; }
        public bool RunAtStartup { get; set; }
        public bool MorningReport { get; set; }
    }
}
