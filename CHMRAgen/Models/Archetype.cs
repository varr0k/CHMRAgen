using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMRAgen.Models
{
    public class Archetype
    {
        public int ArchetypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subtype { get; set; }
        public int BaseGrit { get; set; }
        public List<Effect> ActiveEffects { get; set; }
        public List<Effect> PassiveEffects { get; set; }
    }
}
