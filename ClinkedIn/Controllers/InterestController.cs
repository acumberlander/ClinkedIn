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
            //filter _interest list by clinkerId.
            List<Interest> userInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == clinkerId).ToList();

            //separate users who are not your friends.
            List<Friendship> yourFriendships = FriendshipRepository._friends.Where(friendship => friendship.ClinkerOneId == clinkerId || friendship.ClinkerTwoId == clinkerId).ToList();
            List<Clinker> notYourFriends = new List<Clinker>();

            foreach (var prisoner in ClinkerRepository._clinkers)
            {
                foreach(var friendship in yourFriendships)
                {
                    if(prisoner.Id != friendship.ClinkerOneId && prisoner.Id != friendship.ClinkerTwoId)
                    {
                        notYourFriends.Add(prisoner);
                    }
                }
            }

            //find prisoners with simalar interests
            var potentialFriendsList = new List<Clinker>();

            foreach(var prisoner in notYourFriends)
            {
                List<Interest> prisonerInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == prisoner.Id).ToList();
                
                foreach(var interest in prisonerInterest)
                {
                    foreach (var clinkerInterest in userInterest)
                    {
                        if (clinkerInterest.Name == interest.Name)
                        {
                            potentialFriendsList.Add(prisoner);
                            break;
                        }
                    }
                }
            }
            
            return Created($"api/getPotentialFriends", potentialFriendsList);
        }
    }
}