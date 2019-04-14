using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Service
    {
        //Properties
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string UpdatedServiceName { get; set; }
        public int ClinkerId { get; set; }
    }
}
