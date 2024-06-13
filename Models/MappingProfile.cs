using AutoMapper;
using SoniaGhandiAPI.DataLayer;

namespace SoniaGhandiAPI.Models
{
    public class MappingProfile:Profile
    {
       public MappingProfile() {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}
