using System;
using System.ComponentModel.DataAnnotations;
using WebUi.Swagger;

namespace WebUi.Models
{
	public class Organization
	{
		[Required]
		public required long Id { get; set; }

		[Required]
		public required string Name { get; set; }

		public virtual ICollection<Patient>? Patients { get; set; }

		public virtual ICollection<ProgressNote>? ProgressNotes { get; set; }
    }
}

