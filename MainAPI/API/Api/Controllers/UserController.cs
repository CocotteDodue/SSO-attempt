//using GruntifyV4.Model.Master.Repository.SignUp;
//using GruntifyV4.Api.Facades;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Dto = GruntifyV4.Model.Master.Contract.Dto.SignUp;

//namespace GruntifyV4.Api.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/User")]
//    public class UserController : Controller
//    {
//        private UserRepository _userRepository;
//        //private UserFacade _userFacade;
//        //public UserController(UserRepository userRepository, UserFacade userFacade)
//        //{
//        //    _userRepository = userRepository;
//        //    _userFacade = userFacade;
//        //}

//        /// <summary>
//        /// /api/User
//        /// 
//        /// Get all users
//        /// </summary>
//        /// <returns>A list of all users</returns>
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await _userRepository.GetAll();
//            return Ok(result);
//        }

//        /// <summary>
//        /// /api/User/{id:int}
//        /// 
//        /// Get a user by id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var result = await _userRepository.Get(id);
//            return Ok(result);
//        }

//        /// <summary>
//        /// /api/User/Create
//        /// 
//        /// Save a new user
//        /// </summary>
//        /// <returns>
//        /// The user id of the created user
//        /// </returns>
//        //[HttpPost("Create")]
//        //public async Task<IActionResult> Create()
//        //{
//        //    //var userId = await _userFacade.CreateUserAsync(user);
//        //    //return Ok();
//        //}

//        /// <summary>
//        /// /api/User/Update
//        /// 
//        /// Update a user
//        /// </summary>
//        /// <param name="user">The user object to update</param>
//        /// <returns>True if update was successful</returns>
//        [HttpPut("Update")]
//        public async Task<IActionResult> Update()
//        {
//            //var result = await _userRepository.Update(user);
//            //return Ok(result);
//            return Ok();
//        }

//        /// <summary>
//        /// /api/User/Delete/{id:int}
//        /// 
//        /// Delete a user
//        /// </summary>
//        /// <param name="id">The userId of the user that must be deleted</param>
//        /// <returns>True if delete is successful</returns>
//        [HttpDelete("Delete/{id:int}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var success = await _userRepository.Delete(id);
//            return Ok(success);
//        }

//        /// <summary>
//        /// Search the repository for a user with specific email
//        /// </summary>
//        /// <returns>A single user matching the search criteria</returns>
//        [HttpPost("SearchByEmail")]
//        public async Task<IActionResult> SearchByEmail([FromBody] string email)
//        {
//            var foundUser = await _userFacade.SearchByEmail(email);
//            return Ok(foundUser);
//        }
//    }
//}
