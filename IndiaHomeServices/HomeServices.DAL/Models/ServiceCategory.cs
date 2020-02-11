﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Data.Models
{
    public class CommonLookup
    {
        public int CommonLkpId { get; set; }
        public string CommonLkpType { get; set; }
        public string CommonLkpName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
