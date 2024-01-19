using AutoMapper;

namespace Exam5.Business.Profiles
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<InstructorCreateVM,Instructor>();
            CreateMap<InstructorUpdateVM,Instructor>();
            CreateMap<Instructor, InstructorListItemVM>();

            CreateMap<Instructor, InstructorUpdateVM>();
                
        }
    }
}
