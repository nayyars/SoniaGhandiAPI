using Microsoft.EntityFrameworkCore;
using SoniaGhandiAPI.DataLayer;
using SoniaGhandiAPI.Models;

namespace SoniaGhandiAPI.Repository
{
    public class TeacherRepository : IRepository<TeacherViewModel>
    {
        private readonly SMSContext _SMSContext;
        public TeacherRepository(SMSContext smsContext)
        {
            _SMSContext = smsContext;
        }
        public TeacherViewModel? GetTeacherByID(int id)
        {
            try
            {
                var tech = _SMSContext.Teachers.FirstOrDefault(t=>t.TeacherId==id);
                if (tech!=null) { return null; } else
                {
                    var xTeacherViewModel = new TeacherViewModel
                    {
                        TeacherId = tech.TeacherId,
                        TeacherName = tech.TeacherName,
                        PhoneNumber = tech.PhoneNumber,
                        Department=tech.Department,
                        DepartmentId=tech.DepartmentId
                       
                    };
                    return xTeacherViewModel;
                }
                
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public IEnumerable<TeacherViewModel>? GetTeachers()
        {
            try
            {
                var teacherlist = _SMSContext.Teachers.ToList();
                IEnumerable<TeacherViewModel> teacherViewModelList = teacherlist.Select(t=>new TeacherViewModel {
                 TeacherId=t.TeacherId,
                 TeacherName=t.TeacherName,
                 PhoneNumber=t.PhoneNumber,
                 Department = t.Department,
                 DepartmentId = t.DepartmentId
                
                }).ToList();
                return teacherViewModelList.Any() ? teacherViewModelList : null;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public TeacherUpdateViewModel GetUpdateTeacher()
        {
            var ContextTeacher= _SMSContext.Teachers.ToList();
            List<TeacherViewModel> techViewModel= ContextTeacher.Select(t => new TeacherViewModel
            {
                TeacherId = t.TeacherId,
                TeacherName = t.TeacherName,
                DepartmentId = t.DepartmentId,
                PhoneNumber = t.PhoneNumber
            }).ToList();

            var ContextDepartment = _SMSContext.Departments.ToList();

            List<DepartmentsViewModel> DepViewModel = ContextDepartment.Select(t => new DepartmentsViewModel
            {
              DepartmentId=t.DepartmentId,
              DepartmentName=t.DepartmentName
            }).ToList();

            TeacherUpdateViewModel updateTeacher = new TeacherUpdateViewModel { DepartmentList = DepViewModel, TeacherViewModelList = techViewModel };
            return updateTeacher;
        }

        public IEnumerable<Teacher> InsertTeacherByID(TeacherViewModel teacherViewModel)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TeacherViewModel> IRepository<TeacherViewModel>.InsertTeacherByID(TeacherViewModel teacherViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
