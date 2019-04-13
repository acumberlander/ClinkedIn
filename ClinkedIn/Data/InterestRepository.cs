using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class InterestRepository
    {
        public static List<Interest> _interests = new List<Interest>
        {
            new Interest(1, "Punching", 1),
            new Interest(2, "Sitting", 1),
            new Interest(3, "Paragliding", 2),
            new Interest(4, "Karate", 3),
            new Interest(5, "Machine learning", 4),
            new Interest(6, "Punching", 4),
            new Interest(7, "Sitting", 4),
            new Interest(8, "Punching", 5)
        };

        public static Interest AddInterest(string name, int clinkerId)
        {
            var newInterest = new Interest(name, clinkerId);

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
