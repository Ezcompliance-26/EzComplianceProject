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
        public DataTable FireEmail(DocumentBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
                 new SqlParameter("@EmailId", obj.ClientId),
                  new SqlParameter("@Id", obj.Id)
            };
            return SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[dbo].[USP_EmailMaster]", CommandType.StoredProcedure, param.ToArray());

        }
    }
}