using System.Collections.Generic;

namespace PopulationGrowth
{
    public class Organism
    {
        public string Name { get; set; }
        public int? GrowthDuration { get; set; }
        public double? DailyGrowth { get; set; }
        public List<double> PopulationRecord { get; set; }

    }
}
