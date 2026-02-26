using BAL;
using EesassinErp.BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace DAL
{
    public partial class DLL
    {
        public async static Task<string> InsertUpdateDelEmployeeMaster(RetialEmployeeManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@PartyTypeId",obj.PartyTypeId),
                new SqlParameter("@PartyId",obj.PartyId),
                new SqlParameter("@UserId",obj.UserId),
                new SqlParameter("@SuperVisior1",obj.SuperVisior1),
                new SqlParameter("@SuperVisior2",obj.SuperVisior2),
                      new SqlParameter("@EmployeeCode",obj.EmployeeCode),
                new SqlParameter("@EmployeeName",obj.EmployeeName),
                new SqlParameter("@EmployeeDesignation",obj.EmployeeDesignation),
                new SqlParameter("@EmployeeDepartment",obj.EmployeeDepartment),
                new SqlParameter("@Father_Husband_Name",obj.Father_Husband_Name),
                new SqlParameter("@Gendar",obj.Gendar),
                new SqlParameter("@MaritalStatus",obj.MaritalStatus),
                new SqlParameter("@DateOfBirth",obj.DateOfBirth),
                new SqlParameter("@PresentAddress",obj.PresentAddress),
                new SqlParameter("@PermanemtAddress",obj.PermanemtAddress),
                new SqlParameter("@AdharCardNumber",obj.AdharCardNumber),
                new SqlParameter("@PANNumber",obj.PANNumber),
                new SqlParameter("@MobileNumber",obj.MobileNumber),
                new SqlParameter("@AlternativeMobileNumber",obj.AlternativeMobileNumber),
                new SqlParameter("@EmployeeEmailID",obj.EmployeeEmailID),
                new SqlParameter("@BankAccountNumber",obj.BankAccountNumber),
                new SqlParameter("@BankIFSCCode",obj.BankIFSCCode),
                new SqlParameter("@PreviousUAN",obj.PreviousUAN),
                new SqlParameter("@PreviousESI",obj.PreviousESI),
                new SqlParameter("@GrossSalary",obj.GrossSalary),
                new SqlParameter("@DOJ",obj.DOJ),
                new SqlParameter("@NomineeName",obj.NomineeName),
                new SqlParameter("@NomineeAddress",obj.NomineeAddress),
                new SqlParameter("@NomineeRelation",obj.NomineeRelation),
                new SqlParameter("@NomineeDOB",obj.NomineeDOB),
                new SqlParameter("@StoreCode",obj.StoreCode),
                new SqlParameter("@Status",obj.Status),
                new SqlParameter("@PANCardFilePath",obj.PANCardFilePath),
                new SqlParameter("@Cheque_Passbook_FilePath", obj.Cheque_Passbook_FilePath),
                new SqlParameter("@EducationCertificateFilePath", obj.EducationCertificateFilePath),
                new SqlParameter("@ExperienceCertificateFilePath", obj.ExperienceCertificateFilePath),
                new SqlParameter("@AdhaarCard_FrontSide_FilePath", obj.AdhaarCard_FrontSide_FilePath),
                new SqlParameter("@AdhaarCard_BackSide_FilePath", obj.AdhaarCard_BackSide_FilePath),
                new SqlParameter("@RelievingLetterfFilePath", obj.RelievingLetterfFilePath),
                new SqlParameter("@PayslipsFilePath", obj.PayslipsFilePath),
                new SqlParameter("@Photos_1_FilePath", obj.Photos_1_FilePath),
                new SqlParameter("@Photos_2_FilePath", obj.Photos_2_FilePath),
                new SqlParameter("@Photos_3_FilePath", obj.Photos_3_FilePath),
                new SqlParameter("@Photos_4_FilePath", obj.Photos_4_FilePath),
                new SqlParameter("@UserIds", obj.LoginId),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_EmployeeMaster", CommandType.StoredProcedure, param.ToArray()));
        }


        public async static Task<DataTable> GetEmployeeMaster(RetialEmployeeManager obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@Id",obj.Id),
                    new SqlParameter("@PartyId",obj.PartyId),
                    new SqlParameter("@UserId",obj.UserId),
                    new SqlParameter("@SuperVisior1",obj.SuperVisior1),
                    new SqlParameter("@SuperVisior2",obj.SuperVisior2),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_EmployeeMaster", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }




        public async static Task<string> UpdateDocumentForEmployee(string fieldName, string filePath, int Id, int LoginId)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", 5),
                new SqlParameter("@Id",Id),
                new SqlParameter("@"+fieldName,filePath),
                new SqlParameter("@UserId", LoginId),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_EmployeeMaster", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<string> UpdateEmpStatus(RetialEmployeeManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", 9),
                new SqlParameter("@Status",obj.Status),
               new SqlParameter("@Id",obj.Id),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_EmployeeMaster", CommandType.StoredProcedure, param.ToArray()));
        }


        public async static Task<string> UpdateStatus(RetialStoreManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@IsActive",obj.IsActive),
               new SqlParameter("@StoreCode",obj.StoreCode),
                new SqlParameter("@DocumentName",obj.DocumentName),
                new SqlParameter("@UFile",obj.AdditionalDoc),
                 new SqlParameter("@Createdby",obj.LoginId),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_StoreMaster", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> GetStoreMaster(RetialStoreManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@StoreCode",obj.StoreCode)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_StoreMaster", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<DataTable> GetMasters(tblMasters obj)
        {

            var param = new List<SqlParameter>
            {
                new SqlParameter("@action",obj.Action),
                new SqlParameter("@parentId",obj.ParentId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.GetMasters", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<DataTable> GetStoreCodeNumber(tblMasters obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@PartyId",obj.PartyTypeId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_GetStoreCodeNumber", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> UpdateStoresStatus(StoreStatusList obj)
        {
            var selectedStores = obj.selectedStores;
            var isActive = obj.isActive;
            var storeIdList = string.Join(",", selectedStores);


            string commandText = $"UPDATE [RTL].[StoreMaster] SET IsActive = @IsActive WHERE Id IN ({storeIdList})";

            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@IsActive", isActive)
            };

            // Execute the command
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters));
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(new { success = true, message = "Store status updated successfully." });
            }
            else
            {
                return JsonConvert.SerializeObject(new { success = false, message = "No stores were updated." });
            }

        }


        public async static Task<string> InsertUpdateDelStoreMaster(RetialStoreManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@PartyTypeId",0),
                new SqlParameter("@SequenceNumber",0),
                new SqlParameter("@StoreCode",""),
                new SqlParameter("@RefStoreCode",obj.RefStoreCode),
                new SqlParameter("@StoreName",obj.StoreName),
                new SqlParameter("@CompleteAddress",obj.CompleteAddress),
                new SqlParameter("@ProposedDate",obj.ProposedDate),
                new SqlParameter("@StoreLocation",obj.StoreLocation),
                new SqlParameter("@CityId",obj.CityId),
                new SqlParameter("@CircleId",obj.CircleId),
                new SqlParameter("@RegionId",obj.RegionId),
                new SqlParameter("@zipCode",obj.ZipCode),
                new SqlParameter("@StoreManagerName",obj.StoreManagerName),
                new SqlParameter("@StoreManagerMobileNo",obj.StoreManagerMobileNo),
                new SqlParameter("@StoreManagerEmail",obj.StoreManagerEmail),
                new SqlParameter("@AreaManagerName",obj.AreaManagerName),
                new SqlParameter("@AreaManagerMobileNo",obj.AreaManagerMobileNo),
                new SqlParameter("@AreaManagerEmail",obj.AreaManagerEmail),
                new SqlParameter("@ZonalManagerName",obj.ZonalManagerName),
                new SqlParameter("@ZonalManagerMobileNo",obj.ZonalManagerMobileNo),
                new SqlParameter("@ZonalManagerEmail",obj.ZonalManagerEmail),
                new SqlParameter("@CircleHeadName",obj.CircleHeadName),
                new SqlParameter("@CircleHeadMobileNo",obj.CircleHeadMobileNo),
                new SqlParameter("@CircleHeadEmail",obj.CircleHeadEmail),
                new SqlParameter("@RegionalHeadName",obj.RegionalHeadName),
                new SqlParameter("@RegionalHeadMobileNo",obj.RegionalHeadMobileNo),
                new SqlParameter("@RegionalHeadEmail",obj.RegionalHeadEmail),
                new SqlParameter("@CorporateHeadName", obj.CorporateHeadName),
                new SqlParameter("@CorporateHeadMobileNo", obj.@CorporateHeadMobileNo),
                new SqlParameter("@CorporateHeadEmail", obj.CorporateHeadEmail),
                new SqlParameter("@SQFTStoreArea", obj.SQFTStoreArea),
                new SqlParameter("@IsActive", obj.IsActive),
                new SqlParameter("@ElectricityBill", obj.ElectricityBill),
                new SqlParameter("@RentAgreement", obj.RentAgreement),
                new SqlParameter("@PropertyTaxPaidReceipt", obj.PropertyTaxPaidReceipt),
                new SqlParameter("@BuildingPlan", obj.BuildingPlan),
                 new SqlParameter("@StabilityStructureCertificate", obj.StabilityStructureCertificate),
                new SqlParameter("@CompletionCertificate", obj.CompletionCertificate),
                new SqlParameter("UserId", obj.LoginId),
                  new SqlParameter("DaysOfExpire", obj.DaysOfExpire),
                 new SqlParameter("@Category",obj.Category),
                new SqlParameter("@ElectricityBillPeriodUpTo", obj.ElectricityBillPeriodUpTo),
                new SqlParameter("@LeasePaidReceiptPeriodUpTo", obj.LeasePaidReceiptPeriodUpTo),
                new SqlParameter("@PropertyTaxPeriodUpTo", obj.PropertyTaxPeriodUpTo),
                new SqlParameter("@FireNocPeriodUpTo", obj.FireNocPeriodUpTo),
                new SqlParameter("@PollutionPeriodUpTo", obj.PollutionPeriodUpTo),
                new SqlParameter("@OwnershipDocPeriodUpTo", obj.OwnershipDocPeriodUpTo),
                new SqlParameter("@AdditionalDocPeriodUpTo", obj.AdditionalDocPeriodUpTo),
                new SqlParameter("@LeaseFromDate", obj.LeaseFromDate),
                new SqlParameter("@ElectricityBillRemark", obj.ElectricityBillRemark),
                new SqlParameter("@LeasePaidReceiptRemark", obj.LeasePaidReceiptRemark),
                new SqlParameter("@PropertyTaxRemark", obj.PropertyTaxRemark),
                new SqlParameter("@FireNocRemark", obj.FireNocRemark),
                new SqlParameter("@PollutionRemark", obj.PollutionRemark),
                new SqlParameter("@OwnershipDocRemark", obj.OwnershipDocRemark),
                new SqlParameter("@AdditionalDocRemark", obj.AdditionalDocRemark),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_StoreMaster", CommandType.StoredProcedure, param.ToArray()));
        }


        public async static Task<DataTable> GenerateEmployeeCode(tblMasters obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@PartyId",obj.PartyTypeId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_GetEmployeeCodeNumber", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }


        public async static Task<DataTable> GetLicenseMaster(RetailLicenseDocuementMaster obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@ActionType", obj.ActionType),
              new SqlParameter("@LoginId",obj.LoginId),
              new SqlParameter("@LicenseId",obj.LicenseId),
              new SqlParameter("@StoreId",obj.StoreId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_GetRetailLicenseDocuementMaster", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }



        public async static Task<string> UploadDoc(StoreLicesensDocument obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreId",obj.StoreId),
                new SqlParameter("@UFile",obj.UFile),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_StoreLicences", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<string> UploadComplianceDoc(StoreLicesensDocument obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@DId",obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@DocumentPath",obj.UFile),
                new SqlParameter("@UserId",obj.LoginId),
                 new SqlParameter("@Verify",obj.Verify),
                new SqlParameter("@StoreId",obj.StoreId),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_ROLEMANAGE", CommandType.StoredProcedure, param.ToArray()));
        }



        public async static Task<string> InsertUpdateDelStoreDocumentMaster(StoreLicesensDocument obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreId",obj.StoreId),
                new SqlParameter("@LicenseId",obj.LicenseId),
                new SqlParameter("@LoginId",obj.LoginId),
                new SqlParameter("@DName",obj.DName),
                new SqlParameter("@DFatherName",obj.DFatherName),
                new SqlParameter("@DAddress",obj.DAddress),
                new SqlParameter("@DAadhaarNo",obj.DAadhaarNo),
                new SqlParameter("@DPanNo",obj.DPanNo),
                new SqlParameter("@DDateOfBirth",obj.DDateOfBirth),
                new SqlParameter("@DEmailId",obj.DEmailId),
                new SqlParameter("@DMobileNo",obj.DMobileNo),
                new SqlParameter("@AName",obj.AName),
                new SqlParameter("@AFatherName",obj.AFatherName),
                new SqlParameter("@AAddress",obj.AAddress),
                new SqlParameter("@AAadhaarNo",obj.AAadhaarNo),
                new SqlParameter("@APanNo",obj.APanNo),
                new SqlParameter("@ADateOfBirth",obj.ADateOfBirth),
                new SqlParameter("@AEmailId",obj.AEmailId),
                new SqlParameter("@AMobileNo",obj.AMobileNo),
                new SqlParameter("@NatureofBusiness",obj.NatureofBusiness),
                new SqlParameter("@DateofCommencement",obj.DateofCommencement),
                new SqlParameter("@ProductCategory",obj.ProductCategory),
                new SqlParameter("@AadhaarRegisteredofficeAddressNo",obj.AadhaarRegisteredofficeAddressNo),
                new SqlParameter("@AadhaarCardofDirector",obj.AadhaarCardofDirector),
                new SqlParameter("@PANCardofDirector", obj.PANCardofDirector),
                new SqlParameter("@PassportSizePhoto1", obj.PassportSizePhoto1),
                new SqlParameter("@AuthorizationLetter", obj.AuthorizationLetter),
                new SqlParameter("@AadhaarCardofAuthorized", obj.AadhaarCardofAuthorized),
                new SqlParameter("@PANCard", obj.PANCard),
                new SqlParameter("@PassportSizePhoto2", obj.PassportSizePhoto2),
                new SqlParameter("@ElectricityBill", obj.ElectricityBill),
                new SqlParameter("@SaledeedRentAgreement", obj.SaledeedRentAgreement),
                new SqlParameter("@FSMSPlan", obj.FSMSPlan),
                new SqlParameter("@FormIX", obj.FormIX),
                new SqlParameter("@WaterTestReport", obj.WaterTestReport),
                new SqlParameter("@IsSaved", obj.IsActive),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_StoreLicences", CommandType.StoredProcedure, param.ToArray()));
        }



        public async static Task<DataSet> GetStoreDocumentDetails(StoreLicesensDocument obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@Id", obj.Id),
              new SqlParameter("@Action",obj.ActionType),
              new SqlParameter("@StoreId",obj.StoreId),
              new SqlParameter("@LicenseId",obj.LicenseId),
              new SqlParameter("@LoginId",obj.LoginId),
            };
            DataSet dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommandds("RTL.Usp_StoreLicences", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }


        public async static Task<string> ApproveLicense(StoreLicesensDocument obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreId",obj.StoreId),
                new SqlParameter("@LicenseId",obj.LicenseId),
                new SqlParameter("@LoginId",obj.LoginId),

                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Usp_StoreLicences", CommandType.StoredProcedure, param.ToArray()));
        }


        public async static Task<DataTable> LicenseRequestData(LicenseRequest obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@userId",obj.UserId),
                new SqlParameter("@Action",obj.Action),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_LicenceRequest", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }


        public async static Task<DataTable> GetStatusMaster(tblMasters obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@keyName",obj.Name),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_GetStatusMaster", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> InsertUpdateDelLicenseRequest(LicenseRequest obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@userId",obj.UserId),
                new SqlParameter("@Action", obj.Action),
                 //new SqlParameter("@StoreCode", obj.StoreCode),
                new SqlParameter("@LicenceRequestId",obj.LicenceRequestId),
                new SqlParameter("@ApplicationStatus",obj.ApplicationStatus),
                new SqlParameter("@ApplicationDate",obj.ApplicationDate),
                new SqlParameter("@UploadApplicationCopy",obj.UploadApplicationCopy),
                new SqlParameter("@UploadChallanCopy",obj.UploadChallanCopy),
                new SqlParameter("@UploadFeesCopy",obj.UploadFeesCopy),
                new SqlParameter("@LicenseStatus",obj.LicenseStatus),
                new SqlParameter("@LicenseDate",obj.LicenseDate),
                new SqlParameter("@LicenseNumber",obj.LicenseNumber),
                new SqlParameter("@ValidityStartDate",obj.ValidityStartDate),
                new SqlParameter("@ValidityEndDate",obj.ValidityEndDate),
                new SqlParameter("@UploadLicenseCopy",obj.UploadLicenseCopy),
                new SqlParameter("@RenewalStatus",obj.RenewalStatus),
                new SqlParameter("@RenewalStartDate",obj.RenewalStartDate),
                new SqlParameter("@RenewalEndDate",obj.RenewalEndDate),
                new SqlParameter("@UploadRenewedCopy",obj.UploadRenewedCopy),
                new SqlParameter("@UserName",obj.UserName),
                new SqlParameter("@UserPassword",obj.UserPassword),
                new SqlParameter("@MobileNumber",obj.MobileNumber),
                new SqlParameter("@EmailId",obj.EmailId),
                new SqlParameter("@TentativeDateofComp",obj.TentativeDateofComp),
                new SqlParameter("@InvoiceStatus",obj.InvoiceStatus),
                new SqlParameter("@InvoiceDate",obj.InvoiceDate),
                new SqlParameter("@InvoiceNo",obj.InvoiceNo),
                new SqlParameter("@InvoiceAmount", obj.InvoiceAmount),
                new SqlParameter("@UploadInvoice", obj.UploadInvoice),
                new SqlParameter("@PaymentStatus", obj.PaymentStatus),
                new SqlParameter("@PaymentTAT", obj.PaymentTAT),
                new SqlParameter("@PaymentDueDate", obj.PaymentDueDate),
                new SqlParameter("@PaymentOverDueDate", obj.PaymentOverDueDate),
                new SqlParameter("@Result",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_LicenceRequest", CommandType.StoredProcedure, param.ToArray()));
        }

        #region GetStoreDataBySearch
        public async static Task<DataTable> GetStoreDataBySearch(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@PartyType", obj.Id),
              new SqlParameter("@PartyId",obj.LoginType),
              new SqlParameter("@StoreCode",obj.Attribute1)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_GetStoreDataBySearch", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        #endregion
        #region Newsletter
        public async static Task<DataTable> GetNewsletter()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Subjectline", typeof(string));
            data.Columns.Add("Id", typeof(int));

            data.Rows.Add(new object[] { "Acts", 1 });
            data.Rows.Add(new object[] { "Forms", 2 });
            data.Rows.Add(new object[] { "Stores", 3 });
            data.Rows.Add(new object[] { "How India almost went", 4 });
            data.Rows.Add(new object[] { "Reincarnation in IIT", 5 });
            data.Rows.Add(new object[] { "Erstwhile royal family", 6 });
            data.Rows.Add(new object[] { "Can Twitter Predict", 7 });
            data.Rows.Add(new object[] { "Do Some Foods Explode", 8 });
            data.Rows.Add(new object[] { "Suicide of a Hacker.", 9 });
            data.Rows.Add(new object[] { "Is the Life of a Child ", 10 });
            data.Rows.Add(new object[] { "Land-for-jobs scandal", 11 });
            data.Rows.Add(new object[] { "Money laundering case", 12 });
            return data;
        }
        #endregion
        #region License & Registration
        public async static Task<DataTable> GetLicenseAndRegistrationBy(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@PartyId", obj.PartyId),
              new SqlParameter("@StoreCode",obj.StoreCode)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Usp_GetLicenseDetailsById", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        #endregion
        public async static Task<string> ApprovalUpdate(LicenseRequest obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@Action", obj.Action),
              new SqlParameter("@LicenceRequestId",obj.LicenceRequestId),
               new SqlParameter("@Result",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_LicenceRequest]", CommandType.StoredProcedure, param.ToArray()));

        }
        public async static Task<DataTable> RetailRolePermisssion(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@Id", obj.Id),
               new SqlParameter("@Action", obj.Action),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_ROLEMANAGE", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<DataTable> StoreComplianceStatusMaster(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
              new SqlParameter("@Id", obj.Id),
               new SqlParameter("@Action", obj.Action),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[Usp_StoreComplianceStatusMaster]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> IUDRetailClientDocMapping(MenuPermission obj)
        {
            StringBuilder menulist = new StringBuilder();
            string seprator = ",";
            string bigseprator = "";
            if (obj.MenuList != null)
            {
                if (obj.MenuList.Count > 0) if (obj.MenuList != null)
                    {
                        for (int i = 0; i < obj.MenuList.Count; i++)
                        {
                            menulist.Append(bigseprator);
                            menulist.Append(obj.MenuList[i].MenuId);

                            menulist.Append(seprator);

                            bigseprator = "|";
                        }
                        bigseprator = "";
                    }
            }
            var param = new List<SqlParameter>
            {

                new SqlParameter("@DocumentList", menulist.ToString()),
                new SqlParameter("@Createdby", obj.CreatedBy),
                new SqlParameter("@ClientId", obj.ClientId),

                new SqlParameter("@Action",obj.Action),
                new SqlParameter("@Result","")
            };

            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_ClientDocumentMapping]", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> SearchRetailClientDocMapping(MenuPermission obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
                 new SqlParameter("@ClientId", obj.ClientId),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_ClientDocumentMapping]", CommandType.StoredProcedure, param.ToArray()));

        }
        public async static Task<DataTable> SearchRetailCreateExecuter(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@Id",obj.Id)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_CreateExecuter]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> IUDRetailCreateExecuter(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@PartyId",obj.PartyId),
                new SqlParameter("@ExecuterId", obj.UserId),
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@IsExecuter", obj.IsActive),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_CreateExecuter]", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<DataTable> SearchRetailAssignExecuter(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@Id",obj.Id)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_AssignExecuter]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> IUDRetailAssignExecuter(TblPartyMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@ExecuterId", obj.UserId),
                new SqlParameter("@PartyId",obj.PartyId),
                new SqlParameter("@ClientId",obj.ClientId),
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_AssignExecuter]", CommandType.StoredProcedure, param.ToArray()));
        }



        public async static Task<DataTable> SearchCompliance(RetialStoreManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreCode", obj.StoreCode),
            };

            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_Compliance", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> IUDRetailcompliance(RetailLicenseDocuementMaster obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@Act", obj.Act),
                    new SqlParameter("@StoreId", obj.StoreId),
                    new SqlParameter("@FY", obj.FY),
                    new SqlParameter("@CMonth", obj.CMonth),
                    new SqlParameter("@ExecuterId", obj.LoginId),
                    new SqlParameter("@DocumentPath", obj.DocumentPath),
                    new SqlParameter("@DocumentName", obj.DocumentName),
                    new SqlParameter("@RESULT",""),

        };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_Compliance", CommandType.StoredProcedure, param.ToArray()));

        }
        public static Task<string> getexcel(RetailLicenseDocuementMaster obj)
        {

            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
                new SqlParameter("@StoreId", obj.StoreCode),
                new SqlParameter("@DocumentPath", obj.DocumentPath),
                new SqlParameter("@DocumentName", obj.DocumentName),
                new SqlParameter("@RESULT",""),
            };
            return Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_Compliance", CommandType.StoredProcedure, param.ToArray()));

        }
        public async static Task<DataTable> SearchRETAILCompliance(RetailLicenseDocuementMaster obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreId", obj.StoreId),
                new SqlParameter("@Act", obj.Act),
                new SqlParameter("@FY", obj.FY),
                new SqlParameter("@CMonth", obj.CMonth),
                new SqlParameter("@ExecuterId", obj.LoginId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_Compliance", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<DataTable> BulkActSave(RetailLicenseDocuementMaster obj)
        {

            StringBuilder ActList = new StringBuilder();
            string seprator = ",";
            string bigseprator = "";
            if (obj.ActList != null)
            {
                if (obj.ActList.Count > 0) if (obj.ActList != null)
                    {
                        for (int i = 0; i < obj.ActList.Count; i++)
                        {
                            ActList.Append(bigseprator);
                            ActList.Append(obj.ActList[i].Act);
                            bigseprator = ",";
                        }
                        bigseprator = "";
                    }
            }
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@StoreId", obj.StoreId),
                new SqlParameter("@ActList", ActList.ToString()),
                new SqlParameter("@FY", obj.FY),
                new SqlParameter("@CMonth", obj.CMonth),
                new SqlParameter("@ExecuterId", obj.LoginId),
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.USP_Compliance", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> IUDExcel(RetialStoreManager obj)
        {

            StringBuilder ComplianceMasterList = new StringBuilder();

            string seprator = ",";
            string bigseprator = "";
            for (int i = 0; i < obj.ComplianceList.Count; i++)
            {
                ComplianceMasterList.Append(bigseprator);
                ComplianceMasterList.Append(obj.ComplianceList[i].Act);
                ComplianceMasterList.Append(seprator);
                ComplianceMasterList.Append(obj.ComplianceList[i].DocumentNo);
                ComplianceMasterList.Append(seprator);
                ComplianceMasterList.Append(obj.ComplianceList[i].DocumentName);
                ComplianceMasterList.Append(seprator);
                ComplianceMasterList.Append(obj.ComplianceList[i].Type);
                ComplianceMasterList.Append(seprator);
                ComplianceMasterList.Append(obj.ComplianceList[i].Frequency);
                ComplianceMasterList.Append(seprator);
                ComplianceMasterList.Append(obj.ComplianceList[i].FilePath);
                bigseprator = "|";
            }

            var param = new List<SqlParameter>
            {
                new SqlParameter("@ComplianceMaster", ComplianceMasterList.ToString()),
                new SqlParameter("@UserId", obj.LoginId),
                new SqlParameter("@StoreCode", obj.StoreCode),
                new SqlParameter("@ExecuterId", obj.ExecuterId),
                new SqlParameter("@Act", obj.Act),
                new SqlParameter("@FY", obj.FY),
                new SqlParameter("@CMonth", obj.CMonth),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.USP_Compliance", CommandType.StoredProcedure, param.ToArray()));

        }

        public async static Task<DataTable> GetNoticeList(NoticeBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@Action", obj.Action),
                new SqlParameter("@StoreId", obj.StoreId),
                new SqlParameter("@DepartmentId", obj.DepartmentId),
                 new SqlParameter("@LoginAs", obj.LoginAs)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_Notice]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<string> InsertUpdateNotice(NoticeBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@Action", obj.Action),
                  new SqlParameter("@LoginAs",obj.LoginAs),
                new SqlParameter("@UserId",obj.UserId),
                new SqlParameter("@StoreId",obj.StoreId),
                new SqlParameter("@DepartmentId",obj.DepartmentId),
                new SqlParameter("@NoticeUpload",obj.NoticeUpload),
                new SqlParameter("@ReceiptDate",obj.ReceiptDate),
                new SqlParameter("@ExecuterId",obj.ExecuterId),
                new SqlParameter("@ExecuterStoreId",obj.ExecuterStoreId),
                new SqlParameter("@ExecuterDepartmentId",obj.ExecuterDepartmentId),
                new SqlParameter("@ExecuterReceiptDate",obj.ExecuterReceiptDate),
                new SqlParameter("@FinalSubmittionbyExecuter",obj.FinalSubmittionbyExecuter),
                new SqlParameter("@Result",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_Notice]", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<string> IUDBulkStoreMaster(RetialStoreManager obj)
        {

            StringBuilder StoreMaster = new StringBuilder();

            string seprator = ",";
            string bigseprator = "";
            for (int i = 0; i < obj.StoreMaster.Count; i++)
            {
                StoreMaster.Append(bigseprator);
                StoreMaster.Append(obj.StoreMaster[i].RefStoreCode);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].StoreName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CompleteAddress);
                StoreMaster.Append(seprator);
                StoreMaster.Append(Convert.ToDateTime(obj.StoreMaster[i].ProposedDate).ToString("yyyy-MM-dd"));
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].StoreLocation);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].ZipCode);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].StoreManagerName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].StoreManagerMobileNo);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].StoreManagerEmail);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].AreaManagerMobileNo);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].AreaManagerName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].AreaManagerEmail);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].ZonalManagerName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].ZonalManagerMobileNo);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].ZonalManagerEmail);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CircleHeadName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CircleHeadMobileNo);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CircleHeadEmail);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].RegionalHeadName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].RegionalHeadMobileNo);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].RegionalHeadEmail);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CorporateHeadName);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CorporateHeadMobileNo);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].CorporateHeadEmail);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].SQFTStoreArea);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].DaysOfExpire);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].IsActive);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].Category);
                StoreMaster.Append(seprator);
                StoreMaster.Append(obj.StoreMaster[i].RegionId);
                bigseprator = "|"; 
            }

            var param = new List<SqlParameter>
            {
                new SqlParameter("@StoreMaster", StoreMaster.ToString()),
                  new SqlParameter("@UserId", obj.LoginId),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[Usp_StoreMaster]", CommandType.StoredProcedure, param.ToArray()));

        }

        public async static Task<string> IUDBulkEmployeee(RetialStoreManager obj)
        {

            StringBuilder EmployeeMaster = new StringBuilder();

            string seprator = ",";
            string bigseprator = "";
            for (int i = 0; i < obj.EmployeeMaster.Count; i++)
            {
                EmployeeMaster.Append(bigseprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].EmployeeName);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].EmployeeDesignation);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].EmployeeDepartment);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].Father_Husband_Name);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].Gendar);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].MaritalStatus);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(Convert.ToDateTime(obj.EmployeeMaster[i].DateOfBirth).ToString("yyyy-MM-dd"));


                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].PresentAddress);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].PermanemtAddress);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].AdharCardNumber);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].PANNumber);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].MobileNumber);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].AlternativeMobileNumber);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].EmployeeEmailID);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].BankAccountNumber);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].BankIFSCCode);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].PreviousUAN);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].PreviousESI);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].GrossSalary);
                EmployeeMaster.Append(seprator);

                EmployeeMaster.Append(Convert.ToDateTime(obj.EmployeeMaster[i].DOJ).ToString("yyyy-MM-dd"));


                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].NomineeName);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].NomineeAddress);
                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].NomineeRelation);
                EmployeeMaster.Append(seprator);

                EmployeeMaster.Append(Convert.ToDateTime(obj.EmployeeMaster[i].NomineeDOB).ToString("yyyy-MM-dd"));

                EmployeeMaster.Append(seprator);
                EmployeeMaster.Append(obj.EmployeeMaster[i].IsActive);
                bigseprator = "|";
            }

            var param = new List<SqlParameter>
            {
                new SqlParameter("@EmployeeMaster", EmployeeMaster.ToString()),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@RESULT",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_EmployeeMaster]", CommandType.StoredProcedure, param.ToArray()));

        }

        public async static Task<DataTable> SearchEscalation(RetialEmployeeManager obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@ClientId",obj.UserId)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("RTL.Escalation", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<string> IUDEscalation(RetialEmployeeManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@ClientId",obj.ClientId),
                new SqlParameter("@Escalation1",obj.Escalation1),
                new SqlParameter("@Escalation2",obj.Escalation2),
                new SqlParameter("@StoreCode",obj.StoreCode),
                new SqlParameter("@LicenceId",obj.LicenceId),
                new SqlParameter("@Remark",obj.Remark),
                new SqlParameter("@Result",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("RTL.Escalation", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<string> IUDPayment(PaymentBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@LicenceReqId", obj.LicenceReqId),
                new SqlParameter("@Action", obj.Action),
                new SqlParameter("@LicenceId",obj.LicenceId),
                new SqlParameter("@StoreCode",obj.StoreCode),
                new SqlParameter("@Amount",obj.Amount),
                new SqlParameter("@TotalAmount",obj.TotalAmount),
                new SqlParameter("@Result",""),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_Payment]", CommandType.StoredProcedure, param.ToArray()));
        }
        public static Task<string> UpdateTransactions(PaymentBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@PaymentMode", obj.PaymentMode),
                new SqlParameter("@Action", "6"),
                new SqlParameter("@PaymentStatus",obj.PaymentStatus),
                new SqlParameter("@TotalAmount",obj.TotalAmount),
                new SqlParameter("@OrderId",obj.OrderId),
                new SqlParameter("@TransId",obj.TransId),
                new SqlParameter("@Result",""),
            };
            return Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[RTL].[USP_Payment]", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<DataTable> SearchPayment(PaymentBAL obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Action", obj.Action),
                    new SqlParameter("@Id",obj.Id)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_Payment]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public static Task<string> RetailONETIMEDOCUMENT(TblSiteManager obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@ClientId",obj.ClientId),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@EmailId",obj.EmailId),
                new SqlParameter("@ContactNo",obj.ContactNo),
                new SqlParameter("@CIN",obj.CIN),
                new SqlParameter("@PAN",obj.Panitno),
                 new SqlParameter("@TAN",obj.TAN),
                new SqlParameter("@GSTN",obj.Gstinuin),
                new SqlParameter("@Pincode",obj.Pincode),
                new SqlParameter("@Country",obj.CountryId),
                new SqlParameter("@State",obj.StateId),
                new SqlParameter("@City",obj.CityId),
                new SqlParameter("@Address",obj.Address),
                new SqlParameter("@PF",obj.PF),
                new SqlParameter("@Labour",obj.Labour),
                new SqlParameter("@ProfessionalTaxReg",obj.ProfessionalTaxReg),
                 new SqlParameter("@FileName",obj.FileName),
                  new SqlParameter("@File",obj.File),
                  new SqlParameter("@Action", obj.ActionType),
                new SqlParameter("@Result",""),
            };
            return Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("USP_RetailOneTimeDocument", CommandType.StoredProcedure, param.ToArray()));
        }
        public async static Task<DataTable> SearchRetailONETIMEDOCUMENT(TblSiteManager obj)
        {
            var param = new List<SqlParameter>
            {
                    new SqlParameter("@Action", obj.ActionType),
                    new SqlParameter("@ClientId",obj.ClientId)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("USP_RetailOneTimeDocument", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }
        public async static Task<DataTable> GetLSDashboard(LSDBAL obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
                new SqlParameter("@loginType",obj.loginType),
                new SqlParameter("@RegionId",obj.RegionId),
                new SqlParameter("@DocumentStatus",obj.DocStatus),
                new SqlParameter("@LicenceStatus",obj.LicenceStatus),
                new SqlParameter("@ExpiryStatus",obj.ExpiryStatus),
                new SqlParameter("@LicenceType",obj.LicenceType),
                new SqlParameter("@Client",obj.Client),
                new SqlParameter("@InvoiceStatus",obj.InvoiceStatus),
                new SqlParameter("@PaymentStatus",obj.PaymentStatus),
                new SqlParameter("@StoreId",obj.Store),
                new SqlParameter("@State",obj.State),
                new SqlParameter("@Address",obj.Address),
                new SqlParameter("@LicenceId",obj.License),
                new SqlParameter("@PartyId",obj.UserId)
            };
            DataTable dt = await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[RTL].[USP_LSDashboard]", CommandType.StoredProcedure, param.ToArray()));
            return dt;
        }

        public async static Task<string> IUDClientActMapping(MenuPermission obj)
        {
            StringBuilder menulist = new StringBuilder();
            string seprator = ",";
            string bigseprator = "";
            if (obj.MenuList != null)
            {
                if (obj.MenuList.Count > 0) if (obj.MenuList != null)
                    {
                        for (int i = 0; i < obj.MenuList.Count; i++)
                        {
                            menulist.Append(bigseprator);
                            menulist.Append(obj.MenuList[i].MenuId);

                            menulist.Append(seprator);

                            bigseprator = "|";
                        }
                        bigseprator = "";
                    }
            }
            var param = new List<SqlParameter>
            {

                new SqlParameter("@DocumentList", menulist.ToString()),
                new SqlParameter("@Createdby", obj.CreatedBy),
                new SqlParameter("@ClientId", obj.ClientId),

                new SqlParameter("@Action",obj.Action),
                new SqlParameter("@Result","")
            };

            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteNonQueryReturnScalar("[USP_ClientActMapping]", CommandType.StoredProcedure, param.ToArray()));
        }

        public async static Task<DataTable> SearchClientActMapping(MenuPermission obj)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Action", obj.Action),
                 new SqlParameter("@ClientId", obj.ClientId),
                   new SqlParameter("@VendorId", obj.VendorId),
            };
            return await Task.Factory.StartNew(() => SqlDBHelper.SqlHelper.ExecuteParamerizedSelectCommand("[USP_ClientActMapping]", CommandType.StoredProcedure, param.ToArray()));

        }

    }
}