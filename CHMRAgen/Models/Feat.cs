using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMRAgen.Models
{
    public class Feat
    {
        public int FeatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int RankIncrement { get; set; }
        public int GritBonus { get; set; }
    }
}
