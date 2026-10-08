using Expenses.API.Data;
using Expenses.API.Data.Services;
using Expenses.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionsService transactionsService) : ControllerBase
    {


        [HttpGet("All")]
        public IActionResult GetTransactions()
        {
            var transaction = transactionsService.GetAllTransactions();
            return Ok(transaction);
        }


        [HttpGet("Details/{id}")]
        public IActionResult GetTranscation(int id)
        {
            var transaction = transactionsService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("Create")]
        public IActionResult CreateTransaction([FromBody] PostTransactionDto payload)
        {
            var transaction = transactionsService.CreateTransaction(payload);
           
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateTransaction(int id, [FromBody] PostTransactionDto payload)
        {
            var transaction = transactionsService.UpdateTransaction(id, payload);
            if (transaction ==null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            transactionsService.DeleteTransaction(id);
            return Ok();
        }


    }
}
