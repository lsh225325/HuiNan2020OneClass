using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.ClassIncomes
{
    public class CreateModel : PageModel
    {
        private readonly AppContext _context;

        public CreateModel(AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category.Where(m => m.CategoryName == "班费收入"), "ID", "CategoryName");
            ViewData["ClassAndTermID"] = new SelectList(_context.ClassAndTerm, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public ClassIncome ClassIncome { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClassIncome.Add(ClassIncome);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
