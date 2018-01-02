//using AutoMapper;
//using GruntifyV4.Api.Mappings.CustomConverter;
//using Dto = GruntifyV4.Model.Master.Contract.Dto.SignUp;
//using Entities = GruntifyV4.Model.Master.Contract.Entities.SignUp;

//namespace GruntifyV4.Api.Public.Mappings.Profiles
//{
//    public class UserProfile: Profile
//    {
//        public UserProfile()
//        {
//            CreateMap<Dto.User, Entities.User>().ReverseMap();

//            CreateMap<Dto.User, Entities.UserOrganisation>()
//                .ForMember(userOrga => userOrga.Id, opt => opt.Ignore())
//                .ForMember(userOrga => userOrga.User, opt => opt.MapFrom(user => user.Id == 0 ? user : null))
//                .ForPath(userOrga => userOrga.UserId, opt => opt.MapFrom(user => user.Id));
//            CreateMap<Entities.UserOrganisation, Dto.User>().ConvertUsing<UserOrganisationToUserContractConverter>();
//        }
//    }
//}
