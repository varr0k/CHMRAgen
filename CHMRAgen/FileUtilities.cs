using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using CHMRAgen.Models;

namespace CHMRAgen
{
    public static class FileUtilities
    {
        private static readonly string _baseDir = Path.Combine(Environment.CurrentDirectory + "\\App_Data");
        private static readonly string _archetypesName = "archetypes.json";
        private static readonly string _featsName = "feats.json";
        private static readonly string _creaturesName = "creatures.json";

        public static List<Archetype> ImportArchetypesFromJson()
        {
            string path = Path.Combine(_baseDir, _archetypesName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Archetype>>(json);
        }
        public static List<Feat> ImportFeatsFromJson()
        {
            string path = Path.Combine(_baseDir, _featsName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Feat>>(json);
        }
        public static List<Creature> ImportCreaturesFromJson()
        {
            string path = Path.Combine(_baseDir, _creaturesName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Creature>>(json);
        }
    }
}
