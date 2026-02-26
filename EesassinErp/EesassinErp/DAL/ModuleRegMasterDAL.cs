using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BAL;
using System.Text;
using System.IO;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using EesassinErp.BAL;

namespace DAL
{
    public partial class DLL
    {
        public async static Task<DataTable> GetSearchModuleReg(TblModuleRegMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_Module_Reg_Master", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<string> InsertUpdateDelModuleRegMaster(TblModuleRegMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@UserId", obj.userid),
                new SqlParameter("@Module_Name", obj.Module_Name),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Start_Date", obj.Start_Date),
                new SqlParameter("@End_Date",obj.End_Date),
                new SqlParameter("@IsActive",obj.IsActive),
                new SqlParameter("@IsApproval",obj.IsApproval),
                new SqlParameter("@IsDeleted",obj.IsDeleted),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_Module_Reg_Master", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> GetSearchModuleMappingMaster(TblModuleMappingMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_Module_Mapping_Master", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<string> InsertUpdateDelModuleMappingMaster(TblModuleMappingMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@UserId", obj.userid),
                new SqlParameter("@Module_Reg_Id", obj.Module_Reg_Id),
                new SqlParameter("@Party_Id", obj.Party_Id),
                new SqlParameter("@Party_Type_ID", obj.Party_Type_Id),
                new SqlParameter("@IsActive",obj.IsActive),
                new SqlParameter("@IsApproval",obj.IsApproval),
                new SqlParameter("@IsDeleted",obj.IsDeleted),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_Module_Mapping_Master", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<string> InsertUpdateDelRoleMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@PartyType", obj.PartyType),
                    new SqlParameter("@PartyId", obj.PartyId),
                    new SqlParameter("@UserId", obj.UserId),
                    new SqlParameter("@RoleName", obj.PartyName),
                    new SqlParameter("@Description", obj.Description),
                    new SqlParameter("@CreatedBy", obj.CreatedBy),
                    new SqlParameter("@StartDate", obj.StartDate),
                    new SqlParameter("@EndDate", obj.EndDate),
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@GradeId", obj.GradeId),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_RoleMaster]", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<DataTable> SearchRoleMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_RoleMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }



        public async static Task<string> InsertUpdateDelGradeMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@PartyType", obj.PartyType),
                    new SqlParameter("@PartyId", obj.PartyId),
                    new SqlParameter("@GradeName", obj.PartyName),
                    new SqlParameter("@Sequence ", obj.Attribute1),
                    new SqlParameter("@Description", obj.Description),
                    new SqlParameter("@CreatedBy", obj.CreatedBy),
                    new SqlParameter("@StartDate", obj.StartDate),
                    new SqlParameter("@EndDate", obj.EndDate),
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_GradeMaster]", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<DataTable> SearchGradeMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@PartyId", obj.PartyId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_GradeMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<DataTable> GetLicenseMasterDocumentList()
        {

            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteSelectCommand("RTL.GetLicenseMasterDocumentList", CommandType.StoredProcedure));
            return dt;
        }

        public async static Task<string> InsertUpdateDelLicenseMasterDocumentList(RetailLicenseDocuementMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@LicenseId", obj.LicenseId),
                    new SqlParameter("@PermissionId", obj.PermissionId),
                    new SqlParameter("@ActionType", obj.ActionType),
                    new SqlParameter("@PartyTypeId", obj.PartyTypeId),
                     new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@selectedUsersList", obj.selectedUsersList),
                    new SqlParameter("@LicenseName ", obj.LicenseName),
                    new SqlParameter("@selectedDocumentsList", obj.selectedDocumentsList),
                    new SqlParameter("@CreatedBy", obj.CreatedBy),
                    new SqlParameter("@StartDate", obj.StartDate),
                    new SqlParameter("@EndDate", obj.EndDate),
                    new SqlParameter("@LicenseMasterType", obj.LicenseMasterType),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_RetailLicenseDocuementMaster]", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> SearchLicenseDocumentMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@ActionType", obj.ActionType),
                new SqlParameter("@LicenseId", obj.Id),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_RetailLicenseDocuementMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }


        public async static Task<DataTable> GetStore(RetialStoreManager obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@Id",obj.Id),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_StoreMaster", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }


        public async static Task<string> InsertUpdateDelStoreMapping(RetailLicenseDocuementMaster obj)
        {
            StringBuilder DocumentList = new StringBuilder();
             
            string bigseprator = "";
            for (int i = 0; i < obj.DocumentList.Count; i++)
            {
                DocumentList.Append(bigseprator);
                DocumentList.Append(obj.DocumentList[i].StoreId); 
                bigseprator = "|";
            } 
           
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreList", DocumentList.ToString()),
                new SqlParameter("@PartyId", obj.PartyId),
                new SqlParameter("@UserId", obj.UserId),
                new SqlParameter("@PartyTypeId", obj.PartyTypeId),
                new SqlParameter("@CreatedBy", obj.CreatedBy),
                new SqlParameter("@StartDate", obj.StartDate),
                new SqlParameter("@EndDate", obj.EndDate),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_StoreMapping]", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> SearchStoreMapping(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@UserId", obj.PartyId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_StoreMapping]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string>  DelStorePrefix(StorePrefix obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Id", obj.Id), 
                    new SqlParameter("@Action", obj.Action),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_StorePrefix]", CommandType.StoredProcedure, param.ToArray()));
        }



        public async static Task<string> InsertUpdateDelStorePrefix(StorePrefix obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@PartyId", obj.PartyTypeId),
                    new SqlParameter("@Prefix", obj.Prefix),
                    new SqlParameter("@Suffix ", obj.Suffix),
                    new SqlParameter("@StartDate", obj.StartDate),
                    new SqlParameter("@EndDate", obj.EndDate),
                    new SqlParameter("@UserId", obj.LoginId),
                    new SqlParameter("@Action", obj.Action),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_StorePrefix]", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<DataTable> SearchStorePrefix(StorePrefix obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_StorePrefix]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        #region Department Master
        public async static Task<string> InsertUpdateDelDepartmentMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@DepartmentId", obj.Id),
                    new SqlParameter("@PartyType", obj.PartyType),
                    new SqlParameter("@PartyId", obj.PartyId),
                    new SqlParameter("@DepartmentName", obj.PartyName),
                    new SqlParameter("@Description", obj.Description),
                    new SqlParameter("@CreatedBy", obj.CreatedBy),
                    new SqlParameter("@StartDate", obj.StartDate),
                    new SqlParameter("@EndDate", obj.EndDate),
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_DepartmentMaster]", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> SearchDepartmentMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_DepartmentMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        #endregion
        #region StoreComplianceStatus Master 
        public async static Task<string> InsertUpdateDelStoreComplianceStatusMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@StoreComplinaceStatusType", obj.PartyName),
                    new SqlParameter("@CreatedBy", obj.CreatedBy),
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_StoreComplianceStatusMaster]", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> SearchStoreComplianceStatusMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                 new SqlParameter("@Id", obj.Id),
                   new SqlParameter("@StoreId", obj.StoreId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_StoreComplianceStatusMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        #endregion
        #region Retail Department Master
        public async static Task<string> InsertUpdateDelRetailDocumentMaster(DocumentBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@DocumentName", obj.DocumentName),
                new SqlParameter("@DocumentType", obj.DocumentType),
                new SqlParameter("@Frequency", obj.Frequency),
                new SqlParameter("@FormatType", obj.FormatType),
                new SqlParameter("@Note", obj.Note),
                new SqlParameter("@Act", obj.Act),
                new SqlParameter("@IsDefault", obj.IsDefault),
                new SqlParameter("@Createdby", obj.Createdby), 
                new SqlParameter("@Updatedby", obj.Updatedby),
                new SqlParameter("@UpdatedON", obj.UpdatedON),
                new SqlParameter("@Isdelete", obj.Isdelete),
                new SqlParameter("@Result",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_RetailDocumentMaster]", CommandType.StoredProcedure, param.ToArray()));

        }

        public async static Task<DataTable> SearchRetailDocumentMaster(DocumentBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_RetailDocumentMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        #endregion
    }
}
 