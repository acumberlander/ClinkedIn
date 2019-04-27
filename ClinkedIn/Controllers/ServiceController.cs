using ClinkedIn.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet("allclinkerservices")]
        public ActionResult GetAllClinkerServices()
        {
            var serviceList = ServiceRepository.GetAllClinkerServices();

            return Created($"api/getAllClinkerServices", serviceList);
        }

        [HttpGet("allservices")]
        public ActionResult GetAllServices()
        {
            var serviceList = ServiceRepository.GetAllServices();

            return Created($"api/getAllServices", serviceList);
        }
    }
}