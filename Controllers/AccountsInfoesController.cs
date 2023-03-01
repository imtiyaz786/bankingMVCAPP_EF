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
    public class AccountsInfoesController : Controller
    {
        private readonly bankDBContext _context = new();

        //public AccountsInfoesController(bankDBContext context)
        //{
        //    _context = context;
        //}

        // GET: AccountsInfoes
        public async Task<IActionResult> Index()
        {
            var bankDBContext = _context.AccountsInfos.Include(a => a.AccBranchNavigation);
            return View(await bankDBContext.ToListAsync());
        }

        // GET: AccountsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos
                .Include(a => a.AccBranchNavigation)
                .FirstOrDefaultAsync(m => m.AccNo == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // GET: AccountsInfoes/Create
        public IActionResult Create()
        {
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId");
            return View();
        }

        // POST: AccountsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccNo,AccName,AccType,AccBalance,AccBranch")] AccountsInfo accountsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // GET: AccountsInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            if (accountsInfo == null)
            {
                return NotFound();
            }
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // POST: AccountsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccNo,AccName,AccType,AccBalance,AccBranch")] AccountsInfo accountsInfo)
        {
            if (id != accountsInfo.AccNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsInfoExists(accountsInfo.AccNo))
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
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // GET: AccountsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos
                .Include(a => a.AccBranchNavigation)
                .FirstOrDefaultAsync(m => m.AccNo == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // POST: AccountsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            _context.AccountsInfos.Remove(accountsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsInfoExists(int id)
        {
            return _context.AccountsInfos.Any(e => e.AccNo == id);
        }
    }
}
