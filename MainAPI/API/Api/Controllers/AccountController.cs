using AutoMapper;
using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Contract.Dto;
using System.Threading.Tasks;

namespace MainApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        UserFacade _userFacade;
        IMapper _mapper;
        CvFacade _cvFacade;

        public AccountController(IMapper mapper, UserFacade userFacade, CvFacade cvFacade)
        {
            _mapper = mapper;
            _userFacade = userFacade;
            _cvFacade = cvFacade;
        }

        [HttpPost("AccountExists")]
        public async Task<bool> AccountExists([FromBody] string email)
        {
            var exists = (await _userFacade.GetByEmail(email)) != null;
            return exists;
        }

        [HttpPost("AccountDetails")]
        public async Task<UserDto> AccountDetails([FromBody] string email)
        {
            return await _userFacade.GetByEmail(email);
        }

        [HttpPost("RegisterNewUser")]
        public async Task<bool> RegisterNewUser([FromBody] UserSignUpDto newUser)
        {
            var registrationSuccessful = await _userFacade.RegisterNewUser(newUser);

            return registrationSuccessful;
        }

    }
}