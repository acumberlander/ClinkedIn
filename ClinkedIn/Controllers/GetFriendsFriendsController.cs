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
        readonly FriendshipRepository _friendshipRepository;

        public GetFriendsFriendsController()
        {
            _friendshipRepository = new FriendshipRepository();
        }

        [HttpGet("{clinkerId}/friendsfriends")]
        public ActionResult GetFriendsFriends(int clinkerId)
        {

            HashSet<Clinker> friendshipList = _friendshipRepository.GetMyFriendsFriends(clinkerId);

            return Created($"api/getFriendsFriends", friendshipList);
        }
    }
}
