﻿using System.ComponentModel.DataAnnotations;

namespace _2301B2WebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } //Hash
        public int RoleId { get; set; } //Hash
    }
}
