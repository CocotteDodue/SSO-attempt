//using GruntifyV4.Model.Master.Repository.SignUp;
//using GruntifyV4.Api.Facades;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Dto = GruntifyV4.Model.Master.Contract.Dto.SignUp;
//using System.Net.Http;
//using AutoMapper;

//namespace GruntifyV4.Api.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    public class OrganisationController : Controller
//    {
//        private OrganisationRepository _organisationRepository;
//        private OrganisationFacade _organisationFacade;
//        private UserFacade _userFacade;

//        public OrganisationController(OrganisationRepository organisationRepository,
//            OrganisationFacade organisationFacade,
//            UserFacade userFacade)
//        {
//            _organisationRepository = organisationRepository;
//            _organisationFacade = organisationFacade;
//            _userFacade = userFacade;
//        }

//        /// <summary>
//        /// /api/Organisation/GetAvaliableUrl/{url}
//        /// 
//        /// Get all organisations
//        /// </summary>
//        /// <returns>All organisations</returns>
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await _organisationRepository.GetAll();
//            return Ok(result);
//        }

//        /// <summary>
//        /// /api/Organisation/GetAvaliableUrl
//        /// 
//        /// Return a valida available url from the base input url
//        /// if input url is valid & available: return input url
//        /// </summary>
//        /// <param name="id">The organisation id</param>
//        /// <returns>The requested organisation</returns>
//        [HttpPost("GetAvaliableUrl")]
//        public async Task<IActionResult> GetAvaliableUrl([FromBody] string url)
//        {
//            string validUrl = await _organisationFacade.RetriveValidUrlAsync(url);
//            return Ok(validUrl);
//        }

//        /// <summary>
//        /// /api/Organisation/Create
//        /// 
//        /// Create a new organisation for the data provided
//        /// - Create a(ll) user(s) related to the organisation, if necessary
//        /// </summary>
//        /// <param name="organisation"></param>
//        /// <returns>the newly created organisation id</returns>
//        [HttpPost("Create")]
//        public async Task<IActionResult> Create([FromBody] Dto.SignUpPayload organisationCreationDataDto)
//        {
//            var newOrganisation = Mapper.Map<Dto.SignUpPayload>(organisationCreationDataDto);
            
//            if (_organisationFacade.IsValidOrganisation(newOrganisation))
//                //&& await _userFacade.CheckUsersValidityAsync(newOrganisation.Users))
//            {
//                using (var httpClient = new HttpClient())
//                {
//                    // create stripeID => billable service
//                    string stripeId = string.Empty;

//                    // create organisation with user & stripe ID
//                    // map with automapper
//                    newOrganisation.StripeId = stripeId;
//                }

//                var result = await _organisationFacade.CreateOrganisation(newOrganisation);
//                // check if all users existing or are valid for creation
//                if (result != null )
//                {
//                    return Ok(result);
//                } else
//                {
//                    // if null -> clear up strip account
//                    // else proceed
//                }
//            }

//            return BadRequest();
//        }
//    }
//}