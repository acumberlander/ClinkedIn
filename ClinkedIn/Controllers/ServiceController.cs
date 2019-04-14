using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinkedIn.Data;
using ClinkedIn.Models;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpPost("addservice")]
        public ActionResult CreateService(Service service)
        {
            var newService = ServicesRepository.AddServices(service.ServiceName, service.ClinkerId);

            return Created($"api/createdService/", newService);
        }

        [HttpDelete("deleteservice")]
        public ActionResult DeleteService(Service service)
        {
            var listAfterDelete = ServicesRepository.DeleteService(service.ServiceName, service.ClinkerId);
            
            return Created($"api/deleteService/", listAfterDelete);
        }

    }
}