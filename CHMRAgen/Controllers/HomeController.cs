using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using CHMRAgen.Models;
using CHMRAgen.ViewModels;
using System.IO;
using System.Text.Json;

namespace CHMRAgen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _fileDirectory;
        private readonly List<Archetype> _archetypes;
        private readonly List<Feat> _feats;
        private readonly List<Creature> _creatures;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _fileDirectory = Environment.CurrentDirectory;
            //_archetypes = new List<Archetype>
            //    {
            //        DebugUtilities.GenerateArchetype(),
            //        DebugUtilities.GenerateArchetype()
            //    };
            //_feats = new List<Feat>
            //    {
            //        DebugUtilities.GenerateFeat(),
            //        DebugUtilities.GenerateFeat(),
            //        DebugUtilities.GenerateFeat()
            //    };

            ////lazy hack
            //_archetypes[1].ArchetypeId = 1;
            //_feats[1].FeatId = 1;
            //_feats[2].FeatId = 2;

            _archetypes = FileUtilities.ImportArchetypesFromJson();
            _feats = FileUtilities.ImportFeatsFromJson();
        }

        public IActionResult Index()
        {
            CharacterViewModel viewModel = new CharacterViewModel
            {
                Character = new Character(),
                Archetypes = _archetypes,
                Feats = _feats,
                ArchetypeSelectList = new SelectList(_archetypes, "ArchetypeId", "Name"),
                FeatSelectList = new SelectList(_feats, "FeatId", "Name")
            };

            //DEBUG
            //TestSerializeAndWrite(viewModel.Archetypes, "archetypes.json");
            //TestSerializeAndWrite(viewModel.Feats, "feats.json");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index([Bind("Character")]CharacterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["viewModel"] = JsonSerializer.Serialize(viewModel);
                return RedirectToAction("Output");
            }

            viewModel.Archetypes = _archetypes;
            viewModel.Feats = _feats;
            viewModel.ArchetypeSelectList = new SelectList(_archetypes, "ArchetypeId", "Name");
            viewModel.FeatSelectList = new SelectList(_feats, "FeatId", "Name");
            return View(viewModel);
        }

        public IActionResult Output()
        {
            if (TempData["viewModel"] != null)
            {
                CharacterViewModel viewModel = JsonSerializer.Deserialize<CharacterViewModel>(TempData["viewModel"] as string);
                viewModel.Character.Archetype = _archetypes
                    .Where(a => a.ArchetypeId == viewModel.Character.ArchetypeId)
                    .FirstOrDefault();

                viewModel.Character.Feats = _feats
                    .Where(f => viewModel.Character.FeatId.Contains(f.FeatId))
                    .ToList();

                return View(viewModel.Character);
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void TestSerializeAndWrite(Object outObject, string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_fileDirectory, filename)))
            {
                outputFile.WriteLine(JsonSerializer.Serialize(outObject));
            }
        }
    }
}
