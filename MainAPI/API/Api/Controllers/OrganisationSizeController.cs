//using GruntifyV4.Model.Master.Contract.Entities.SignUp;
//using GruntifyV4.Model.Master.Repository.SignUp;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GruntifyV4.Api.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    public class OrganisationSizeController : Controller
//    {
//        private OrganisationSizeRepository _organisationSizeRepository;

//        public OrganisationSizeController(OrganisationSizeRepository organisationSizeRepository)
//        {
//            _organisationSizeRepository = organisationSizeRepository;
//        }
//        /// <summary>
//        /// api/Industry
//        /// 
//        /// return list of all system OrganisationSize order by increasing order
//        /// </summary>
//        /// <returns>IEnumerable<Country></returns>
//        [HttpGet()]
//        public async Task<IActionResult> Get()
//        {
//            var sizesList = await _organisationSizeRepository.GetAll();
//            return Ok(sizesList.OrderBy(size => size.Id));
//        }

//        /// <summary>
//        /// api/OrganisationSize/5
//        /// 
//        /// retreive organisationSize with specified id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns>OrganisationSize if exist</returns>
//        // GET: 
//        [HttpGet("{id}")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var result = await _organisationSizeRepository.Get(id);
//            return Ok(result);
//        }

//        /// <summary>
//        /// api/OrganisationSize/Create
//        /// 
//        /// Create new organisationSize in the system
//        /// </summary>
//        /// <param name="OrganisationSize"></param>
//        [HttpPost("Create")]
//        public void Post([FromBody]OrganisationSize country)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// api/Industry/Update
//        /// </summary>
//        /// <param name="industry"></param>
//        [HttpPut("Update")]
//        public void Put([FromBody]OrganisationSize country)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// api/OrganisationSize/Delete/5
//        /// 
//        /// Delete organisationSize with following id
//        /// </summary>
//        /// <param name="id"></param>
//        [HttpDelete("Delete/{id}")]
//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
