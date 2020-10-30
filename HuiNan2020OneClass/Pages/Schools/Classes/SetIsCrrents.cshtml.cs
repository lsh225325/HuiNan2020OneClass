using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class SetIsCrrentsModel : PageModel
    {
        private readonly AppContext _context;

        public SetIsCrrentsModel(AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassAndTerm ClassAndTerm { get; set; }


        [BindProperty]
        public int clID { get; set; }


        public async Task OnGetAsync()
        {

            ViewData["ClassName"] = new SelectList(_context.ClassAndTerm, "ID", "Name");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ClassAndTerm = _context.ClassAndTerm.FirstOrDefault(m => m.ID == clID);

            var ctlists = _context.ClassAndTerm.Where(m => m.ID != ClassAndTerm.ID).ToList();
            var ctlist = ctlists.Where(m => m.IsCurrentClass == true);
            foreach (var m in ctlist)
            {

                m.IsCurrentClass = false;
                _context.Attach(m).State = EntityState.Modified;


            }
            await _context.SaveChangesAsync();


            ClassAndTerm.IsCurrentClass = true;
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
