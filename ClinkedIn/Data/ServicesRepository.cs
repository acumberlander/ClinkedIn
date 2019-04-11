using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class ServicesRepository
    {
        static List<Service> _Services = new List<Service>();

        public static Service AddServices(string serviceName, int clinker)
        {
            var newService = new Service() { ServiceName = serviceName, ClinkerId = clinker};

            newService.Id = _Services.Count + 1;

            _Services.Add(newService);

            return newService;
        }
    }
}
