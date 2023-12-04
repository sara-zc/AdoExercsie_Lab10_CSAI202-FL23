using FL23_Lab10_AdoExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FL23_Lab10_AdoExercise.Pages
{
    public class UpdateModel : PageModel
    {
        public DB db { get; set; }
        UpdateModel(DB db) {
            this.db = db;
        }
        public void OnGet()
        {
        }
        public void OnPost() { 

        }
    }
}
