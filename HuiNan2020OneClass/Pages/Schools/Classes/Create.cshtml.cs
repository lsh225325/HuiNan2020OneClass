using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Classes
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
        ViewData["ClassNuberID"] = new SelectList(_context.ClassNuber, "ID", "ClassNuberName");
        ViewData["GradeID"] = new SelectList(_context.Grade, "ID", "GradeName");
        ViewData["SchoolTermID"] = new SelectList(_context.SchoolTerm, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public ClassAndTerm ClassAndTerm { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var sgrade = _context.Grade.Find(ClassAndTerm.GradeID);
            var sclaNo = _context.ClassNuber.Find(ClassAndTerm.ClassNuberID);
            var sterm = _context.SchoolTerm.Find(ClassAndTerm.SchoolTermID);
            ClassAndTerm.Name = sgrade.GradeName + sclaNo.ClassNuberName + "-" + sterm.Name;
            _context.ClassAndTerm.Add(ClassAndTerm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
