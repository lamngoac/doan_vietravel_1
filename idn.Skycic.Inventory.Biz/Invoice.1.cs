﻿using idn.Skycic.Inventory.BizService.Services;
using idn.Skycic.Inventory.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Xml.Linq;

using CmUtils = CommonUtils;
using TConst = idn.Skycic.Inventory.Constants;
using TDALUtils = EzDAL.Utils;
using TError = idn.Skycic.Inventory.Errors;
using TJson = Newtonsoft.Json;
using TUtils = idn.Skycic.Inventory.Utils;

namespace idn.Skycic.Inventory.Biz
{
	public partial class BizidNInventory
	{
		public DataSet WAS_Invoice_Invoice_Calc(
		   ref ArrayList alParamsCoupleError
		   , RQ_Invoice_Invoice objRQ_Invoice_Invoice
		   ////
		   , out RT_Invoice_Invoice objRT_Invoice_Invoice
		   )
		{
			#region // Temp:
			string strTid = objRQ_Invoice_Invoice.Tid;
			objRT_Invoice_Invoice = new RT_Invoice_Invoice();
			DataSet mdsResult = CmUtils.CMyDataSet.NewMyDataSet(strTid);
			DateTime dtimeSys = DateTime.UtcNow;
			//DataSet mdsExec = null;
			//DataSet mdsFinal = CmUtils.CMyDataSet.NewMyDataSet(objRQ_Invoice_Invoice.Tid);
			//int nTidSeq = 0;
			//bool bNeedTransaction = true;
			string strFunctionName = "WAS_Invoice_Invoice_Calc";
			string strErrorCodeDefault = TError.ErridnInventory.WAS_Invoice_Invoice_Calc;
			alParamsCoupleError.AddRange(new object[]{
				"strFunctionName", strFunctionName
				, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
				////
                , "FlagIsDelete", objRQ_Invoice_Invoice.FlagIsDelete
				, "Lst_Invoice_Invoice", TJson.JsonConvert.SerializeObject(objRQ_Invoice_Invoice.Lst_Invoice_Invoice)
				, "Lst_Invoice_InvoiceDtl", TJson.JsonConvert.SerializeObject(objRQ_Invoice_Invoice.Lst_Invoice_InvoiceDtl)
				});
			#endregion

			try
			{
				#region // Init:
				#endregion

				#region // Refine and Check Input:
				List<Invoice_Invoice> lst_Invoice_Invoice = new List<Invoice_Invoice>();
				#endregion

				#region // Refine and Check Input:
				////
				List<Invoice_InvoiceCalc> lst_Invoice_InvoiceCalc = new List<Invoice_InvoiceCalc>();
				////
				DataSet dsData = new DataSet();
				{
					////
					DataTable dt_Invoice_Invoice = TUtils.DataTableCmUtils.ToDataTable<Invoice_Invoice>(objRQ_Invoice_Invoice.Lst_Invoice_Invoice, "Invoice_Invoice");
					dsData.Tables.Add(dt_Invoice_Invoice);
					////
					DataTable dt_Invoice_InvoiceDtl = TUtils.DataTableCmUtils.ToDataTable<Invoice_InvoiceDtl>(objRQ_Invoice_Invoice.Lst_Invoice_InvoiceDtl, "Invoice_InvoiceDtl");
					dsData.Tables.Add(dt_Invoice_InvoiceDtl);
					////

				}
				#endregion

				#region // Invoice_Invoice_Calc:
				mdsResult = Invoice_Invoice_Calc(
					objRQ_Invoice_Invoice.Tid // strTid
					, objRQ_Invoice_Invoice.GwUserCode // strGwUserCode
					, objRQ_Invoice_Invoice.GwPassword // strGwPassword
					, objRQ_Invoice_Invoice.WAUserCode // strUserCode
					, objRQ_Invoice_Invoice.WAUserPassword // strUserPassword
					, ref alParamsCoupleError // alParamsCoupleError
														 ////
					, dsData // dsData
					);
				#endregion

				#region // GetData:

				if (!CmUtils.CMyDataSet.HasError(mdsResult))
				{
					////
					DataTable dt_Invoice_InvoiceCalc = mdsResult.Tables["Invoice_InvoiceCalc"].Copy();
					lst_Invoice_InvoiceCalc = TUtils.DataTableCmUtils.ToListof<Invoice_InvoiceCalc>(dt_Invoice_InvoiceCalc);
					objRT_Invoice_Invoice.Lst_Invoice_InvoiceCalc = lst_Invoice_InvoiceCalc;
					/////
				}
				#endregion

				// Return Good:
				return mdsResult;
			}
			catch (Exception exc)
			{
				#region // Catch of try:
				// Return Bad:
				return TUtils.CProcessExc.Process(
					ref mdsResult
					, exc
					, strErrorCodeDefault
					, alParamsCoupleError.ToArray()
					);
				#endregion
			}
			finally
			{
				#region // Finally of try:
				// Write ReturnLog:
				//_cf.ProcessBizReturn(
				//	ref mdsResult // mdsFinal
				//	, strTid // strTid
				//	, strFunctionName // strFunctionName
				//	);
				#endregion
			}
		}

		public DataSet Invoice_Invoice_Calc(
			string strTid
			, string strGwUserCode
			, string strGwPassword
			, string strWAUserCode
			, string strWAUserPassword
			, ref ArrayList alParamsCoupleError
			////
			, DataSet dsData
			)
		{
			#region // Temp:
			DataSet mdsFinal = CmUtils.CMyDataSet.NewMyDataSet(strTid);
			DataSet mdsFinalCalc = CmUtils.CMyDataSet.NewMyDataSet(strTid);
			//int nTidSeq = 0;
			DateTime dtimeSys = DateTime.UtcNow;
			string strFunctionName = "Invoice_Invoice_Calc";
			string strErrorCodeDefault = TError.ErridnInventory.Invoice_Invoice_Calc;
			alParamsCoupleError.AddRange(new object[]{
					"strFunctionName", strFunctionName
					, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
			        ////
                    });
			#endregion

			try
			{
				#region // Init:
				//_cf.db.LogUserId = _cf.sinf.strUserCode;
				//_cf.db.BeginTransaction();

				// Write RequestLog:
				_cf.ProcessBizReq_OutSide(
					strTid // strTid
					, strGwUserCode // strGwUserCode
					, strGwPassword // strGwPassword
					, strWAUserCode // objUserCode
					, strFunctionName // strFunctionName
					, alParamsCoupleError // alParamsCoupleError
					);

				// Sys_User_CheckAuthentication:
				//Sys_User_CheckAuthentication(
				//	ref alParamsCoupleError
				//	, strWAUserCode
				//	, strWAUserPassword
				//	);

				// Check Access/Deny:
				//Sys_Access_CheckDenyV30(
				//	ref alParamsCoupleError
				//	, strWAUserCode
				//	, strFunctionName
				//	);
				#endregion

				#region // Invoice_Invoice_SaveX:
				////
				DataTable dtResult = new DataTable("Invoice_InvoiceCalc");
				dtResult.Columns.Add("InvoiceCode", typeof(object));
				dtResult.Columns.Add("ErrorCode", typeof(object));
				dtResult.Columns.Add("ErrorDetail", typeof(object));
				//DataSet dsGetData = null;
				{
					////

					DataTable dt_Invoice_Invoice = dsData.Tables["Invoice_Invoice"];
					DataTable dt_Invoice_InvoiceDtl = dsData.Tables["Invoice_InvoiceDtl"];

					for (int nScan = 0; nScan < dt_Invoice_Invoice.Rows.Count; nScan++)
					{
						////
						DataRow drScan = dt_Invoice_Invoice.Rows[nScan];
						string strInvoiceCode = TUtils.CUtils.StdParam(drScan["InvoiceCode"]);
						DataRow drResult = dtResult.NewRow();
						drResult["InvoiceCode"] = strInvoiceCode;

						////
						try
						{
							////
							string strWhere = CmUtils.StringUtils.Replace("InvoiceCode = '@strInvoiceCode'", "@strInvoiceCode", strInvoiceCode);
							DataRow[] arrayDataRowDtl = dt_Invoice_InvoiceDtl.Select(strWhere);
							DataTable dtCalc_Invoice_Invoice = CmUtils.DataTableUtils.CopySchema(dt_Invoice_Invoice);
							dtCalc_Invoice_Invoice.TableName = "Invoice_Invoice";
							dtCalc_Invoice_Invoice.ImportRow(drScan);

							////
							DataTable dtCalc_Invoice_InvoiceDtl = CmUtils.DataTableUtils.CopySchema(dt_Invoice_InvoiceDtl);
							dtCalc_Invoice_InvoiceDtl.TableName = "Invoice_InvoiceDtl";

							foreach (var item in arrayDataRowDtl)
							{
								////
								dtCalc_Invoice_InvoiceDtl.ImportRow(item);
							}


							////
							DataSet dsDataCalc = new DataSet();
							dsDataCalc.Tables.Add(dtCalc_Invoice_Invoice);
							dsDataCalc.Tables.Add(dtCalc_Invoice_InvoiceDtl);

							////
							_cf.db.BeginTransaction();

							Invoice_Invoice_CalcX(
								strTid // strTid
								, strGwUserCode // strGwUserCode
								, strGwPassword // strGwPassword
								, strWAUserCode // strWAUserCode
								, strWAUserPassword // strWAUserPassword
								, ref alParamsCoupleError // alParamsCoupleError
								, dtimeSys // dtimeSys
										   ////
										   ////
								, dsDataCalc // dsData
								);

							drResult["ErrorCode"] = "0";
							drResult["ErrorDetail"] = null;

							// Return Good:
							TDALUtils.DBUtils.RollbackSafety(_cf.db);
						}
						catch (Exception exc)
						{
							// Rollback:
							TDALUtils.DBUtils.RollbackSafety(_cf.db);

							DataSet dsResult = TUtils.CProcessExc.Process(
								ref mdsFinalCalc
								, exc
								, strErrorCodeDefault
								, alParamsCoupleError.ToArray()
								);

							TUtils.ServiceException ex = TUtils.CUtils.BizGenServiceException(dsResult); 

							drResult["ErrorCode"] = ex.ErrorCode;
							drResult["ErrorDetail"] = ex.ErrorDetail;
						}
						////
						dtResult.Rows.Add(drResult);
						continue;
					}
				}
				////
				CmUtils.DataUtils.MoveDataTable(ref mdsFinal, ref dtResult);
				#endregion

				
				mdsFinal.AcceptChanges();
				return mdsFinal;
			}
			catch (Exception exc)
			{
				#region // Catch of try:
				//// Rollback:
				//TDALUtils.DBUtils.RollbackSafety(_cf.db);

				// Return Bad:
				return TUtils.CProcessExc.Process(
					ref mdsFinal
					, exc
					, strErrorCodeDefault
					, alParamsCoupleError.ToArray()
					);
				#endregion
			}
			finally
			{
				#region // Finally of try:
				// Rollback and Release resources:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);
				TDALUtils.DBUtils.ReleaseAllSemaphore(_cf.db_Sys, true);

				// Write ReturnLog:
				_cf.ProcessBizReturn_OutSide(
					ref mdsFinal // mdsFinal
					, strTid // strTid
					, strGwUserCode // strGwUserCode
					, strGwPassword // strGwPassword
					, strWAUserCode // objUserCode
					, strFunctionName // strFunctionName
					);
				#endregion
			}
		}

		private void Invoice_Invoice_CalcX(
			string strTid
			, string strGwUserCode
			, string strGwPassword
			, string strWAUserCode
			, string strWAUserPassword
			, ref ArrayList alParamsCoupleError
			, DateTime dtimeSys
			////
			, DataSet dsData
			)
		{
			#region // Temp:
			//int nTidSeq = 0;
			//bool bMyDebugSql = false;
			string strFunctionName = "Invoice_Invoice_CalcX";
			//string strErrorCodeDefault = TError.ErridnInventory.Invoice_Invoice_SaveAllX;
			alParamsCoupleError.AddRange(new object[]{
				"strFunctionName", strFunctionName
				, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
                ////
				////
                });
			//ArrayList alPCErrEx = new ArrayList();
			////
			Hashtable htParamsSql = new Hashtable();
			#endregion

			#region // Convert Input:
			//DataSet dsData = TUtils.CUtils.StdDS(arrobjDSData);
			//if (dsData == null) dsData = new DataSet("dsData");
			//dsData.AcceptChanges();
			alParamsCoupleError.AddRange(new object[]{
				"Check.dsData", CmUtils.XmlUtils.DataSet2XmlSimple(dsData)
				});
			#endregion

			#region // Refine and Check Input:
			////
			DataRow drAbilityOfUser = Sys_User_GetAbilityViewOfUser(strWAUserCode);
			////
			object objFlagIsDelete = TConst.Flag.Inactive;

			bool bIsDelete = CmUtils.StringUtils.StringEqual(objFlagIsDelete, TConst.Flag.Yes);
			////
			string strMST = TUtils.CUtils.StdParam(drAbilityOfUser["MNNTMST"]);
			#endregion

			#region // Refine and Check Input Invoice_Invoice:
			////
			DataTable dtInput_Invoice_Invoice = null;
			{
				////
				string strTableCheck = "Invoice_Invoice";
				////
				if (!dsData.Tables.Contains(strTableCheck))
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.TableName", strTableCheck
						});
					throw CmUtils.CMyException.Raise(
						TError.ErridnInventory.Invoice_Invoice_Calc_Input_InvoiceTblNotFound
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				dtInput_Invoice_Invoice = dsData.Tables[strTableCheck];
				////
				if (dtInput_Invoice_Invoice.Rows.Count < 1)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.TableName", strTableCheck
						});
					throw CmUtils.CMyException.Raise(
						TError.ErridnInventory.Invoice_Invoice_Calc_Input_InvoiceTblInvalid
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				////
				TUtils.CUtils.StdDataInTable(
					dtInput_Invoice_Invoice // dtData
					, "StdParam", "InvoiceCode" // arrstrCouple
					, "StdParam", "MST" // arrstrCouple
					, "StdParam", "NetworkID" // arrstrCouple
					, "StdParam", "RefNo" // arrstrCouple
					, "StdParam", "FormNo" // arrstrCouple
					, "StdParam", "Sign" // arrstrCouple
					, "StdParam", "SourceInvoiceCode" // arrstrCouple
					, "StdParam", "InvoiceAdjType" // arrstrCouple
					, "StdParam", "PaymentMethodCode" // arrstrCouple
					, "StdParam", "InvoiceType2" // arrstrCouple
					, "StdParam", "CustomerNNTCode" // arrstrCouple
					, "", "CustomerNNTName" // arrstrCouple
					, "", "CustomerNNTAddress" // arrstrCouple
					, "", "CustomerNNTPhone" // arrstrCouple
					, "", "CustomerNNTBankName" // arrstrCouple
					, "", "CustomerNNTEmail" // arrstrCouple
					, "", "CustomerNNTAccNo" // arrstrCouple
					, "", "CustomerNNTBuyerName" // arrstrCouple
					, "StdParam", "CustomerMST" // arrstrCouple
					, "StdParam", "TInvoiceCode" // arrstrCouple
					, "StdParam", "InvoiceNo" // arrstrCouple
					, "", "InvoiceDateUTC" // arrstrCouple
					, "StdParam", "EmailSend" // arrstrCouple
					, "", "InvoiceFileSpec" // arrstrCouple
					, "", "InvoiceFilePath" // arrstrCouple
					, "", "InvoicePDFFilePath" // arrstrCouple
					, "float", "TotalValInvoice" // arrstrCouple
					, "float", "TotalValVAT" // arrstrCouple
					, "float", "TotalValPmt" // arrstrCouple
					, "", "AttachedDelFilePath" // arrstrCouple
					, "", "DeleteReason" // arrstrCouple
					, "StdParam", "InvoiceVerifyCQTCode" // arrstrCouple
					, "StdParam", "CurrencyCode" // arrstrCouple
					, "float", "CurrencyRate" // arrstrCouple
					, "float", "ValGoodsNotTaxable" // arrstrCouple
					, "float", "ValGoodsNotChargeTax" // arrstrCouple
					, "float", "ValGoodsVAT5" // arrstrCouple
					, "float", "ValVAT5" // arrstrCouple
					, "float", "ValGoodsVAT10" // arrstrCouple
					, "float", "ValVAT10" // arrstrCouple
					, "", "NNTFullName" // arrstrCouple
					, "", "NNTFullAdress" // arrstrCouple
					, "", "NNTPhone" // arrstrCouple
					, "", "NNTFax" // arrstrCouple
					, "", "NNTEmail" // arrstrCouple
					, "", "NNTWebsite" // arrstrCouple
					, "", "NNTAccNo" // arrstrCouple
					, "", "NNTBankName" // arrstrCouple
					, "", "Remark" // arrstrCouple
					, "", "InvoiceCF1" // arrstrCouple
					, "", "InvoiceCF2" // arrstrCouple
					, "", "InvoiceCF3" // arrstrCouple
					, "", "InvoiceCF4" // arrstrCouple
					, "", "InvoiceCF5" // arrstrCouple
					, "", "InvoiceCF6" // arrstrCouple
					, "", "InvoiceCF7" // arrstrCouple
					, "", "InvoiceCF8" // arrstrCouple
					, "", "InvoiceCF9" // arrstrCouple
					, "", "InvoiceCF10" // arrstrCouple
					, "", "FlagConfirm" // arrstrCouple
					, "", "FlagCheckCustomer" // arrstrCouple
					);
				////
				//TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "EmailSend", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "CreateDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "CreateBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "InvoiceNoDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "InvoiceNoBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "SignDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "SignBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "ApprDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "ApprBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "CancelDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "CancelBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "SendEmailDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "SendEmailBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "IssuedDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "IssuedBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "DeleteDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "DeleteBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "ChangeDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "ChangeBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "LUDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "LUBy", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "FlagChange", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "FlagPushOutSite", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "InvoiceStatus", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "LogLUDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_Invoice, "LogLUBy", typeof(object));
			}
			#endregion

			#region //// SaveTemp Invoice_Invoice For Check:
			//if (!bIsDelete)
			{
				// Upload:
				TUtils.CUtils.MyBuildDBDT_Common(
					_cf.db // db
					, "#input_Invoice_Invoice" // strTableName
					, new object[] {
							"InvoiceCode", TConst.BizMix.Default_DBColType
							, "MST", TConst.BizMix.Default_DBColType
							, "NetworkID", TConst.BizMix.Default_DBColType
							, "RefNo", TConst.BizMix.Default_DBColType
							, "FormNo", TConst.BizMix.Default_DBColType
							, "Sign", TConst.BizMix.Default_DBColType
							, "SourceInvoiceCode", TConst.BizMix.Default_DBColType
							, "InvoiceAdjType", TConst.BizMix.Default_DBColType
							, "PaymentMethodCode", TConst.BizMix.Default_DBColType
							, "InvoiceType2", TConst.BizMix.Default_DBColType
							, "CustomerNNTCode", TConst.BizMix.Default_DBColType
							, "CustomerNNTName", TConst.BizMix.Default_DBColType
							, "CustomerNNTAddress", TConst.BizMix.Default_DBColType
							, "CustomerNNTPhone", TConst.BizMix.Default_DBColType
							, "CustomerNNTBankName", TConst.BizMix.Default_DBColType
							, "CustomerNNTEmail", TConst.BizMix.Default_DBColType
							, "CustomerNNTAccNo", TConst.BizMix.Default_DBColType
							, "CustomerNNTBuyerName", TConst.BizMix.Default_DBColType
							, "CustomerMST", TConst.BizMix.Default_DBColType
							, "TInvoiceCode", TConst.BizMix.Default_DBColType
							, "InvoiceNo", TConst.BizMix.Default_DBColType
							, "InvoiceDateUTC", TConst.BizMix.Default_DBColType
							, "EmailSend", TConst.BizMix.Default_DBColType
							, "InvoiceFileSpec", TConst.BizMix.Default_DBColType
							, "InvoiceFilePath", TConst.BizMix.Default_DBColType
							, "InvoicePDFFilePath", TConst.BizMix.Default_DBColType
							, "TotalValInvoice", "float"
							, "TotalValVAT", "float"
							, "TotalValPmt", "float"
							, "CreateDTimeUTC", TConst.BizMix.Default_DBColType
							, "CreateBy", TConst.BizMix.Default_DBColType
							, "InvoiceNoDTimeUTC", TConst.BizMix.Default_DBColType
							, "InvoiceNoBy", TConst.BizMix.Default_DBColType
							, "SignDTimeUTC", TConst.BizMix.Default_DBColType
							, "SignBy", TConst.BizMix.Default_DBColType
							, "ApprDTimeUTC", TConst.BizMix.Default_DBColType
							, "ApprBy", TConst.BizMix.Default_DBColType
							, "CancelDTimeUTC", TConst.BizMix.Default_DBColType
							, "CancelBy", TConst.BizMix.Default_DBColType
							, "SendEmailDTimeUTC", TConst.BizMix.Default_DBColType
							, "SendEmailBy", TConst.BizMix.Default_DBColType
							, "IssuedDTimeUTC", TConst.BizMix.Default_DBColType
							, "IssuedBy", TConst.BizMix.Default_DBColType
							, "AttachedDelFilePath", TConst.BizMix.Default_DBColType
							, "DeleteReason", TConst.BizMix.Default_DBColType
							, "DeleteDTimeUTC", TConst.BizMix.Default_DBColType
							, "DeleteBy", TConst.BizMix.Default_DBColType
							, "ChangeDTimeUTC", TConst.BizMix.Default_DBColType
							, "ChangeBy", TConst.BizMix.Default_DBColType
							, "InvoiceVerifyCQTCode", TConst.BizMix.Default_DBColType
							, "CurrencyCode", TConst.BizMix.Default_DBColType
							, "CurrencyRate", TConst.BizMix.Default_DBColType
							, "ValGoodsNotTaxable", "float"
							, "ValGoodsNotChargeTax", "float"
							, "ValGoodsVAT5", "float"
							, "ValVAT5", "float"
							, "ValGoodsVAT10", "float"
							, "ValVAT10", "float"
							, "NNTFullName", TConst.BizMix.Default_DBColType
							, "NNTFullAdress", TConst.BizMix.Default_DBColType
							, "NNTPhone", TConst.BizMix.Default_DBColType
							, "NNTFax", TConst.BizMix.Default_DBColType
							, "NNTEmail", TConst.BizMix.Default_DBColType
							, "NNTWebsite", TConst.BizMix.Default_DBColType
							, "NNTAccNo", TConst.BizMix.Default_DBColType
							, "NNTBankName", TConst.BizMix.Default_DBColType
							, "LUDTimeUTC", TConst.BizMix.Default_DBColType
							, "LUBy", TConst.BizMix.Default_DBColType
							, "Remark", TConst.BizMix.Default_DBColType
							, "InvoiceCF1", TConst.BizMix.Default_DBColType
							, "InvoiceCF2", TConst.BizMix.Default_DBColType
							, "InvoiceCF3", TConst.BizMix.Default_DBColType
							, "InvoiceCF4", TConst.BizMix.Default_DBColType
							, "InvoiceCF5", TConst.BizMix.Default_DBColType
							, "InvoiceCF6", TConst.BizMix.Default_DBColType
							, "InvoiceCF7", TConst.BizMix.Default_DBColType
							, "InvoiceCF8", TConst.BizMix.Default_DBColType
							, "InvoiceCF9", TConst.BizMix.Default_DBColType
							, "InvoiceCF10", TConst.BizMix.Default_DBColType
							, "FlagConfirm", TConst.BizMix.Default_DBColType
							, "FlagCheckCustomer", TConst.BizMix.Default_DBColType
							, "FlagChange", TConst.BizMix.Default_DBColType
							, "FlagPushOutSite", TConst.BizMix.Default_DBColType
							, "FlagDeleteOutSite", TConst.BizMix.Default_DBColType
							, "InvoiceStatus", TConst.BizMix.Default_DBColType
							, "LogLUDTimeUTC", TConst.BizMix.Default_DBColType
							, "LogLUBy", TConst.BizMix.Default_DBColType
						} // arrSingleStructure
					, dtInput_Invoice_Invoice // dtData
				);
			}
			#endregion

			#region /// Refine and check Input Invoice_Invoice:
			{
				#region ----// Check InvalidInvoiceCode:
				{
					string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
							--- Check:
							select distinct 
								t.InvoiceCode
							from #input_Invoice_Invoice t --//[mylock]
							where(1=1)
								and (t.InvoiceCode is null or LTRIM(RTRIM(t.InvoiceCode)) = '')
							;
						");
					DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
						strSql_CheckInvalidInvoiceCode
						).Tables[0];
					/////
					if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.ErrConditionalRaise", "(t.InvoiceCode is null or LTRIM(RTRIM(t.InvoiceCode)) = '')"
							, "Check.NumberRows", dt_CheckInvalidInvoiceCode.Rows.Count
							});
						throw CmUtils.CMyException.Raise(
							TError.ErridnInventory.Invoice_Invoice_Calc_InvalidInvoiceCode
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					//
				}
				#endregion

				#region ----// Check InvalidInvoiceStatus:
				{
					string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
							--- #tbl_Invoice_Invoice_ForSTUFF:
							select distinct 
								t.InvoiceCode
							into #tbl_Invoice_Invoice_ForSTUFF
							from #input_Invoice_Invoice t --//[mylock]
								inner join Invoice_Invoice f --//[mylock]
									on t.InvoiceCode = f.InvoiceCode
							where(1=1)
								and f.InvoiceStatus not in ('PENDING') 
							;

							--- Return:					
							select 
								STUFF(( 
							SELECT ',' + f.InvoiceCode
							FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
							WHERE(1=1)
							FOR
							XML PATH('')
							), 1, 1, ''
								) AS ListInvoiceCode
							where(1=1)
							;

							--- Clear For Debug:
							drop table #tbl_Invoice_Invoice_ForSTUFF;
						");
					DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
						strSql_CheckInvalidInvoiceCode
						).Tables[0];
					/////
					if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
					{
						string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceCode.Rows[0]["ListInvoiceCode"]);
						/////
						if (!string.IsNullOrEmpty(strListInvoiceCode))
						{
							if (bIsDelete)
							{
								goto MyCodeLabel_Done; // Thành công
							}
							else // if (!string.IsNullOrEmpty(strListInvoiceCode))
							{
								alParamsCoupleError.AddRange(new object[]{
									"Check.ErrConditionalRaise", "f.InvoiceStatus not in ('PENDING')"
									, "Check.strListInvoiceCode", strListInvoiceCode
									});
								throw CmUtils.CMyException.Raise(
									TError.ErridnInventory.Invoice_Invoice_Calc_StatusNotMatched
									, null
									, alParamsCoupleError.ToArray()
									);

							}
						}
						/////
					}
					//              ////
				}
				#endregion

				#region ----// Đã cấp số hóa đơn thì không được Xóa:
				if (bIsDelete)
				{
					string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
						--- #tbl_Invoice_Invoice_ForSTUFF:
						select distinct 
							t.InvoiceCode
						into #tbl_Invoice_Invoice_ForSTUFF
						from #input_Invoice_Invoice t --//[mylock]
							inner join Invoice_Invoice f --//[mylock]
								on t.InvoiceCode = f.InvoiceCode
						where(1=1)
							and f.InvoiceNo is not null 
						;

						--- Return:					
						select 
							STUFF(( 
						SELECT ',' + f.InvoiceCode
						FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
						WHERE(1=1)
						FOR
						XML PATH('')
						), 1, 1, ''
							) AS ListInvoiceCode
						where(1=1)
						;

						--- Clear For Debug:
						drop table #tbl_Invoice_Invoice_ForSTUFF;
						");
					DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
						strSql_CheckInvalidInvoiceCode
						).Tables[0];
					/////
					if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
					{
						/////
						string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceCode.Rows[0]["ListInvoiceCode"]);
						////
						if (!string.IsNullOrEmpty(strListInvoiceCode))
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.ErrConditionalRaise", "f.InvoiceNo is not null "
								, "Check.strListInvoiceCode", strListInvoiceCode
								});
							throw CmUtils.CMyException.Raise(
								TError.ErridnInventory.Invoice_Invoice_Calc_ExistInvoiceNo
								, null
								, alParamsCoupleError.ToArray()
								);

						}
					}
					//
				}
				#endregion

				#region ----// Nếu là hóa đơn điều chỉnh thì RefNo không được Null:
				//          if (!bIsDelete)
				//          {
				//              string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
				//                      --- #tbl_Invoice_Invoice_ForSTUFF:
				//                      select distinct 
				//                          t.InvoiceCode
				//                      into #tbl_Invoice_Invoice_ForSTUFF
				//                      from #input_Invoice_Invoice t --//[mylock]
				//                      where(1=1)
				//                          and t.RefNo is null
				//                          and t.InvoiceAdjType in ('@strADJINCREASE', '@strADJDESCREASE')
				//                      ;

				//                      --- Return:					
				//                      select 
				//                          STUFF(( 
				//                        SELECT ',' + f.InvoiceCode
				//                        FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
				//                        WHERE(1=1)
				//                        FOR
				//                        XML PATH('')
				//                        ), 1, 1, ''
				//                          ) AS ListInvoiceCode
				//                      where(1=1)
				//                      ;

				//                      --- Clear For Debug:
				//                      drop table #tbl_Invoice_Invoice_ForSTUFF;
				//"
				//                  , "@strADJINCREASE", TConst.InvoiceAdjType.AdjInCrease
				//                  , "@strADJINCREASE", TConst.InvoiceAdjType.AdjDescrease
				//                  );
				//              DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
				//                  strSql_CheckInvalidInvoiceCode
				//                  ).Tables[0];
				//              /////
				//              if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
				//              {
				//                  string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceCode.Rows[0]["ListInvoiceCode"]);
				//                  /////
				//                  if (!string.IsNullOrEmpty(strListInvoiceCode))
				//                  {
				//                      alParamsCoupleError.AddRange(new object[]{
				//                          "Check.ErrConditionalRaise", "and t.InvoiceAdjType in ('@strADJINCREASE', '@strADJDESCREASE') and t.RefNo is null"
				//                          , "Check.strListInvoiceCode", strListInvoiceCode
				//                          });
				//                      throw CmUtils.CMyException.Raise(
				//                          TError.ErridnInventory.Invoice_Invoice_Calc_InvoiceAdjTypeIsNotNull
				//                          , null
				//                          , alParamsCoupleError.ToArray()
				//                          );
				//                  }
				//                  /////
				//              }
				//              ////
				//          }
				#endregion

				#region ----// Nếu là hóa đơn thay thế:
				{
					//          #region ----// Nếu là hóa đơn thay thế thì RefNo không được Null:
					//          {
					//              string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                          t.RefNo
					//                      into #tbl_Invoice_Invoice_ForSTUFF
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                      where(1=1)
					//                          and t.SourceInvoiceCode in ('@strInvoiceReplace') 
					//                          and (t.RefNo is null or LTRIM(RTRIM(t.RefNo)) = '')
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.RefNo
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListRefNo
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF;
					//"
					//                  , "@strInvoiceReplace", TConst.SourceInvoiceCode.InvoiceReplace
					//                  );
					//              DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
					//                  strSql_CheckInvalidInvoiceCode
					//                  ).Tables[0];
					//              /////
					//              if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
					//              {
					//                  /////
					//                  string strListRefNo = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceCode.Rows[0]["ListRefNo"]);
					//                  ////
					//                  if (!string.IsNullOrEmpty(strListRefNo))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "and t.SourceInvoiceCode in ('@strInvoiceReplace') and (t.RefNo is null or LTRIM(RTRIM(t.RefNo)) = '')"
					//                          , "Check.strListRefNo", strListRefNo
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Input_Invoice_InvalidRefNo
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );

					//                  }
					//              }
					//              ////
					//          }
					//          #endregion

					//          #region ----// RefNo ở trạng thái Deleted:
					//          {
					//              string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                          t.RefNo
					//                      into #tbl_Invoice_Invoice_ForSTUFF
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                          left join Invoice_Invoice f --//[mylock]
					//                              on t.RefNo = f.InvoiceCode
					//                      where(1=1)
					//                          and t.SourceInvoiceCode in ('@strInvoiceReplace') 
					//                          and (f.InvoiceStatus not in ('DELETED', 'ISSUED')) 
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.RefNo
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListRefNo
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF;
					//"
					//                  , "@strInvoiceReplace", TConst.SourceInvoiceCode.InvoiceReplace
					//                  );
					//              DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
					//                  strSql_CheckInvalidInvoiceCode
					//                  ).Tables[0];
					//              /////
					//              if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
					//              {
					//                  /////
					//                  string strListRefNo = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceCode.Rows[0]["ListRefNo"]);
					//                  ////
					//                  if (!string.IsNullOrEmpty(strListRefNo))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "and t.SourceInvoiceCode in ('@strInvoiceReplace')  and (f.InvoiceStatus not in ('DELETED', 'ISSUED')) "
					//                          , "Check.strListRefNo", strListRefNo
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Input_Invoice_InvalidInvoiceStatusRefNo
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );

					//                  }
					//              }
					//              ////
					//          }
					//          #endregion

					//          #region ----// Không cho phép xóa hóa đơn thay thế:
					//          if (bIsDelete)
					//          {
					//              string strSql_CheckInvalidInvoiceCode = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                          t.RefNo
					//                      into #tbl_Invoice_Invoice_ForSTUFF
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                      where(1=1)
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.RefNo
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListRefNo
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF;
					//"
					//                  , "@strInvoiceReplace", TConst.SourceInvoiceCode.InvoiceReplace
					//                  );
					//              DataTable dt_CheckInvalidInvoiceCode = _cf.db.ExecQuery(
					//                  strSql_CheckInvalidInvoiceCode
					//                  ).Tables[0];
					//              /////
					//              if (dt_CheckInvalidInvoiceCode.Rows.Count > 0)
					//              {
					//                  /////
					//                  string strListRefNo = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceCode.Rows[0]["ListRefNo"]);
					//                  ////
					//                  if (!string.IsNullOrEmpty(strListRefNo))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.strListRefNo", strListRefNo
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_NotDelete
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );

					//                  }
					//              }
					//              ////
					//          }
					//          #endregion
				}
				#endregion

				#region ----// Check Mst_NNT:
				{
					//              string strSql_CheckMstNNT = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                       t.MST
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Exist
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_NNT f --//[mylock]
					//                        on t.MST = f.MST
					//                      where(1=1)
					//                       and f.MST is null
					//                      ;

					//                      --- #tbl_Invoice_Invoice_ForSTUFF_Active:
					//                      select distinct 
					//                       t.MST
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Active
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_NNT f --//[mylock]
					//                        on t.MST = f.MST
					//                      where(1=1)
					//                       and f.FlagActive = '0'
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.MST
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Exist f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListMST
					//                      where(1=1)
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.MST
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Active f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListMST
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Exist;
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Active;
					//");
					//              DataSet ds_CheckMstNNT = _cf.db.ExecQuery(
					//                  strSql_CheckMstNNT
					//                  );
					//              ////
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Exist = ds_CheckMstNNT.Tables[0];
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Active = ds_CheckMstNNT.Tables[1];
					//              /////
					//              if (dt_Invoice_Invoice_ForSTUFF_Exist.Rows.Count > 0)
					//              {
					//                  string strListMST = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Exist.Rows[0]["ListMST"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListMST))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_NNT.MST is null"
					//                          , "Check.strListMST", strListMST
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_MstNNT_NotFound
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
					//              if (dt_Invoice_Invoice_ForSTUFF_Active.Rows.Count > 0)
					//              {
					//                  string strListMST = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Active.Rows[0]["ListMST"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListMST))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_NNT.FlagActive = '0'"
					//                          , "Check.strListMST", strListMST
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_MstNNT_FlagActive
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					////
				}
				#endregion

				#region ----// Check Mst_PaymentMethods:
				{
					//              string strSql_CheckPaymentMethods = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                       t.PaymentMethodCode
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Exist
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_PaymentMethods f --//[mylock]
					//                        on t.PaymentMethodCode = f.PaymentMethodCode
					//                      where(1=1)
					//                       and f.PaymentMethodCode is null
					//                      ;

					//                      --- #tbl_Invoice_Invoice_ForSTUFF_Active:
					//                      select distinct 
					//                       t.PaymentMethodCode
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Active
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_PaymentMethods f --//[mylock]
					//                        on t.PaymentMethodCode = f.PaymentMethodCode
					//                      where(1=1)
					//                       and f.FlagActive = '0'
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.PaymentMethodCode
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Exist f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListPaymentMethodCode
					//                      where(1=1)
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.PaymentMethodCode
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Active f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListPaymentMethodCode
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Exist;
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Active;
					//");
					//              DataSet ds_CheckMst_PaymentMethods = _cf.db.ExecQuery(
					//                  strSql_CheckPaymentMethods
					//                  );
					//              ////
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Exist = ds_CheckMst_PaymentMethods.Tables[0];
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Active = ds_CheckMst_PaymentMethods.Tables[1];
					//              /////
					//              if (dt_Invoice_Invoice_ForSTUFF_Exist.Rows.Count > 0)
					//              {
					//                  string strListPaymentMethodCode = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Exist.Rows[0]["ListPaymentMethodCode"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListPaymentMethodCode))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_PaymentMethods.PaymentMethodCode is null"
					//                          , "Check.strListPaymentMethodCode", strListPaymentMethodCode
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_PaymentMethods_NotFound
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
					//              if (dt_Invoice_Invoice_ForSTUFF_Active.Rows.Count > 0)
					//              {
					//                  string strListPaymentMethodCode = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Active.Rows[0]["ListPaymentMethodCode"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListPaymentMethodCode))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_PaymentMethods.FlagActive = '0'"
					//                          , "Check.strListPaymentMethodCode", strListPaymentMethodCode
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_PaymentMethods_FlagActive
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//    /////
					//}
					////
				}
				#endregion

				#region ----// Check Mst_InvoiceType2:
				{
					//              string strSql_CheckInvoiceType2 = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                       t.InvoiceType2
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Exist
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_InvoiceType2 f --//[mylock]
					//                        on t.InvoiceType2 = f.InvoiceType2
					//                      where(1=1)
					//                       and f.InvoiceType2 is null
					//                      ;

					//                      --- #tbl_Invoice_Invoice_ForSTUFF_Active:
					//                      select distinct 
					//                       t.InvoiceType2
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Active
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_InvoiceType2 f --//[mylock]
					//                        on t.InvoiceType2 = f.InvoiceType2
					//                      where(1=1)
					//                       and f.FlagActive = '0'
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.InvoiceType2
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Exist f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListInvoiceType2
					//                      where(1=1)
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.InvoiceType2
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Active f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListInvoiceType2
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Exist;
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Active;
					//");
					//              DataSet ds_CheckMst_InvoiceType2 = _cf.db.ExecQuery(
					//                  strSql_CheckInvoiceType2
					//                  );
					//              ////
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Exist = ds_CheckMst_InvoiceType2.Tables[0];
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Active = ds_CheckMst_InvoiceType2.Tables[1];
					//              /////
					//              if (dt_Invoice_Invoice_ForSTUFF_Exist.Rows.Count > 0)
					//              {
					//                  string strListInvoiceType2 = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Exist.Rows[0]["ListInvoiceType2"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListInvoiceType2))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_InvoiceType2.InvoiceType2 is null"
					//                          , "Check.strListInvoiceType2", strListInvoiceType2
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_InvoiceType2_NotFound
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
					//              if (dt_Invoice_Invoice_ForSTUFF_Active.Rows.Count > 0)
					//              {
					//                  string strListInvoiceType2 = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Active.Rows[0]["ListInvoiceType2"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListInvoiceType2))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_InvoiceType2.FlagActive = '0'"
					//                          , "Check.strListInvoiceType2", strListInvoiceType2
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_InvoiceType2_FlagActive
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
				}
				#endregion

				#region ----// Check Mst_SourceInvoice:
				{
					//              string strSql_CheckMst_SourceInvoice = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF:
					//                      select distinct 
					//                       t.SourceInvoiceCode
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Exist
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_SourceInvoice f --//[mylock]
					//                        on t.SourceInvoiceCode = f.SourceInvoiceCode
					//                      where(1=1)
					//                       and f.SourceInvoiceCode is null
					//                      ;

					//                      --- #tbl_Invoice_Invoice_ForSTUFF_Active:
					//                      select distinct 
					//                       t.SourceInvoiceCode
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Active
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Mst_SourceInvoice f --//[mylock]
					//                        on t.SourceInvoiceCode = f.SourceInvoiceCode
					//                      where(1=1)
					//                       and f.FlagActive = '0'
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.SourceInvoiceCode
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Exist f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListSourceInvoiceCode
					//                      where(1=1)
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.SourceInvoiceCode
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Active f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListSourceInvoiceCode
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Exist;
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Active;
					//");
					//              DataSet ds_CheckMst_PaymentMethods = _cf.db.ExecQuery(
					//                  strSql_CheckMst_SourceInvoice
					//                  );
					//              ////
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Exist = ds_CheckMst_PaymentMethods.Tables[0];
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Active = ds_CheckMst_PaymentMethods.Tables[1];
					//              /////
					//              if (dt_Invoice_Invoice_ForSTUFF_Exist.Rows.Count > 0)
					//              {
					//                  string strListSourceInvoiceCode = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Exist.Rows[0]["ListSourceInvoiceCode"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListSourceInvoiceCode))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_SourceInvoice.SourceInvoiceCode is null"
					//                          , "Check.strListSourceInvoiceCode", strListSourceInvoiceCode
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_SourceInvoice_NotFound
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
					//              if (dt_Invoice_Invoice_ForSTUFF_Active.Rows.Count > 0)
					//              {
					//                  string strListSourceInvoiceCode = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Active.Rows[0]["ListSourceInvoiceCode"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListSourceInvoiceCode))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Mst_SourceInvoice.FlagActive = '0'"
					//                          , "Check.strListPaymentMethodCode", strListSourceInvoiceCode
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_SourceInvoice_FlagActive
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					////
				}
				#endregion

				#region ----// Check Invoice_TempInvoice:
				{
					//              string strSql_CheckInvoice_TempInvoice = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_Invoice_ForSTUFF_Exist:
					//                      select distinct 
					//                       t.TInvoiceCode
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Exist
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Invoice_TempInvoice f --//[mylock]
					//                        on t.TInvoiceCode = f.TInvoiceCode
					//                      where(1=1)
					//                       and f.TInvoiceCode is null
					//                      ;

					//                      --- #tbl_Invoice_Invoice_ForSTUFF_Active:
					//                      select distinct 
					//                       t.TInvoiceCode
					//                      into #tbl_Invoice_Invoice_ForSTUFF_Active
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       left join Invoice_TempInvoice f --//[mylock]
					//                        on t.TInvoiceCode = f.TInvoiceCode
					//                      where(1=1)
					//                       and f.TInvoiceStatus not in ('ISSUED')
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.TInvoiceCode
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Exist f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListTInvoiceCode
					//                      where(1=1)
					//                      ;

					//                      --- Return:					
					//                      select 
					//                          STUFF(( 
					//                        SELECT ',' + f.TInvoiceCode
					//                        FROM #tbl_Invoice_Invoice_ForSTUFF_Active f --//[mylock]
					//                        WHERE(1=1)
					//                        FOR
					//                        XML PATH('')
					//                        ), 1, 1, ''
					//                          ) AS ListTInvoiceCode
					//                      where(1=1)
					//                      ;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Exist;
					//                      drop table #tbl_Invoice_Invoice_ForSTUFF_Active;
					//");
					//              DataSet ds_CheckInvoice_TempInvoice = _cf.db.ExecQuery(
					//                  strSql_CheckInvoice_TempInvoice
					//                  );
					//              ////
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Exist = ds_CheckInvoice_TempInvoice.Tables[0];
					//              DataTable dt_Invoice_Invoice_ForSTUFF_Active = ds_CheckInvoice_TempInvoice.Tables[1];
					//              /////
					//              if (dt_Invoice_Invoice_ForSTUFF_Exist.Rows.Count > 0)
					//              {
					//                  string strListTInvoiceCode = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Exist.Rows[0]["ListTInvoiceCode"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListTInvoiceCode))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Invoice_TempInvoice.TInvoiceCode is null"
					//                          , "Check.strListTInvoiceCode", strListTInvoiceCode
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_TempInvoice_NotFound
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
					//              if (dt_Invoice_Invoice_ForSTUFF_Active.Rows.Count > 0)
					//              {
					//                  string strListTInvoiceCode = TUtils.CUtils.StdParam(dt_Invoice_Invoice_ForSTUFF_Active.Rows[0]["ListTInvoiceCode"]);
					//                  /////
					//                  if (!string.IsNullOrEmpty(strListTInvoiceCode))
					//                  {
					//                      alParamsCoupleError.AddRange(new object[]{
					//                          "Check.ErrConditionalRaise", "Invoice_TempInvoice.TInvoiceStatus not in ('ISSUED')"
					//                          , "Check.strListTInvoiceCode", strListTInvoiceCode
					//                          });
					//                      throw CmUtils.CMyException.Raise(
					//                          TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_TempInvoice_StatusNotMatch
					//                          , null
					//                          , alParamsCoupleError.ToArray()
					//                          );
					//                  }
					//                  /////
					//              }
					//              ////
				}
				#endregion

				#region ----// Check SL hóa đơn sử dụng:
				{
					//              string strSql_CheckInvoice_TempInvoice = CmUtils.StringUtils.Replace(@"
					//                      --- #tbl_Invoice_TempInvoice:
					//                      select distinct 
					//                       t.TInvoiceCode
					//                      into #tbl_Invoice_TempInvoice
					//                      from #input_Invoice_Invoice t --//[mylock]
					//                       inner join Invoice_TempInvoice f --//[mylock]
					//                        on t.TInvoiceCode = t.TInvoiceCode
					//                      where(1=1)
					//                      ;

					//	---- Return:
					//	select 
					//		t.TInvoiceCode
					//		, f.EndInvoiceNo
					//		, f.StartInvoiceNo
					//		, f.QtyUsed
					//		, (f.EndInvoiceNo - f.StartInvoiceNo + 1 - f.QtyUsed) QtyRemain
					//	from #tbl_Invoice_TempInvoice t --//[mylock]
					//		inner join Invoice_TempInvoice f --//[mylock]
					//			on t.TInvoiceCode = f.TInvoiceCode
					//	where(1=1)
					//		and (f.EndInvoiceNo - f.StartInvoiceNo + 1 - f.QtyUsed) < 1
					//	;

					//                      --- Clear For Debug:
					//                      drop table #tbl_Invoice_TempInvoice;
					//");
					//              DataSet ds_Invoice_TempInvoice = _cf.db.ExecQuery(
					//                  strSql_CheckInvoice_TempInvoice
					//                  );
					//              ////
					//              DataTable dt_Invoice_TempInvoice = ds_Invoice_TempInvoice.Tables[0];
					//              /////
					//              if (dt_Invoice_TempInvoice.Rows.Count > 0)
					//              {
					//                  alParamsCoupleError.AddRange(new object[]{
					//                      "Check.strTInvoiceCode", dt_Invoice_TempInvoice.Rows[0]["TInvoiceCode"]
					//                      , "Check.DB.StartInvoiceNo", dt_Invoice_TempInvoice.Rows[0]["StartInvoiceNo"]
					//                      , "Check.DB.EndInvoiceNo", dt_Invoice_TempInvoice.Rows[0]["EndInvoiceNo"]
					//                      , "Check.DB.QtyUsed",  dt_Invoice_TempInvoice.Rows[0]["QtyUsed"]
					//                      , "Check.ErrConditionRaise", "((nEndInvoiceNo - nStartInvoiceNo - nQtyUsed)< 1)"
					//                      });
					//                  throw CmUtils.CMyException.Raise(
					//                      TError.ErridnInventory.Invoice_Invoice_Calc_Invalid_SourceInvoice_NotFound
					//                      , null
					//                      , alParamsCoupleError.ToArray()
					//                      );
					//              }
					////
				}
				#endregion

				#region ----// 20190919. Check InvoiceDateUTC:
				{
					string strSqlCheck_InvalidInvoiceDateUTC = CmUtils.StringUtils.Replace(@"
							--- Check:
							select distinct 
								t.InvoiceCode
							into #tbl_Invoice_Invoice_ForSTUFF
							from #input_Invoice_Invoice t --//[mylock]
							where(1=1)
								and (t.InvoiceDateUTC is null or LTRIM(RTRIM(t.InvoiceDateUTC)) = '')
							;

							--- Return:					
							select 
								STUFF(( 
							SELECT ',' + f.InvoiceCode
							FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
							WHERE(1=1)
							FOR
							XML PATH('')
							), 1, 1, ''
								) AS ListInvoiceCode
							where(1=1)
							;

							--- Clear For Debug:
							drop table #tbl_Invoice_Invoice_ForSTUFF;
						");
					DataTable dt_CheckInvalidInvoiceDateUTC = _cf.db.ExecQuery(
						strSqlCheck_InvalidInvoiceDateUTC
						).Tables[0];
					/////
					if (dt_CheckInvalidInvoiceDateUTC.Rows.Count > 0)
					{
						////
						string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidInvoiceDateUTC.Rows[0]["ListInvoiceCode"]);

						if (!string.IsNullOrEmpty(strListInvoiceCode))
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.strListInvoiceCode", strListInvoiceCode
								, "Check.ErrConditionalRaise", "and (t.InvoiceDateUTC is null or LTRIM(RTRIM(t.InvoiceDateUTC)) = '')"
								, "Check.NumberRows", dt_CheckInvalidInvoiceDateUTC.Rows.Count
								});
							throw CmUtils.CMyException.Raise(
								TError.ErridnInventory.Invoice_Invoice_Calc_InvalidInvoiceDateUTC
								, null
								, alParamsCoupleError.ToArray()
								);
						}
							
					}
				}
				#endregion

				#region ----// 20190919. Check CustomerNNTCode:
				{
					string strSqlCheck_InvalidCustomerNNTCode = CmUtils.StringUtils.Replace(@"
							--- Check:
							select distinct 
								t.InvoiceCode
							into #tbl_Invoice_Invoice_ForSTUFF
							from #input_Invoice_Invoice t --//[mylock]
							where(1=1)
								and t.FlagCheckCustomer = '1'
								and (t.CustomerNNTCode is null or LTRIM(RTRIM(t.CustomerNNTCode)) = '')
							;

							--- Return:					
							select 
								STUFF(( 
							SELECT ',' + f.InvoiceCode
							FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
							WHERE(1=1)
							FOR
							XML PATH('')
							), 1, 1, ''
								) AS ListInvoiceCode
							where(1=1)
							;

							--- Clear For Debug:
							drop table #tbl_Invoice_Invoice_ForSTUFF;
						");
					DataTable dt_CheckInvalidCustomerNNTCode = _cf.db.ExecQuery(
						strSqlCheck_InvalidCustomerNNTCode
						).Tables[0];
					/////
					if (dt_CheckInvalidCustomerNNTCode.Rows.Count > 0)
					{
						////
						string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidCustomerNNTCode.Rows[0]["ListInvoiceCode"]);

						if (!string.IsNullOrEmpty(strListInvoiceCode))
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.strListInvoiceCode", strListInvoiceCode
								, "Check.ErrConditionalRaise", "and t.FlagCheckCustomer = '1' and (t.CustomerNNTCode is null or LTRIM(RTRIM(t.CustomerNNTCode)) = '')"
								, "Check.NumberRows", dt_CheckInvalidCustomerNNTCode.Rows.Count
								});
							throw CmUtils.CMyException.Raise(
								TError.ErridnInventory.Invoice_Invoice_Calc_InvalidCustomerNNTCode
								, null
								, alParamsCoupleError.ToArray()
								);
						}						
					}
				}
				#endregion

				#region ----// 20190919. Check EmailSend:
				{
					string strSqlCheck_InvalidEmailSend = CmUtils.StringUtils.Replace(@"
							--- Check:
							select distinct 
								t.InvoiceCode
							into #tbl_Invoice_Invoice_ForSTUFF
							from #input_Invoice_Invoice t --//[mylock]
							where(1=1)
								and (t.EmailSend is null or LTRIM(RTRIM(t.EmailSend)) = '')
							;

							--- Return:					
							select 
								STUFF(( 
							SELECT ',' + f.InvoiceCode
							FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
							WHERE(1=1)
							FOR
							XML PATH('')
							), 1, 1, ''
								) AS ListInvoiceCode
							where(1=1)
							;

							--- Clear For Debug:
							drop table #tbl_Invoice_Invoice_ForSTUFF;
						");
					DataTable dt_CheckInvalidEmailSend = _cf.db.ExecQuery(
						strSqlCheck_InvalidEmailSend
						).Tables[0];
					/////
					if (dt_CheckInvalidEmailSend.Rows.Count > 0)
					{
						////
						string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidEmailSend.Rows[0]["ListInvoiceCode"]);

						if (!string.IsNullOrEmpty(strListInvoiceCode))
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.strListInvoiceCode", strListInvoiceCode
								, "Check.ErrConditionalRaise", "and t.FlagCheckCustomer = '1' and (t.EmailSend is null or LTRIM(RTRIM(t.EmailSend)) = '')"
								, "Check.NumberRows", dt_CheckInvalidEmailSend.Rows.Count
								});
							throw CmUtils.CMyException.Raise(
								TError.ErridnInventory.Invoice_Invoice_Calc_InvalidEmailSend
								, null
								, alParamsCoupleError.ToArray()
								);
						}
					}
				}
				#endregion

				#region ----// 20190919. Check PaymentMethodCode:
				{
					string strSqlCheck_InvalidPaymentMethodCode = CmUtils.StringUtils.Replace(@"
							--- Check:
							select distinct 
								t.InvoiceCode
							into #tbl_Invoice_Invoice_ForSTUFF
							from #input_Invoice_Invoice t --//[mylock]
							where(1=1)
								and (t.PaymentMethodCode is null or LTRIM(RTRIM(t.PaymentMethodCode)) = '')
							;

							--- Return:					
							select 
								STUFF(( 
							SELECT ',' + f.InvoiceCode
							FROM #tbl_Invoice_Invoice_ForSTUFF f --//[mylock]
							WHERE(1=1)
							FOR
							XML PATH('')
							), 1, 1, ''
								) AS ListInvoiceCode
							where(1=1)
							;

							--- Clear For Debug:
							drop table #tbl_Invoice_Invoice_ForSTUFF;
						");
					DataTable dt_CheckInvalidPaymentMethodCode = _cf.db.ExecQuery(
						strSqlCheck_InvalidPaymentMethodCode
						).Tables[0];
					/////
					if (dt_CheckInvalidPaymentMethodCode.Rows.Count > 0)
					{
						////
						string strListInvoiceCode = TUtils.CUtils.StdParam(dt_CheckInvalidPaymentMethodCode.Rows[0]["ListInvoiceCode"]);

						if (!string.IsNullOrEmpty(strListInvoiceCode))
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.strListInvoiceCode", strListInvoiceCode
								, "Check.ErrConditionalRaise", "and (t.PaymentMethodCode is null or LTRIM(RTRIM(t.PaymentMethodCode)) = '')"
								, "Check.NumberRows", dt_CheckInvalidPaymentMethodCode.Rows.Count
								});
							throw CmUtils.CMyException.Raise(
								TError.ErridnInventory.Invoice_Invoice_Calc_InvalidPaymentMethodCode
								, null
								, alParamsCoupleError.ToArray()
								);
						}						
					}
				}
				#endregion
			}
			#endregion

			#region // Build Invoice_Invoice:
			{
				string strSql_Build = CmUtils.StringUtils.Replace(@"
                        ----- #tbl_Invoice_Invoice_Build:
                        select 
	                        t.InvoiceCode
	                        , t.MST
	                        , t.NetworkID
	                        , t.RefNo
	                        , t.FormNo
	                        , t.Sign
	                        , t.SourceInvoiceCode
	                        , t.InvoiceAdjType
	                        , t.InvoiceType2
	                        , t.PaymentMethodCode
	                        , t.CustomerNNTCode
	                        , t.CustomerNNTName
	                        , t.CustomerNNTAddress
	                        , t.CustomerNNTPhone
	                        , t.CustomerNNTBankName
	                        , t.CustomerNNTEmail
	                        , t.CustomerNNTAccNo
	                        , t.CustomerNNTBuyerName
	                        , t.CustomerMST
	                        , t.TInvoiceCode
	                        , t.InvoiceNo
	                        , t.InvoiceDateUTC
	                        , t.EmailSend
	                        , t.InvoiceFileSpec
	                        , t.InvoiceFilePath
	                        , null InvoicePDFFilePath
	                        , t.TotalValInvoice
	                        , t.TotalValVAT
	                        , t.TotalValPmt
	                        , IsNull(f.CreateDTimeUTC, '@strLogLUDTimeUTC') CreateDTimeUTC --t.CreateDTimeUTC
	                        , IsNull(f.CreateBy, '@strLogLUBy') CreateBy --t.CreateBy
	                        , t.InvoiceNoDTimeUTC
	                        , t.InvoiceNoBy
	                        , t.SignDTimeUTC
	                        , t.SignBy
	                        , t.ApprDTimeUTC
	                        , t.ApprBy
	                        , t.CancelDTimeUTC
	                        , t.CancelBy
	                        , t.SendEmailDTimeUTC
	                        , t.SendEmailBy
	                        , t.IssuedDTimeUTC
	                        , t.IssuedBy
                            , null AttachedDelFilePath
                            , null DeleteReason
                            , t.DeleteDTimeUTC
	                        , t.DeleteBy
	                        , t.ChangeDTimeUTC
	                        , t.ChangeBy
	                        , t.InvoiceVerifyCQTCode
	                        , t.CurrencyCode
	                        , t.CurrencyRate
	                        , t.ValGoodsNotTaxable
	                        , t.ValGoodsNotChargeTax
	                        , t.ValGoodsVAT5
	                        , t.ValVAT5
	                        , t.ValGoodsVAT10
	                        , t.ValVAT10
	                        , t.NNTFullName
	                        , t.NNTFullAdress
	                        , t.NNTPhone
	                        , t.NNTFax
	                        , t.NNTEmail
	                        , t.NNTWebsite
	                        , t.NNTAccNo
	                        , t.NNTBankName
	                        , '@strLogLUDTimeUTC' LUDTimeUTC --t.LUDTimeUTC
	                        , '@strLogLUBy' LUBy --t.LUBy
	                        , t.Remark
	                        , t.InvoiceCF1
	                        , t.InvoiceCF2
	                        , t.InvoiceCF3
	                        , t.InvoiceCF4
	                        , t.InvoiceCF5
	                        , t.InvoiceCF6
	                        , t.InvoiceCF7
	                        , t.InvoiceCF8
	                        , t.InvoiceCF9
	                        , t.InvoiceCF10
	                        , t.FlagConfirm
	                        , '1' FlagChange --t.FlagChange
	                        , null FlagPushOutSite -- t.FlagPushOutSite
	                        , null FlagDeleteOutSite -- t.FlagDeleteOutSite
	                        , '@strInvoiceStatus' InvoiceStatus --t.InvoiceStatus
	                        , '@strLogLUDTimeUTC' LogLUDTimeUTC --t.LogLUDTimeUTC
	                        , '@strLogLUBy' LogLUBy --t.LogLUBy
							-- 20190919.DũngND
							, t.FlagCheckCustomer
							----					
                        into #tbl_Invoice_Invoice_Build
                        from #input_Invoice_Invoice t --//[mylock]
                            left join Invoice_Invoice f --//[mylock]
                                on t.InvoiceCode = f.InvoiceCode
                        where(1=1)
                        ;

                        select null tbl_Invoice_Invoice_Build, t.* from #tbl_Invoice_Invoice_Build t --//[mylock];
                    ;"
					, "@strInvoiceStatus", TConst.InvoiceStatus.Pending
					, "@strLogLUDTimeUTC", dtimeSys.ToString("yyyy-MM-dd hh:mm:ss")
					, "@strLogLUBy", strWAUserCode
					);
				DataTable dt_Build = _cf.db.ExecQuery(
					strSql_Build
					).Tables[0];
				/////
			}
			#endregion

			#region //// Refine and Check Input Invoice_InvoiceDtl:
			////
			DataTable dtInput_Invoice_InvoiceDtl = null;
			if (!bIsDelete)
			{
				////
				string strTableCheck = "Invoice_InvoiceDtl";
				////
				if (!dsData.Tables.Contains(strTableCheck))
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.TableName", strTableCheck
						});
					throw CmUtils.CMyException.Raise(
						TError.ErridnInventory.Invoice_Invoice_Calc_Input_InvoiceDtlTblNotFound
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				dtInput_Invoice_InvoiceDtl = dsData.Tables[strTableCheck];
				////

				if (dtInput_Invoice_InvoiceDtl.Rows.Count < 1)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.TableName", strTableCheck
						});
					throw CmUtils.CMyException.Raise(
						TError.ErridnInventory.Invoice_Invoice_Calc_Input_InvoiceDtlTblInvalid
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				////
				TUtils.CUtils.StdDataInTable(
					dtInput_Invoice_InvoiceDtl // dtData
					, "StdParam", "InvoiceCode" // arrstrCouple
					, "StdParam", "Idx" // arrstrCouple
					, "StdParam", "NetworkID" // arrstrCouple
					, "StdParam", "SpecCode" // arrstrCouple
					, "", "SpecName" // arrstrCouple
					, "StdParam", "ProductID" // arrstrCouple
					, "", "ProductName" // arrstrCouple
					, "StdParam", "VATRateCode" // arrstrCouple
					, "float", "VATRate" // arrstrCouple
					, "StdParam", "UnitCode" // arrstrCouple
					, "", "UnitName" // arrstrCouple
					, "float", "UnitPrice" // arrstrCouple
					, "float", "Qty" // arrstrCouple
					, "float", "ValInvoice" // arrstrCouple
					, "float", "ValTax" // arrstrCouple
					, "StdParam", "InventoryCode" // arrstrCouple
					, "float", "DiscountRate" // arrstrCouple
					, "float", "ValDiscount" // arrstrCouple
					, "", "Remark" // arrstrCouple
					, "", "InvoiceDCF1" // arrstrCouple
					, "", "InvoiceDCF2" // arrstrCouple
					, "", "InvoiceDCF3" // arrstrCouple
					, "", "InvoiceDCF4" // arrstrCouple
					, "", "InvoiceDCF5" // arrstrCouple
					);
				////
				//TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_InvoiceDtl, "InvoiceCode", typeof(object));
				//TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_InvoiceDtl, "NetworkID", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_InvoiceDtl, "InvoiceDtlStatus", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_InvoiceDtl, "LogLUDTimeUTC", typeof(object));
				TUtils.CUtils.MyForceNewColumn(ref dtInput_Invoice_InvoiceDtl, "LogLUBy", typeof(object));
				////////
			}
			#endregion

			#region //// SaveTemp Invoice_InvoiceDtl For Check:
			if (!bIsDelete)
			{
				// Upload:
				TUtils.CUtils.MyBuildDBDT_Common(
					_cf.db // db
					, "#input_Invoice_InvoiceDtl" // strTableName
					, new object[] {
							"InvoiceCode", TConst.BizMix.Default_DBColType
							, "Idx", TConst.BizMix.Default_DBColType
							, "NetworkID", TConst.BizMix.Default_DBColType
							, "SpecCode", TConst.BizMix.Default_DBColType
							, "SpecName", TConst.BizMix.Default_DBColType
							, "ProductID", TConst.BizMix.Default_DBColType
							, "ProductName", TConst.BizMix.Default_DBColType
							, "VATRateCode", TConst.BizMix.Default_DBColType
							, "VATRate", "float"
							, "UnitCode", TConst.BizMix.Default_DBColType
							, "UnitName", TConst.BizMix.Default_DBColType
							, "UnitPrice", "float"
							, "Qty", "float"
							, "ValInvoice", "float"
							, "ValTax", "float"
							, "InventoryCode", TConst.BizMix.Default_DBColType
							, "DiscountRate", "float"
							, "ValDiscount", "float"
							, "InvoiceDtlStatus", TConst.BizMix.Default_DBColType
							, "Remark", TConst.BizMix.Default_DBColType
							, "InvoiceDCF1", TConst.BizMix.Default_DBColType
							, "InvoiceDCF2", TConst.BizMix.Default_DBColType
							, "InvoiceDCF3", TConst.BizMix.Default_DBColType
							, "InvoiceDCF4", TConst.BizMix.Default_DBColType
							, "InvoiceDCF5", TConst.BizMix.Default_DBColType
							, "LogLUDTimeUTC", TConst.BizMix.Default_DBColType
							, "LogLUBy", TConst.BizMix.Default_DBColType
						} // arrSingleStructure
					, dtInput_Invoice_InvoiceDtl // dtData
				);
			}
			#endregion

			#region // Refine and Check Input Invoice_InvoiceDtl:
			if (!bIsDelete)
			{
				#region ----// Check ProductID + SpecCode là duy nhất:
				{
					string strSql_CheckProducID = CmUtils.StringUtils.Replace(@"                            
                            ---- #tbl_Invoice_InvoiceDtl_TotalProductID:
                            select 
	                            t.InvoiceCode
	                            , t.SpecCode
	                            , t.ProductID
	                            , count(0) QtyProductID
                            into #tbl_Invoice_InvoiceDtl_TotalProductID
                            from #input_Invoice_InvoiceDtl t --//[mylock]
                            where(1=1)
	                            and t.ProductID is not null
                            group by 
	                            t.InvoiceCode
	                            , t.SpecCode
	                            , t.ProductID
                            ;

                            ---- Return:
                            select top 1
	                            t.InvoiceCode
	                            , t.ProductID
	                            , t.SpecCode
	                            , t.QtyProductID
                            from #tbl_Invoice_InvoiceDtl_TotalProductID t --//[mylock]
                            where(1=1)
	                            and t.QtyProductID > 1
                            ;

                            -- Clear For Debug:
                            drop table #tbl_Invoice_InvoiceDtl_TotalProductID;

						");
					DataTable dt_CheckProductID = _cf.db.ExecQuery(
						strSql_CheckProducID
						).Tables[0];
					/////
					if (dt_CheckProductID.Rows.Count > 0)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.ErrConditionalRaise", "t.QtyProductID > 1"
                            //, "Check.NumberRows", dt_CheckProductID.Rows.Count
                            , "Check.InvoiceCode", dt_CheckProductID.Rows[0]["InvoiceCode"]
							, "Check.SpecCode", dt_CheckProductID.Rows[0]["SpecCode"]
							, "Check.ProductID", dt_CheckProductID.Rows[0]["ProductID"]
							, "Check.QtyProductID", dt_CheckProductID.Rows[0]["QtyProductID"]
							});
						throw CmUtils.CMyException.Raise(
							TError.ErridnInventory.Invoice_Invoice_Calc_Input_InvoiceDtl_ProductIDDuplicate
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
				}
				#endregion

				#region ----// Check SpecCode là duy nhất:
				{
					string strSql_CheckSpec = CmUtils.StringUtils.Replace(@"                         
                            ---- #tbl_Invoice_InvoiceDtl_TotalSpec:
                            select 
	                            t.InvoiceCode
	                            , t.SpecCode
	                            , count(0) QtySpecCode
                            into #tbl_Invoice_InvoiceDtl_TotalSpec
                            from #input_Invoice_InvoiceDtl t --//[mylock]
                            where(1=1)
	                            and t.ProductID is null
								and t.SpecCode is not null
                            group by 
	                            t.InvoiceCode
	                            , t.SpecCode
                            ;

                            ---- Return:
                            select top 1
	                            t.InvoiceCode
	                            , t.SpecCode
	                            , t.QtySpecCode
                            from #tbl_Invoice_InvoiceDtl_TotalSpec t --//[mylock]
                            where(1=1)
	                            and t.QtySpecCode > 1
                            ;

                            -- Clear For Debug:
                            drop table #tbl_Invoice_InvoiceDtl_TotalSpec;

						");
					DataTable dt_CheckSpecCode = _cf.db.ExecQuery(
						strSql_CheckSpec
						).Tables[0];
					/////
					if (dt_CheckSpecCode.Rows.Count > 0)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.ErrConditionalRaise", "t.QtyProductID > 1"
                            //, "Check.NumberRows", dt_CheckProductID.Rows.Count
                            , "Check.InvoiceCode", dt_CheckSpecCode.Rows[0]["InvoiceCode"]
							, "Check.SpecCode", dt_CheckSpecCode.Rows[0]["SpecCode"]
							, "Check.QtySpecCode", dt_CheckSpecCode.Rows[0]["QtySpecCode"]
							});
						throw CmUtils.CMyException.Raise(
							TError.ErridnInventory.Invoice_Invoice_Calc_Input_InvoiceDtl_SpecCodeDuplicate
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
				}
				#endregion

			}
			#endregion

			#region // Build Invoice_InvoiceDtl:
			if (!bIsDelete)
			{
				string strSql_Build = CmUtils.StringUtils.Replace(@"
                        ----- #tbl_Invoice_InvoiceDtl_Build:
                        select 
	                        t.InvoiceCode
							, Row_Number() over( partition by t.InvoiceCode order by t.Idx asc) Idx 
							--, Row_Number() over (order by t.Idx desc) Idx 
	                        --, t.Idx
	                        , t.NetworkID
	                        , t.SpecCode
	                        , t.SpecName
	                        , t.ProductID
	                        , t.ProductName
	                        , t.VATRateCode
	                        , t.VATRate
	                        , t.UnitCode
	                        , t.UnitName
	                        , t.UnitPrice
	                        , t.Qty
	                        , t.ValInvoice
	                        , t.ValTax
	                        , t.InventoryCode
	                        , t.DiscountRate
	                        , t.ValDiscount
	                        , '@strInvoiceStatus' InvoiceDtlStatus --t.InvoiceDtlStatus
	                        , t.Remark
	                        , t.InvoiceDCF1
	                        , t.InvoiceDCF2
	                        , t.InvoiceDCF3
	                        , t.InvoiceDCF4
	                        , t.InvoiceDCF5
	                        , '@strLogLUDTimeUTC' LogLUDTimeUTC --t.LogLUDTimeUTC
	                        , '@strLogLUBy' LogLUBy --t.LogLUBy
                        into #tbl_Invoice_InvoiceDtl_Build
                        from #input_Invoice_InvoiceDtl t --//[mylock]

                        select null tbl_Invoice_InvoiceDtl_Build, t.* from #tbl_Invoice_InvoiceDtl_Build t --//[mylock];
                    ;"
					, "@strInvoiceStatus", TConst.InvoiceStatus.Pending
					, "@strLogLUDTimeUTC", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
					, "@strLogLUBy", strWAUserCode
					);
				DataTable dt_Build = _cf.db.ExecQuery(
					strSql_Build
					).Tables[0];
				/////
			}
			#endregion

			#region // SaveDB:
			{
				////// Clear All:
				//{
				//	string strSqlDelete = CmUtils.StringUtils.Replace(@"
    //                        ---- #tbl_Invoice_InvoiceDtl:
    //                        select 
    //                            t.InvoiceCode
    //                            , t.Idx
    //                        into #tbl_Invoice_InvoiceDtl
    //                        from Invoice_InvoiceDtl t --//[mylock]
	   //                         inner join #input_Invoice_Invoice f --//[mylock]
		  //                          on t.InvoiceCode = f.InvoiceCode
    //                        where (1=1)
    //                        ;

    //                        --- Delete:
    //                        ---- Invoice_InvoiceDtl:
    //                        delete t 
    //                        from Invoice_InvoiceDtl t --//[mylock]
	   //                         inner join #tbl_Invoice_InvoiceDtl f --//[mylock]
		  //                          on t.InvoiceCode = f.InvoiceCode
		  //                              and t.Idx = f.Idx
    //                        where (1=1)
    //                        ;

    //                        ---- Invoice_Invoice:
    //                        delete t
    //                        from Invoice_Invoice t --//[mylock]
	   //                         inner join #input_Invoice_Invoice f --//[mylock]
		  //                          on t.InvoiceCode = f.InvoiceCode
    //                        where (1=1)
    //                        ;

    //                        --- Clear For Debug:
    //                        drop table #tbl_Invoice_InvoiceDtl;
				//		");
				//	DataSet dtDB = _cf.db.ExecQuery(
				//		strSqlDelete
				//		);
				//}

				////// Insert All:
				//if (!bIsDelete)
				//{
				//	#region // Insert:
				//	{
				//		////
				//		string zzzzClauseInsert_Invoice_Invoice_zSave = CmUtils.StringUtils.Replace(@"
    //                            ---- Invoice_Invoice:                                
    //                            insert into Invoice_Invoice(
	   //                             InvoiceCode
	   //                             , MST
	   //                             , NetworkID
	   //                             , RefNo
	   //                             , FormNo
	   //                             , Sign
	   //                             , SourceInvoiceCode
	   //                             , InvoiceAdjType
	   //                             , PaymentMethodCode
	   //                             , InvoiceType2
	   //                             , CustomerNNTCode
	   //                             , CustomerNNTName
	   //                             , CustomerNNTAddress
	   //                             , CustomerNNTPhone
	   //                             , CustomerNNTBankName
	   //                             , CustomerNNTEmail
	   //                             , CustomerNNTAccNo
	   //                             , CustomerNNTBuyerName
	   //                             , CustomerMST
	   //                             , TInvoiceCode
	   //                             , InvoiceNo
	   //                             , InvoiceDateUTC
	   //                             , EmailSend
	   //                             , InvoiceFileSpec
	   //                             , InvoiceFilePath
	   //                             , InvoicePDFFilePath
	   //                             , TotalValInvoice
	   //                             , TotalValVAT
	   //                             , TotalValPmt
	   //                             , CreateDTimeUTC
	   //                             , CreateBy
	   //                             , InvoiceNoDTimeUTC
	   //                             , InvoiceNoBy
	   //                             , SignDTimeUTC
	   //                             , SignBy
	   //                             , ApprDTimeUTC
	   //                             , ApprBy
	   //                             , CancelDTimeUTC
	   //                             , CancelBy
	   //                             , SendEmailDTimeUTC
	   //                             , SendEmailBy
	   //                             , IssuedDTimeUTC
	   //                             , IssuedBy
	   //                             , AttachedDelFilePath
	   //                             , DeleteReason
	   //                             , DeleteDTimeUTC
	   //                             , DeleteBy
	   //                             , ChangeDTimeUTC
	   //                             , ChangeBy
	   //                             , InvoiceVerifyCQTCode
	   //                             , CurrencyCode
	   //                             , CurrencyRate
	   //                             , ValGoodsNotTaxable
	   //                             , ValGoodsNotChargeTax
	   //                             , ValGoodsVAT5
	   //                             , ValVAT5
	   //                             , ValGoodsVAT10
	   //                             , ValVAT10
	   //                             , NNTFullName
	   //                             , NNTFullAdress
	   //                             , NNTPhone
	   //                             , NNTFax
	   //                             , NNTEmail
	   //                             , NNTWebsite
	   //                             , NNTAccNo
	   //                             , NNTBankName
	   //                             , LUDTimeUTC
	   //                             , LUBy
	   //                             , Remark
	   //                             , InvoiceCF1
	   //                             , InvoiceCF2
	   //                             , InvoiceCF3
	   //                             , InvoiceCF4
	   //                             , InvoiceCF5
	   //                             , InvoiceCF6
	   //                             , InvoiceCF7
	   //                             , InvoiceCF8
	   //                             , InvoiceCF9
	   //                             , InvoiceCF10
				//					, FlagConfirm
				//					, FlagCheckCustomer
	   //                             , FlagChange
	   //                             , FlagPushOutSite
	   //                             , FlagDeleteOutSite
	   //                             , InvoiceStatus
	   //                             , LogLUDTimeUTC
	   //                             , LogLUBy
    //                            )
    //                            select 
	   //                             t.InvoiceCode
	   //                             , t.MST
	   //                             , t.NetworkID
	   //                             , t.RefNo
	   //                             , t.FormNo
	   //                             , t.Sign
	   //                             , t.SourceInvoiceCode
	   //                             , t.InvoiceAdjType
	   //                             , t.PaymentMethodCode
	   //                             , t.InvoiceType2
	   //                             , t.CustomerNNTCode
	   //                             , t.CustomerNNTName
	   //                             , t.CustomerNNTAddress
	   //                             , t.CustomerNNTPhone
	   //                             , t.CustomerNNTBankName
	   //                             , t.CustomerNNTEmail
	   //                             , t.CustomerNNTAccNo
	   //                             , t.CustomerNNTBuyerName
	   //                             , t.CustomerMST
	   //                             , t.TInvoiceCode
	   //                             , t.InvoiceNo
	   //                             , t.InvoiceDateUTC
	   //                             , t.EmailSend
	   //                             , t.InvoiceFileSpec
	   //                             , t.InvoiceFilePath
	   //                             , t.InvoicePDFFilePath
	   //                             , t.TotalValInvoice
	   //                             , t.TotalValVAT
	   //                             , t.TotalValPmt
	   //                             , t.CreateDTimeUTC
	   //                             , t.CreateBy
	   //                             , t.InvoiceNoDTimeUTC
	   //                             , t.InvoiceNoBy
	   //                             , t.SignDTimeUTC
	   //                             , t.SignBy
	   //                             , t.ApprDTimeUTC
	   //                             , t.ApprBy
	   //                             , t.CancelDTimeUTC
	   //                             , t.CancelBy
	   //                             , t.SendEmailDTimeUTC
	   //                             , t.SendEmailBy
	   //                             , t.IssuedDTimeUTC
	   //                             , t.IssuedBy
	   //                             , t.AttachedDelFilePath
	   //                             , t.DeleteReason
	   //                             , t.DeleteDTimeUTC
	   //                             , t.DeleteBy
	   //                             , t.ChangeDTimeUTC
	   //                             , t.ChangeBy
	   //                             , t.InvoiceVerifyCQTCode
	   //                             , t.CurrencyCode
	   //                             , t.CurrencyRate
	   //                             , t.ValGoodsNotTaxable
	   //                             , t.ValGoodsNotChargeTax
	   //                             , t.ValGoodsVAT5
	   //                             , t.ValVAT5
	   //                             , t.ValGoodsVAT10
	   //                             , t.ValVAT10
	   //                             , t.NNTFullName
	   //                             , t.NNTFullAdress
	   //                             , t.NNTPhone
	   //                             , t.NNTFax
	   //                             , t.NNTEmail
	   //                             , t.NNTWebsite
	   //                             , t.NNTAccNo
	   //                             , t.NNTBankName
	   //                             , t.LUDTimeUTC
	   //                             , t.LUBy
	   //                             , t.Remark
	   //                             , t.InvoiceCF1
	   //                             , t.InvoiceCF2
	   //                             , t.InvoiceCF3
	   //                             , t.InvoiceCF4
	   //                             , t.InvoiceCF5
	   //                             , t.InvoiceCF6
	   //                             , t.InvoiceCF7
	   //                             , t.InvoiceCF8
	   //                             , t.InvoiceCF9
	   //                             , t.InvoiceCF10
				//					, t.FlagConfirm
				//					, t.FlagCheckCustomer
	   //                             , t.FlagChange
	   //                             , t.FlagPushOutSite
	   //                             , t.FlagDeleteOutSite
	   //                             , t.InvoiceStatus
	   //                             , t.LogLUDTimeUTC
	   //                             , t.LogLUBy
    //                            from #tbl_Invoice_Invoice_Build t --//[mylock]
    //                        ");
				//		/////
				//		string zzzzClauseInsert_Invoice_InvoiceDtl_zSave = CmUtils.StringUtils.Replace(@"
    //                            ---- Invoice_InvoiceDtl:  
    //                            insert into Invoice_InvoiceDtl(
	   //                             InvoiceCode
	   //                             , Idx
	   //                             , NetworkID
	   //                             , SpecCode
	   //                             , SpecName
	   //                             , ProductID
	   //                             , ProductName
	   //                             , VATRateCode
	   //                             , VATRate
	   //                             , UnitCode
	   //                             , UnitName
	   //                             , UnitPrice
	   //                             , Qty
	   //                             , ValInvoice
	   //                             , ValTax
	   //                             , InventoryCode
	   //                             , DiscountRate
	   //                             , ValDiscount
	   //                             , InvoiceDtlStatus
	   //                             , Remark
	   //                             , InvoiceDCF1
	   //                             , InvoiceDCF2
	   //                             , InvoiceDCF3
	   //                             , InvoiceDCF4
	   //                             , InvoiceDCF5
	   //                             , LogLUDTimeUTC
	   //                             , LogLUBy
    //                            )
    //                            select 
	   //                             t.InvoiceCode
	   //                             , t.Idx
	   //                             , t.NetworkID
	   //                             , t.SpecCode
	   //                             , t.SpecName
	   //                             , t.ProductID
	   //                             , t.ProductName
	   //                             , t.VATRateCode
	   //                             , t.VATRate
	   //                             , t.UnitCode
	   //                             , t.UnitName
	   //                             , t.UnitPrice
	   //                             , t.Qty
	   //                             , t.ValInvoice
	   //                             , t.ValTax
	   //                             , t.InventoryCode
	   //                             , t.DiscountRate
	   //                             , t.ValDiscount
	   //                             , t.InvoiceDtlStatus
	   //                             , t.Remark
	   //                             , t.InvoiceDCF1
	   //                             , t.InvoiceDCF2
	   //                             , t.InvoiceDCF3
	   //                             , t.InvoiceDCF4
	   //                             , t.InvoiceDCF5
	   //                             , t.LogLUDTimeUTC
	   //                             , t.LogLUBy
    //                            from #tbl_Invoice_InvoiceDtl_Build t
    //                        ");

				//		/////
				//		string strSqlExec = CmUtils.StringUtils.Replace(@"
				//				----
				//				zzzzClauseInsert_Invoice_Invoice_zSave			
				//				----
				//				zzzzClauseInsert_Invoice_InvoiceDtl_zSave			
				//				----
				//			"
				//			, "zzzzClauseInsert_Invoice_Invoice_zSave", zzzzClauseInsert_Invoice_Invoice_zSave
				//			, "zzzzClauseInsert_Invoice_InvoiceDtl_zSave", zzzzClauseInsert_Invoice_InvoiceDtl_zSave
				//			);
				//		////
				//		DataSet dsExec = _cf.db.ExecQuery(strSqlExec);
				//		////
				//	}
				//	#endregion
				//}
			}
			#endregion

			#region // Check One RefNo:
			if (!bIsDelete)
			{
				//myCheck_Invoice_Invoice_RefNo_New20190705(
				//	ref alParamsCoupleError // alParamsCoupleError
				//	, dtimeSys // dtimeSys
				//	, "#tbl_Invoice_Invoice_Build"  //zzzz_tbl_Invoice_Invoice_RefNo
				//	);
			}
			#endregion

			#region // myCheck_Invoice_Invoice_Total:
			if (!bIsDelete)
			{
				//myCheck_Invoice_Invoice_Total_New20190905(
				//	ref alParamsCoupleError // alParamsCoupleError
				//	, dtimeSys // dtimeSys
				//	, "#tbl_Invoice_Invoice_Build"  //zzzz_tbl_Invoice_Invoice_RefNo
				//	);
				//////
				//myCheck_Invoice_InvoiceDtl_Total_New20190905(
				//	ref alParamsCoupleError // alParamsCoupleError
				//	, dtimeSys // dtimeSys
				//	, "#tbl_Invoice_Invoice_Build"  //zzzz_tbl_Invoice_Invoice_RefNo
				//	);
			}
			#endregion

			#region // myCheck_OS_Invoice_Invoice_CheckMasterPrd:


			if (!bIsDelete)
			{
				///*Ngày 2019-08-02:
    //            * A @HuongNV chốt: Client truyền thêm 1 cờ xác nhận (FlagConfirm) check hàng hóa:
    //                + Cờ FlagConfirm chỉ truyền vào không lưu trong DB.
    //                + Nếu FlagConfirm = 1 => Không thay đổi luật check hiện tại tính đến trước ngày 2019-08-02.
    //                + Nếu FlagConfirm = 0 => Bỏ luật check các FK hàng hóa trừ SpecCode.
    //            */
				//////
				//string strFlagConfirm = dtInput_Invoice_Invoice.Rows[0]["FlagConfirm"].ToString();

				//if (CmUtils.StringUtils.StringEqual(strFlagConfirm, TConst.Flag.Active))
				//{
				//	myCheck_OS_Invoice_Invoice_CheckMasterPrd(
				//	ref alParamsCoupleError  //alParamsCoupleError
				//	, dtimeSys  //dtimeSys
				//	, strTid  //strTid
				//	, "#tbl_Invoice_Invoice_Build"  //zzzz_tbl_Invoice_Invoice_RefNo
				//	);
				//}
				//else
				//{
				//	myCheck_OS_Invoice_Invoice_CheckMasterPrd_NotConfirm(
				//	ref alParamsCoupleError  //alParamsCoupleError
				//	, dtimeSys  //dtimeSys
				//	, strTid  //strTid
				//	, "#tbl_Invoice_Invoice_Build"  //zzzz_tbl_Invoice_Invoice_RefNo
				//	);
				//}
			}
			#endregion

			#region //// Clear For Debug:
			if (!bIsDelete)
			{
				////
				string strSqlClearForDebug = CmUtils.StringUtils.Replace(@"
						---- Clear for Debug:
						drop table #input_Invoice_Invoice;
						drop table #input_Invoice_InvoiceDtl;
						drop table #tbl_Invoice_Invoice_Build;
						drop table #tbl_Invoice_InvoiceDtl_Build;
					");

				_cf.db.ExecQuery(
					strSqlClearForDebug
					);
				////
			}
			else
			{
				////
				string strSqlClearForDebug = CmUtils.StringUtils.Replace(@"
						---- Clear for Debug:
						drop table #input_Invoice_Invoice;
					");

				_cf.db.ExecQuery(
					strSqlClearForDebug
					);
				////

			}
		#endregion

		// Return Good:
		MyCodeLabel_Done:
			return;
			//TDALUtils.DBUtils.CommitSafety(_cf.db);
			//mdsFinal.AcceptChanges();
			//return mdsFinal;		
		}
	}
}
