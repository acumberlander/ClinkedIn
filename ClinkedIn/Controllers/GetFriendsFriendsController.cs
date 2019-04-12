using System.Collections.Generic;
using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFriendsFriendsController : ControllerBase
    {
        [HttpGet("friendsfriends")]
        public ActionResult GetFriendsFriends()
        {
            List<Friendship> friendsOfFriends = FriendshipRepository.GetClinkerFriendsFriends();

            return Created($"api/getFriendsFriends", friendsOfFriends);
        }
    }
}