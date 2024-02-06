using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class User
	{
		[Required]
		public long Id { get; set; }

        [Required]
		public required string Username { get; set; }
		
        [Required]
		public required string Password { get; set; }
    }
}

