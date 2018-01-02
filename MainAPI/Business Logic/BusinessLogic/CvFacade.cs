using AutoMapper;
using Model.Contract.Interfaces.Business;
using ModelContract;

namespace Business
{
    public class CvFacade: ICvFacade
    {
        private MainApiDbContextInstance _dbInstanceProperties;
        private IMapper _mapper;
        private UserFacade _userFacade;

        public CvFacade(MainApiDbContextInstance dbInstanceProperties, IMapper mapper,  UserFacade userFacade)
        {
            _dbInstanceProperties = dbInstanceProperties;
            _mapper = mapper;
            _userFacade = userFacade;
        }
    }
}
