using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ClinkerRepository
    {
        public static List<Clinker> _clinkers = new List<Clinker>();

        public Clinker AddClinker(string name, string password)
        {
            var newClinker = new Clinker(name, password);

            newClinker.Id = _clinkers.Count + 1;

            _clinkers.Add(newClinker);

            return newClinker;
        }
    }
}
