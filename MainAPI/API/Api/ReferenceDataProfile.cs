using AutoMapper;
using Dto = GruntifyV4.Model.Master.Contract.SignUp;
using Entities = GruntifyV4.Model.Master.Entities.SignUp;

namespace GruntifyV4.Api.Public.Mappings.Profiles
{
    public class ReferenceDataProfile: Profile
    {
        public ReferenceDataProfile()
        {
            CreateMap<Dto.Country, Entities.Country>().ReverseMap();
            CreateMap<Dto.Industry, Entities.Industry>().ReverseMap();
            CreateMap<Dto.OrganisationSize, Entities.OrganisationSize>().ReverseMap();
        }
        
    }
}
