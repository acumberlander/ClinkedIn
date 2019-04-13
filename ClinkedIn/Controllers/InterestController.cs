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
        public ActionResult CreateInterst(Interest interest)
        {
            var newInterest = InterestRepository.AddInterest(interest.Name, interest.ClinkerId);

            return Created($"api/createdInterest/{newInterest.Id}", newInterest);
        }

        [HttpGet("allinterests")]
        public ActionResult GetAllClinkers()
        {

            var interestList = InterestRepository.GetAllInterests();

            return Created($"api/getAllInterests", interestList);
        }

        [HttpGet("{clinkerId}/findfriends")]
        public ActionResult GetPotentialFriends(int clinkerId)
        {
            var potentialFriendsList = ClinkerRepository.FindPotentialFriends(clinkerId);
            
            return Created($"api/getPotentialFriends", potentialFriendsList);
        }
    }
}