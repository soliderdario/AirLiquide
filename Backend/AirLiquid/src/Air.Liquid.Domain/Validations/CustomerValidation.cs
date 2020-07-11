using Air.Liquide.Domain.Model.Person;
using FluentValidation;

namespace Air.Liquide.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Age <= 0)
                .Equal(false)
                .WithMessage("Idade não permitida");
        }

    }
}
