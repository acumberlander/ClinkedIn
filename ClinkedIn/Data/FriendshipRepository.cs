using ClinkedIn.Models;
using System.Collections.Generic;

namespace ClinkedIn.Data
{
    class FriendshipRepository
    {
        static List<Friendship> _friends = new List<Friendship>();

        public static Friendship AddFriendship(int clinkerOneId, int clinkerTwoId)
        {
            var newFriendship = new Friendship() { ClinkerOneId = clinkerOneId, ClinkerTwoId = clinkerTwoId };

            newFriendship.Id = _friends.Count + 1;

            _friends.Add(newFriendship);

            return newFriendship;
        }

        static Friendship friend = new Friendship();
        public static List<Friendship> clinkerFriendsFriends = _friends.FindAll(x => friend.Id == friend.ClinkerOneId || friend.Id == friend.ClinkerTwoId);

        public static List<Friendship> GetClinkerFriendsFriends()
        {
            return clinkerFriendsFriends;
        }
    }
}
