using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Sexs
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<Sex> Sex { get; set; }

        public async Task OnGetAsync()
        {
            Sex = await _context.Sex.ToListAsync();
        }
    }
}
