using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL
{
    [Serializable]
    public class DocumentBAL
    {
        public string ClientId { get; set; }
        public string VendorId { get; set; }
        public string AuditorId { get; set; }
        public string Act { get; set; }
        public string Form { get; set; }
        public string Nature { get; set; }
        public string Remark { get; set; }

        public string Score { get; set; }
        public string DocumentId { get; set; }
        public string FileDoc { get; set; }
        public string VaildFrom { get; set; }
        public string VaildTo { get; set; }
        public string Description { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string Frequency { get; set; }

        public string FormatType { get; set; }
        public string Note { get; set; }
        public string IsDefault { get; set; }
        public string CreatedOn { get; set; }
        public string Createdby { get; set; }

        public string Updatedby { get; set; }
        public string UpdatedON { get; set; }
        public string Isdelete { get; set; }
        public string  Id { get; set; }

        public string Action { get; set; }

        public string InvoiceNo { get; set; }

        public string ConversationId { get; set; }

        public string SNO { get; set; }
        public string Conversation { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Document1 { get; set; }
        public string Document2 { get; set; }
        public string Document3 { get; set; }
        public string Document4 { get; set; }
        public string Document5 { get; set; }
        public string ComplianceId { get; set; }
        public string AuditorQuery { get; set; }
        public string VendorQuery { get; set; }
        public string extention { get; set; }


        public string ComplianceDetailStr { get; set; }
        public List<ComplianceDetailList> ComplianceDetail { get; set; }
    }
    public class ComplianceDetailList
    {
        public string SrNo { get; set; }
        public string DocId { get; set; }
        public string ComplianceId { get; set; }
        public string InvoiceNo { get; set; }
        public string Form { get; set; }
        public string ComplianceScore { get; set; }
        public string ComplianceScoreAchieved { get; set; }
        public string CompalianceStatus { get; set; }
        public string Remark { get; set; }
        public string VendorRemark { get; set; }
    }
  
}