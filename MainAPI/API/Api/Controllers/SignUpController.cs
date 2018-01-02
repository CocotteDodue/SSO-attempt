using AutoMapper;
using Business;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/SignUp")]
    public class SignUpController : Controller
    {
        IMapper _mapper;
        UserLogic _userLogic;
        CvLogic _cvLogic;

        public SignUpController(IMapper mapper, UserLogic userLogic, CvLogic cvLogic)
        {
            _mapper = mapper;
            _userLogic = userLogic;
            _cvLogic = cvLogic;
        }
    }
}
