using AutoMapper;
using WebAPISecondLook.DTO;
using WebAPISecondLook.Models;

namespace WebAPISecondLook.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmpNameWithDeptNameDTO>()
                .ForPath(x => x.EmpName, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.DeptName, x => x.MapFrom(x => x.Department.Name));
        }
    }
}
