using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public string ErrMsg { get; set; }


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


            if (_context.ClassAndTerm.FirstOrDefault(m => m.GradeID == ClassAndTerm.GradeID && m.ClassNuberID == ClassAndTerm.ClassNuberID && m.SchoolTermID == ClassAndTerm.SchoolTermID) != null)
            {
                ViewData["ClassNuberID"] = new SelectList(_context.ClassNuber, "ID", "ClassNuberName");
                ViewData["GradeID"] = new SelectList(_context.Grade, "ID", "GradeName");
                ViewData["SchoolTermID"] = new SelectList(_context.SchoolTerm, "ID", "Name");
                ErrMsg = "已存在的班级，请重新选择";
                return Page();
            }

            if (ClassAndTerm.IsCurrentClass == true)
            {
                var ctlist = _context.ClassAndTerm.Where(m => m.IsCurrentClass == true).ToList();
                foreach (var m in ctlist)
                {

                    m.IsCurrentClass = false;
                    _context.Attach(m).State = EntityState.Modified;

                }


                await _context.SaveChangesAsync();
            }

            ClassAndTerm.Name = sgrade.GradeName + sclaNo.ClassNuberName + "-" + sterm.Name;
            ClassAndTerm.TermNuber = _context.ClassAndTerm.Select(m => m.TermNuber).Max() + 1;
            _context.ClassAndTerm.Add(ClassAndTerm);



            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
