using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.ClassIncomes
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<ClassIncome> ClassIncome { get; set; }

        public async Task OnGetAsync()
        {
            ClassIncome = await _context.ClassIncome
                .Include(c => c.Category)
                .Include(c => c.classAndTerm).ToListAsync();
        }
    }
}
