using System.ComponentModel.DataAnnotations;

namespace DynamicTimeTable.Models
{
    public class InputModel
    {
        [Range(1, 7, ErrorMessage = "Enter days between 1 and 7")]
        public int WorkingDays { get; set; }

        [Range(1, 8, ErrorMessage = "Subjects per day must be < 9")]
        public int SubjectsPerDay { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter a valid number of subjects")]
        public int TotalSubjects { get; set; }

        public int TotalHours => WorkingDays * SubjectsPerDay;
    }
}
