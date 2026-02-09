using System.ComponentModel.DataAnnotations;
using Clinical_Trial_Task_Manager.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinical_Trial_Task_Manager.Domain.Entities
{
    public class Study
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Sponsor { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public StudyStatus Status { get; set; }

        // Navigation
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

    }
}
