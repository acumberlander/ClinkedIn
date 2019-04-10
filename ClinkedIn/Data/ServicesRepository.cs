using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ServicesRepository
    {
        List<Service> _Services = new List<Service>();

        public Service AddServices(string serviceName, int clinker)
        {
            var newService = new Service() { ServiceName = serviceName, ClinkerId = clinker};

            newService.Id = _Services.Count + 1;

            _Services.Add(newService);

            return newService;
        }
    }
}
