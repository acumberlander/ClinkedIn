using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class AddFriend
    {
        public List<Clinker> AddNewFriend(Clinker clinker, Clinker friend)
        {
            var friendList = clinker.Friends;
            friendList.Add(friend);

            return friendList;
        }
    }
}
