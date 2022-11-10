﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineeTrackerApp.Data;
using TraineeTrackerApp.Models;
using TraineeTrackerApp.Models.ViewModels;
using TraineeTrackerApp.Services;

namespace TraineeTrackerApp.Controllers
{
    [Authorize]
    public class TraineesController : Controller
    {
        private readonly ITraineeService _traineeService;
        private readonly IWeekService _weekService;
        private UserManager<Spartan> _userManager;

        public TraineesController(ITraineeService traineeService, IWeekService weekService, UserManager<Spartan> userManager)
        {
            _traineeService = traineeService;
            _weekService = weekService;
            _userManager = userManager;
        }

        // GET: Trainees

        [Authorize(Roles = "Trainee, Trainer, Admin")]
        public async Task<IActionResult> Index()
        {
            var traineeSpartans = await _userManager.GetUsersInRoleAsync("Trainee");
            List<TraineeViewModel> traineeViewModels = new List<TraineeViewModel>();
            foreach (var s in traineeSpartans)
            {
                var traineeViewModel = Utils.TraineeToViewModel(s, _userManager);
                traineeViewModels.Add(traineeViewModel);
            }
            return View(traineeViewModels);
        }

        // GET: Trainees/Details/{id}
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _traineeService.GetSpartansAsync().Result == new List<Spartan>())
            {
                return NotFound();
            }
            var spartan = await _traineeService.GetSpartanByIdAsync(id);
            if (spartan == null)
            {
                return NotFound();
            }

            return View(spartan);
        }

        // GET: Trainees/{TraineeId}/Weeks
        public async Task<IActionResult> Tracker(string? id)
        {
            var weeks = await _traineeService.GetWeeksBySpartanIdAsync(id);
            return View(weeks);
        }

        // GET: Trainees/{TraineeId}/Weeks/{weekId}
        public async Task<IActionResult> WeekDetails(int? id)
        {
            if (id == null || _weekService.GetWeeksAsync().Result == new List<Week>())
            {
                return NotFound();
            }

            var week = await _weekService.GetWeekByIdAsync(id);
            if (week == null)
            {
                return NotFound();
            }

            return View(week);
        }



    }
}
