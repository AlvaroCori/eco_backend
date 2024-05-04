using ecoapp.DTOS;
using ecoapp.Models;
using ecoapp.Repositories;
using ecoapp.Response;

namespace ecoapp.Services
{
    public class ExpenseService : IExpenseService
    {
        IExpenseRepository Repository;
        public ExpenseService(IExpenseRepository repository) {
            Repository = repository;
        }
        private ExpenseResponse GetRes(ExpenseModel expense)
        {
            return new ExpenseResponse()
            {
                Id = expense.Id,
                Date = expense.DateRegister,
                Detail = expense.Detail,
                Egress = expense.Egress,
                Income = expense.Income,
                Observation = expense.Observation
            };
        }

        public async Task<ResponseObject<ExpenseResponse>> CreateExpense(ExpenseDTO expenseDTO)
        {
            try 
            { 
                var newExpense = new ExpenseModel()
                {
                    Id = 0,
                    DateRegister = DateTime.UtcNow,
                    Detail = expenseDTO.Detail,
                    Egress = expenseDTO.Egress,
                    Income = expenseDTO.Income,
                    Observation = expenseDTO.Observation
                };
                var expense = await Repository.CreateExpense(newExpense);
                return ResponseMaker<ExpenseResponse>.GetResponse(GetRes(expense), 201, "Gasto creado exitosamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseObject<ICollection<ExpenseResponse>>> GetExpenses()
        {
            try
            {
                var expenses = await Repository.GetExpenses();
                var expensesResponse = new List<ExpenseResponse>();
                foreach (var expense in expenses)
                {
                    expensesResponse.Add(GetRes(expense));
                
                }
                return ResponseMaker<ICollection<ExpenseResponse>>.GetResponse(expensesResponse, 200, "Gastos obtenidos exitosamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseObject<ExpenseResponse>> UpdateExpense(int id, ExpenseDTO expenseDTO)
        {
            try 
            { 
                var expenseToEdit = new ExpenseModel()
                {
                    DateRegister = DateTime.UtcNow,
                    Detail = expenseDTO.Detail,
                    Egress = expenseDTO.Egress,
                    Id = id,
                    Income = expenseDTO.Income,
                    Observation = expenseDTO.Observation
                };
                var newExpense = await Repository.UpdateExpense(expenseToEdit);
                return ResponseMaker<ExpenseResponse>.GetResponse(GetRes(newExpense), 200, "Gasto editado exitosamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseObject<string>> DeleteExpense(int id)
        {
            try 
            { 
                await Repository.DeleteExpense(id);
                return ResponseMaker<string>.GetResponse("Eliminado", 200, "Gasto editado exitosamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseObject<ExpenseResponse>> GetExpense(int id)
        {
            try 
            { 
                var expense = await Repository.GetExpense(id);
                return ResponseMaker<ExpenseResponse>.GetResponse(GetRes(expense), 200, "Gasto editado exitosamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
