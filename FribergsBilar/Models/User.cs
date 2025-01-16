﻿using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}