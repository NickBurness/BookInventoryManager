using BookInventoryManager.Models;
using FluentValidation;

namespace BookInventoryManager.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        private int min = 1;
        private int max = 50;
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(min, max).WithMessage("{PropertyName} contains too many characters")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(min, max).WithMessage("{PropertyName} contains too many characters")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
        }

        protected bool BeAValidName(string name)
        {
            name.Replace(" ", "");
            return name.All(Char.IsLetter);
        }
    }
}
