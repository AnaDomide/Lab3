using Lab3.Models;
using Lab3.ViewModels;
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

        public IEnumerable<CommentGetModel> GetAllFiltered(String filter)
        {
            IQueryable<CommentGetModel> result = context
                             .Comments
                             .Select(c => CommentGetModel.FromExpense(c))
                             .Where(c => c.Text.Contains(filter))
                             ;
            return result;
        }
    }
}
