using AutoMapper;
using Model.Contract.Dto;
using ModelContract.Entities;

namespace Model.Contract.Mappings.Profiles
{
    public class CvProfile: Profile
    {
        public CvProfile()
        {
            CreateMap<CvDto, Cv>().ReverseMap();
        }
    }
}
