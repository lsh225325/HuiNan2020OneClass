using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Exps
{
    public class DetailsModel : PageModel
    {
        private readonly AppContext _context;

        public DetailsModel(AppContext context)
        {
            _context = context;
        }

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
    }
}
