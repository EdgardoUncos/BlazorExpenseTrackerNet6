using BlazorExpenseTracker.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.UI.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseDetails(int id);
        Task SaveExpense(Expense expense);
        Task DeleteExpense(int id);
    }
}
