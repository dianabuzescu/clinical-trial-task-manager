using System.ComponentModel.DataAnnotations;

namespace Clinical_Trial_Task_Manager.Domain.Validation
{
    public class NotInFutureAttribute : ValidationAttribute
    {
        public NotInFutureAttribute()
        {
            ErrorMessage = "Date cannot be in the future.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return true; 

            if (value is DateTime date)
            {
                return date.Date <= DateTime.Today;
            }

            return false;
        }
    }
}
