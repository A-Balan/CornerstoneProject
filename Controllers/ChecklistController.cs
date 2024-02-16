using CornerstoneChecklist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CornerstoneChecklist.Controllers
{
    public class ChecklistController : Controller

    {
        private readonly IWebHostEnvironment _environment;

        public ChecklistController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            var checklistData = LoadChecklistData();
            return View(checklistData);
        }

        private List<ChecklistCategory> LoadChecklistData()
        {
            var filePath = Path.Combine(_environment.WebRootPath, "payload.json");
            var json = System.IO.File.ReadAllText(filePath);
            var categories = JsonConvert.DeserializeObject<Dictionary<string, List<ChecklistItem>>>(json);

            return categories.Select(category => new ChecklistCategory
            {
                CategoryName = category.Key,
                Items = category.Value
            }).ToList();
        }

        public class Item
        {
            public int Id { get; set; }
            // Other properties
        }
    }
}