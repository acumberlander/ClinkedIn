using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.Data
{
    public class DaysLeftInClink
    {
        public string GetDaysLeftInClink(DateTime releaseDate)
        {
            //releaseDate = clinker.ReleaseDate;
            DateTime today = DateTime.Now;
            TimeSpan timeLeftInClink = (releaseDate - today);
            var days = timeLeftInClink.Days.ToString();
            var hours = timeLeftInClink.Hours.ToString();
            var mins = timeLeftInClink.Minutes.ToString();

            var totalTimeLeftInClink = $"{days} days {hours} hours {mins} mins";

            return totalTimeLeftInClink;
        }
    }
}
