using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.Data
{
    public class DaysLeftInClink
    {
        public double GetDaysLeftInClink(DateTime releaseDate)
        {
            //releaseDate = clinker.ReleaseDate;
            DateTime today = DateTime.Now;
            double daysLeftInClink = (releaseDate - today).TotalDays;

            return daysLeftInClink;
        }
    }
}
