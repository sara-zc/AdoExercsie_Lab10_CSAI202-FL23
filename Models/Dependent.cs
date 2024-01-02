using System.ComponentModel.DataAnnotations;

namespace FL23_Lab10_AdoExercise.Models
{
    public class Dependent
    {
        [Required]
        public int Essn { get; set; }
        [Required]
        public string Dependent_name { get; set; }
        public string Sex { get; set; }
        public string Bdate { get; set; }
        public string Relationship { get; set; }
    }
}
