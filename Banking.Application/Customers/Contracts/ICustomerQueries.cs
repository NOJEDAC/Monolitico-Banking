using Banking.Application.Customers.Dtos;
using Banking.Application.Customers.ViewModels;
using Common;
using System.Collections.Generic;

namespace Banking.Application.Customers.Contracts
{
    public interface ICustomerQueries 
    {
        List<CustomerDto> GetListPaginated(int page = 0, int pageSize = 5); 
    }
}
 