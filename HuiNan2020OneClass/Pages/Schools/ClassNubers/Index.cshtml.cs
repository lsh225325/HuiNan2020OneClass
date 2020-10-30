using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.ClassNubers
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<ClassNuber> ClassNuber { get; set; }

        public async Task OnGetAsync()
        {
            ClassNuber = await _context.ClassNuber.ToListAsync();
        }
    }
}
