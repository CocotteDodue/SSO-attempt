//using AutoMapper;
//using GruntifyV4.Model.Master.Contract.Dto.SignUp;
//using Dto = GruntifyV4.Model.Master.Contract.Dto.SignUp;
//using Entities = GruntifyV4.Model.Master.Contract.Entities.SignUp;

//namespace GruntifyV4.Api.Public.Mappings.Profiles
//{
//    public class OrganisationProfile : Profile
//    {
//        public OrganisationProfile()
//        {
//            CreateMap<Dto.OrganisationWithUsers, Entities.Organisation>()
//                .ForMember(orgaEntity => orgaEntity.UserOrganisation, opt => opt.MapFrom(orgaContract => orgaContract.Users));

//            CreateMap<Entities.Organisation, Dto.OrganisationWithUsers>()
//                .ForMember(orgaContract => orgaContract.Users, opt => opt.MapFrom(orgaEntity => orgaEntity.UserOrganisation));


//            CreateMap<OrganisationCreationData, OrganisationWithUsers>().ReverseMap();
//        }

//    }
//}