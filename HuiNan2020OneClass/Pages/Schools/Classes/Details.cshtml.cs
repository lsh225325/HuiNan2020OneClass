using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly AppContext _context;

        public DetailsModel(AppContext context)
        {
            _context = context;
        }

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
    }
}
