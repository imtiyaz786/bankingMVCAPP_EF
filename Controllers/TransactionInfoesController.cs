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
    public class TransactionInfoesController : Controller
    {
        private readonly bankDBContext _context = new();

        //public TransactionInfoesController(bankDBContext context)
        //{
        //    _context = context;
        //}

        // GET: TransactionInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransactionInfos.ToListAsync());
        }

        // GET: TransactionInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionInfo = await _context.TransactionInfos
                .FirstOrDefaultAsync(m => m.TrId == id);
            if (transactionInfo == null)
            {
                return NotFound();
            }

            return View(transactionInfo);
        }

        // GET: TransactionInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrId,TrFromAccount,TrToAccount,TrAmount")] TransactionInfo transactionInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionInfo);
        }

        // GET: TransactionInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionInfo = await _context.TransactionInfos.FindAsync(id);
            if (transactionInfo == null)
            {
                return NotFound();
            }
            return View(transactionInfo);
        }

        // POST: TransactionInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrId,TrFromAccount,TrToAccount,TrAmount")] TransactionInfo transactionInfo)
        {
            if (id != transactionInfo.TrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionInfoExists(transactionInfo.TrId))
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
            return View(transactionInfo);
        }

        // GET: TransactionInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionInfo = await _context.TransactionInfos
                .FirstOrDefaultAsync(m => m.TrId == id);
            if (transactionInfo == null)
            {
                return NotFound();
            }

            return View(transactionInfo);
        }

        // POST: TransactionInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionInfo = await _context.TransactionInfos.FindAsync(id);
            _context.TransactionInfos.Remove(transactionInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionInfoExists(int id)
        {
            return _context.TransactionInfos.Any(e => e.TrId == id);
        }
    }
}
