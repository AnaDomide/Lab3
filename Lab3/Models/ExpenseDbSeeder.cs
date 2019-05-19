using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class ExpensesDbSeeder
    {

        public static void Initialize(ExpensesDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any expenses.
            if (context.Expenses.Any())
            {
                return;   // DB has been seeded
            }

            context.Expenses.AddRange(
                new Expense
                {
                    Description = "Description 1",
                    Sum = 24,
                    Location = "Cluj",
                    Currency = "Euro",
                    Typ = "food"
                },
                new Expense
                {
                    Description = "Description 2",
                    Sum = 30,
                    Location = "Bistrita",
                    Currency = "Euro",
                    Typ = "other"
                }
            );
            context.SaveChanges();
        }
    }
}

