using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class EditModel : PageModel
    {
        private readonly AppContext _context;

        public EditModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassAndTerm ClassAndTerm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassAndTerm = await _context.ClassAndTerm
                .Include(c => c.ClassNuber)
                .Include(c => c.Grade)
                .Include(c => c.SchoolTerm).FirstOrDefaultAsync(m => m.ID == id);

            if (ClassAndTerm == null)
            {
                return NotFound();
            }
           ViewData["ClassNuberID"] = new SelectList(_context.ClassNuber, "ID", "ClassNuberName");
           ViewData["GradeID"] = new SelectList(_context.Grade, "ID", "GradeName");
           ViewData["SchoolTermID"] = new SelectList(_context.SchoolTerm, "ID", "Name");
            return Page();
        }

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
            _context.Attach(ClassAndTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassAndTermExists(ClassAndTerm.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClassAndTermExists(int id)
        {
            return _context.ClassAndTerm.Any(e => e.ID == id);
        }
    }
}
