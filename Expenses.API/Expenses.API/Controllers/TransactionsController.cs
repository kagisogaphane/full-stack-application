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
    
        [HttpPost]
        public IActionResult CreateTransaction([FromBody] TransactionDto payload) { 
            var transaction = new Models.Transaction
            {
                Type = payload.Type,
                Amount = payload.Amount,
                Category = payload.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Transactions.Add(transaction);
            context.SaveChanges();

            return Ok();
        }
    }
}
