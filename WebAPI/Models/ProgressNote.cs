using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class ProgressNote
	{
		[Required]
		public required long Id { get; set; }

		[Required]
		public required string SectionName { get; set; }

		[Required]
		public required string SectionText { get; set; }

		[Required]
		public required long PatientId { get; set; }

		[Required]
		public required long OrganizationId { get; set; }
	}
}

