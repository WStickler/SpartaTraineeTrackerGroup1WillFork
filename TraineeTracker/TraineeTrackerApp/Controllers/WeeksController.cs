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
    public class WeeksController : Controller
    {
        private readonly IWeekService _service;
        private UserManager<Spartan> _userManager;

        public WeeksController(IWeekService service, UserManager<Spartan> userManager)
        {
            _service = service;
            _userManager = userManager;
        }


        // GET: Weeks
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var weeks = await _service.GetWeeksAsync();
            var weekViewModels = new List<WeekViewModel>();
            foreach (var week in weeks)
            {
                var weekViewModel = Utils.WeekToViewModel(week);
                weekViewModels.Add(weekViewModel);
            }
            var filteredWeekViewModels = weekViewModels.Where(w => w.SpartanId == currentUser.Id)
                .OrderBy(w => w.WeekStart.Date).ToList();
            return View(filteredWeekViewModels);
        }

        // GET: Weeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.GetWeeksAsync().Result == new List<Week>())
            {
                return NotFound();
            }
            var week = await _service.GetWeekByIdAsync(id);
            if (week == null) return NotFound();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (week.SpartanId != currentUser.Id)
            {
                return Unauthorized();
            }
            var weekViewModel = Utils.WeekToViewModel(week);
            return View(weekViewModel);
        }

        // GET: Weeks/Create
        [Authorize(Roles = "Trainee")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "Trainee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Start,Stop,Continue,WeekStart,GitHubLink,TechnicalSkill,ConsultantSkill")] Week week)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            week.SpartanId = currentUser.Id;
            week.Spartan = currentUser;

            if (week.SpartanId != null)
            {
                await _service.AddWeek(week);
                return RedirectToAction(nameof(Index));
            }
            var weekViewModel = Utils.WeekToViewModel(week);
            return View(weekViewModel);
        }

        // GET: Weeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.GetWeeksAsync().Result == new List<Week>())
            {
                return NotFound();
            }

            var week = await _service.GetWeekByIdAsync(id);
            if (week == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (week.SpartanId != currentUser.Id)
            {
                return Unauthorized();
            }
            var weekViewModel = Utils.WeekToViewModel(week);
            return View(weekViewModel);
        }

        // POST: Weeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start,Stop,Continue,WeekStart,GitHubLink,TechnicalSkill,ConsultantSkill")] Week week)
        {
            if (id != week.Id)
            {
                return NotFound();
            }

            try
            {
                var weekToUpdate = _service.GetWeekByIdAsync(id).Result;
                if (weekToUpdate == null) return NotFound();
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                if (weekToUpdate.SpartanId != currentUser.Id) return Unauthorized();;
                weekToUpdate.WeekStart = week.WeekStart;
                weekToUpdate.Start = week.Start ?? weekToUpdate.Start;
                weekToUpdate.Stop = week.Stop ?? weekToUpdate.Stop;
                weekToUpdate.Continue = week.Continue ?? weekToUpdate.Continue;
                weekToUpdate.GitHubLink = week.GitHubLink ?? weekToUpdate.GitHubLink;
                weekToUpdate.TechnicalSkill = week.TechnicalSkill;
                weekToUpdate.ConsultantSkill = week.ConsultantSkill;

                await _service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeekExists(week.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Details), new {id = week.Id});
        }

        // GET: Weeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service.GetWeeksAsync().Result == new List<Week>())
            {
                return NotFound();
            }

            var week = await _service.GetWeekByIdAsync(id);
            if (week == null)
            {
                return NotFound();
            }

            return View(week);
        }

        // POST: Weeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.GetWeeksAsync().Result == new List<Week>())
            {
                return Problem("Entity set 'ApplicationDbContext.Weeks' is empty.");
            }

            
            var week = await _service.GetWeekByIdAsync(id);
            if (week == null)
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (week.SpartanId != currentUser.Id)
            {
                return Unauthorized();
            }
            if (week != null)
            {
                await _service.RemoveWeekAsync(week);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool WeekExists(int id)
        {
            return _service.GetWeekByIdAsync(id).Result != null;
        }
    }
}
