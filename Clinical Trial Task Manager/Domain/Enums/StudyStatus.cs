using System.ComponentModel.DataAnnotations;

namespace Clinical_Trial_Task_Manager.Domain.Enums
{
    public enum StudyStatus
    {
        [Display(Name = "Planned")]
        Planned = 0,

        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Closed")]
        Closed = 2
    }
}
