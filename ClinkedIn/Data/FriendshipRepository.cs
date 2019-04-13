using ClinkedIn.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClinkedIn.Data
{
    class FriendshipRepository
    {
        public static List<Friendship> _friends = new List<Friendship>();

        public static Friendship AddFriendship(int clinkerOneId, int clinkerTwoId)
        {
            var newFriendship = new Friendship() { ClinkerOneId = clinkerOneId, ClinkerTwoId = clinkerTwoId };

            newFriendship.Id = _friends.Count + 1;

            _friends.Add(newFriendship);

            return newFriendship;
        }

        //Method to get my friends friends, to be called in the controller
        public HashSet<Clinker> GetMyFriendsFriends(int clinkerId)
        {
            var myFriendships = _friends.Where(x => clinkerId == x.ClinkerOneId || clinkerId == x.ClinkerTwoId).ToList();

            HashSet<int> myFriendsIds = new HashSet<int>();
            HashSet<Clinker> notMyFriends = new HashSet<Clinker>();
            HashSet<Clinker> myFriendsFriends = new HashSet<Clinker>();

            foreach (var friendship in myFriendships)
            {
                if (friendship.ClinkerOneId != clinkerId)
                {
                    myFriendsIds.Add(friendship.ClinkerOneId);
                }
                else myFriendsIds.Add(friendship.ClinkerTwoId);
            }

            var clinkerList = ClinkerRepository._clinkers;

            foreach (var clinker in clinkerList)
            {
                foreach (var friendId in myFriendsIds)
                {
                    if (clinker.Id != friendId)
                    {
                        notMyFriends.Add(clinker);
                    }
                }
            }

            foreach (var friendship in _friends)
            {
                foreach(var friendId in myFriendsIds)
                {
                    //check to see if my friends have a friendship with people who are NOT my friends
                    if ((friendship.ClinkerOneId == friendId && friendship.ClinkerTwoId != clinkerId) || (friendship.ClinkerTwoId == friendId && friendship.ClinkerTwoId != clinkerId))
                    {
                        foreach (var person in notMyFriends)
                        {
                            if((friendship.ClinkerOneId == person.Id && friendship.ClinkerOneId != clinkerId) || (friendship.ClinkerTwoId == person.Id && friendship.ClinkerTwoId != clinkerId))
                            {
                                myFriendsFriends.Add(person);
                            }
                        }
                    }
                }
            }

            return myFriendsFriends;

        }

        //static Friendship friend = new Friendship();

        //public static List<Friendship> clinkerFriendsFriends = _friends.FindAll(x => friend.Id == friend.ClinkerOneId || friend.Id == friend.ClinkerTwoId);

        //public static List<Friendship> GetClinkerFriendsFriends()
        //{
        //    return clinkerFriendsFriends;
        //}
    }
}
