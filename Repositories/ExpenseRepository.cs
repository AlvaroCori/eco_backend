using ecoapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ecoapp.Repositories
{
    public class ExpenseRepository(DbContextApp dbContext) : IExpenseRepository
    {
        private ICollection<ExpenseModel> Expenses;
        private DbContextApp DbContext = dbContext;

        public async Task<ICollection<ExpenseModel>> GetExpenses()
        {
            //await CreateUser();
            return DbContext.Expenses.ToList();
        }
        public async Task CreateUser()
        {
            DbContext.Users.Add(new UserModel() { Id= 2, Email = "admin@gmail.com", Name = "admin", PasswordUser = "6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090", Balance = 0, Logs = new List<LogModel>() });
            await DbContext.SaveChangesAsync();
        }

        private void InsertLog(int id, string action, DateTime date, string table, string detail, int userId, UserModel user)
        {
            DbContext.Logs.Add(new LogModel()
            {
                Id = id,
                Action = action,
                DateRegistered = date,
                TableRegitered = table,
                Detail = detail,
                UserId = userId,
                User = user
            });
        }

        public async Task<ExpenseModel> CreateExpense(ExpenseModel expense)
        {
            try
            {
                DbContext.Expenses.Add(expense);
                InsertLog(0, "CREAR", expense.DateRegister, "Expenses", "Gasto creado.", 2, await DbContext.Users.FirstAsync(u => u.Id == 2));
                await DbContext.SaveChangesAsync();
                return expense;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ExpenseModel> UpdateExpense(ExpenseModel expense)
        {
            try
            {
                ExpenseModel? expenseToUpdate = await DbContext.Expenses.FirstOrDefaultAsync(e => e.Id == expense.Id);
                if (expenseToUpdate == null) throw new Exception("Gasto no encontrado");
                //expenseToUpdate.DateRegister = expense.DateRegister;
                expenseToUpdate.Egress = expense.Egress;
                expenseToUpdate.Income = expense.Income;
                expenseToUpdate.Observation = expenseToUpdate.Observation;
                expenseToUpdate.Detail = expenseToUpdate.Detail;
                InsertLog(0, "EDITAR", DateTime.UtcNow, "Expenses", "Gasto editado.", 2, await DbContext.Users.FirstAsync(u => u.Id == 2));
                await DbContext.SaveChangesAsync();
                return expenseToUpdate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteExpense(int id)
        {
            try
            {
                var expenseToDelete = await DbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
                if (expenseToDelete == null) throw new Exception("Gasto no encontrado.");
                DbContext.Expenses.Remove(expenseToDelete);
                InsertLog(0, "ELIMINAR", DateTime.UtcNow, "Expenses", "Gasto eliminado.", 2, await DbContext.Users.FirstAsync(u => u.Id == 2));
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ExpenseModel> GetExpense(int id)
        {
            try
            {
                var expense = await DbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
                if (expense == null) throw new Exception("Gasto no encontrado.");
                return expense;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
