using ClinkedIn.Models;
using System;
using System.Collections.Generic;

namespace ClinkedIn.Data
{
    public class ClinkerRepository
    {
        public static List<Clinker> _clinkers = new List<Clinker>();

        public Clinker AddClinker(string name, string password, DateTime releaseDate)
        {
            var newClinker = new Clinker(name, password, releaseDate);

            newClinker.Id = _clinkers.Count + 1;

            _clinkers.Add(newClinker);

            return newClinker;
        }

        //Method to get the clinkers, to be called in the controller
        public List<Clinker> GetAllClinkers()
        {
            return _clinkers;
        }

        public static HashSet<Clinker> FindPotentialFriends(int clinkerId)
        {
            //filter _interest list by clinkerId.
            HashSet<Interest> userInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == clinkerId).ToHashSet();

            //separate users who are not your friends.
            HashSet<Friendship> yourFriendships = FriendshipRepository._friends.Where(friendship => friendship.ClinkerOneId == clinkerId || friendship.ClinkerTwoId == clinkerId).ToHashSet();
            HashSet<Clinker> notYourFriends = new HashSet<Clinker>();

            foreach (var prisoner in _clinkers)
            {
                foreach (var friendship in yourFriendships)
                {
                    if (prisoner.Id != friendship.ClinkerOneId && prisoner.Id != friendship.ClinkerTwoId)
                    {
                        notYourFriends.Add(prisoner);
                    }
                }
            }

            //find prisoners with simalar interests
            var potentialFriendsList = new HashSet<Clinker>();

            foreach (var prisoner in notYourFriends)
            {
                List<Interest> prisonerInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == prisoner.Id).ToList();

                foreach (var interest in prisonerInterest)
                {
                    foreach (var clinkerInterest in userInterest)
                    {
                        if (clinkerInterest.Name == interest.Name)
                        {
                            potentialFriendsList.Add(prisoner);
                            break;
                        }
                    }
                }
            }

            return potentialFriendsList;
        }
    }
}
