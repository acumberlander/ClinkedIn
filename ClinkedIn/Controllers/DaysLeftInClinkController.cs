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
    public class DaysLeftInClinkController : ControllerBase
    {
        [HttpGet("{id}/seedaysleft")]
        public ActionResult GetDaysLeftInClink(int id)
        {
            var repository = new ClinkerRepository();
            var clinker = repository.GetAllClinkers().First(c => c.Id == id);

            //Clinker clinker = new Clinker("some", "body");
            
            DaysLeftInClink daysLeftInClink = new DaysLeftInClink();

            var daysLeft = daysLeftInClink.GetDaysLeftInClink(clinker.ReleaseDate);

            return Created($"api/daysLeftInClink/", daysLeft);
        }
    }
}