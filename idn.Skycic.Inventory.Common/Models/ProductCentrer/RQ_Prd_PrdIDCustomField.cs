﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.Skycic.Inventory.Common.Models
{
    public class RQ_Prd_PrdIDCustomField : WARQBase
    {
        public string Rt_Cols_Prd_PrdIDCustomField { get; set; }

        public Prd_PrdIDCustomField Prd_PrdIDCustomField { get; set; }
    }
}
