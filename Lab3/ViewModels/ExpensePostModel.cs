using Lab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Type = Lab3.Models.Type;

namespace Lab3.ViewModels
{
    public class ExpensePostModel
    {
        public string Description { get; set; }
        public double Sum { get; set; }
        public string Location { get; set; }
        public string Currency { get; set; }
        public string Typ { get; set; }
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }


        public static Expense ToExpense(ExpensePostModel expense)
        {
            //Transformare din string in Enum Type
            
            if (expense.Typ == "utilities")
            {
            }
            else if (expense.Typ == "transportation")
            {
            }
            else if (expense.Typ == "outing")
            {
            }
            else if (expense.Typ == "groceries")
            {
            }
            else if (expense.Typ == "clothes")
            { 
            }
            else if (expense.Typ == "electronics")
            {
            }
            else if (expense.Typ == "others")
            {
            }
            return new Expense
            {
                Description = expense.Description,
                Sum = expense.Sum,
                Location = expense.Location,
                Currency = expense.Currency,
                Typ= expense.Typ,
                Date = expense.Date,
                Comments = expense.Comments
            };
        }

    }
}
