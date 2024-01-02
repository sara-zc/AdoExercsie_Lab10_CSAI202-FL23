using System.ComponentModel.DataAnnotations;

namespace FL23_Lab10_AdoExercise.Models
{
    public class WorksOn
    {
        [Required]
        public int Essn { get; set; }
        public int Pno { get; set; }
        public int Hours { get; set; }
    }
}
