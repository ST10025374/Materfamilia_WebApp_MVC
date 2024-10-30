using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class DonationInterestsController : Controller
    {
        private readonly MaterDBContext _context;

        public DonationInterestsController(MaterDBContext context)
        {
            _context = context;
        }

        // GET: DonationInterests
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonationInterests.ToListAsync());
        }

        // GET: DonationInterests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationInterest = await _context.DonationInterests
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donationInterest == null)
            {
                return NotFound();
            }

            return View(donationInterest);
        }

        // GET: DonationInterests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonationInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,FirstName,LastName,PhoneNumber,AmountPledged,DateSubmitted")] DonationInterest donationInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donationInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donationInterest);
        }

        // GET: DonationInterests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationInterest = await _context.DonationInterests.FindAsync(id);
            if (donationInterest == null)
            {
                return NotFound();
            }
            return View(donationInterest);
        }

        // POST: DonationInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationId,FirstName,LastName,PhoneNumber,AmountPledged,DateSubmitted")] DonationInterest donationInterest)
        {
            if (id != donationInterest.DonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donationInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationInterestExists(donationInterest.DonationId))
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
            return View(donationInterest);
        }

        // GET: DonationInterests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationInterest = await _context.DonationInterests
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donationInterest == null)
            {
                return NotFound();
            }

            return View(donationInterest);
        }

        // POST: DonationInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donationInterest = await _context.DonationInterests.FindAsync(id);
            if (donationInterest != null)
            {
                _context.DonationInterests.Remove(donationInterest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationInterestExists(int id)
        {
            return _context.DonationInterests.Any(e => e.DonationId == id);
        }
    }
}
