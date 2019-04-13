using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWardenController : ControllerBase
    {
        readonly WardenRepository _wardenRepository;
        readonly CreateWardenRequestValidator _validator;

        public RegisterWardenController()
        {
            _validator = new CreateWardenRequestValidator();
            _wardenRepository = new WardenRepository();
        }

        [HttpPost("register")]
        public ActionResult AddWarden(CreateWardenRequest createRequest)
        {
            //validation
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name and password" });
            }

            var newWarden = _wardenRepository.AddWarden(createRequest.Name, createRequest.Password);

            return Created($"api/wardens/{newWarden.Id}", newWarden);
        }
    }

}