using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookInventoryManager.Data;
using BookInventoryManager.Models;
using BookInventoryManager.Validators;
using FluentValidation.AspNetCore;

namespace BookInventoryManager.Pages.Books
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
        public Book Book { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var validator = new BookValidator();
            var validationResults = validator.Validate(Book);

            validationResults.AddToModelState(ModelState, "Book");

            if (!validationResults.IsValid)
            {
                foreach(var error in validationResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
