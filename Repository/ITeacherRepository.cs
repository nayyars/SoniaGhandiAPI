using SoniaGhandiAPI.Models;

namespace SoniaGhandiAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        TeacherUpdateViewModel GetUpdateTeacher();
        IEnumerable<T>? GetTeachers();
        IEnumerable<T> InsertTeacherByID(TeacherViewModel teacherViewModel);
        TeacherViewModel? GetTeacherByID(int id);
    }
}
