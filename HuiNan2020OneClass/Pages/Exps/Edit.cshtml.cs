using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Exps
{
    public class EditModel : PageModel
    {
        private readonly AppContext _context;

        public EditModel(AppContext context)
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
                .Include(e => e.Category).FirstOrDefaultAsync(m => m.ID == id && m.IsDelete == false);

            if (Exp == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            ViewData["classAndTermID"] = new SelectList(_context.ClassAndTerm, "ID", "Name");
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

            _context.Attach(Exp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpExists(Exp.ID))
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

        private bool ExpExists(int id)
        {
            return _context.Exp.Any(e => e.ID == id);
        }
    }
}
