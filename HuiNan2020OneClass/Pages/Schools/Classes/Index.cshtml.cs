using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<ClassAndTerm> ClassAndTerm { get; set; }

        public async Task OnGetAsync()
        {
            ClassAndTerm = await _context.ClassAndTerm
                .Include(c => c.ClassNuber)
                .Include(c => c.Grade)
                .Include(c => c.SchoolTerm).ToListAsync();
        }
    }
}
