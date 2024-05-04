using ecoapp.DTOS;
using ecoapp.Response;
using ecoapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ecoapp.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ExpenseController : Controller
    {
        private IExpenseService Service;
        public ExpenseController(IExpenseService service) { 
            Service = service;
        }
        [HttpGet]
        public async Task<ResponseObject<ICollection<ExpenseResponse>>> GetExpenses()
        {
            try
            { 
                return await Service.GetExpenses();
            }
            catch (Exception e)
            {
                var response = new ResponseObject<ICollection<ExpenseResponse>>() { Code = 500, Data = null, Message = "error - " + e.Message };
                return response;
            }
        }
        [HttpPost("expense")]
        public async Task<ResponseObject<ExpenseResponse>> PostExpense([FromBody] ExpenseDTO newExpense)
        {
            try
            {
                return await Service.CreateExpense(newExpense);
            }
            catch (Exception e)
            {
                var response = new ResponseObject<ExpenseResponse>() { Code = 500, Data = null, Message = "error - " + e.Message };
                return response;
            }
        }
        [HttpPut("{id}")]
        public async Task<ResponseObject<ExpenseResponse>> UpdateExpense([FromRoute] int id , [FromBody] ExpenseDTO newExpense)
        {
            try
            { 
                return await Service.UpdateExpense(id, newExpense);
            }
            catch (Exception e)
            {
                var response = new ResponseObject<ExpenseResponse>() { Code = 500, Data = null, Message = "error - " + e.Message };
                return response;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ResponseObject<string>> DeleteExpense([FromRoute] int id)
        {
            try
            { 
                return await Service.DeleteExpense(id);
            }
            catch (Exception e)
            {
                var response = new ResponseObject<string>() { Code = 500, Data = null, Message = "error - " + e.Message };
                return response;
            }
        }
        [HttpGet("{id}")]
        public async Task<ResponseObject<ExpenseResponse>> GetExpense([FromRoute] int id)
        {
            try
            { 
                return await Service.GetExpense(id);
            }
            catch (Exception e)
            {
                var response = new ResponseObject<ExpenseResponse>() { Code = 500, Data = null, Message = "error - " + e.Message };
                return response;
            }
        }
    }
}
