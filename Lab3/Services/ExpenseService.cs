using Lab3.Models;
using Lab3.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = Lab3.Models.Type;

namespace Lab3.Services
{

    public interface IExpenseService {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<ExpenseGetModel> GetAll(DateTime? from=null,DateTime? to=null,String type=null);
        Expense GetById(int id);
        Expense Create(ExpensePostModel expense);
        Expense Upsert(int id, Expense expense);
        Expense Delete(int id);


    }

    public class ExpenseService : IExpenseService
    {
        private ExpensesDbContext context;

        public ExpenseService(ExpensesDbContext context)
        {
            this.context = context;
        }

        public Expense Create(ExpensePostModel expense)
        {
            Expense toAdd = ExpensePostModel.ToExpense(expense);
            context.Expenses.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Expense Delete(int id)
        {
            var existing = context.Expenses
                .Include(e => e.Comments).FirstOrDefault(Expense => Expense.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Expenses.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public Expense GetById(int id)
        {
            //sau context.Expenses.Find()
            return context.Expenses
                .Include(e => e.Comments)
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<ExpenseGetModel> GetAll(DateTime? from=null, DateTime? to=null, string type=null)
        {
            IQueryable<Expense> result = context
                .Expenses
                .Include(t => t.Comments);
            if (from == null & to == null & type == null)
            {
                return result.Select(t => ExpenseGetModel.FromExpense(t));
            }
            if (from != null)
            {
                result = result.Where(f => f.Date >= from);

            }
            if (to != null)
            {
                result = result.Where(f => f.Date <= to);
            }
            if (type != null)
            {
                result = result.Where(f => f.Typ.Equals(type));
            }
            return result.Select(t => ExpenseGetModel.FromExpense(t));
        }

        public Expense Upsert(int id, Expense expense)
        {
            var existing = context.Expenses.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Expenses.Add(expense);
                context.SaveChanges();
                return expense;
            }
            expense.Id = id;
            context.Expenses.Update(expense);
            context.SaveChanges();
            return expense;
        }
    }
}
