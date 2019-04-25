//using ClinkedIn.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace ClinkedIn.Data
//{
//    class FriendshipRepository
//    {
//        public static List<Friendship> _friends = new List<Friendship>
//        {
//            new Friendship(1, 2),
//            new Friendship(1, 3),
//            new Friendship(2, 3),
//            new Friendship(2, 4),
//            new Friendship(2, 5)
//        };

//        public static Friendship AddFriendship(int clinkerOneId, int clinkerTwoId)
//        {
//            var newFriendship = new Friendship(clinkerOneId, clinkerTwoId);

//            newFriendship.Id = _friends.Count + 1;

//            _friends.Add(newFriendship);

//            return newFriendship;
//        }

//        //Method to get my friends friends, to be called in the controller
//        public HashSet<Clinker> GetMyFriendsFriends(int clinkerId)
//        {
//            var myFriendships = _friends.Where(x => clinkerId == x.ClinkerOneId || clinkerId == x.ClinkerTwoId).ToList();

//            HashSet<int> myFriendsIds = new HashSet<int>();
//            HashSet<Clinker> notMyFriends = new HashSet<Clinker>();
//            HashSet<Clinker> myFriendsFriends = new HashSet<Clinker>();
//            HashSet<Clinker> possibleFriends = new HashSet<Clinker>();

//            foreach (var friendship in myFriendships)
//            {
//                if (friendship.ClinkerOneId != clinkerId)
//                {
//                    myFriendsIds.Add(friendship.ClinkerOneId);
//                }
//                else myFriendsIds.Add(friendship.ClinkerTwoId);
//            }

//            ////var clinkerList = ClinkerRepository._clinkers;

//            foreach (var clinker in clinkerList)
//            {
//                foreach (var friendId in myFriendsIds)
//                {
//                    if (clinker.Id != friendId)
//                    {
//                        notMyFriends.Add(clinker);
//                    }
//                }
//            }

//            foreach (var friendship in _friends)
//            {
//                foreach(var friendId in myFriendsIds)
//                {
//                    //check to see if my friends have a friendship with people who are NOT my friends
//                    if ((friendship.ClinkerOneId == friendId && friendship.ClinkerTwoId != clinkerId) || (friendship.ClinkerTwoId == friendId && friendship.ClinkerTwoId != clinkerId))
//                    {
//                        foreach (var person in notMyFriends)
//                        {
//                            if((friendship.ClinkerOneId == person.Id && friendship.ClinkerOneId != clinkerId) || (friendship.ClinkerTwoId == person.Id && friendship.ClinkerTwoId != clinkerId))
//                            {
//                                myFriendsFriends.Add(person);
//                            }
//                        }
//                    }
//                }
//            }

//            foreach (var person in myFriendsFriends)
//            {
//                if (!myFriendsIds.Any(s => s == person.Id))
//                {
//                    possibleFriends.Add(person);
//                }
//            }

//            return possibleFriends;

//        }

//    }
//}
