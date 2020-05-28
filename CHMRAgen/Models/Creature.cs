using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMRAgen.Models
{
    public class Creature
    {
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public string Subtype { get; set; }
        public int BaseGrit { get; set; }
        public List<Effect> Effects { get; set; }
    }
}
