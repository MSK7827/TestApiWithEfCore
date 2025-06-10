using AutoMapper;

namespace TestApiWithEfCore.NewFolder
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentCreateDto, Student>();
            CreateMap<EnrollmentCreateDto, Enrollment>();
            CreateMap<CreateBasketDto, BasketModel>();
            CreateMap<CreateBasketLoanItemDto, BasketLoanItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
