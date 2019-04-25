//using ClinkedIn.Data;
//using ClinkedIn.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ClinkedIn.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CreateFriendshipController : ControllerBase
//    {

//        [HttpPost("addfriend")]
//        public ActionResult CreateFriendship(Friendship friendship)
//        {
//            var newFriendship = FriendshipRepository.AddFriendship(friendship.ClinkerOneId, friendship.ClinkerTwoId);

//            return Created($"api/createFriendship/{newFriendship.Id}", newFriendship);
//        }
//    }
//}
