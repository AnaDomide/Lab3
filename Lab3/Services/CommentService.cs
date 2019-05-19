using Lab3.Models;
using Lab3.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Services
{

    public interface ICommentService
    {
        IEnumerable<CommentGetModel> GetAllFiltered(String filter);
    }

    public class CommentService : ICommentService
    {

        private ExpensesDbContext context;

        public CommentService(ExpensesDbContext context)
        {
            this.context = context;
        }

        //public IEnumerable<CommentGetModel> GetAllFiltered(String filter)
        //{
        //    IQueryable<CommentGetModel> result = context
        //                     .Comments
        //                     .Select(c => CommentGetModel.FromExpense(c))
        //                     .Where(c => c.Text.Contains(filter))
        //                     ;
        //    return result;
        //}

        public IEnumerable<CommentGetModel> GetAllFiltered(String filter)
        {
            IQueryable<Expense> result = context.Expenses.Include(c => c.Comments);

            List<CommentGetModel> resultComments = new List<CommentGetModel>();
            List<CommentGetModel> resultCommentsAll = new List<CommentGetModel>();

            foreach (Expense expense in result)
            {
                expense.Comments.ForEach(c =>
                {
                    if (c.Text == null || filter == null)
                    {
                        CommentGetModel comment = new CommentGetModel
                        {
                            Id = c.Id,
                            Important = c.Important,
                            Text = c.Text,
                            ExpenseId = expense.Id

                        };
                        resultCommentsAll.Add(comment);
                    }
                    else if (c.Text.Contains(filter))
                    {
                        CommentGetModel comment = new CommentGetModel
                        {
                            Id = c.Id,
                            Important = c.Important,
                            Text = c.Text,
                            ExpenseId = expense.Id

                        };
                        resultComments.Add(comment);

                    }
                });
            }
            if (filter == null)
            {
                return resultCommentsAll;
            }
            return resultComments;
        }
    }
}
