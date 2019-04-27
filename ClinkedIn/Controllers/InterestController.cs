using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        //static object _interests;

        [HttpPost("addinterest")]
        public ActionResult CreateInterest(Interests interestObject)
        {
            var newInterest = InterestRepository.AddInterest(interestObject);

            return Created($"api/createdInterest/{newInterest.Id}", newInterest);
        }

        [HttpPost("addclinkerinterest")]
        public ActionResult CreateClinkerInterest(ClinkerInterests clinkerInterestObject)
        {
            var newClinkerInterest = InterestRepository.AddClinkerInterest(clinkerInterestObject);

            return Created($"api/createdInterest/{newClinkerInterest.Id}", newClinkerInterest);
        }

        [HttpGet("allclinkerinterests")]
        public ActionResult GetAllClinkerInterests()
        {

            var interestList = InterestRepository.GetAllClinkerInterests();

            return Created($"api/getAllClinkerInterests", interestList);
        }

        [HttpGet("allinterests")]
        public ActionResult GetAllInterests()
        {

            var interestList = InterestRepository.GetAllInterests();

            return Created($"api/getAllInterests", interestList);
        }

        //[HttpGet("{clinkerId}/findfriends")]
        //public ActionResult GetPotentialFriends(int clinkerId)
        //{

        //    var potentialFriendsList = ClinkerRepository.FindPotentialFriends(clinkerId);
            
        //    return Created($"api/getPotentialFriends", potentialFriendsList);
        //}


        //[HttpDelete("{interestId}/deleteIt")]
        //public ActionResult deleteInterest(int interestId)
        //{
        //var newInterestList = InterestRepository.DeleteInterest(interestId);

        //return Created("api/interestList", newInterestList);
        //}

        //[HttpPut("updateIt")]
        //public ActionResult updateInterest(Interest newInterest)
        //{
        //var updatedInterestObject = InterestRepository.UpdateInterest(newInterest);

        //return Created("api/updatedInterest", updatedInterestObject);
        //}
    }
}