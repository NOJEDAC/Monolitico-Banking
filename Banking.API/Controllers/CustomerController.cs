using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using System;
using System.Collections.Generic;
using Banking.Application.Customers.Dtos;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Route("v1/customers")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerQueries _customerQueries;
        private readonly ICustomerApplicationService _customerApplicationService;
        public CustomerController(ICustomerQueries customerQueries, ICustomerApplicationService customerApplicationService)
        {
            _customerQueries = customerQueries;
            _customerApplicationService = customerApplicationService;
        }

        [HttpGet]
        public IActionResult GetListPaginated([FromQuery]int page = 0, [FromQuery]int pageSize = 10)
        {
            try
            {                
                List<CustomerDto> customers = _customerQueries.GetListPaginated(page, pageSize);
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponse(ApiConstants.InternalServerError));
            }
        }

        //[HttpPost]
        //public IActionResult Register([FromBody] NewCustomerDto newCustomerDto)
        //{
        //    NewCustomerResponseDto response = _customerApplicationService.Register(newCustomerDto);
        //    return StatusCode(response.HttpStatusCode, response.Response);
        //}
         
    }
}
