using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkersController : ControllerBase
    {
        readonly ClinkerRepository _clinkerRepository;
        readonly CreateClinkerRequestValidator _validator;

        public ClinkersController()
        {
            _validator = new CreateClinkerRequestValidator();
            _clinkerRepository = new ClinkerRepository();
        }

        // Register new clinker
        [HttpPost("register")]
        public ActionResult AddClinker(CreateClinkerRequest createRequest)
        {
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name and password" });
            }

            var newClinker = _clinkerRepository.AddClinker(createRequest.Name, createRequest.Password, createRequest.Age, createRequest.IsPrisoner, createRequest.ReleaseDate);

            return Created($"api/clinkers/{newClinker.Id}", newClinker);
        }

        // Get all clinkers
        [HttpGet]
        public ActionResult GetAllClinkers()
        {
            var clinkers = _clinkerRepository.GetAllClinkers();

            return Ok(clinkers);
        }

        // Delete a clinker
        [HttpDelete("{clinkerId}/deleteClinker")]
        public ActionResult deleteClinker(int clinkerId)
        {
            var newClinkerList = _clinkerRepository.DeleteClinker(clinkerId);

            return Created("api/clinkers", newClinkerList);
        }

        // Update a clinker
        [HttpPut("{clinkerId}/updateClinker")]
        public ActionResult updateClinker(int clinkerId, UpdateClinkerRequest updateRequest)
        {
            var updatedClinker = _clinkerRepository.UpdateClinker
                (clinkerId, 
                updateRequest.Name, 
                updateRequest.Password, 
                updateRequest.Age, 
                updateRequest.IsPrisoner, 
                updateRequest.ReleaseDate);

            if (updatedClinker)
            {
                return Ok();
            }
            return NotFound();
        }
    }

}