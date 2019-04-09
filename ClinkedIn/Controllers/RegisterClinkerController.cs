using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterClinkerController : ControllerBase
    {
        readonly ClinkerRepository _clinkerRepository;
        readonly CreateClinkerRequestValidator _validator;

        public RegisterClinkerController()
        {
            _validator = new CreateClinkerRequestValidator();
            _clinkerRepository = new ClinkerRepository();
        }

        [HttpPost("register")]
        public ActionResult AddClinker(CreateClinkerRequest createRequest)
        {
            //validation
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name and password" });
            }

            var newClinker = _clinkerRepository.AddClinker(createRequest.Name, createRequest.Password);

            return Created($"api/clinkers/{newClinker.Id}", newClinker);
        }
    }

}