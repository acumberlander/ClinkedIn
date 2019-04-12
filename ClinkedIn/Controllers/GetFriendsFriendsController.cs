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
    public class GetFriendsFriendsController : ControllerBase
    {
        //readonly FriendshipRepository _friendshipRepository;

        //public static GetFriendsFriendsController()
        //{
        //    FriendshipRepository _friendshipRepository = new FriendshipRepository();
        //}

        [HttpGet("friendsfriends")]
        public static ActionResult GetFriendsFriends()
        {
            List<Friendship> friendsOfFriends = FriendshipRepository.GetClinkerFriendsFriends();

            return Created($"api/getFriendsFriends", friendsOfFriends);
        }
    }
}