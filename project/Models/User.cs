using System;
namespace ExpensesManaging.project.POCO
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int age { get; set; }
        public DateTime BirthdayDate { get; set; }
    }
}