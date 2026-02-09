using System.ComponentModel.DataAnnotations;
using Clinical_Trial_Task_Manager.Domain.Enums;
using TaskStatus = Clinical_Trial_Task_Manager.Domain.Enums.TaskStatus;

namespace Clinical_Trial_Task_Manager.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public TaskPriority Priority { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        // Foreign key
        [Required]
        public int PatientId { get; set; }

        // Navigation
        public Patient? Patient { get; set; }
    }
}
