﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class MediaContentsController : Controller
    {
        private readonly MaterDBContext _context;

        public MediaContentsController(MaterDBContext context)
        {
            _context = context;
        }

        // GET: MediaContents
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaContents.ToListAsync());
        }

        //// GET: MediaContents/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MediaContents/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(MediaContent mediaContent)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (mediaContent.ImageFile != null && mediaContent.ImageFile.Length > 0)
        //        {
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", mediaContent.ImageFile.FileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await mediaContent.ImageFile.CopyToAsync(stream);
        //            }

        //            mediaContent.Url = "/images/" + mediaContent.ImageFile.FileName;
        //        }

        //        _context.Add(mediaContent);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mediaContent);
        //}

        //// GET: MediaContents/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var mediaContent = await _context.MediaContents.FindAsync(id);
        //    if (mediaContent == null) return NotFound();

        //    return View(mediaContent);
        //}

        //// POST: MediaContents/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, MediaContent mediaContent)
        //{
        //    if (id != mediaContent.MediaId) return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(mediaContent);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!_context.MediaContents.Any(e => e.MediaId == mediaContent.MediaId))
        //                return NotFound();
        //            else
        //                throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mediaContent);
        //}

        //// GET: MediaContents/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var mediaContent = await _context.MediaContents
        //        .FirstOrDefaultAsync(m => m.MediaId == id);
        //    if (mediaContent == null) return NotFound();

        //    return View(mediaContent);
        //}

        //// POST: MediaContents/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var mediaContent = await _context.MediaContents.FindAsync(id);
        //    if (mediaContent != null)
        //    {
        //        _context.MediaContents.Remove(mediaContent);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
