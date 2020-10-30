using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.ClassIncomes
{
    public class DeleteModel : PageModel
    {
        private readonly AppContext _context;

        public DeleteModel(AppContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassIncome = await _context.ClassIncome.FindAsync(id);

            if (ClassIncome != null)
            {
                _context.ClassIncome.Remove(ClassIncome);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
