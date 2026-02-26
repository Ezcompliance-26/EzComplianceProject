using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace DAL
{
    public partial class DLL
    {
        public async Task<DataTable> SearchReport(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Sptype", obj.ActionType),
                new SqlParameter("@ClientId",obj.ClientId), 
                new SqlParameter("@ClientSiteId",obj.ClientSiteId),
                new SqlParameter("@VendorId",obj.VendorId),
                new SqlParameter("@AuditorId",obj.AuditorId)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("EVM.USP_TBL_PartyMaster", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
      
    }
}