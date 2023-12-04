using Microsoft.AspNetCore.Mvc;

namespace FL23_Lab10_AdoExercise.Models
{
    [BindProperties(SupportsGet =true)]
    public class Employee
    {
        public string SSN { get; set; }
        public string Fname { get; set; }
        public char Minit { get; set; }
        public string Lname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
