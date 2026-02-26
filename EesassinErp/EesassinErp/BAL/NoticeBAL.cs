using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EesassinErp.BAL
{
    public class NoticeBAL
    {
        public string Id { get; set; }
        public string LoginAs { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string StoreId { get; set; }
        public string DepartmentId { get; set; }
        public string NoticeUpload { get; set; }
        public string ReceiptDate { get; set; }
        public string ExecuterId { get; set; }
        public string ExecuterStoreId { get; set; }
        public string ExecuterDepartmentId { get; set; }
        public string ExecuterNoticeUpload { get; set; }
        public string ExecuterReceiptDate { get; set; }
        public string SubmitionbyExecuter { get; set; }
        public string FinalSubmittionbyExecuter { get; set; }
        public string CloserSubmittionbyExecuter { get; set; }
        public string CreatedOn { get; set; }
        public string Createdby { get; set; }
        public string Result { get; set; }
    }
}