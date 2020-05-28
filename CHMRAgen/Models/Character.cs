using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHMRAgen.Models
{
    public class Character
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        public string Description { get; set; }
        public Archetype Archetype { get; set; }
        [Required]
        [Display(Name = "Archetype")]
        public int ArchetypeId { get; set; }
        public List<Feat> Feats { get; set; }
        [Display(Name = "Feats")]
        public int[] FeatId { get; set; }
    }
}
