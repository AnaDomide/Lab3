using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Models;
using Lab3.Services;
using Lab3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private IExpenseService expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        /// <summary>
        /// Gets all the expenses
        /// </summary>
        
        /// <param name="from">Optional, filter by minimum Date</param>
        /// <param name="to">Optional,filter by maximum Date</param>
        /// <param name="type">Optional,filter by Type</param>
        /// <returns>A list of Expenses Objects</returns>
        [HttpGet]
        public IEnumerable<ExpenseGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to, [FromQuery]String type)
        {
          
            return expenseService.GetAll(from,to,type);

       }

        // GET: api/Expenses/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var found = expenseService.GetById(id);
           
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }


        /// <summary>
        /// Add an expense
        /// </summary>
        ///  <remarks>
        /// Sample request:
        ///
        ///     POST /expenses
        ///     {
        ///         "description": "Description 4",
        ///         "sum": 70,
        ///         "location": "Cluj",
        ///         "currency": "Euro",
        ///         "type": "other",
        ///         "date": "2019-06-06T00:00:00",
        ///          "comments": [
        ///	         {
        ///		             "text":"big town",
        ///		             "important":true
        ///          }, 
        ///	         {
        ///                  "text":"nice place",
        ///                  "important":true
        ///          }
        ///	       ]
        ///     }
        /// </remarks>
        /// <param name="expense">The expense to add.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] ExpensePostModel expense)
        {
            expenseService.Create(expense);
        }
        /// <summary>
        /// Update an expense
        /// </summary>
        /// <param name="id">Id to be updated</param>
        /// <param name="expense"></param>
        /// <returns></returns>
        // PUT: api/Expenses/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Expense expense)
        {
            var result = expenseService.Upsert(id, expense);
            return Ok(result);
        }

        /// <summary>
        /// Delete an expense
        /// </summary>
        /// <param name="id">Id to be deleted</param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = expenseService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
           
            return Ok(result);
        }
    }
}