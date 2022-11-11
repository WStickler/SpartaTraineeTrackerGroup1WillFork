using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TraineeTrackerApp.Models.ViewModels
{
    public class WeekViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Start { get; set; }
        [Required]
        public string? Stop { get; set; }
        [Required]
        public string? Continue { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Week Starting")]
        public DateTime WeekStart { get; set; }
        [Display(Name = "Github Repo Link")]
        public string? GitHubLink { get; set; }
        [Required]
        [Display(Name = "Technical Skill")]
        public Proficiency TechnicalSkill { get; set; }
        [Required]
        [Display(Name = "Consultant Skill")]
        public Proficiency ConsultantSkill { get; set; }
        [ForeignKey("Spartan")]
        public string? SpartanId { get; set; }
    }
}
