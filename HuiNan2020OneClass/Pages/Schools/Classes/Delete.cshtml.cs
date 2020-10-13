using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public ClassAndTerm ClassAndTerm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassAndTerm = await _context.ClassAndTerm
                .Include(c => c.ClassNuber)
                .Include(c => c.Grade)
                .Include(c => c.SchoolTerm).FirstOrDefaultAsync(m => m.ID == id);

            if (ClassAndTerm == null)
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

            ClassAndTerm = await _context.ClassAndTerm.FindAsync(id);

            if (ClassAndTerm != null)
            {
                _context.ClassAndTerm.Remove(ClassAndTerm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
