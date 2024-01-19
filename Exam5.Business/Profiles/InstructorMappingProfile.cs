using AutoMapper;
using Exam5.Business.Helpers;

namespace Exam5.Business.Profiles
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile(string rootPath)
        {
            CreateMap<Instructor, InstructorListItemVM>();
            CreateMap<Instructor, InstructorUpdateVM>();

            CreateMap<InstructorCreateVM, Instructor>()
                .ForMember(i => i.ImageUrl, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = src.ImageFile.SaveAndProvideName(rootPath);
                    }
                });
            CreateMap<InstructorUpdateVM,Instructor>()
                .ForMember(i => i.ImageUrl, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = src.ImageFile.SaveAndProvideName(rootPath);
                    }
                });
        }
    }
}
