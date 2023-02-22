﻿using System.ComponentModel.DataAnnotations;

namespace Auth_CQRS_Example.Models.DTO
{
    public class UserRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
