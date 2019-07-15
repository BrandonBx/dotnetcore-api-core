using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesManaging.project.POCO
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }
    }
}