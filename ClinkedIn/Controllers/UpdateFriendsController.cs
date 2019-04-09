using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateFriendsController : ControllerBase
    {
        [HttpPost("addFriend")]
        public ActionResult AddFriend(AddFriend addRequest, Clinker clinker, Clinker friend)
        {

            var newFriendList = addRequest.AddNewFriend(clinker, friend);
            clinker.Friends = newFriendList;

            return Created($"api/clinkers/{clinker.Id}", clinker);

        }


    }
}