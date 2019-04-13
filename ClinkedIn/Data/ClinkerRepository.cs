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
    }
}
