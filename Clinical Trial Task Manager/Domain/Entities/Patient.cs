using System.ComponentModel.DataAnnotations;
using Clinical_Trial_Task_Manager.Domain.Validation;


namespace Clinical_Trial_Task_Manager.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [NotInFuture]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        // Foreign key
        [Required]
        public int StudyId { get; set; }

        // Navigation
        public Study? Study { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
