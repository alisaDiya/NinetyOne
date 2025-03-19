using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NinetyOne.Data;
using NinetyOne.Models;

namespace NinetyOne.Controllers
{

    public class ScoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ScoresController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var allPeople = await _context.People
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.SecondName)
                .ToListAsync();

            return View(allPeople);
        }

        [HttpPost]
        public async Task<IActionResult> Import()
        {
            //reading the csv
            string filePath = Path.Combine(_env.ContentRootPath, "CSV", "TestData.csv");

            if (!System.IO.File.Exists(filePath))
                return BadRequest("CSV file not found.");

            string csvData = System.IO.File.ReadAllText(filePath);

            
            var peopleFromCsv = CsvParser.ParseCsv(csvData);

            _context.People.AddRange(peopleFromCsv);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

      
        [HttpGet]
        public async Task<IActionResult> TopScorers()
        {
            // Error Handeling
            if (!await _context.People.AnyAsync())
                return Content("No data available.");

            //Responsible for getting max score 
            var topScore = await _context.People.MaxAsync(p => p.Score);

           //sorted by alpahbetical order
            var topScorers = await _context.People
                .Where(p => p.Score == topScore)
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.SecondName)
                .ToListAsync();

            return View(topScorers);
        }
    }
}