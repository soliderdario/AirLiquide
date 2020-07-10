using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Air.Liquide.Domain.Model.Person;

namespace Air.Liquide.Domain.Interface.Person
{
    public interface ICustomerService
    {
        Task Save(Customer customer);
        Task Delete(Customer customer);
        Task<IEnumerable<Customer>> Query(Expression<Func<Customer, bool>> predicate);

        Task<IEnumerable<Customer>> Query();
    }
}
