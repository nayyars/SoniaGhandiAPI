using SoniaGhandiAPI.DataLayer;

namespace SoniaGhandiAPI.Models
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }

        public string? TeacherName { get; set; }

        public int? DepartmentId { get; set; }

        public string? PhoneNumber { get; set; }

        public virtual Department? Department { get; set; }
    }
}
