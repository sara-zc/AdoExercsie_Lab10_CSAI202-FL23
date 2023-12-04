using FL23_Lab10_AdoExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FL23_Lab10_AdoExercise.Pages
{
    public class DeleteModel : PageModel
    {
        public DB db { get; set; }
        [BindProperty(SupportsGet =true)]
        public string ssn { get; set; }

        [BindProperty(SupportsGet = true)]
        public string msg { get; set; }
        public DeleteModel(DB db) {
            this.db = db;
        }
        public void OnGet(string ssn)
        {
            this.ssn = ssn;
        }
        public IActionResult? OnPost() { 
            msg = db.DeleteEmployee(ssn);
            if(msg == "1")
            {
                return RedirectToPage("/Index");
            }
            return null;
        }
    }
}
