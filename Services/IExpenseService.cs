using ecoapp.DTOS;
using ecoapp.Response;

namespace ecoapp.Services
{
    public interface IExpenseService
    {
        public Task<ResponseObject<ICollection<ExpenseResponse>>> GetExpenses();
        public Task<ResponseObject<ExpenseResponse>> CreateExpense(ExpenseDTO expenseDTO);
        public Task<ResponseObject<ExpenseResponse>> UpdateExpense(int id, ExpenseDTO expenseDTO);
        public Task<ResponseObject<string>> DeleteExpense(int id);
        public Task<ResponseObject<ExpenseResponse>> GetExpense(int id);
    }
}
