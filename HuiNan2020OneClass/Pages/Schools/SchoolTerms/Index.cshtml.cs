using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Schools.SchoolTerms
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<SchoolTerm> SchoolTerm { get; set; }

        public async Task OnGetAsync()
        {
            SchoolTerm = await _context.SchoolTerm.OrderBy(m => m.Name)
                .Include(s => s.Semester).ToListAsync();
        }
    }
}
