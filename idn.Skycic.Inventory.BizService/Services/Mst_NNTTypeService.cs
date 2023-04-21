﻿using idn.Skycic.Inventory.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUtils = idn.Skycic.Inventory.Utils;

namespace idn.Skycic.Inventory.BizService.Services
{
    public class Mst_NNTTypeService : ClientServiceBase<Mst_NNTType>
    {
        public static Mst_NNTTypeService Instance
        {
            get
            {
                return GetInstance<Mst_NNTTypeService>();
            }
        }

        public override string ApiControllerName
        {
            get
            {
                return "MstNNTType";
            }
        }

        //public RT_Mst_NNTType WA_Mst_NNTType_Get(RQ_Mst_NNTType objRQ_Mst_NNTType)
        //{
        //    var result = PostData<RT_Mst_NNTType, RQ_Mst_NNTType>("MstNNTType", "WA_Mst_NNTType_Get", new { }, objRQ_Mst_NNTType);
        //    return result;
        //}

        //public RT_Mst_NNTType WA_Mst_NNTType_Create(RQ_Mst_NNTType objRQ_Mst_NNTType)
        //{
        //    var result = PostData<RT_Mst_NNTType, RQ_Mst_NNTType>("MstNNTType", "WA_Mst_NNTType_Create", new { }, objRQ_Mst_NNTType);
        //    return result;
        //}

        //public RT_Mst_NNTType WA_Mst_NNTType_Update(RQ_Mst_NNTType objRQ_Mst_NNTType)
        //{
        //    var result = PostData<RT_Mst_NNTType, RQ_Mst_NNTType>("MstNNTType", "WA_Mst_NNTType_Update", new { }, objRQ_Mst_NNTType);
        //    return result;
        //}

        //public RT_Mst_NNTType WA_Mst_NNTType_Delete(RQ_Mst_NNTType objRQ_Mst_NNTType)
        //{
        //    var result = PostData<RT_Mst_NNTType, RQ_Mst_NNTType>("MstNNTType", "WA_Mst_NNTType_Delete", new { }, objRQ_Mst_NNTType);
        //    return result;
        //}
    }
}
