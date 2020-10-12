using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class EditModel : PageModel
    {
        private readonly AppContext _context;

        public EditModel(AppContext context)
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
           ViewData["ClassNuberID"] = new SelectList(_context.ClassNuber, "ID", "ID");
           ViewData["GradeID"] = new SelectList(_context.Grade, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GradeClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeClassExists(GradeClass.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GradeClassExists(int id)
        {
            return _context.GradeClass.Any(e => e.ID == id);
        }
    }
}
