using FL23_Lab10_AdoExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FL23_Lab10_AdoExercise.Pages
{
    [BindProperties(SupportsGet = true)]
    public class CreateModel : PageModel
    {
        public DB db { get; set; }
        public string msg { get; set; }
        public Employee emp { get; set; }
        public CreateModel(DB db)
        {
            this.db = db;
            msg = "";
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string res = db.AddEmployee(emp);
            if (res == "1")
                msg = "successfully added new employee!";
            else
                msg = res;
        }
    }
}
