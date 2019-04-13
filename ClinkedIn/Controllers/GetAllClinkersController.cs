using ClinkedIn.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllClinkersController : ControllerBase
    {
        readonly ClinkerRepository _clinkerRepository;

        public GetAllClinkersController()
        {
            _clinkerRepository = new ClinkerRepository();
        }

        [HttpGet("allclinkers")]
        public ActionResult GetAllClinkers()
        {
            
            var clinkerList = _clinkerRepository.GetAllClinkers();

            return Created($"api/getAllClinkers", clinkerList);
        }
    }
}