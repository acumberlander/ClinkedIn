using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class FriendshipRepository
    {
        static List<Friendship> _friends = new List<Friendship>();

        public static Friendship AddFriendship(int clinkerOneId, int clinkerTwoId)
        {
            var newFriendship = new Friendship() { ClinkerOneId = clinkerOneId, ClinkerTwoId = clinkerTwoId };

            newFriendship.Id = _friends.Count + 1;

            _friends.Add(newFriendship);

            return newFriendship;
        }
    }
}
