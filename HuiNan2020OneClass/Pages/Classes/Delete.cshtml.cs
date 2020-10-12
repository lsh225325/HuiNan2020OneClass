using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        private readonly AppContext _context;

        public DeleteModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GradeClass GradeClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GradeClass = await _context.GradeClass
                .Include(g => g.ClassNuber)
                .Include(g => g.Grade).FirstOrDefaultAsync(m => m.ID == id);

            if (GradeClass == null)
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

            GradeClass = await _context.GradeClass.FindAsync(id);

            if (GradeClass != null)
            {
                _context.GradeClass.Remove(GradeClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
