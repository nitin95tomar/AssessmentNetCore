using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Patient
    {
        [Required]
        public required long Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public string? Address { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        [Required]
        public required long OrganizationId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }

        public ICollection<ProgressNote>? ProgressNotes { get; set; }
    }
}