using BookInventoryManager.Models;
using FluentValidation;

namespace BookInventoryManager.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private int min = 1;
        private int max = 100;
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
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
