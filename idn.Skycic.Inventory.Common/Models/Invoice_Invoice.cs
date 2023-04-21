﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.Skycic.Inventory.Common.Models
{
    public class Invoice_Invoice
    {
        public object InvoiceCode { get; set; } // Số tra cứu
        public object MST { get; set; } // Mã số thế
        public object NetworkID { get; set; } // NetworkID
        public object RefNo { get; set; } // RefNo
        public object FormNo { get; set; } // Mẫu số
        public object Sign { get; set; } // Ký hiệu
        public object SourceInvoiceCode { get; set; } // Nguồn hóa đơn
        public object InvoiceAdjType { get; set; } // Loại điều chỉnh
        public object PaymentMethodCode { get; set; } // Phương thức thanh toán
        public object InvoiceType2 { get; set; } // Loại hóa đơn (DMS, null,....)
        public object InvoiceDateUTC { get; set; } // ngày hóa đơn
        public object CustomerNNTCode { get; set; } // Mã khách hàng NNT
        public object CustomerNNTName { get; set; } // Tên khách hàng
        public object CustomerNNTAddress { get; set; } // địa chỉ
        public object CustomerNNTPhone { get; set; } // Số điện thoại
        public object CustomerNNTBankName { get; set; } // Tên ngân hàng
        public object CustomerNNTEmail { get; set; } // email khách hàng
        public object CustomerNNTAccNo { get; set; } // số tài khoản khách hàng
        public object CustomerNNTBuyerName { get; set; } // Tên người mua
        public object CustomerMST { get; set; } // Mã số thuế
        public object TInvoiceCode { get; set; } // Mẫu hóa đơn
        public object InvoiceNo { get; set; } // Số hóa đơn
        public object EmailSend { get; set; } // Email Send        
        public object InvoiceFileSpec { get; set; } // Nội dung hóa đơn
        public object InvoiceFilePath { get; set; } // Đường dẫn hóa đơn
        public object InvoicePDFFilePath { get; set; } // Đường file PDF dẫn hóa đơn
        public object TotalValInvoice { get; set; } // Tổng tiền hàng
        public object TotalValVAT { get; set; }  // Tổng tiền thuế
        public object TotalValPmt { get; set; }  // Tiền thanh toán
        public object CreateDTimeUTC { get; set; }  // Ngày tạo hóa đơn
        public object CreateBy { get; set; } // Người tạo hóa đơn 
        public object InvoiceNoDTimeUTC { get; set; } // Ngày nhập số hóa đơn
        public object InvoiceNoBy { get; set; } // Người ấn cấp số
        public object SignDTimeUTC { get; set; } // Thời gian ký hóa đơn
        public object SignBy { get; set; } // Người ký hóa đơn
        public object ApprDTimeUTC { get; set; } // thời gain duyệt hóa đơn
        public object ApprBy { get; set; } // người duyệt hóa đơn
        public object CancelDTimeUTC { get; set; } // Thời gian hủy hóa đơn
        public object CancelBy { get; set; } // Người hủy hóa đơn
        public object SendEmailDTimeUTC { get; set; } // Thời gian send email
        public object SendEmailBy { get; set; } // Người send Email
        public object IssuedDTimeUTC { get; set; } // Thời gian chấp thuận
        public object IssuedBy { get; set; } // Người chấp thuận
        public object DeleteDTimeUTC { get; set; } // Thời gian delete
        public object DeleteBy { get; set; } // Người delete
        public object AttachedDelFilePath { get; set; } // File hủy đính kèm
        public object DeleteReason { get; set; } // Lý do hủy
        public object ChangeDTimeUTC { get; set; } // Thời gian in chuyển đổi
        public object ChangeBy { get; set; } // Người in chuyển đổi
        public object InvoiceVerifyCQTCode { get; set; } // Mã xác thực CQT
        public object CurrencyCode { get; set; } // Người in chuyển đổi
        public object CurrencyRate { get; set; } // Người in chuyển đổi
        public object ValGoodsNotTaxable { get; set; } // Người in chuyển đổi
        public object ValGoodsNotChargeTax { get; set; } // Người in chuyển đổi
        public object ValGoodsVAT5 { get; set; } // Người in chuyển đổi
        public object ValVAT5 { get; set; } // Người in chuyển đổi
        public object ValGoodsVAT10 { get; set; } // Người in chuyển đổi
        public object ValVAT10 { get; set; } // Người in chuyển đổi
        public object NNTFullName { get; set; } // Tên người nộp thuế
        public object NNTFullAdress { get; set; } // địa chỉ người nộp thuế
        public object NNTPhone { get; set; } // Điện thoại cố định người nộp thuế
        public object NNTFax { get; set; } // Fax người nộp thuế
        public object NNTEmail { get; set; } // Email người nộp thuế
        public object NNTWebsite { get; set; } // website người nộp thuế
        public object NNTAccNo { get; set; } // Số tài khoản ngân hàng NNT
        public object NNTBankName { get; set; } // Tên ngân hàng NNT
        public object LUDTimeUTC { get; set; }
        public object LUBy { get; set; }
        public object Remark { get; set; }
        public object InvoiceCF1 { get; set; } // InvoiceCF1
        public object InvoiceCF2 { get; set; } // InvoiceCF2
        public object InvoiceCF3 { get; set; } // InvoiceCF3
        public object InvoiceCF4 { get; set; } // InvoiceCF4
        public object InvoiceCF5 { get; set; } // InvoiceCF5
        public object InvoiceCF6 { get; set; } // InvoiceCF6
        public object InvoiceCF7 { get; set; } // InvoiceCF7
        public object InvoiceCF8 { get; set; } // InvoiceCF8
        public object InvoiceCF9 { get; set; } // InvoiceCF9
        public object InvoiceCF10 { get; set; } // InvoiceCF10
        public object InvoiceStatus { get; set; } // trạng thái hóa đơn
        public object FlagChange { get; set; } // trạng thái hóa đơn in chuyển đổi (1 là chưa in, 0 là đã in)
        public object FlagConfirm { get; set; } // trạng thái xác nhận dữ liệu - Check Product
		public object FlagCheckCustomer { get; set; } // trạng thái Check Customer
		public object FlagPushOutSite { get; set; } // trạng thái hóa đơn
        public object FlagDeleteOutSite { get; set; } // Trạng thái đẩy Delete Sang 3 A
        public object LogLUDTimeUTC { get; set; } // Thời gian cập nhật cuối cùng
        public object LogLUBy { get; set; } // Người cập nhật cuối cùng

        //public object mcnnt_CustomerNNTCode { get; set; }
        //public object mcnnt_CustomerNNTName { get; set; }
        //public object mcnnt_CustomerNNTAddress { get; set; }
        //public object mcnnt_CustomerMST { get; set; }
        //public object mcnnt_CustomerNNTEmail { get; set; }
        //public object mcnnt_ContactEmail { get; set; }

        //public object mpm_PaymentMethodCode { get; set; }
        public object mpm_PaymentMethodName { get; set; }

        //public object iti_TInvoiceCode { get; set; }
        //public object iti_TInvoiceName { get; set; }
        public object iti_LogoFilePath { get; set; }
        public object iti_WatermarkFilePath { get; set; }
        public object iti_InvoiceTGroupCode { get; set; }
        public object iti_InvoiceType { get; set; }
        //public object iti_Sign { get; set; }
        //public object iti_FormNo { get; set; }

        public object itg_InvoiceTGroupCode { get; set; }
        public object itg_Spec_Prd_Type { get; set; }

        public object itg_VATType { get; set; }

        public object ValInvoice { get; set; }

        public object InvoiceFileEncodeBase64 { get; set; }

        public object MailSentDTimeUTC { get; set; }

        ////2019-09-25
        public object Invoice_Idx { get; set; }

        public object MailSentDateTime { get; set; }

        //FlagResult: 0, 1, 2
        // 0: tinh toan thu loi => bo qua khong truyen cho Biz;
        // 1: tinh toan thu thanh cong => truyen cho Biz (ket qua thanh cong)
        // 2: tinh toan thu thanh cong => truyen cho Biz (ket qua KO thanh cong)
        public object FlagResult { get; set; }

        public object FlagIsCheckInvoiceTotal { get; set; }
    }
}
