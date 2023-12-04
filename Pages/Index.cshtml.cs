﻿using FL23_Lab10_AdoExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace FL23_Lab10_AdoExercise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public DB db { get; set; }
        public DataTable dt { get; set; }

        [BindProperty(SupportsGet = true)]
        public string selectedSSN { get; set; }

        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("Employee");
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostDelete(string ssn)
        {
            Console.WriteLine("Inside onpostdelete.");
            return RedirectToPage("/Delete", new { ssn = ssn});
        }
    }
}