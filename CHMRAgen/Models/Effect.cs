﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMRAgen.Models
{
    public class Effect
    {
        public int EffectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public RollTable Table { get; set; }
    }
}
