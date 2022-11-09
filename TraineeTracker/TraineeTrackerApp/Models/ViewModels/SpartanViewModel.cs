using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using TraineeTrackerApp.Utilities;

namespace TraineeTrackerApp.Models.ViewModels
{
    public class SpartanViewModel
    {
        public SpartanViewModel()
        {
            Weeks = new HashSet<Week>();
        }

        [Required]
        [DisplayName("ID")]
        public string Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public string Role { get; set; }

        public virtual ICollection<Course> Course { get; set; }

        public virtual ICollection<Week> Weeks { get; set; }
    }
}
