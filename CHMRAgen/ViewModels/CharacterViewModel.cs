using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CHMRAgen.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHMRAgen.ViewModels
{
    public class CharacterViewModel
    {
        [Required]
        public Character Character { get; set; }
        public List<Archetype> Archetypes { get; set; }
        public List<Feat> Feats { get; set; }

        public SelectList ArchetypeSelectList { get; set; }
        public SelectList FeatSelectList { get; set; }
    }
}
