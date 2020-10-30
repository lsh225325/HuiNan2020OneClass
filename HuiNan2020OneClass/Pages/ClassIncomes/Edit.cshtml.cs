using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.ClassIncomes
{
    public class EditModel : PageModel
    {
        private readonly AppContext _context;

        public EditModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassIncome ClassIncome { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassIncome = await _context.ClassIncome
                .Include(c => c.Category)
                .Include(c => c.classAndTerm).FirstOrDefaultAsync(m => m.ID == id);

            if (ClassIncome == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            ViewData["ClassAndTermID"] = new SelectList(_context.ClassAndTerm, "ID", "ID");
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

            _context.Attach(ClassIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassIncomeExists(ClassIncome.ID))
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

        private bool ClassIncomeExists(int id)
        {
            return _context.ClassIncome.Any(e => e.ID == id);
        }
    }
}
