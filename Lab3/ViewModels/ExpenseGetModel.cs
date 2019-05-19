using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.ViewModels
{
    public class ExpenseGetModel
    {
        public string Description { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public string Typ { get; set; }
        public int NumberOfComments { get; set; }

        public static ExpenseGetModel FromExpense(Expense expense)
        {
            return new ExpenseGetModel
            {
                Description = expense.Description,
                Sum = expense.Sum,
                Typ= expense.Typ,
                Date= expense.Date,
                NumberOfComments = expense.Comments.Count
            };
        }
    }
}
