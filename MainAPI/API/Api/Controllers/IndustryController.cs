//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using GruntifyV4.Model.Master.Repository.SignUp;
//using GruntifyV4.Model.Master.Contract.Entities.SignUp;

//namespace GruntifyV4.Api.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    public class IndustryController : Controller
//    {
//        private IndustryRepository _industryRepository;

//        public IndustryController(IndustryRepository industryRepository)
//        {
//            _industryRepository = industryRepository;
//        }
//        /// <summary>
//        /// api/Industry
//        /// 
//        /// return list of all industries
//        ///// </summary>
//        /// <returns>IEnumerable<Country></returns>
//        [HttpGet()]
//        public async Task<IActionResult> Get()
//        {
//            var result = await _industryRepository.GetAll();
//            return Ok(result);
//        }

//        /// <summary>
//        /// api/Industry/5
//        /// 
//        /// retreive industry with specified id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns>Industry if exist</returns>
//        // GET: 
//        [HttpGet("{id}")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var result = await _industryRepository.Get(id);
//            return Ok(result);
//        }

//        /// <summary>
//        /// api/Industry/Create
//        /// 
//        /// Create new industry in the system
//        /// </summary>
//        /// <param name="Industry"></param>
//        [HttpPost("Create")]
//        public void Post([FromBody]Industry country)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// api/Industry/Update
//        /// </summary>
//        /// <param name="industry"></param>
//        [HttpPut("Update")]
//        public void Put([FromBody]Industry country)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// api/Industry/Delete/5
//        /// 
//        /// Delete industry with following id
//        /// </summary>
//        /// <param name="id"></param>
//        [HttpDelete("Delete/{id}")]
//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
