﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Models
{
    public class RegisterationModel
    {
        [Required]
        public string? Name { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}

