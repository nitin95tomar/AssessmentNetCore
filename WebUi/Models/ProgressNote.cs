using System;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Models
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
		public required long PatientId;

		[Required]
		public required long OrganizationId;
	}
}

