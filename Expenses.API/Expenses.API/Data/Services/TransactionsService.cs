using Expenses.API.Dtos;
using Expenses.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.API.Data.Services
{
    public interface ITransactionsService
    {
        List<Transaction> GetAllTransactions();
        Transaction? GetTransactionById(int id);
        Transaction CreateTransaction(PostTransactionDto transaction);
        Transaction? UpdateTransaction(int id,PostTransactionDto transaction);
        void DeleteTransaction(int id);
    }
    public class TransactionsService(AppDbContext context) : ITransactionsService
    {
        public Transaction CreateTransaction(PostTransactionDto postTransaction)
        {
            var transaction = new Transaction
            {
                Type = postTransaction.Type,
                Amount = postTransaction.Amount,
                Category = postTransaction.Category,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            context.Transactions.Add(transaction);
            context.SaveChanges();

            return transaction;
        }

        public void DeleteTransaction(int id)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);

            if (transaction != null)
            context.Transactions.Remove(transaction);
            context.SaveChanges();
        }

        public List<Transaction> GetAllTransactions()
        {
            var AllTransactions = context.Transactions.ToList();
            return AllTransactions;
        }

        public Transaction? GetTransactionById(int id)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);
            return transaction;
            
        }

        public Transaction? UpdateTransaction(int id, PostTransactionDto putTransaction)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transaction != null)
            {
                transaction.Type = putTransaction.Type;
                transaction.Amount = putTransaction.Amount;
                transaction.Category = putTransaction.Category;
                transaction.UpdatedAt = DateTime.Now;

                context.Transactions.Update(transaction);
                context.SaveChanges();

            }
            return (transaction);
        }
    }
}
