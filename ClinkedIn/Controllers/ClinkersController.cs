﻿using ClinkedIn.Data;
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

        [HttpPost("register")]
        public ActionResult AddClinker(CreateClinkerRequest createRequest)
        {
            //validation
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name and password" });
            }

            var newClinker = _clinkerRepository.AddClinker(createRequest.Name, createRequest.Password, createRequest.Age, createRequest.IsPrisoner, createRequest.ReleaseDate);

            return Created($"api/clinkers/{newClinker.Id}", newClinker);
        }

        [HttpGet]
        public ActionResult GetAllClinkers()
        {
            var clinkers = _clinkerRepository.GetAllClinkers();

            return Ok(clinkers);
        }
    }

}