using Expenses.API.Data;
using Expenses.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(AppDbContext context) : ControllerBase
    {


        [HttpGet("All")]
        public IActionResult GetTransactions()
        {
            var AllTransactions = context.Transactions.ToList();
            return Ok(AllTransactions);
        }


        [HttpGet("Details/{id}")]
        public IActionResult GetTranscation(int id)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("Create")]
        public IActionResult CreateTransaction([FromBody] PostTransactionDto payload)
        {
            var transaction = new Models.Transaction
            {
                Type = payload.Type,
                Amount = payload.Amount,
                Category = payload.Category,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            context.Transactions.Add(transaction);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateTransaction(int id, [FromBody] PostTransactionDto payload)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transaction ==null)
                return NotFound();

            transaction.Type = payload.Type;
            transaction.Amount = payload.Amount;
            transaction.Category = payload.Category;
            transaction.UpdatedAt = DateTime.Now;

            context.Transactions.Update(transaction);
            context.SaveChanges();

            return Ok(transaction);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);

            if (transaction == null)
                return NotFound();

            context.Transactions.Remove(transaction);
            context.SaveChanges();
            return Ok();
        }


    }
}
