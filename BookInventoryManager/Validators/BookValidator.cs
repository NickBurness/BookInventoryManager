using BookInventoryManager.Data;
using BookInventoryManager.Models;
using FluentValidation;

namespace BookInventoryManager.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        private int minQuantity = 0;
        private int maxQuantity = 10000;

        private int minLength = 1;
        private int maxTitleLength = 100;
        private int maxDescriptionLength = 1000;

        private readonly BookManagerContext _context;


        public BookValidator(BookManagerContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(minLength, maxTitleLength).WithMessage("{PropertyName} contains too many characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(minLength, maxDescriptionLength).WithMessage("{PropertyName} contains too many characters");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .GreaterThanOrEqualTo(minQuantity).WithMessage("{PropertyName} is too low")
                .LessThanOrEqualTo(maxQuantity).WithMessage("{PropertyName} is too high");

            RuleFor(x => x.Edition)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .IsInEnum().WithMessage("{PropertyName} is invalid");

            RuleFor(x => x.AuthorID)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .NotNull().WithMessage("{PropertyName} should not be empty")
                .Must(BeAValidAuthor).WithMessage("{PropertyName} does not yet exist");

            RuleFor(x => x.CategoryID)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .NotNull().WithMessage("{PropertyName} should not be empty")
                .Must(BeAValidCategory).WithMessage("{PropertyName} does not yet exist");
        }

        protected bool BeAValidAuthor(int id)
        {
            return _context.Authors.Any(x => x.ID == id);
        }

        protected bool BeAValidCategory(int id)
        {
            return _context.Categories.Any(x => x.ID == id);
        }
    }
}
