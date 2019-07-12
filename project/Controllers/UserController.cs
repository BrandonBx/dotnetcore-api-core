using ExpensesManaging.project.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManaging.project.Controllers
{
    public class UserController
    {
        private readonly UserContext _context;

        public UserController (UserContext context) {
            _context = context;
        }
    }
}