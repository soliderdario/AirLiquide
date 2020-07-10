using FluentValidation;
using FluentValidation.Results;
using Air.Liquide.Infrastrucutre.Notifiers;
using Air.Liquide.Domain;

namespace Air.Liquide.Service
{
    public class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.SetNotification(new Notification(mensagem));
        }

        public bool ExecuteValidation<TV, TE>(TV validation, TE entidade) where TV : AbstractValidator<TE> where TE : BaseModel
        {
            var validator = validation.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
