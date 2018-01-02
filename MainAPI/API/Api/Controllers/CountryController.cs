//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using GruntifyV4.Model.Master.Repository.SignUp;
//using GruntifyV4.Model.Master.Contract.Entities.SignUp;

//namespace GruntifyV4.Api.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    public class CountryController : Controller
//    {
//        private CountryRepository _countryRepository;

//        public CountryController(CountryRepository countryRepository)
//        {
//            _countryRepository = countryRepository;
//        }
//        /// <summary>
//        /// api/Country
//        /// 
//        /// return list of all system countries
//        /// </summary>
//        /// <returns>IEnumerable<Country></returns>
//        [HttpGet()]
//        public async Task<IActionResult> Get()
//        {
//            var result = await _countryRepository.GetAll();
//            return Ok(result);
//        }

//        /// <summary>
//        /// api/Country/5
//        /// 
//        /// retreive country with specified id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns>country if exist</returns>
//        // GET: 
//        [HttpGet("{id}")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var result = await _countryRepository.Get(id);
//            return Ok(result);
//        }

//        /// <summary>
//        /// api/Country/Create
//        /// 
//        /// Create new country in the system
//        /// </summary>
//        /// <param name="country"></param>
//        [HttpPost("Create")]
//        public void Post([FromBody]Country country)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// api/Country/Update
//        /// </summary>
//        /// <param name="country"></param>
//        [HttpPut("Update")]
//        public void Put([FromBody]Country country)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// api/Country/Delete/5
//        /// 
//        /// Delete country with following id
//        /// </summary>
//        /// <param name="id"></param>
//        [HttpDelete("Delete/{id}")]
//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
