using System.ComponentModel.DataAnnotations;

namespace FL23_Lab10_AdoExercise.Models
{
    public class DeptLocations
    {
        [Required]
        public int Dnumber { get; set; }
        [Required]
        public string Dlocation { get; set; }
    }
}
