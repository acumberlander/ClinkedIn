﻿using ClinkedIn.Models;
using System.Collections.Generic;

namespace ClinkedIn.Data
{
    public class ClinkerRepository
    {
        static List<Clinker> _clinkers = new List<Clinker>();

        public Clinker AddClinker(string name, string password)
        {
            var newClinker = new Clinker(name, password);

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
