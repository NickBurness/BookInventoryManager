using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookInventoryManager.Data;
using BookInventoryManager.Models;
using BookInventoryManager.Validators;
using FluentValidation.AspNetCore;

namespace BookInventoryManager.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly BookManagerContext _context;

        public CreateModel(BookManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var validator = new AuthorValidator();
            var validationResults = validator.Validate(Author);

            validationResults.AddToModelState(ModelState, "Author");

            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Page();
            }

            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
