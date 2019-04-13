using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClinkerId { get; set; }

        public Interest(int id, string name, int clinkerId)
        {
            Id = id;
            Name = name;
            ClinkerId = clinkerId;
        }

        public Interest(string name, int clinkerId)
        {
            Name = name;
            ClinkerId = clinkerId;
        }
    }
}
