using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;
using System.Security.Cryptography.X509Certificates;

namespace HuiNan2020OneClass.Pages.Schools.SchoolTerms
{
    public class EditModel : PageModel
    {
        private readonly AppContext _context;

        public EditModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolTerm SchoolTerm { get; set; }

        public string ErrMsg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolTerm = await _context.SchoolTerm
                .Include(s => s.Semester).FirstOrDefaultAsync(m => m.ID == id);

            if (SchoolTerm == null)
            {
                return NotFound();
            }
                ViewData["SemesterID"] = new SelectList(_context.Semester, "ID", "SemesterName");
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
            var sem = _context.Semester.FirstOrDefault(x => x.ID == SchoolTerm.Semester.ID);
            SchoolTerm.Name = SchoolTerm.SchoolYear.ToString() + sem.SemesterName;

            if (_context.SchoolTerm.FirstOrDefault(x=>x.Name== SchoolTerm.Name)!=null)
            {
                ErrMsg = "年级+学期组合已存在";
                ViewData["SemesterID"] = new SelectList(_context.Semester, "ID", "SemesterName");

                return Page();
            }

            SchoolTerm.Semester = null;
            SchoolTerm.SemesterID = sem.ID;
            _context.Attach(SchoolTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolTermExists(SchoolTerm.ID))
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

        private bool SchoolTermExists(int id)
        {
            return _context.SchoolTerm.Any(e => e.ID == id);
        }
    }
}
