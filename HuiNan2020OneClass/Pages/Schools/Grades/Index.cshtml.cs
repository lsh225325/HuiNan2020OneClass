using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<Grade> Grade { get; set; }

        public async Task OnGetAsync()
        {
            Grade = await _context.Grade.ToListAsync();
        }
    }
}
