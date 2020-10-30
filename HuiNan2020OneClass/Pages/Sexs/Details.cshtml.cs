using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Sexs
{
    public class DetailsModel : PageModel
    {
        private readonly AppContext _context;

        public DetailsModel(AppContext context)
        {
            _context = context;
        }

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
    }
}
