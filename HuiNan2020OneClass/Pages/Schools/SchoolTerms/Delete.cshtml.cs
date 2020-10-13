using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Schools.SchoolTerms
{
    public class DeleteModel : PageModel
    {
        private readonly AppContext _context;

        public DeleteModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolTerm SchoolTerm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolTerm = await _context.SchoolTerm
                .Include(s => s.Semester).FirstOrDefaultAsync(m => m.ID == id);

            if (SchoolTerm == null)
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

            SchoolTerm = await _context.SchoolTerm.FindAsync(id);

            if (SchoolTerm != null)
            {
                _context.SchoolTerm.Remove(SchoolTerm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
