﻿using System;
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
    }
}
