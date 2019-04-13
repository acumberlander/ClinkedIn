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

    }
}
