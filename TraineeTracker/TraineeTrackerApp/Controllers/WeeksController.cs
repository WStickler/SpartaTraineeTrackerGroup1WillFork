﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineeTrackerApp.Data;
using TraineeTrackerApp.Models;
using TraineeTrackerApp.Services;

namespace TraineeTrackerApp.Controllers
{
    public class WeeksController : Controller
    {
        private readonly IWeekService _service;

        public WeeksController(IWeekService service)
        {
            _service = service;
        }

        // GET: Weeks
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _service.Weeks.Include(w => w.Spartan);
            //return View(await applicationDbContext.ToListAsync());
            return View(await _service.GetWeeksAsync());
        }

        // GET: Weeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.GetWeeksAsync().Result == new List<Week>())
            {
                return NotFound();
            }

            //var week = await _service.Weeks
            //    .Include(w => w.Spartan)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var week = await _service.GetWeekByIdAsync(id);
            if (week == null)
            {
                return NotFound();
            }

            return View(week);
        }

        // GET: Weeks/Create
        public IActionResult Create()
        {
            ViewData["SpartanId"] = new SelectList(_service.GetSpartansAsync().Result, "Id", "Id");
            return View();
        }

        // POST: Weeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Start,Stop,Continue,WeekStart,GitHubLink,TechnicalSkill,ConsultantSkill,SpartanId")] Week week)
        {
            if (ModelState.IsValid)
            {
                await _service.AddWeek(week);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpartanId"] = new SelectList(_service.GetSpartansAsync().Result, "Id", "Id", week.SpartanId);
            return View(week);
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
            ViewData["SpartanId"] = new SelectList(_service.GetSpartansAsync().Result, "Id", "Id", week.SpartanId);
            return View(week);
        }

        // POST: Weeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start,Stop,Continue,WeekStart,GitHubLink,TechnicalSkill,ConsultantSkill,SpartanId")] Week week)
        {
            if (id != week.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var weekToUpdate = _service.GetWeekByIdAsync(id).Result;
                    weekToUpdate = week;
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpartanId"] = new SelectList(_service.GetSpartansAsync().Result, "Id", "Id", week.SpartanId);
            return View(week);
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
