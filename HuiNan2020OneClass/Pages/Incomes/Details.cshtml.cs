using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Incomes
{
    public class DetailsModel : PageModel
    {
        private readonly AppContext _context;

        public DetailsModel(AppContext context)
        {
            _context = context;
        }

        public Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.Income
                .Include(i => i.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (Income == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
