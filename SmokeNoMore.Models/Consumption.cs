using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeNoMore.Models
{
    public class Consumption
    {
        public const string TABLE = "Consumption";
        public const string Id_COLUMN = $"{TABLE}.Id";
        public const string PoisonId_COLUMN = $"{TABLE}.PoisonId";
        public const string TakenAt_COLUMN = $"{TABLE}.TakenAt";

        public string Id { get; set; }
        public string PoisonId { get; set; }
        public DateTime TakenAt { get; set; }

        [Ignore]
        public Poison Poison { get; set; }
    }
}
