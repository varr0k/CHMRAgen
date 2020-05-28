using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMRAgen.Models
{
    public static class DebugUtilities
    {
        public static Archetype GenerateArchetype() => new Archetype
        {
            ArchetypeId = 0,
            Name = "Aethermaw",
            Description = "Tanky types that thrive on taunting and draining aether from enemies.",
            Subtype = "Tank",
            BaseGrit = 10,
            ActiveEffects = new List<Effect>
                {
                    new Effect
                    {
                        EffectId = 0,
                        Name = "Aetherdrain",
                        Description = "Can drain aether from aether-wielding enemies - mainly inhibits casters.",
                        Text = "Twice per event, can apply a -100 to a caster enemy's attack roll."
                    },
                    new Effect
                    {
                        EffectId = 1,
                        Name = "Aetherfocus",
                        Description = "Can draw attention to self in the event of random attacks from enemies.",
                        Text = "Twice per event, can take the opportunity to direct a number of enemies' attention for two rounds.",
                        Table = new RollTable
                        {
                            Lines = new List<RollTableLine>
                            {
                                new RollTableLine
                                {
                                    Target = "901+",
                                    Text = "Taunt all enemies",
                                    Order = 0
                                },
                                new RollTableLine
                                {
                                    Target = "601-900",
                                    Text = "Taunt all enemies",
                                    Order = 1
                                },
                                new RollTableLine
                                {
                                    Target = "301-600",
                                    Text = "Taunt all enemies",
                                    Order = 2
                                },
                                new RollTableLine
                                {
                                    Target = "0-300",
                                    Text = "Taunt all enemies",
                                    Order = 3
                                }
                            }
                        }
                    }
                },
            PassiveEffects = new List<Effect>
                {
                    new Effect
                    {
                        EffectId = 2,
                        Name = "Hardy",
                        Description = "Is granted a +100 passive bonus to all defense rolls for self."
                    }
                }
        };

        public static Feat GenerateFeat() => new Feat
        {
            FeatId = 0,
            Name = "Toughness",
            Description = "Adds 1 permanent point of Grit per rank to one's total Grit.",
            Rank = 0,
            RankIncrement = 1,
            GritBonus = 1
        };
    }
}
