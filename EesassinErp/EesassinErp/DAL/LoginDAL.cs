using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAL;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
    public partial class DLL
    {
        public static readonly DLL dll = new DLL();
        public DataTable LoginVerify(LoginBAL obj)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            { 
                new SqlParameter("@UserName",obj.UserName),
                new SqlParameter("@Password",obj.Password),
                new SqlParameter("@Action",obj.Action)
            };
            return SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("USP_LoginTable", CommandType.StoredProcedure, param.ToArray());
        }

        public async Task<DataTable> GetUrlAccessPermission(BCommon obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@LoginId", obj.LoginId),
                    new SqlParameter("@BranchCode",obj.BranchCode),
                    new SqlParameter("@MenuId",obj.MenuId),
                    new SqlParameter("@Action", 4)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("USP_UrlAccessPermission", CommandType.StoredProcedure, param.ToArray()));

            return dt;
        }
        public async Task<DataTable> GetModulePermission(BCommon obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@LoginId", obj.LoginId),
                    new SqlParameter("@UserName",obj.UserName), 
                    new SqlParameter("@Action", obj.Action)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[dbo].[USP_LoginTable]", CommandType.StoredProcedure, param.ToArray()));

            return dt;
        }
    }
}