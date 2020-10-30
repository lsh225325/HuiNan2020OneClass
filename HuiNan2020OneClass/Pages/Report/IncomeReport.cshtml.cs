using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Report
{
    public class IncomeReportModel : PageModel
    {
        private readonly AppContext _context;

        public IncomeReportModel(AppContext context)
        {
            _context = context;
        }

        public IList<ClassIncome> ClassIncome { get; set; }

        public async Task OnGetAsync()
        {
            ClassIncome = await _context.ClassIncome.Where(m => m.IsDelete == false)
                .OrderByDescending(x => x.ReData)
                .Include(c => c.Category)
                .Include(c => c.classAndTerm).ToListAsync();
        }
    }
}
