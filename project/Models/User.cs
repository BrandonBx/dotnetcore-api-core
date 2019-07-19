using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ExpensesManaging.project.Models
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
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }
    }
}