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
    public class DeleteModel : PageModel
    {
        private readonly AppContext _context;

        public DeleteModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.Income.FindAsync(id);

            if (Income != null)
            {
                _context.Income.Remove(Income);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
