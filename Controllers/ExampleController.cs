using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManagingApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ExampleContext _context;

        public TodoController(ExampleContext context)
        {
            _context = context;

            if (_context.ExampleItems.Count() == 0)
            {
                // Create a new ExampleItem if collection is empty,
                // which means you can't delete all ExampleItems.
                _context.ExampleItems.Add(new ExampleItem { name = "Item1" });
                _context.SaveChanges();
            }
        }
    }
}