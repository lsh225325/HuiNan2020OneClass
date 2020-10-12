using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Exps
{
    public class DeleteModel : PageModel
    {
        private readonly AppContext _context;

        public DeleteModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exp Exp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exp = await _context.Exp
                .Include(e => e.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (Exp == null)
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

            Exp = await _context.Exp.FindAsync(id);

            if (Exp != null)
            {
                Exp.IsDelete = true;
                _context.Attach(Exp).State = EntityState.Modified;                
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        /*
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exp = await _context.Exp.FindAsync(id);

            if (Exp != null)
            {
                _context.Exp.Remove(Exp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }*/
    }
}
