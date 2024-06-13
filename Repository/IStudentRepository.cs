using AutoMapper;
using SoniaGhandiAPI.DataLayer;
using SoniaGhandiAPI.Models;
using System.Collections.Generic;

namespace SoniaGhandiAPI.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentViewModel> GetStudents();
        public StudentViewModel GetStudentByID(int id);
        public StudentViewModel InsertStudent(StudentViewModel student);
        public void UpdateStudent(StudentViewModel student);
    }
    public class StudentRepository : IStudentRepository
    {
        private readonly SMSContext _SMSContext;
        private readonly IMapper _IMapper;
        public StudentRepository(SMSContext smsContext, IMapper iMapper )
        {
            _SMSContext = smsContext;
            _IMapper = iMapper;
        }
        public IEnumerable<StudentViewModel> GetStudents()
        {
            IEnumerable<Student> StudentEntityData =_SMSContext.Students.ToList();
             var da= StudentEntityData.Select(t => new StudentViewModel
              { StudentId=t.StudentId,StudentName=t.StudentName,RollNumber=t.RollNumber,Mobile=t.Mobile,FatherName=t.FatherName }
            ).ToList();
         
            return da;
        }

        public StudentViewModel GetStudentByID(int id)
        {
            var t= _SMSContext.Students.FirstOrDefault(t=>t.StudentId==id);
            if(t==null)
            {
                return new StudentViewModel();
            }
            StudentViewModel student=new StudentViewModel { StudentId = t.StudentId, StudentName = t.StudentName, RollNumber = t.RollNumber, Mobile = t.Mobile, FatherName = t.FatherName };
            
            return student;
        }

        public StudentViewModel InsertStudent(StudentViewModel student)
        {

            var EntityStudent = _IMapper.Map<Student>(student);
            _SMSContext.Students.Add(EntityStudent);
            _SMSContext.SaveChanges();
            return student;

        }

        public void UpdateStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }
    }

}
