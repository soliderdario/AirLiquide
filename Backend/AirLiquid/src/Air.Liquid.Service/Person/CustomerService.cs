using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Air.Liquide.Data;
using Air.Liquide.Data.Repository;
using Air.Liquide.Domain.Interface.Person;
using Air.Liquide.Domain.Model.Person;
using Air.Liquide.Domain.Type;
using Air.Liquide.Infrastrucutre.Notifiers;

namespace Air.Liquide.Service.Person
{
    public class CustomerService : Repository<Customer>, ICustomerService
    {
        private readonly INotifier _notifier;
        public CustomerService(
            INotifier notifier,
            Context db) : base(db)
        {
            _notifier = notifier;
        }

        public new async Task Delete(Customer customer)
        {
            await base.Delete(customer);
        }

        private void Validation(Customer customer)
        {
            if (Query(src => src.Name == customer.Name && src.Id != customer.Id).Result.Any())
            {
                _notifier.SetNotification(new Notification("Já existe um cliente cadastrado com essa nome."));
                return;
            }
        }

        public async Task Save(Customer customer)
        {
            Validation(customer);
            if (_notifier.HasNotification())
            {
                return;
            }
            if (customer.Operation == OperationType.Insert)
            {
                await base.Insert(customer);
            }
            else
            {
                await base.Update(customer);
            }
        }

        public new async Task<IEnumerable<Customer>> Query(Expression<Func<Customer, bool>> predicate)
        {
            return await base.Query(predicate);
        }

        public async Task<IEnumerable<Customer>> Query()
        {
            return await base.List();
        }
    }
}

