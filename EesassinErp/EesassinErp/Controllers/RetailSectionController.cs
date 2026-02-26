using BAL;
using EesassinErp.BAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace EesassinErp.Controllers
{
    public class RetailSectionController : Controller
    {
        // GET: RetailSection
        /// <summary>
        /// Employee Master
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeMaster()
        {
            return View();
        }
        public ActionResult testing()
        {
            return View();
        }
        public async Task<string> InsertUpdateDelEmployeeMaster()
        {
            string result = "";
            var form = Request.Form;
            string Id = form["Id"];
            string actiontype = form["ActionType"];
            string PartyTypeId = form["PartyTypeId"];
            string UserId = form["UserId"];
            string SuperVisior1 = form["SuperVisior1"];
            string SuperVisior2 = form["SuperVisior2"];
            string PartyId = form["PartyId"];
            string employeeCode = form["EmployeeCode"];
            string employeeName = form["EmployeeName"];
            string employeeDesignation = form["EmployeeDesignation"];
            string employeeDepartment = form["EmployeeDepartment"];
            string fatherHusbandName = form["FatherHusbandName"];
            string gender = form["Gender"];
            string maritalStatus = form["MaritalStatus"];
            DateTime dateOfBirth = Convert.ToDateTime(form["DateofBirth"]);
            string presentAddress = form["PresentAddress"];
            string permanentAddress = form["PermanentAddress"];
            string adharCardNumber = form["AdharCardNumber"];
            string panNumber = form["PANNumber"];
            string mobileNumber = form["MobileNumber"];
            string alternativeMobileNumber = form["AlternativeMobileNumber"];
            string employeeEmailID = form["EmployeeEmailID"];
            string bankAccountNumber = form["BankAccountNumber"];
            string bankIFSCCode = form["BankIFSCCode"];
            string previousUAN = form["PreviousUAN"];
            string previousESI = form["PreviousESI"];
            string grossSalary = form["GrossSalary"];
            DateTime doj = Convert.ToDateTime(form["DOJ"]);
            string nameofNominee = form["NameofNominee"];
            string addressofNominee = form["AddressofNominee"];
            string relationofNominee = form["RelationofNominee"];
            DateTime dobofNominee = Convert.ToDateTime(form["DOBofNominee"]);
            string storeCode = form["StoreCode"];
            string Status = form["Status"];

            string panCardFilePath = null;
            string chequePassbookFilePath = null;
            string educationCertificateFilePath = null;
            string experienceCertificateFilePath = null;
            string adhaarCardFrontSideFilePath = null;
            string adhaarCardBackSideFilePath = null;
            string relievingLetterFilePath = null;
            string payslipsFilePath = null;
            string photos1FilePath = null;
            string photos2FilePath = null;
            string photos3FilePath = null;
            string photos4FilePath = null;
            if (Convert.ToInt32(Id) == 0)
            {
                if (!string.IsNullOrEmpty(form["PANCardFilePath"]))
                {
                    panCardFilePath = SaveFile(form["PANCardFilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["Cheque_Passbook_FilePath"]))
                {
                    chequePassbookFilePath = SaveFile(form["Cheque_Passbook_FilePath"], "Employee");
                }

                if (!string.IsNullOrEmpty(form["EducationCertificateFilePath"]))
                {
                    educationCertificateFilePath = SaveFile(form["EducationCertificateFilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["ExperienceCertificateFilePath"]))
                {
                    experienceCertificateFilePath = SaveFile(form["ExperienceCertificateFilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["AdhaarCard_FrontSide_FilePath"]))
                {
                    adhaarCardFrontSideFilePath = SaveFile(form["AdhaarCard_FrontSide_FilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["AdhaarCard_BackSide_FilePath"]))
                {
                    adhaarCardBackSideFilePath = SaveFile(form["AdhaarCard_BackSide_FilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["RelievingLetterfFilePath"]))
                {
                    relievingLetterFilePath = SaveFile(form["RelievingLetterfFilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["PayslipsFilePath"]))
                {
                    payslipsFilePath = SaveFile(form["PayslipsFilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["Photos_1_FilePath"]))
                {
                    photos1FilePath = SaveFile(form["Photos_1_FilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["Photos_2_FilePath"]))
                {
                    photos2FilePath = SaveFile(form["Photos_2_FilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["Photos_3_FilePath"]))
                {
                    photos3FilePath = SaveFile(form["Photos_3_FilePath"], "Employee");
                }
                if (!string.IsNullOrEmpty(form["Photos_4_FilePath"]))
                {
                    photos4FilePath = SaveFile(form["Photos_4_FilePath"], "Employee");
                }
            }
            try
            {
                var employeeData = new RetialEmployeeManager
                {
                    Id = Id,
                    ActionType = actiontype,
                    PartyTypeId = PartyTypeId,
                    PartyId = PartyId,
                    UserId = UserId,
                    Status = Status,
                    SuperVisior1 = SuperVisior1,
                    SuperVisior2 = SuperVisior2,
                    EmployeeCode = employeeCode,
                    EmployeeName = employeeName,
                    EmployeeDesignation = employeeDesignation,
                    EmployeeDepartment = employeeDepartment,
                    Father_Husband_Name = fatherHusbandName,
                    Gendar = gender,
                    MaritalStatus = maritalStatus,
                    DateOfBirth = dateOfBirth,
                    PresentAddress = presentAddress,
                    PermanemtAddress = permanentAddress,
                    AdharCardNumber = adharCardNumber,
                    PANNumber = panNumber,
                    MobileNumber = mobileNumber,
                    AlternativeMobileNumber = alternativeMobileNumber,
                    EmployeeEmailID = employeeEmailID,
                    BankAccountNumber = bankAccountNumber,
                    BankIFSCCode = bankIFSCCode,
                    PreviousUAN = previousUAN,
                    PreviousESI = previousESI,
                    GrossSalary = grossSalary,
                    DOJ = doj,
                    NomineeName = nameofNominee,
                    NomineeAddress = addressofNominee,
                    NomineeRelation = relationofNominee,
                    NomineeDOB = dobofNominee,
                    StoreCode = storeCode,
                    PANCardFilePath = panCardFilePath,
                    Cheque_Passbook_FilePath = chequePassbookFilePath,
                    EducationCertificateFilePath = educationCertificateFilePath,
                    ExperienceCertificateFilePath = experienceCertificateFilePath,
                    AdhaarCard_FrontSide_FilePath = adhaarCardFrontSideFilePath,
                    AdhaarCard_BackSide_FilePath = adhaarCardBackSideFilePath,
                    RelievingLetterfFilePath = relievingLetterFilePath,
                    PayslipsFilePath = payslipsFilePath,
                    Photos_1_FilePath = photos1FilePath,
                    Photos_2_FilePath = photos2FilePath,
                    Photos_3_FilePath = photos3FilePath,
                    Photos_4_FilePath = photos4FilePath
                };
                result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelEmployeeMaster(employeeData)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return result;
        }

        private string SaveFile(string dataURI, string For)
        {
            try
            {
                if (!string.IsNullOrEmpty(dataURI) && dataURI.StartsWith("data:application/"))
                {
                    string extension = Regex.Match(dataURI, @"^data:application\/[a-zA-Z]+;base64,").Value;
                    extension = extension.Replace("data:application/", "").Replace(";base64,", "");
                    string fileName = Guid.NewGuid().ToString("N") + "." + extension;
                    byte[] fileData = Convert.FromBase64String(dataURI.Substring(dataURI.IndexOf(',') + 1));
                    string folderPath = "";
                    string uploadpath = "";
                    if (For == "Employee")
                    {
                        uploadpath = "../DownloadMat/Retail/Employee/" + fileName;
                        folderPath = Server.MapPath("~/DownloadMat/Retail/Employee/");
                    }
                    else if (For == "StoreLicense")
                    {
                        uploadpath = "../DownloadMat/Retail/StoreLicense/" + fileName;
                        folderPath = Server.MapPath("~/DownloadMat/Retail/StoreLicense/");
                    }
                    else
                    {
                        uploadpath = "../DownloadMat/Retail/Store/" + fileName;
                        folderPath = Server.MapPath("~/DownloadMat/Retail/Store/");
                    }

                    string filePath = Path.Combine(folderPath, fileName);
                    string directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    System.IO.File.WriteAllBytes(filePath, fileData);
                    return uploadpath;
                }
                if (!string.IsNullOrEmpty(dataURI) && dataURI.StartsWith("data:image/"))
                {
                    string extension = Regex.Match(dataURI, @"^data:image\/[a-zA-Z]+;base64,").Value;
                    extension = extension.Replace("data:image/", "").Replace(";base64,", "");
                    string fileName = Guid.NewGuid().ToString("N") + "." + extension;
                    byte[] fileData = Convert.FromBase64String(dataURI.Substring(dataURI.IndexOf(',') + 1));
                    string folderPath = "";
                    string uploadpath = "";
                    if (For == "Employee")
                    {
                        uploadpath = "../DownloadMat/Retail/Employee/" + fileName;
                        folderPath = Server.MapPath("~/DownloadMat/Retail/Employee/");
                    }
                    else if (For == "StoreLicense")
                    {
                        uploadpath = "../DownloadMat/Retail/StoreLicense/" + fileName;
                        folderPath = Server.MapPath("~/DownloadMat/Retail/StoreLicense/");
                    }
                    else
                    {
                        uploadpath = "../DownloadMat/Retail/Store/" + fileName;
                        folderPath = Server.MapPath("~/DownloadMat/Retail/Store/");
                    }

                    string filePath = Path.Combine(folderPath, fileName);
                    string directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    System.IO.File.WriteAllBytes(filePath, fileData);
                    return uploadpath;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            // Check if the data URI is valid


            // Return empty string if the data URI is not valid or empty
            return "";
        }

        public async Task<string> GetEmployeeMaster(RetialEmployeeManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetEmployeeMaster(obj)));
            return result;
        }

        public async Task<string> UpdateEmpStatus(RetialEmployeeManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.UpdateEmpStatus(obj)));
            return result;
        }



        public async Task<string> UpdateDocumentForEmployee()
        {
            var form = Request.Form;
            string Id = form["Id"];
            //int actiontype = 5;
            string FieldName = form["FieldName"];
            string FilePath = form["FilePath"];
            int Loginid = 0;
            string panCardFilePath = null;
            if (!string.IsNullOrEmpty(form["FilePath"]))
            {
                panCardFilePath = SaveFile(form["FilePath"], "Employee");
            }

            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject
            (DAL.DLL.UpdateDocumentForEmployee(FieldName, panCardFilePath, Convert.ToInt32(Id), Loginid)));

            JObject jsonObject = JObject.Parse(result); // Parse JSON string into JObject

            int resultValue = jsonObject["Result"].Value<int>();

            if (resultValue == 2)
            {
                result = panCardFilePath;
            }
            return result;
        }



        /// <summary>
        /// Store Master
        /// </summary>
        /// <returns></returns>
        public ActionResult StoreMaster()
        {
            return View();
        }
        public async Task<string> GetStoreMaster(RetialStoreManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetStoreMaster(obj)));
            return result;
        }

        [HttpPost]
        public async Task<string> GetMasters(tblMasters obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetMasters(obj)));
            return result;
        }

        public async Task<string> GetStoreCodeNumber(tblMasters obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetStoreCodeNumber(obj)));
            return result;
        }

        public async Task<string> UpdateStoresStatus(StoreStatusList obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.UpdateStoresStatus(obj)));
            return result;
        }

        public async Task<string> GenerateEmployeeCode(tblMasters obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GenerateEmployeeCode(obj)));
            return result;
        }
        public async Task<string> UpdateStatus(RetialStoreManager obj)
        {

            if (!string.IsNullOrEmpty(obj.AdditionalDoc))
            {
                if (obj.AdditionalDoc.Contains("data:application/"))
                {
                    obj.AdditionalDoc = Regex.Replace(obj.AdditionalDoc, @"^data:application\/[a-zA-Z]+;base64,", string.Empty);
                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += "Additional_Document_";
                    NewFileName += obj.StoreCode.ToString();
                    NewFileName += "_" + strPassword.ToString();

                    byte[] data = Convert.FromBase64String(obj.AdditionalDoc);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".pdf";
                    string uploadpath = "../DownloadMat/StoreLicDocument/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.AdditionalDoc = uploadpath;
                }
            }
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.UpdateStatus(obj)));
            return result;
        }


        public async Task<string> InsertUpdateDelStoreMaster()
        {
            var form = Request.Form;
            string actiontype = Request.Form["ActionType"];
            int id = int.Parse(Request.Form["Id"]);
            //int partyTypeId = int.Parse(Request.Form["PartyTypeId"]);
            // string storeCode = Request.Form["StoreCode"];
            string RefStoreCode = Request.Form["RefStoreCode"];
            string storeName = Request.Form["StoreName"];
            string category = Request.Form["Category"];
            string completeAddress = Request.Form["CompleteAddress"];
            DateTime proposedDate = DateTime.Parse(Request.Form["ProposedDate"]);
            string storeLocation = Request.Form["StoreLocation"];
            float cityId = float.Parse(Request.Form["CityId"]);
            float circleId = float.Parse(Request.Form["CircleId"]);
            float regionId = float.Parse(Request.Form["RegionId"]);
            string zipCode = Request.Form["ZipCode"];
            string storeManagerName = Request.Form["StoreManagerName"];
            string storeManagerMobileNo = Request.Form["StoreManagerMobileNo"];
            string storeManagerEmail = Request.Form["StoreManagerEmail"];
            string areaManagerName = Request.Form["AreaManagerName"];
            string areaManagerMobileNo = Request.Form["AreaManagerMobileNo"];
            string areaManagerEmail = Request.Form["AreaManagerEmail"];
            string zonalManagerName = Request.Form["ZonalManagerName"];
            string zonalManagerMobileNo = Request.Form["ZonalManagerMobileNo"];
            string zonalManagerEmail = Request.Form["ZonalManagerEmail"];
            string circleHeadName = Request.Form["CircleHeadName"];
            string circleHeadMobileNo = Request.Form["CircleHeadMobileNo"];
            string circleHeadEmail = Request.Form["CircleHeadEmail"];
            string regionalHeadName = Request.Form["RegionalHeadName"];
            string regionalHeadMobileNo = Request.Form["RegionalHeadMobileNo"];
            string regionalHeadEmail = Request.Form["RegionalHeadEmail"];
            string corporateHeadName = Request.Form["CorporateHeadName"];
            string corporateHeadMobileNo = Request.Form["CorporateHeadMobileNo"];
            string corporateHeadEmail = Request.Form["CorporateHeadEmail"];
            string sqftStoreArea = Request.Form["SQFTStoreArea"];
            string isActive = Request.Form["IsActive"];
            int loginId = int.Parse(Request.Form["LoginId"]);
            int DaysOfExpire = int.Parse(Request.Form["DaysOfExpire"]);

            string ElectricityBillFilePath = null;
            string RentAgreementFilePath = null;
            string propertyTaxPaidReceiptFilePath = null;
            string buildingPlanFilePath = null;
            string stabilityStructureCertificateFilePath = null;
            string completionCertificateFilePath = null;

            DateTime ElectricityBillPeriodUpTo = DateTime.Parse(Request.Form["ElectricityBillPeriodUpTo"]);
            DateTime LeasePaidReceiptPeriodUpTo = DateTime.Parse(Request.Form["LeasePaidReceiptPeriodUpTo"]);
            DateTime PropertyTaxPeriodUpTo = DateTime.Parse(Request.Form["PropertyTaxPeriodUpTo"]);
            DateTime FireNocPeriodUpTo = DateTime.Parse(Request.Form["FireNocPeriodUpTo"]);
            DateTime PollutionPeriodUpTo = DateTime.Parse(Request.Form["PollutionPeriodUpTo"]);
            DateTime OwnershipDocPeriodUpTo = DateTime.Parse(Request.Form["OwnershipDocPeriodUpTo"]);
            DateTime AdditionalDocPeriodUpTo = DateTime.Parse(Request.Form["AdditionalDocPeriodUpTo"]);
            DateTime LeaseFromDate = DateTime.Parse(Request.Form["LeaseFromDate"]); 

            string ElectricityBillRemark = Request.Form["ElectricityBillRemark"];
            string LeasePaidReceiptRemark = Request.Form["LeasePaidReceiptRemark"];
            string PropertyTaxRemark = Request.Form["PropertyTaxRemark"];
            string FireNocRemark = Request.Form["FireNocRemark"];
            string PollutionRemark = Request.Form["PollutionRemark"];
            string OwnershipDocRemark = Request.Form["OwnershipDocRemark"];
            string AdditionalDocRemark = Request.Form["AdditionalDocRemark"];


            if (!string.IsNullOrEmpty(form["ElectricityBill"]))
            {
                if (form["ElectricityBill"].Contains("../DownloadMat/"))
                {
                    ElectricityBillFilePath = form["ElectricityBill"];
                }
                else
                {
                    ElectricityBillFilePath = SaveFile(form["ElectricityBill"], "Store");
                }

            }
            if (!string.IsNullOrEmpty(form["RentAgreement"]))
            {
                if (form["RentAgreement"].Contains("../DownloadMat/"))
                {
                    RentAgreementFilePath = form["RentAgreement"];
                }
                else
                {
                    RentAgreementFilePath = SaveFile(form["RentAgreement"], "Store");
                }
            }
            if (!string.IsNullOrEmpty(form["PropertyTaxPaidReceipt"]))
            {
                if (form["PropertyTaxPaidReceipt"].Contains("../DownloadMat/"))
                {
                    propertyTaxPaidReceiptFilePath = form["PropertyTaxPaidReceipt"];
                }
                else
                {
                    propertyTaxPaidReceiptFilePath = SaveFile(form["PropertyTaxPaidReceipt"], "Store");
                }
            }
            if (!string.IsNullOrEmpty(form["BuildingPlan"]))
            {
                if (form["BuildingPlan"].Contains("../DownloadMat/"))
                {
                    buildingPlanFilePath = form["BuildingPlan"];
                }
                else
                {
                    buildingPlanFilePath = SaveFile(form["BuildingPlan"], "Store");
                }
            }
            if (!string.IsNullOrEmpty(form["StabilityStructureCertificate"]))
            {
                if (form["StabilityStructureCertificate"].Contains("../DownloadMat/"))
                {
                    stabilityStructureCertificateFilePath = form["StabilityStructureCertificate"];
                }
                else
                {
                    stabilityStructureCertificateFilePath = SaveFile(form["StabilityStructureCertificate"], "Store");
                }
            }
            if (!string.IsNullOrEmpty(form["CompletionCertificate"]))
            {
                if (form["CompletionCertificate"].Contains("../DownloadMat/"))
                {
                    completionCertificateFilePath = form["CompletionCertificate"];
                }
                else
                {
                    completionCertificateFilePath = SaveFile(form["CompletionCertificate"], "Store");
                }
            }


            var storeobj = new RetialStoreManager
            {
                Id = Convert.ToInt32(id),
                ActionType = Convert.ToInt32(actiontype),
                //PartyTypeId = Convert.ToInt32(partyTypeId),
                RefStoreCode = RefStoreCode,
                StoreName = storeName,
                Category = category,
                CompleteAddress = completeAddress,
                ProposedDate = proposedDate,
                StoreLocation = storeLocation,
                CityId = cityId,
                CircleId = circleId,
                RegionId = regionId,
                ZipCode = zipCode,
                StoreManagerName = storeManagerName,
                StoreManagerMobileNo = storeManagerMobileNo,
                StoreManagerEmail = storeManagerEmail,
                AreaManagerName = areaManagerName,
                AreaManagerMobileNo = areaManagerMobileNo,
                AreaManagerEmail = areaManagerEmail,
                ZonalManagerName = zonalManagerName,
                ZonalManagerMobileNo = zonalManagerMobileNo,
                ZonalManagerEmail = zonalManagerEmail,
                CircleHeadName = circleHeadName,
                CircleHeadMobileNo = circleHeadMobileNo,
                CircleHeadEmail = circleHeadEmail,
                RegionalHeadName = regionalHeadName,
                RegionalHeadMobileNo = regionalHeadMobileNo,
                RegionalHeadEmail = regionalHeadEmail,
                CorporateHeadName = corporateHeadName,
                CorporateHeadMobileNo = corporateHeadMobileNo,
                CorporateHeadEmail = corporateHeadEmail,
                SQFTStoreArea = sqftStoreArea,
                IsActive = isActive,
                ElectricityBill = ElectricityBillFilePath,
                RentAgreement = RentAgreementFilePath,
                PropertyTaxPaidReceipt = propertyTaxPaidReceiptFilePath,
                BuildingPlan = buildingPlanFilePath,
                StabilityStructureCertificate = stabilityStructureCertificateFilePath,
                CompletionCertificate = completionCertificateFilePath,
                LoginId = loginId,
                DaysOfExpire = DaysOfExpire,
                ElectricityBillPeriodUpTo = ElectricityBillPeriodUpTo,
                LeasePaidReceiptPeriodUpTo = LeasePaidReceiptPeriodUpTo,
                PropertyTaxPeriodUpTo = PropertyTaxPeriodUpTo,
                FireNocPeriodUpTo = FireNocPeriodUpTo,
                PollutionPeriodUpTo = PollutionPeriodUpTo,
                OwnershipDocPeriodUpTo = OwnershipDocPeriodUpTo,
                AdditionalDocPeriodUpTo = AdditionalDocPeriodUpTo,
                LeaseFromDate = LeaseFromDate,
                ElectricityBillRemark = ElectricityBillRemark,
                LeasePaidReceiptRemark = LeasePaidReceiptRemark,
                PropertyTaxRemark = PropertyTaxRemark,
                FireNocRemark = FireNocRemark,
                PollutionRemark = PollutionRemark,
                OwnershipDocRemark = OwnershipDocRemark,
                AdditionalDocRemark = AdditionalDocRemark
            };


            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelStoreMaster(storeobj)));
            return result;
        }


        /// <summary>
        /// Dashboard
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult Dashboard()
        {
            return View();
        }

        /// <summary>
        /// NewsLetterDetail
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult NewsLetterDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult NewsLetterDetailAll()
        {
            return View();
        }


        /// <summary>
        /// Dashboard
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ComplianceDoc()
        {
            return View();
        }


        [HttpPost]
        public virtual string UploadFiles(object obj)
        {
            var length = Request.ContentLength;
            var bytes = new byte[length];
            var uploadpath = "";
            Request.InputStream.Read(bytes, 0, length);

            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];
            var StoreId = Request.Headers["StoreId"];

            var saveToFileLoc = "";
            if (fileType == "application/vnd.ms-excel")
            {
                string NewFileName = "";
                string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                NewFileName += strPassword;
                NewFileName += DateTime.Now.Year.ToString();
                NewFileName += DateTime.Now.Month.ToString();
                NewFileName += DateTime.Now.Day.ToString();
                NewFileName += DateTime.Now.Hour.ToString();
                NewFileName += DateTime.Now.Minute.ToString();
                NewFileName += DateTime.Now.Second.ToString();
                NewFileName += DateTime.Now.Millisecond.ToString();
                string extention = ".csv";

                uploadpath = "..\\DownloadMat\\ComplianceBulk\\BaseFileExcel\\" + NewFileName + extention;
                saveToFileLoc = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                Updateexcel(fileName, uploadpath, StoreId);
            }
            else
            {

                uploadpath = "..\\DownloadMat\\ComplianceBulk\\ComplianceFile\\" + fileName;

                saveToFileLoc = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
            }


            // save the file.
            var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, length);
            fileStream.Close();

            //if (fileType == "application/vnd.ms-excel")
            //{
            //    RetailLicenseDocuementMaster obj1 = new RetailLicenseDocuementMaster()
            //    { 

            //        DocumentName = fileName,
            //        DocumentPath = uploadpath,
            //        StoreCode = StoreId,
            //        ActionType = 13
            //    };
            //    string result = JsonConvert.SerializeObject(DAL.DLL.getexcel(obj1)); 
            //}


            return string.Format("{0} bytes uploaded", bytes.Length);
        }

        public void Updateexcel(string fileName, string uploadpath, string StoreId)
        {
            RetailLicenseDocuementMaster obj = new RetailLicenseDocuementMaster()
            {

                DocumentName = fileName,
                DocumentPath = uploadpath,
                StoreCode = StoreId,
                Action = 13
            };
            string result = DAL.DLL.getexcel(obj).ToString();

        }
        public ActionResult ComplianceHistory()
        {
            return View();
        }
        /// <summary>
        /// Dashboard
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult LicenseMaster()
        {
            return View();
        }

        public ActionResult profile()
        {
            return View();
        }

        public ActionResult documents()
        {
            return View();
        }

        public ActionResult licenseMasterBulkP()
        {
            return View();
        }

        public ActionResult checkout()
        {
            return View();
        }

        public ActionResult paymentOption()
        {
            return View();
        }

        public ActionResult thankyou()
        {

            return View();
        }

        public async Task<string> GetLicenseMaster(RetailLicenseDocuementMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetLicenseMaster(obj)));
            return result;
        }
        public async Task<string> UploadDoc(StoreLicesensDocument obj)
        {
            if (!string.IsNullOrEmpty(obj.UFile))
            {
                if (obj.UFile.Contains("data:application/"))
                {
                    obj.UFile = Regex.Replace(obj.UFile, @"^data:application\/[a-zA-Z]+;base64,", string.Empty);
                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.UFile);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".pdf";
                    string uploadpath = "../DownloadMat/StoreLicDocument/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.UFile = uploadpath;
                }
            }
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.UploadDoc(obj)));
            return result;
        }

        public async Task<string> InsertUpdateDelStoreDocumentMaster()
        {
            var form = Request.Form;
            int Id = int.Parse(Request.Form["Id"]);
            int IsActive = int.Parse(Request.Form["IsActive"]);
            int actiontype = int.Parse(Request.Form["ActionType"]);
            long storeid = long.Parse(Request.Form["StoreId"]);
            int loginId = int.Parse(Request.Form["LoginId"]);
            int LicenseId = int.Parse(Request.Form["LicenseId"]);

            string DName = Request.Form["DName"].ToString();
            if (Request.Form["DName"].ToString() == "null") { DName = ""; } else { DName = Request.Form["DName"].ToString(); }

            string DFatherName = "";
            if (Request.Form["DFatherName"].ToString() == "null") { DFatherName = ""; } else { DFatherName = Request.Form["DFatherName"].ToString(); }

            string DAddress = "";
            if (Request.Form["DAddress"].ToString() == "null") { DAddress = ""; } else { DAddress = Request.Form["DAddress"].ToString(); }

            string DAadhaarNo = "";
            if (Request.Form["DAadhaarNo"].ToString() == "null") { DAadhaarNo = ""; } else { DAadhaarNo = Request.Form["DAadhaarNo"].ToString(); }

            string DPanNo = "";
            if (Request.Form["DPanNo"].ToString() == "null") { DPanNo = ""; } else { DPanNo = Request.Form["DPanNo"].ToString(); }

            DateTime DDateOfBirth = DateTime.Parse(Request.Form["DDateOfBirth"]);

            string DEmailId = "";
            if (Request.Form["DEmailId"].ToString() == "null") { DEmailId = ""; } else { DEmailId = Request.Form["DEmailId"].ToString(); }

            string DMobileNo = "";
            if (Request.Form["DMobileNo"].ToString() == "null") { DMobileNo = ""; } else { DMobileNo = Request.Form["DMobileNo"].ToString(); }

            string AName = "";
            if (Request.Form["AName"].ToString() == "null") { AName = ""; } else { AName = Request.Form["AName"].ToString(); }

            string AFatherName = "";
            if (Request.Form["AFatherName"].ToString() == "null") { AFatherName = ""; } else { AFatherName = Request.Form["AFatherName"].ToString(); }

            string AAddress = "";
            if (Request.Form["AAddress"].ToString() == "null") { AAddress = ""; } else { AAddress = Request.Form["AAddress"].ToString(); }

            string AAadhaarNo = "";
            if (Request.Form["AAadhaarNo"].ToString() == "null") { AAadhaarNo = ""; } else { AAadhaarNo = Request.Form["AAadhaarNo"].ToString(); }

            string APanNo = "";
            if (Request.Form["APanNo"].ToString() == "null") { APanNo = ""; } else { APanNo = Request.Form["APanNo"].ToString(); }

            DateTime ADateOfBirth = DateTime.Parse(Request.Form["ADateOfBirth"]);


            string AEmailId = "";
            if (Request.Form["AEmailId"].ToString() == "null") { AEmailId = ""; } else { AEmailId = Request.Form["AEmailId"].ToString(); }

            string AMobileNo = "";
            if (Request.Form["AMobileNo"].ToString() == "null") { AMobileNo = ""; } else { AMobileNo = Request.Form["AMobileNo"].ToString(); }

            string NatureofBusiness = "";
            if (Request.Form["NatureofBusiness"].ToString() == "null") { NatureofBusiness = ""; } else { NatureofBusiness = Request.Form["NatureofBusiness"].ToString(); }

            DateTime DateofCommencement = DateTime.Parse(Request.Form["DateofCommencement"]);
            string ProductCategory = "";
            if (Request.Form["ProductCategory"].ToString() == "null") { ProductCategory = ""; } else { ProductCategory = Request.Form["ProductCategory"].ToString(); }

            string AadhaarRegisteredofficeAddressNo = "";
            if (Request.Form["AadhaarRegisteredofficeAddressNo"].ToString() == "null") { AadhaarRegisteredofficeAddressNo = ""; } else { AadhaarRegisteredofficeAddressNo = Request.Form["AadhaarRegisteredofficeAddressNo"].ToString(); }

            string AadhaarCardofDirectorPath = null;
            string PANCardofDirectorPath = null;
            string PassportSizePhotoPath1 = null;
            string AuthorizationLetterPath = null;
            string AadhaarCardofAuthorizedPath = null;
            string PANCardPath = null;
            string PassportSizePhotoPath2 = null;
            string ElectricityBillPath = null;
            string SaledeedRentAgreementPath = null;
            string FSMSPlanPath = null;
            string FormIXPath = null;
            string WaterTestReportPath = null;

            //if (Convert.ToInt32(Id) == 0)
            //{

            if (!string.IsNullOrEmpty(form["AadhaarCardofDirector"]))
            {
                AadhaarCardofDirectorPath = SaveFile(form["AadhaarCardofDirector"], "StoreLicense");
            }
            if (!string.IsNullOrEmpty(form["PANCardofDirector"]))
            {
                PANCardofDirectorPath = SaveFile(form["PANCardofDirector"], "StoreLicense");
            }
            if (!string.IsNullOrEmpty(form["PassportSizePhoto"]))
            {
                PassportSizePhotoPath1 = SaveFile(form["PassportSizePhoto"], "StoreLicense");
            }

            if (!string.IsNullOrEmpty(form["AuthorizationLetter"]))
            {
                AuthorizationLetterPath = SaveFile(form["AuthorizationLetter"], "StoreLicense");
            }

            if (!string.IsNullOrEmpty(form["AadhaarCardofAuthorized"]))
            {
                AadhaarCardofAuthorizedPath = SaveFile(form["AadhaarCardofAuthorized"], "StoreLicense");
            }
            if (!string.IsNullOrEmpty(form["PANCardPath"]))
            {
                PANCardPath = SaveFile(form["PANCardPath"], "StoreLicense");
            }
            if (!string.IsNullOrEmpty(form["PassportSizePhotoPath2"]))
            {
                PassportSizePhotoPath2 = SaveFile(form["PassportSizePhotoPath2"], "StoreLicense");
            }
            if (!string.IsNullOrEmpty(form["ElectricityBill"]))
            {
                ElectricityBillPath = SaveFile(form["ElectricityBill"], "StoreLicense");
            }

            if (!string.IsNullOrEmpty(form["SaledeedRentAgreement"]))
            {
                SaledeedRentAgreementPath = SaveFile(form["SaledeedRentAgreement"], "StoreLicense");
            }

            if (!string.IsNullOrEmpty(form["FSMSPlan"]))
            {
                FSMSPlanPath = SaveFile(form["FSMSPlan"], "StoreLicense");
            }


            if (!string.IsNullOrEmpty(form["FormIX"]))
            {
                FormIXPath = SaveFile(form["FormIX"], "StoreLicense");
            }

            if (!string.IsNullOrEmpty(form["WaterTestReport"]))
            {
                WaterTestReportPath = SaveFile(form["WaterTestReport"], "StoreLicense");
            }
            //}
            var storeobj = new StoreLicesensDocument
            {
                Id = Convert.ToInt32(Id),
                ActionType = actiontype,
                StoreId = storeid,
                LoginId = loginId,
                LicenseId = LicenseId,
                DName = DName,
                DFatherName = DFatherName,
                DAddress = DAddress,
                DAadhaarNo = DAadhaarNo,
                DPanNo = DPanNo,
                DDateOfBirth = DDateOfBirth,
                DEmailId = DEmailId,
                DMobileNo = DMobileNo,
                AName = AName,
                AFatherName = AFatherName,
                AAddress = AAddress,
                AAadhaarNo = AAadhaarNo,
                APanNo = APanNo,
                ADateOfBirth = ADateOfBirth,
                AEmailId = AEmailId,
                AMobileNo = AMobileNo,
                NatureofBusiness = NatureofBusiness,
                DateofCommencement = DateofCommencement,
                ProductCategory = ProductCategory,
                AadhaarRegisteredofficeAddressNo = AadhaarRegisteredofficeAddressNo,
                AadhaarCardofDirector = AadhaarCardofDirectorPath,
                PANCardofDirector = PANCardofDirectorPath,
                PassportSizePhoto1 = PassportSizePhotoPath1,
                AuthorizationLetter = AuthorizationLetterPath,
                AadhaarCardofAuthorized = AadhaarCardofAuthorizedPath,
                PANCard = PANCardPath,
                PassportSizePhoto2 = PassportSizePhotoPath2,
                ElectricityBill = ElectricityBillPath,
                SaledeedRentAgreement = SaledeedRentAgreementPath,
                FSMSPlan = FSMSPlanPath,
                FormIX = FormIXPath,
                WaterTestReport = WaterTestReportPath,
                IsActive = IsActive
            };
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelStoreDocumentMaster(storeobj)));
            return result;
        }


        public async Task<string> GetStoreDocumentDetails(StoreLicesensDocument obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetStoreDocumentDetails(obj)));
            return result;
        }

        public async Task<string> ApproveLicense(StoreLicesensDocument obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.ApproveLicense(obj)));
            return result;
        }



        public async Task<string> LicenseRequestData(LicenseRequest obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.LicenseRequestData(obj)));
            return result;
        }
        public async Task<string> GetStatusMaster(tblMasters obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetStatusMaster(obj)));
            return result;
        }
        public async Task<string> StoreComplianceStatusMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.StoreComplianceStatusMaster(obj)));
            return result;
        }


        public async Task<string> InsertUpdateDelLicenseRequest()
        {
            var form = Request.Form;
            int UserId = int.Parse(Request.Form["UserId"]);
            int Action = int.Parse(Request.Form["Action"]);
            long LicenceRequestId = long.Parse(Request.Form["LicenceRequestId"]);
            string ApplicationStatus = Request.Form["ApplicationStatus"];
            string ApplicationDate = Request.Form["ApplicationDate"];
            if (ApplicationDate == "Invalid date")
            {
                ApplicationDate = null;
            }
            string UploadApplicationCopy = Request.Form["UploadApplicationCopy"];
            string UploadChallanCopy = Request.Form["UploadChallanCopy"];
            string UploadFeesCopy = Request.Form["UploadFeesCopy"];
            string LicenseStatus = Request.Form["LicenseStatus"];
            string LicenseDate = Request.Form["IssuedDate"];
            if (LicenseDate == "Invalid date")
            {
                LicenseDate = null;
            }
            string LicenseNumber = Request.Form["LicenseNumber"];
            string ValidityStartDate = Request.Form["ValidityStartDate"];
            if (ValidityStartDate == "Invalid date")
            {
                ValidityStartDate = null;
            }
            string ValidityEndDate = Request.Form["ValidityEndDate"];
            if (ValidityEndDate == "Invalid date")
            {
                ValidityEndDate = null;
            }
            string UploadLicenseCopy = Request.Form["UploadLicenseCopy"];
            string UserName = Request.Form["UserName"];
            string UserPassword = Request.Form["UserPassword"];
            string MobileNumber = Request.Form["MobileNumber"];
            string EmailId = Request.Form["EmailId"];
            string TentativeDateofComp = Request.Form["TentativeDateofComp"];
            if (TentativeDateofComp == "Invalid date")
            {
                TentativeDateofComp = null;
            }
            string NatureofBusiness = Request.Form["NatureofBusiness"];
            string InvoiceStatus = Request.Form["InvoiceStatus"];
            string InvoiceDate = Request.Form["InvoiceDate"];
            if (InvoiceDate == "Invalid date")
            {
                InvoiceDate = null;
            }
            string InvoiceNo = Request.Form["InvoiceNo"];
            string InvoiceAmount = Request.Form["InvoiceAmount"];
            string UploadInvoice = Request.Form["UploadInvoice"];
            string PaymentStatus = Request.Form["PaymentStatus"];
            string PaymentTAT = Request.Form["PaymentTAT"];
            if (PaymentTAT == null)
            {
                PaymentTAT = "0";
            }
            string RenewalStatus = Request.Form["RenewalStatus"];
            string UploadRenewedCopy = Request.Form["UploadRenewedCopy"];

            string RenewalStartDate = Request.Form["RenewalStartDate"];
            if (RenewalStartDate == "Invalid date")
            {
                RenewalStartDate = null;
            }

            string RenewalEndDate = Request.Form["RenewalEndDate"];
            if (RenewalEndDate == "Invalid date")
            {
                RenewalEndDate = null;
            }

            string AUploadApplicationCopy = Request.Form["AUploadApplicationCopy"];
            string AUploadChallanCopy = Request.Form["AUploadChallanCopy"];
            string AUploadFeesCopy = Request.Form["AUploadFeesCopy"];
            string AUploadLicenseCopy = Request.Form["AUploadLicenseCopy"];
            string AUploadRenewedCopy = Request.Form["AUploadRenewedCopy"];
            string AUploadInvoice = Request.Form["AUploadInvoice"];

            string UploadApplicationCopyPath = null;
            string UploadChallanCopyPath = null;
            string UploadFeesCopyPath = null;
            string UploadLicenseCopyPath = null;
            string UploadRenewedCopyPath = null;
            string UploadInvoicePath = null;
            if (!string.IsNullOrEmpty(form["UploadApplicationCopy"]))
            {
                if (AUploadApplicationCopy == "1")
                {
                    UploadApplicationCopyPath = UploadApplicationCopy;
                }
                else
                {
                    UploadApplicationCopyPath = SaveFile(form["UploadApplicationCopy"], "LicenseRequest");
                }

            }
            if (!string.IsNullOrEmpty(form["UploadChallanCopy"]))
            {
                if (AUploadChallanCopy == "1")
                {
                    UploadChallanCopyPath = UploadChallanCopy;
                }
                else
                {
                    UploadChallanCopyPath = SaveFile(form["UploadChallanCopy"], "LicenseRequest");
                }
            }
            if (!string.IsNullOrEmpty(form["UploadFeesCopy"]))
            {
                if (AUploadFeesCopy == "1")
                {
                    UploadFeesCopyPath = UploadFeesCopy;
                }
                else
                {
                    UploadFeesCopyPath = SaveFile(form["UploadFeesCopy"], "LicenseRequest");
                }
            }
            if (!string.IsNullOrEmpty(form["UploadLicenseCopy"]))
            {
                if (AUploadLicenseCopy == "1")
                {
                    UploadLicenseCopyPath = UploadLicenseCopy;
                }
                else
                {
                    UploadLicenseCopyPath = SaveFile(form["UploadLicenseCopy"], "LicenseRequest");
                }
            }

            if (!string.IsNullOrEmpty(form["UploadRenewedCopy"]))
            {
                if (AUploadRenewedCopy == "1")
                {
                    UploadRenewedCopyPath = UploadRenewedCopy;
                }
                else
                {
                    UploadRenewedCopyPath = SaveFile(form["UploadRenewedCopy"], "LicenseRequest");
                }
            }

            if (!string.IsNullOrEmpty(form["UploadInvoice"]))
            {
                if (AUploadInvoice == "1")
                {
                    UploadInvoicePath = UploadInvoice;
                }
                else
                {
                    UploadInvoicePath = SaveFile(form["UploadInvoice"], "LicenseRequest");
                }
            }

            var License = new LicenseRequest
            {
                UserId = UserId,
                Action = Action,
                LicenceRequestId = LicenceRequestId,
                ApplicationStatus = ApplicationStatus,
                ApplicationDate = ApplicationDate,
                UploadApplicationCopy = UploadApplicationCopyPath,
                UploadChallanCopy = UploadChallanCopyPath,
                UploadFeesCopy = UploadFeesCopyPath,
                LicenseStatus = LicenseStatus,
                LicenseDate = LicenseDate,
                LicenseNumber = LicenseNumber,
                ValidityStartDate = ValidityStartDate,
                ValidityEndDate = ValidityEndDate,
                UploadLicenseCopy = UploadLicenseCopyPath,
                UploadRenewedCopy = UploadRenewedCopyPath,
                UserName = UserName,
                UserPassword = UserPassword,
                MobileNumber = MobileNumber,
                EmailId = EmailId,
                TentativeDateofComp = TentativeDateofComp,
                InvoiceStatus = InvoiceStatus,
                InvoiceDate = InvoiceDate,
                InvoiceNo = InvoiceNo,
                InvoiceAmount = InvoiceAmount,
                UploadInvoice = UploadInvoicePath,
                PaymentStatus = PaymentStatus,
                PaymentTAT = PaymentTAT,
                RenewalStatus = RenewalStatus,
                RenewalStartDate = RenewalStartDate,
                RenewalEndDate = RenewalEndDate,

                //PaymentDueDate = PaymentDueDate,
                //PaymentOverDueDate = PaymentOverDueDate,
            };
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelLicenseRequest(License)));
            return result;
        }
        #region GetStoreDataBySearch
        public async Task<string> GetStoreDataBySearch(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetStoreDataBySearch(obj)));
            return result;
        }
        #endregion
        #region Newsletter
        public async Task<string> GetNewsletter(TblNewLetter obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.Get_NewLetters(obj)));
            return result;
        }
        #endregion
        #region License & Registration
        public async Task<string> GetLicenseAndRegistrationBy(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetLicenseAndRegistrationBy(obj)));
            return result;
        }
        #endregion
        public async Task<string> ApprovalUpdate(LicenseRequest obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.ApprovalUpdate(obj)));
            return result;
        }
        public async Task<string> RetailRolePermisssion(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.RetailRolePermisssion(obj)));
            return result;
        }


        public async Task<string> UploadComplianceDoc(StoreLicesensDocument obj)
        {
            if (!string.IsNullOrEmpty(obj.UFile))
            {
                if (obj.UFile.Contains("data:application/"))
                {
                    obj.UFile = Regex.Replace(obj.UFile, @"^data:application\/[a-zA-Z]+;base64,", string.Empty);
                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.UFile);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".pdf";
                    string uploadpath = "../DownloadMat/SCS/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.UFile = uploadpath;
                }
            }
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.UploadComplianceDoc(obj)));
            return result;
        }
        public async Task<string> SearchCompliance(RetialStoreManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchCompliance(obj)));
            return result;
        }
        public async Task<string> IUDRetailUpdatecompliance(RetailLicenseDocuementMaster obj)
        {
            if (!string.IsNullOrEmpty(obj.DocumentPath))
            {
                if (obj.DocumentPath.Contains("data:image/"))
                {
                    obj.DocumentPath = Regex.Replace(obj.DocumentPath, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.DocumentPath);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".jpeg";
                    string uploadpath = "../DownloadMat/CDoc/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.DocumentPath = uploadpath;
                }
                if (obj.DocumentPath.Contains("data:application/"))
                {
                    obj.DocumentPath = Regex.Replace(obj.DocumentPath, @"^data:application\/[a-zA-Z]+;base64,", string.Empty);

                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.DocumentPath);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".pdf";
                    string uploadpath = "../DownloadMat/CDoc/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.DocumentPath = uploadpath;
                }

            }
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDRetailcompliance(obj)));
            return result;
        }
        #region compliance Search
        public async Task<string> IUDRetailcompliance(RetailLicenseDocuementMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDRetailcompliance(obj)));
            return result;
        }
        public async Task<string> SearchRETAILCompliance(RetailLicenseDocuementMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRETAILCompliance(obj)));
            return result;
        }
        public async Task<string> BulkActSave(RetailLicenseDocuementMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.BulkActSave(obj)));
            return result;
        }

        public ActionResult Download(RetailLicenseDocuementMaster obj)
        {

            string newFolder = "abcd1234";

            string path = System.IO.Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
               newFolder
            );


            if (Directory.Exists(path))
            {
                Directory.Delete(path, recursive: true);
                Directory.CreateDirectory(path);
            }
            if (!System.IO.Directory.Exists(path))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (IOException ie)
                {
                    Response.Redirect("../RetailSection/thankyou?" + ie.Message);
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Response.Redirect("../RetailSection/thankyou?" + e.Message);
                    Console.WriteLine("General Error: " + e.Message);
                }
            }
            return new EmptyResult();
        }

        public async Task<string> IUDExcel(RetialStoreManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDExcel(obj)));
            return result;
        }
        #endregion


        #region Notice

        public async Task<string> GetNoticeList(NoticeBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetNoticeList(obj)));
            return result;
        }
        public async Task<string> InsertUpdateNotice(NoticeBAL obj)
        {
            if (!string.IsNullOrEmpty(obj.NoticeUpload))
            {
                if (obj.NoticeUpload.Contains("data:image/"))
                {
                    obj.NoticeUpload = Regex.Replace(obj.NoticeUpload, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.NoticeUpload);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".jpeg";
                    string uploadpath = "../DownloadMat/NoticeDoc/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.NoticeUpload = uploadpath;
                }
                if (obj.NoticeUpload.Contains("data:application/"))
                {
                    obj.NoticeUpload = Regex.Replace(obj.NoticeUpload, @"^data:application\/[a-zA-Z]+;base64,", string.Empty);

                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.NoticeUpload);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".pdf";
                    string uploadpath = "../DownloadMat/NoticeDoc/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.NoticeUpload = uploadpath;
                }

            }
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateNotice(obj)));
            return result;
        }
        #endregion


        #region BulkStoreMaster
        public async Task<string> IUDBulkStoreMaster(RetialStoreManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDBulkStoreMaster(obj)));
            return result;
        }
        #endregion
        #region BulkEmployeeMaster

        public async Task<string> IUDBulkEmployeee(RetialStoreManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDBulkEmployeee(obj)));
            return result;
        }
        #endregion

        public async Task<string> SearchEscalation(RetialEmployeeManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchEscalation(obj)));
            return result;
        }
        public async Task<string> IUDEscalation(RetialEmployeeManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDEscalation(obj)));
            return result;
        }
        #region Payment
        public async Task<string> SearchPayment(PaymentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchPayment(obj)));
            return result;
        }
        public async Task<string> IUDPayment(PaymentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDPayment(obj)));
            return result;
        }
        #endregion
        #region ManualPayment
        public ActionResult ManualPayment()
        {
            return View();
        }


        public async Task<string> IUDManualPayment(PaymentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDPayment(obj)));
            return result;
        }
        #endregion
        public ActionResult AdditionalDocument()
        {
            return View();
        }

        public async Task<string> RetailONETIMEDOCUMENT(TblSiteManager obj)
        {
            if (!string.IsNullOrEmpty(obj.File))
            {
                if (obj.File.Contains("data:image/"))
                {
                    obj.File = Regex.Replace(obj.File, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.File);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".jpeg";
                    string uploadpath = "../DownloadMat/ProfileDoc/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.File = uploadpath;
                }
                if (obj.File.Contains("data:application/"))
                {
                    obj.File = Regex.Replace(obj.File, @"^data:application\/[a-zA-Z]+;base64,", string.Empty);

                    string NewFileName = "";
                    string strPassword = Guid.NewGuid().ToString("N").Substring(0, 4);
                    NewFileName += strPassword;
                    NewFileName += DateTime.Now.Year.ToString();
                    NewFileName += DateTime.Now.Month.ToString();
                    NewFileName += DateTime.Now.Day.ToString();
                    NewFileName += DateTime.Now.Hour.ToString();
                    NewFileName += DateTime.Now.Minute.ToString();
                    NewFileName += DateTime.Now.Second.ToString();
                    NewFileName += DateTime.Now.Millisecond.ToString();
                    byte[] data = Convert.FromBase64String(obj.File);
                    var imageStream = new MemoryStream(data, false);
                    string extention = ".pdf";
                    string uploadpath = "../DownloadMat/ProfileDoc/" + NewFileName + extention;
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(uploadpath);
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    imageStream.WriteTo(file);
                    file.Close();
                    imageStream.Close();
                    obj.File = uploadpath;
                }

            }
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.RetailONETIMEDOCUMENT(obj)));
            return result;
        }
        public async Task<string> SearchRetailONETIMEDOCUMENT(TblSiteManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRetailONETIMEDOCUMENT(obj)));
            return result;
        }
        public ActionResult LicenceStatusDashboard()
        {
            return View();
        }
        public async Task<string> GetLSDashboard(LSDBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetLSDashboard(obj)));
            return result;
        }
        public ActionResult LicenceStatusDashboardReport()
        {
            return View();
        }
    }
}