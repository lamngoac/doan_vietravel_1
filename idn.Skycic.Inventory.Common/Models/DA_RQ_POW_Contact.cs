﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.Skycic.Inventory.Common.Models
{
    public class DA_RQ_POW_Contact : WARQBase
    {
        public string Rt_Cols_POW_Contact { get; set; }

        public DA_POW_Contact POW_Contact { get; set; }
    }
}
