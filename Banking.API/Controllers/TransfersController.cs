using Banking.Application.Transactions.Contracts;
using Banking.Application.Transactions.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("v1/transfers")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private readonly ITransactionApplicationService _transactionApplicationService;

        public TransfersController(ITransactionApplicationService transactionApplicationService)
        {
            _transactionApplicationService = transactionApplicationService;
        }

        [HttpPost]
        public IActionResult PerformTransfer([FromBody] NewTransferDto newTransferDto)
        {
            NewTransferResponseDto response = _transactionApplicationService.PerformTransfer(newTransferDto);
            return StatusCode(response.HttpStatusCode, response.StringResponse);
        }
    }
}
