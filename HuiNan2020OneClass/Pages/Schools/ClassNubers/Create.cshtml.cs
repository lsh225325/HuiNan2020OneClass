using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.ClassNubers
{
    public class CreateClassMaxModel : PageModel
    {
        private readonly AppContext _context;

        public CreateClassMaxModel(AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [Range(1, 100)]
        [BindProperty]
        public int MaxClass { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            for (int i = 1; i <= MaxClass; i++)
            {

                string ss = i + "班";


                var ckcl = _context.ClassNuber.FirstOrDefault(m => m.ClassNuberName == ss);
                if (ckcl != null)
                {
                    continue;
                }

                var cl = new ClassNuber();

                cl.CreatTime = DateTime.Now;
                cl.ClassNuberName = ss;
                _context.ClassNuber.Add(cl);

            }
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
