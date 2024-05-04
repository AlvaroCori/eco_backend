using ecoapp.Models;

namespace ecoapp.Repositories
{
    public interface IExpenseRepository
    {
        public Task<ExpenseModel> CreateExpense(ExpenseModel expense);
        public Task<ExpenseModel> GetExpense(int id);
        public Task<ICollection<ExpenseModel>> GetExpenses();
        public Task<ExpenseModel> UpdateExpense(ExpenseModel expense);
        public Task DeleteExpense(int id);
    }
}
