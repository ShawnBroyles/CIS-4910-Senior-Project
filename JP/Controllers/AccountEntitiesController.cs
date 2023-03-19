using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JP.Data;
using JP.Models;

namespace JP.Controllers
{
    public class AccountEntitiesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AccountEntitiesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: AccountEntities
        public async Task<IActionResult> Index()
        {
            
              return View(await _context.account.ToListAsync());
        }

        // GET: AccountEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.account == null)
            {
                return NotFound();
            }

            var accountEntity = await _context.account
                .FirstOrDefaultAsync(m => m.accountID == id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            return View(accountEntity);
        }

        // GET: AccountEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("accountID,username,password")] Account accountEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountEntity);
        }

        // GET: AccountEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.account == null)
            {
                return NotFound();
            }

            var accountEntity = await _context.account.FindAsync(id);
            if (accountEntity == null)
            {
                return NotFound();
            }
            return View(accountEntity);
        }

        // POST: AccountEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("accountID,username,password")] Account accountEntity)
        {
            if (id != accountEntity.accountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountEntityExists(accountEntity.accountID))
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
            return View(accountEntity);
        }

        // GET: AccountEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.account == null)
            {
                return NotFound();
            }

            var accountEntity = await _context.account
                .FirstOrDefaultAsync(m => m.accountID == id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            return View(accountEntity);
        }

        // POST: AccountEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.account == null)
            {
                return Problem("Entity set 'ApplicationDBContext.account'  is null.");
            }
            var accountEntity = await _context.account.FindAsync(id);
            if (accountEntity != null)
            {
                _context.account.Remove(accountEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountEntityExists(int id)
        {
          return _context.account.Any(e => e.accountID == id);
        }
    }
}
