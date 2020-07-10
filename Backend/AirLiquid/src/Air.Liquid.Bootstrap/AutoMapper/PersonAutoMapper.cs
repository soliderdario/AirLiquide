using Air.Liquide.Bootstrap.ViewModel.Person;
using Air.Liquide.Domain.Model.Person;
using AutoMapper;

namespace Air.Liquide.Bootstrap.AutoMapper
{
    public class PersonAutoMapper : Profile
    {
        public PersonAutoMapper()
        {
            //Customer
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

        }
    }
}
