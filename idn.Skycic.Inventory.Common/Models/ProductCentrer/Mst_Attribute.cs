﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.Skycic.Inventory.Common.Models.ProductCentrer
{
	public class Mst_Attribute
	{
		public object AttributeCode { get; set; }
		public object NetworkID { get; set; }
		public object AttributeName { get; set; }
		//public object Remark { get; set; }
		public object FlagActive { get; set; }
		public object LogLUDTimeUTC { get; set; }
		public object LogLUBy { get; set; }
        public object SolutionCode { get; set; }
        public object FunctionActionType { get; set; }
    }
}
