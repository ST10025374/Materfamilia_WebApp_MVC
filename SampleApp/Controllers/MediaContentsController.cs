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
    [Authorize(Roles = "Admin")]  //if uncommented only Admin have access to the Media Page
    public class MediaContentsController : Controller
    {
        /// <summary>
        /// The database context for media contents.
        /// </summary>
        private readonly MaterDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaContentsController"/> class.
        /// </summary>
        /// <param name="context"></param>
        public MediaContentsController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents
        /// <summary>
        /// Method to get all media contents
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaContents.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Details/5
        /// <summary>
        /// Method to get the details of a media content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContents
                .FirstOrDefaultAsync(m => m.MediaId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }

            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Create
        /// <summary>
        /// Method to create a media content
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: MediaContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Method to create a media content
        /// </summary>
        /// <param name="mediaContent"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaId,Type,Url,Description")] MediaContent mediaContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Edit/5
        /// <summary>
        /// Method to edit a media content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent == null)
            {
                return NotFound();
            }
            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // POST: MediaContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Method to edit a media content
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mediaContent"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MediaId,Type,Url,Description")] MediaContent mediaContent)
        {
            if (id != mediaContent.MediaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaContentExists(mediaContent.MediaId))
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
            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Delete/5
        /// <summary>
        /// Method to delete a media content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContents
                .FirstOrDefaultAsync(m => m.MediaId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }

            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // POST: MediaContents/Delete/5
        /// <summary>
        /// Method to delete a media content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent != null)
            {
                _context.MediaContents.Remove(mediaContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to check if a media content exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MediaContentExists(int id)
        {
            return _context.MediaContents.Any(e => e.MediaId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 