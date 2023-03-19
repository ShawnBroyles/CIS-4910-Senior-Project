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
    public class ProductDataController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductDataController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: AccountEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.product.ToListAsync());
        }
    }
}
