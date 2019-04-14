using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class InterestRepository
    {
        public static List<Interest> _interests = new List<Interest>();

        public static Interest AddInterest(string name, int clinkerId)
        {
            var newInterest = new Interest() { Name = name, ClinkerId = clinkerId };

            newInterest.Id = _interests.Count + 1;

            _interests.Add(newInterest);

            return newInterest;
        }

        public static List<Interest> GetAllInterests()
        {
            return _interests;
        }

        public static List<Interest> DeleteInterest(int interestId)
        {
            var interestToDelete = _interests.First(interest => interest.Id == interestId);

            _interests.Remove(interestToDelete);

            return _interests;
        }

        public static Interest UpdateInterest(Interest newInterest)
        {
            var interestObject = _interests.First(interest => interest.Id == newInterest.Id);

            interestObject.ClinkerId = newInterest.ClinkerId;
            interestObject.Name = newInterest.Name;

            return interestObject;

        }

    }
}
