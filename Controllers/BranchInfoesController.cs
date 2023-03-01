using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bankingMVCApp_EF.Models.EF;

namespace bankingMVCApp_EF.Controllers
{
    public class BranchInfoesController : Controller
    {
        private readonly bankDBContext _context = new();

        //public BranchInfoesController(bankDBContext context)
        //{
        //    _context = context;
        //}

        // GET: BranchInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BranchInfos.ToListAsync());
        }

        // GET: BranchInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos
                .FirstOrDefaultAsync(m => m.BranchId == id);
            if (branchInfo == null)
            {
                return NotFound();
            }

            return View(branchInfo);
        }

        // GET: BranchInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BranchInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchId,BranchName,BranchCity")] BranchInfo branchInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchInfo);
        }

        // GET: BranchInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos.FindAsync(id);
            if (branchInfo == null)
            {
                return NotFound();
            }
            return View(branchInfo);
        }

        // POST: BranchInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchId,BranchName,BranchCity")] BranchInfo branchInfo)
        {
            if (id != branchInfo.BranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchInfoExists(branchInfo.BranchId))
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
            return View(branchInfo);
        }

        // GET: BranchInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos
                .FirstOrDefaultAsync(m => m.BranchId == id);
            if (branchInfo == null)
            {
                return NotFound();
            }

            return View(branchInfo);
        }

        // POST: BranchInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchInfo = await _context.BranchInfos.FindAsync(id);
            _context.BranchInfos.Remove(branchInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchInfoExists(int id)
        {
            return _context.BranchInfos.Any(e => e.BranchId == id);
        }
    }
}
