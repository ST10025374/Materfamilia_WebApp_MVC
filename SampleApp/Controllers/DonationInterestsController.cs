using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    [Authorize(Roles = "Client")]  //if uncommented only Client have access to the Donation Page
    public class DonationInterestsController : Controller
    {
        /// <summary>
        /// The database context for donation interests.
        /// </summary>
        private readonly MaterDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DonationInterestsController"/> class.
        /// </summary>
        /// <param name="context"></param>
        public DonationInterestsController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests
        /// <summary>
        /// Method to get all donation interests
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonationInterests.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Details/5
        /// <summary>
        /// Method to get the details of a donation interest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Create
        /// <summary>
        /// Method to create a donation interest
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: DonationInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Method to create a donation interest
        /// </summary>
        /// <param name="donationInterest"></param>
        /// <returns></returns>
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

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Edit/5
        /// <summary>
        /// Method to edit a donation interest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //---------------------------------------------------------------------//
        // POST: DonationInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="donationInterest"></param>
        /// <returns></returns>
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

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //---------------------------------------------------------------------//
        // POST: DonationInterests/Delete/5
        /// <summary>
        /// Method to delete a donation interest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to check if the donation interest exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DonationInterestExists(int id)
        {
            return _context.DonationInterests.Any(e => e.DonationId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 