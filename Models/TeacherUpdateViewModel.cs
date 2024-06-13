using SoniaGhandiAPI.DataLayer;

namespace SoniaGhandiAPI.Models
{
    public class TeacherUpdateViewModel
    {
        public List<DepartmentsViewModel>? DepartmentList { get; set; }
        public List<TeacherViewModel>? TeacherViewModelList { get; set; }
    }
}
