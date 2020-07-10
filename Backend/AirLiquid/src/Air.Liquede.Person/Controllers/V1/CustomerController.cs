using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Air.Liquide.Bootstrap;
using Air.Liquide.Bootstrap.ViewModel.Person;
using Air.Liquide.Domain.Interface.Person;
using Air.Liquide.Domain.Model.Person;
using Air.Liquide.Infrastrucutre.Notifiers;
using Air.Liquide.Domain.Type;

namespace Air.Liquide.Person.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomerController : MainController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(
            ICustomerService customerService,
            INotifier notifier, 
            IMapper mapper) : base(notifier, mapper)
        {
            _customerService = customerService;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<CustomerViewModel>>Insert(CustomerViewModel customerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
                var customer = _mapper.Map<Customer>(customerViewModel);
                customer.Operation = OperationType.Insert;
                await _customerService.Save(customer);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(customerViewModel);
        }

        [HttpPut("update")]
        public async Task<ActionResult<CustomerViewModel>>Update(CustomerViewModel customerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
                var customer = _mapper.Map<Customer>(customerViewModel);
                customer.Operation = OperationType.Update;
                await _customerService.Save(customer);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(customerViewModel);
        }

        [HttpGet("query")]
        public async Task<IEnumerable<CustomerViewModel>>Query()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerService.Query());
                return result;
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return (IEnumerable<CustomerViewModel>)BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult>Delete(Guid Id)
        {
            try
            {
                var customer = _customerService.Query().Result?.Where(src => src.Id == Id).FirstOrDefault();
                if (customer == null) return NotFound();
                await _customerService.Delete(customer);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(Id);
        }
    }
}
