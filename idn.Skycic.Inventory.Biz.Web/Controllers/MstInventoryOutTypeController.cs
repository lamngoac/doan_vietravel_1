﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using CmUtils = CommonUtils;
using TUtils = idn.Skycic.Inventory.Utils;
using TJson = Newtonsoft.Json;
using idn.Skycic.Inventory.Common.Models;

namespace idn.Skycic.Inventory.Biz.Web.Controllers
{
    public class MstInventoryOutTypeController : ApiControllerBase
	{
		[AcceptVerbs("POST")]
		public ServiceResult<RT_Mst_InventoryOutType> WA_Mst_InventoryOutType_Get(RQ_Mst_InventoryOutType objRQ_Mst_InventoryOutType)
		{
			#region // Temp:
			if (_mdsInitError != null) return ProcessMyDSInitError<RT_Mst_InventoryOutType>();
			DataSet mdsReturn = CmUtils.CMyDataSet.NewMyDataSet(objRQ_Mst_InventoryOutType.Tid);
			RT_Mst_InventoryOutType objRT_Mst_InventoryOutType = null;
			DateTime dtimeSys = DateTime.Now;
			string strControllerName = "WA_Mst_InventoryOutType_Get";
			string strErrorCodeDefault = "WA_Mst_InventoryOutType_Get";

			ArrayList alParamsCoupleError = new ArrayList();
			alParamsCoupleError.AddRange(new object[] {
				"strControllerName", strControllerName
				, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
				////
				//, "_biz._cf.nvcParams", TJson.JsonConvert.SerializeObject(_biz._cf.nvcParams)
				//, "_biz.RQ_Mst_Dealer", TJson.JsonConvert.SerializeObject(objRQ_Mst_Dealer)
				});
			#endregion

			try
			{
				#region // CheckGatewayAuthentication:
				TUtils.CConnectionManager.CheckGatewayAuthentication(
					_biz._cf.nvcParams // nvcParams
					, ref alParamsCoupleError // alParamsCoupleError
					, objRQ_Mst_InventoryOutType.GwUserCode // strGwUserCode
					, objRQ_Mst_InventoryOutType.GwPassword // strGwPassword
					);
				#endregion

				#region // Process:
				//
				//mdsReturn = _biz.WAS_Mst_InventoryOutType_Get(
				//	ref alParamsCoupleError // alParamsCoupleError
				//	, objRQ_Mst_InventoryOutType // RQ_Mst_InventoryOutType
				//						  ////
				//	, out objRT_Mst_InventoryOutType // RT_Mst_InventoryOutType
				//	);

				if (CmUtils.CMyDataSet.HasError(mdsReturn))
				{
					throw CmUtils.CMyException.Raise(
						(string)CmUtils.CMyDataSet.GetErrorCode(mdsReturn)
						, null
						, null
						);
				}
				#endregion

				// Return Good:
				objRT_Mst_InventoryOutType.c_K_DT_Sys = TUtils.CMyDataList.CProcessMyDS(mdsReturn);
				return Success<RT_Mst_InventoryOutType>(objRT_Mst_InventoryOutType);
			}
			catch (Exception ex)
			{
				#region // Catch of try:
				////
				TUtils.CProcessExc.Process(
					ref mdsReturn // mdsFinal
					, ex // exc
					, strErrorCodeDefault // strErrorCode
					, alParamsCoupleError.ToArray() // arrobjErrorParams
					);

				// Return Bad:
				if (objRT_Mst_InventoryOutType == null) objRT_Mst_InventoryOutType = new RT_Mst_InventoryOutType();
				objRT_Mst_InventoryOutType.c_K_DT_Sys = TUtils.CMyDataList.CProcessMyDS(mdsReturn);
				return Error<RT_Mst_InventoryOutType>(ex, objRT_Mst_InventoryOutType);
				#endregion
			}
		}

	}
}
