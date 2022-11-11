using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TraineeTrackerApp.Models;
using TraineeTrackerApp.Models.ViewModels;

namespace TraineeTrackerApp.Controllers
{
    public class Utils
    {
        public static SpartanViewModel SpartanToViewModel(Spartan spartan, UserManager<Spartan> userManager) =>
            new SpartanViewModel
            {
                Id = spartan.Id,  
                FirstName = spartan.FirstName,
                LastName = spartan.LastName,
                StartDate = spartan.StartDate,
                Weeks = spartan.Weeks,
                Role = userManager.GetRolesAsync(spartan).Result[0]
            };
        public static TraineeViewModel TraineeToViewModel(Spartan spartan, UserManager<Spartan> userManager) =>
            new TraineeViewModel
            {
                Id = spartan.Id,
                FirstName = spartan.FirstName,
                LastName = spartan.LastName,
                StartDate = spartan.StartDate,
                Weeks = spartan.Weeks,
                Email = spartan.Email,
                PhoneNumber = spartan.PhoneNumber
            };
        public static WeekViewModel WeekToViewModel(Week week) =>
            new WeekViewModel
            {
                Id = week.Id,
                Start = week.Start,
                Stop = week.Stop,
                Continue = week.Continue,
                WeekStart = week.WeekStart,
                GitHubLink = week.GitHubLink,
                TechnicalSkill = week.TechnicalSkill,
                ConsultantSkill = week.ConsultantSkill,
                SpartanId = week.SpartanId
            };

    }
}
