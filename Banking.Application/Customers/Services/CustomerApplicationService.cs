
using Banking.Application.Customers.Assemblers;
using Banking.Application.Customers.Constants;
using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.Dtos;
using Banking.Domain.Customers.Contracts;
using Banking.Domain.Customers.Entities;
using Common;
using Microsoft.AspNetCore.Http;
using System; 

namespace Banking.Application.Customers.Services
{
    public class CustomerApplicationService : ICustomerApplicationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly NewCustomerAssembler _newCustomerAssembler;

        public CustomerApplicationService(
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepositor,
            NewCustomerAssembler newCustomerAssembler)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepositor;
            _newCustomerAssembler = newCustomerAssembler;
        }

        public NewCustomerResponseDto Register(NewCustomerDto newCustomerDto)
        {
            try
            {
                Customer customer = _newCustomerAssembler.ToEntity(newCustomerDto);
                _customerRepository.SaveOrUpdate(customer);
                return new NewCustomerResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(CustomerAppConstants.CustomerCreated)
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewCustomerResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }


    }
}
