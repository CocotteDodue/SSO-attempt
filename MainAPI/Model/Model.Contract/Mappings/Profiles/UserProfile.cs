using AutoMapper;
using Model.Contract.Dto;
using ModelContract.Entities;
using System.Linq;

namespace ModelContract.Mappings.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserSignUpDto, User>()
                .ForMember(user => user.HashedPassword, opt => opt.MapFrom(userDto => userDto.Password));

            CreateMap<User, UserDto>()
                .ForMember(userDto => userDto.Cvs, opt => opt.MapFrom(user => user.UserCv.Select(userCv => userCv.Cv)));
        }
    }
}
