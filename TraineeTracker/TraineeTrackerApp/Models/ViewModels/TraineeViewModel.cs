using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TraineeTrackerApp.Models.ViewModels
{
    public class TraineeViewModel
    {
        public TraineeViewModel()
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

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public virtual ICollection<Course> Course { get; set; }

        public virtual ICollection<Week> Weeks { get; set; }
    }
}
