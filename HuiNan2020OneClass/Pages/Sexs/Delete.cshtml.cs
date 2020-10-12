using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Sexs
{
    public class DeleteModel : PageModel
    {
        private readonly AppContext _context;

        public DeleteModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sex Sex { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sex = await _context.Sex.FirstOrDefaultAsync(m => m.ID == id);

            if (Sex == null)
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

            Sex = await _context.Sex.FindAsync(id);

            if (Sex != null)
            {
                _context.Sex.Remove(Sex);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
