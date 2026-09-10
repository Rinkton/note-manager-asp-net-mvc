using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<NoteModel> _notes = new List<NoteModel>();
        private static int _nextId = 1;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var notes = await _context.Notes.OrderByDescending(n => n.Id).ToListAsync();
            return View(notes);
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

        [HttpPost]
        public async Task<IActionResult> SubmitFormAsync(string noteText)
        {
            if(!string.IsNullOrWhiteSpace(noteText)) {
                var note = new NoteModel { Text = noteText };
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
