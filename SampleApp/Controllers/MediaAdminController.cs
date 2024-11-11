using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class MediaAdminController : Controller
    {
        /// <summary>
        /// this is the context for the database
        /// </summary>
        private readonly MaterDBContext _context;

        /// <summary>
        /// This constructor initializes the context
        /// </summary>
        /// <param name="context"></param>
        public MediaAdminController(MaterDBContext context)
        {
            _context = context;
        }

        // GET: MediaAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaContents.ToListAsync());
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: MediaAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MediaContent mediaContent)
        {
            if (ModelState.IsValid)
            {
                if (mediaContent.ImageFile != null && mediaContent.ImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await mediaContent.ImageFile.CopyToAsync(memoryStream);
                        mediaContent.ImageData = memoryStream.ToArray();
                        mediaContent.ImageFileName = mediaContent.ImageFile.FileName;
                    }
                }

                _context.Add(mediaContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaContent);
        }


        // GET: MediaAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent == null) return NotFound();

            return View(mediaContent);
        }

        // POST: MediaAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MediaContent mediaContent)
        {
            if (id != mediaContent.MediaId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.MediaContents.Any(e => e.MediaId == mediaContent.MediaId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mediaContent);
        }

        // GET: MediaAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mediaContent = await _context.MediaContents
                .FirstOrDefaultAsync(m => m.MediaId == id);
            if (mediaContent == null) return NotFound();

            return View(mediaContent);
        }

        // POST: MediaAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent != null)
            {
                _context.MediaContents.Remove(mediaContent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
