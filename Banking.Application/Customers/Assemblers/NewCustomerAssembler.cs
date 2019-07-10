using AutoMapper;
using Banking.Application.Customers.Dtos; 
using Banking.Domain.Customers.Entities;
using System; 

namespace Banking.Application.Customers.Assemblers
{
    public class NewCustomerAssembler
    {
        private readonly IMapper _mapper;

        public NewCustomerAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Customer ToEntity(NewCustomerDto newCustomerDto)
        {
            Customer customer = _mapper.Map<Customer>(newCustomerDto);
            DateTime utcNow = DateTime.UtcNow;
            customer.CreatedAt = utcNow;
            customer.UpdatedAt = utcNow;
            return customer;
        }
    }
}
