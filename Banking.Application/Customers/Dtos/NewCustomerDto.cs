using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Application.Customers.Dtos
{
    public class NewCustomerDto
    {

        public long User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public bool Active { get; set; }

        public NewCustomerDto()
        {
            Active = true;
        }

    }
}
