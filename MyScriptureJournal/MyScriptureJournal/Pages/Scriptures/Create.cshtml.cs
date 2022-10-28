using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public CreateModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        //The OnGet method initializes any state needed for the page.
        //The Create page doesn't have any state to initialize, so Page is returned.
        public IActionResult OnGet()
        {
            return Page();
        }

        //The Movie property uses the [BindProperty] attribute to opt-in to model binding.
        //When the Create form posts the form values, the ASP.NET Core runtime
        //binds the posted values to the Movie model.
        [BindProperty]
        public Scripture Scripture { get; set; }

        //The OnPostAsync method is run when the page posts form data:
        //When the return type is IActionResult or Task<IActionResult>, a return statement must be provided
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
