using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Exps
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<Exp> Exp { get; set; }

        public async Task OnGetAsync()
        {
            Exp = await _context.Exp.OrderByDescending(m => m.ReData).Where(m => m.IsDelete == false)
                .Include(e => e.Category)
                .Include(e => e.classAndTerm)
                .ToListAsync();
        }
    }
}
