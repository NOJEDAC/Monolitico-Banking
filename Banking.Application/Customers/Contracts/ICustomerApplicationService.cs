using Banking.Application.Customers.Dtos;

namespace Banking.Application.Customers.Contracts
{
    public interface ICustomerApplicationService
    {
        NewCustomerResponseDto Register(NewCustomerDto newCustomerDto);
    }
}
