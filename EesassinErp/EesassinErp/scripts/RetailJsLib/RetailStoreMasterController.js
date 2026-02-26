app.RetailStoreMasterController = function ($scope, $element, $filter, myService) {
    $scope.ButtonName = 'Create Store';
    $scope.ButtonReset = true;
    $scope.isDisabled = true;
    $scope.Id = 0;
    $scope._TId = 0;
    $scope.PartyTypeId = '';
    $scope.RefStoreCode = '';
    $scope.StoreCode = '';
    $scope.Category = '';
    $scope._StoreId = '';
    $scope._LicenseId = 0;
    $scope.StoreName = '';
    $scope.CompleteAddress = '';
    $scope.ProposedDate = new Date();
    $scope.StoreLocation = '';
    $scope.CityId = "";
    $scope.CircleId = "";
    $scope.RegionId = "";
    $scope.ZipCode = '';
    $scope.StoreManagerName = '';
    $scope.StoreManagerMobileNo = '';
    $scope.StoreManagerEmail = '';
    $scope.AreaManagerName = '';
    $scope.AreaManagerMobileNo = '';
    $scope.AreaManagerEmail = '';
    $scope.ZonalManagerName = '';
    $scope.ZonalManagerMobileNo = '';
    $scope.ZonalManagerEmail = '';
    $scope.CircleHeadName = '';
    $scope.CircleHeadMobileNo = '';
    $scope.CircleHeadEmail = '';
    $scope.RegionalHeadName = '';
    $scope.RegionalHeadMobileNo = '';
    $scope.RegionalHeadEmail = '';
    $scope.CorporateHeadName = '';
    $scope.CorporateHeadMobileNo = '';
    $scope.CorporateHeadEmail = '';
    $scope.SQFTStoreArea = '';
    $scope.DaysOfExpire = '';
    $scope.IsActive = '';
    $scope.ElectricityBill = '';
    $scope.RentAgreement = '';
    $scope.PropertyTaxPaidReceipt = '';
    $scope.BuildingPlan = '';
    $scope.StabilityStructureCertificate = '';
    $scope.CompletionCertificate = '';
    $scope.DName = "";
    $scope.DFatherName = "";
    $scope.DAddress = "";
    $scope.DAadhaarNo = "";
    $scope.DPanNo = "";
    $scope.DDateOfBirth = "";
    $scope.DEmailId = "";
    $scope.DMobileNo = "";
    $scope.AName = "";
    $scope.AFatherName = "";
    $scope.AAddress = "";
    $scope.AAadhaarNo = "";
    $scope.APanNo = "";
    $scope.ADateOfBirth = "";
    $scope.AEmailId = "";
    $scope.AMobileNo = "";

    $scope.NatureofBusiness = "";
    $scope.DateofCommencement = "";
    $scope.ProductCategory = "";
    $scope.AadhaarRegisteredofficeAddressNo = "";


    $scope.AadhaarCardofDirector = "";
    $scope.PANCardofDirector = "";
    $scope.PassportSizePhoto1 = "";
    $scope.AuthorizationLetter = "";
    $scope.AadhaarCardofAuthorized = "";
    $scope.PANCard = "";
    $scope.PassportSizePhoto2 = "";
    $scope.ElectricityBill = "";
    $scope.SaledeedRentAgreement = "";
    $scope.FSMSPlan = "";
    $scope.FormIX = "";
    $scope.WaterTestReport = "";



    $scope.StoreMasterGrid = true;
    $scope.StoreMasterForm = false;
    $scope.StoreUploadDocs = true;
    $scope.StoreList = [];
    $scope.CityList = [];
    $scope.CircleList = [];
    $scope.RegionList = [];
    $scope._RequiredDocuemntList = [];

    $scope.IsActionType = 0;
    $scope.EditId = 0;


    $scope.DDateOfBirth = new Date();
    $scope.ADateOfBirth = new Date();
    $scope.DateofCommencement = new Date();

    $scope.Elec = 'none';
    $scope.Electr = 'none';
    $scope.Rent = 'none';
    $scope.RentA = 'none';

    $scope.Property = 'none';
    $scope.Propertyt = 'none';
    $scope.Building = 'none';
    $scope.BuildingP = 'none';
    $scope.Stability = 'none';
    $scope.StabilityS = 'none';
    $scope.Completion = 'none';
    $scope.CompletionC = 'none';
    $scope.ElectricityBill = "none";
    $scope.RentAgreement = "none";
    $scope.PropertyTaxPaidReceipt = "none";
    $scope.BuildingPlan = "none";
    $scope.StabilityStructureCertificate = "none";
    $scope.CompletionCertificate = "none";
    $scope.ElectricityBillPeriodUpTo = new Date();
    $scope.LeasePaidReceiptPeriodUpTo = new Date();
    $scope.PropertyTaxPeriodUpTo = new Date();
    $scope.FireNocPeriodUpTo = new Date();
    $scope.PollutionPeriodUpTo = new Date();
    $scope.OwnershipDocPeriodUpTo = new Date();
    $scope.AdditionalDocPeriodUpTo = new Date();
    $scope.LeaseFromDate = new Date();
    $scope.ElectricityBillRemark = "";
    $scope.LeasePaidReceiptRemark = "";
    $scope.PropertyTaxRemark = "";
    $scope.FireNocRemark = "";
    $scope.PollutionRemark = "";
    $scope.OwnershipDocRemark = "";
    $scope.AdditionalDocRemark = "";

    $scope.ChangeStatus = function (IsActive, StoreCode) {
        if (IsActive == 1) {
            IsActive = 0;
        }
        else {
            IsActive = 1;
        }
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.ActionType = 6;
        collectionobj.IsActive = IsActive;
        collectionobj.StoreCode = StoreCode;
        var getData = myService.methode('POST', ("../RetailSection/UpdateStatus"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            window.top.location.href = '../RetailSection/StoreMaster?StoreMaster';
        });
        $scope.hideLoader();
    }

    $scope.isChecked = false;
    $scope.selectedStores = [];
    $scope.toggleSelectAll = function () {
        if ($scope.isChecked) {
            // If checkbox is checked, select all parties
            $scope.selectedStores = $scope.StoreList.map(function (store) {
                return store.StoreId.toString();
            });
        } else {
            // If checkbox is unchecked, clear all selections
            $scope.selectedStores = [];
        }

    };

    $scope.saveStoresStatus = function () {
        if ($scope.selectedStores.length > 0 && $scope.IsActive != '') {
            var collectionobj = {};
            collectionobj.selectedStores = $scope.selectedStores;
            collectionobj.IsActive = $scope.IsActive;
            var a = JSON.stringify(collectionobj);
            var getData = myService.methode('POST', ("../RetailSection/UpdateStoresStatus"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                window.top.location.href = '../RetailSection/StoreMaster?StoreMaster';
            });
        }
    }
    $scope.onCross = function () {
        $scope.selectedStores = [];
        $scope.IsActive = '';
        $scope.isChecked = false
    }

    $scope.AllState = function () {
        var getData = myService.methode('POST', ("../PartyMaster/GetPartyMasterDT"), { "ActionType": 28, "PartyId": "1" });
        getData.then(function (response) {
            debugger;
            $scope.AllStateList = response.data.Result;
        });
    }
    $scope.AllCity = function () {
        var getData = myService.methode('POST', ("../PartyMaster/GetPartyMasterDT"), { "ActionType": 29, "PartyId": $scope.State });
        getData.then(function (response) {
            debugger;
            $scope.AllCityList = response.data.Result;
        });
    }

    $scope.GetStoreMaster = function () {

        $scope.showLoader();
        var collectionobj = {};
        collectionobj.ActionType = 4;
        collectionobj.Id = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetStoreMaster"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.StoreList = response.data.Result;
            angular.element(document).ready(function () {
                $('#example').DataTable().destroy();
                dTable = $('#example')

                dTable.DataTable({
                    searching: false,
                    dom: 'Bfrtip',
                    buttons: [
                        //'colvis',
                        {
                            extend: 'csv',
                            filename: 'Store Master',
                            orientation: 'landscape', //portrait
                            title: function () {
                                var printTitle = 'Store Master';
                                return printTitle
                            },
                            exportOptions: {
                                columns: [0, 1, 2, 4, 5, 6, 7, 8]
                            },
                        },

                        'excel',
                        {
                            extend: 'pdfHtml5',
                            text: 'Export PDF',
                            filename: 'Store Master',
                            orientation: 'landscape', //portrait
                            pageSize: 'A4', //A3 , A5 , A6 , legal , letter 
                            customize: function (doc) {
                                doc.styles['table'] = { width: '100%' }
                                doc.pageMargins = [20, 60, 20, 30];
                                doc.styles.tableHeader.fontSize = 15;
                                doc['header'] = (function () {
                                    return {
                                        columns: [
                                            {
                                                alignment: 'center',
                                                fontSize: 14,
                                                text: 'Store Master'
                                            }
                                        ],
                                        margin: 40
                                    }
                                });
                            },
                            exportOptions: {
                                columns: [0, 1, 2, 4, 5, 6, 7, 8]
                            },

                        },
                        , {
                            extend: 'print',
                            filename: 'Store Master',
                            orientation: 'landscape', //portrait
                            title: function () {
                                var printTitle = 'Store Master';
                                return printTitle
                            },
                            customize: function (win) {
                                $(win.document.body).addClass('white-bg');
                                $(win.document.body).css('font-size', '14px');

                                $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', '14px')
                                    .css('color', 'black');

                            },
                            exportOptions: {
                                columns: [0, 1, 2, 4, 5, 6, 7, 8]
                            },
                        }
                    ],

                });
                //buttons: ['copy', 'excelHtml5', 'print']

            });
            $scope.hideLoader();
        });
        $scope.hideLoader();
    };
    $scope.GetStoreMaster();
    $scope.ShowDivStoreMasterGrid = function () {
        $scope.SaveStore();
    };
    $scope.SaveStore = function () {

        $scope.PartyTypeId = 4;
        if (isValidate()) {
            var _isFileValid = true;
            if ($scope.EditId == 0) {
                _isFileValid = IsFileValidation();
            }
            if (_isFileValid) {
                var formData = new FormData();
                formData.append("ActionType", $scope.IsActionType);
                formData.append("Id", $scope.EditId);
                formData.append("PartyTypeId", $scope.PartyTypeId);
                formData.append("StoreCode", $scope.StoreCode);
                formData.append("RefStoreCode", $scope.RefStoreCode);
                formData.append("Category", $scope.Category);
                formData.append("StoreName", $scope.StoreName);
                formData.append("CompleteAddress", $scope.CompleteAddress);
                formData.append("ProposedDate", $scope.StartDate.toISOString());
                formData.append("StoreLocation", $scope.StoreLocation);
                formData.append("CityId", $scope.CityId);
                if ($scope.CircleId == "") {
                    $scope.CircleId = 0;
                }
                if ($scope.RegionId == "") {
                    $scope.RegionId = 0;
                }
                formData.append("CircleId", $scope.CircleId);
                formData.append("RegionId", $scope.RegionId);
                formData.append("ZipCode", $scope.ZipCode);
                formData.append("StoreManagerName", $scope.StoreManagerName);
                formData.append("StoreManagerMobileNo", $scope.StoreManagerMobileNo);
                formData.append("StoreManagerEmail", $scope.StoreManagerEmail);
                formData.append("AreaManagerName", $scope.AreaManagerName);
                formData.append("AreaManagerMobileNo", $scope.AreaManagerMobileNo);
                formData.append("AreaManagerEmail", $scope.AreaManagerEmail);
                formData.append("ZonalManagerName", $scope.ZonalManagerName);
                formData.append("ZonalManagerMobileNo", $scope.ZonalManagerMobileNo);
                formData.append("ZonalManagerEmail", $scope.ZonalManagerEmail);
                formData.append("CircleHeadName", $scope.CircleHeadName);
                formData.append("CircleHeadMobileNo", $scope.CircleHeadMobileNo);
                formData.append("CircleHeadEmail", $scope.CircleHeadEmail);
                formData.append("RegionalHeadName", $scope.RegionalHeadName);
                formData.append("RegionalHeadMobileNo", $scope.RegionalHeadMobileNo);
                formData.append("RegionalHeadEmail", $scope.RegionalHeadEmail);
                formData.append("CorporateHeadName", $scope.CorporateHeadName);
                formData.append("CorporateHeadMobileNo", $scope.CorporateHeadMobileNo);
                formData.append("CorporateHeadEmail", $scope.CorporateHeadEmail);
                formData.append("SQFTStoreArea", $scope.SQFTStoreArea);
                formData.append("DaysOfExpire", $scope.DaysOfExpire);
                formData.append("IsActive", $scope.IsActive);
                formData.append("ElectricityBill", $scope.ElectricityBill);
                formData.append("RentAgreement", $scope.RentAgreement);
                formData.append("PropertyTaxPaidReceipt", $scope.PropertyTaxPaidReceipt);
                formData.append("BuildingPlan", $scope.BuildingPlan);
                formData.append("StabilityStructureCertificate", $scope.StabilityStructureCertificate);
                formData.append("CompletionCertificate", $scope.CompletionCertificate);
                formData.append("ElectricityBillPeriodUpTo", $scope.ElectricityBillPeriodUpTo.toISOString());
                formData.append("LeasePaidReceiptPeriodUpTo", $scope.LeasePaidReceiptPeriodUpTo.toISOString());
                formData.append("PropertyTaxPeriodUpTo", $scope.PropertyTaxPeriodUpTo.toISOString());
                formData.append("FireNocPeriodUpTo", $scope.FireNocPeriodUpTo.toISOString());
                formData.append("PollutionPeriodUpTo", $scope.PollutionPeriodUpTo.toISOString());
                formData.append("OwnershipDocPeriodUpTo", $scope.OwnershipDocPeriodUpTo.toISOString());
                formData.append("AdditionalDocPeriodUpTo", $scope.AdditionalDocPeriodUpTo.toISOString());
                formData.append("ElectricityBillRemark", $scope.ElectricityBillRemark);
                formData.append("LeasePaidReceiptRemark", $scope.LeasePaidReceiptRemark);
                formData.append("PropertyTaxRemark", $scope.PropertyTaxRemark);
                formData.append("FireNocRemark", $scope.FireNocRemark);
                formData.append("PollutionRemark", $scope.PollutionRemark);
                formData.append("OwnershipDocRemark", $scope.OwnershipDocRemark);
                formData.append("AdditionalDocRemark", $scope.AdditionalDocRemark);
                formData.append("LeaseFromDate", $scope.LeaseFromDate.toISOString());
                formData.append("LoginId", sessionStorage.getItem('LoginId'));

                $.ajax({
                    url: "../RetailSection/InsertUpdateDelStoreMaster",
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        var data = JSON.parse(response);
                        if (showMsgBox('999', 'Alert', data.Result, 'warning', 'btn-warning')) {

                            $scope.StoreMasterGrid = true;
                            $scope.StoreMasterForm = false;
                            $scope.GetStoreMaster();
                            $scope.FireEmail(5, $scope.StoreManagerEmail, 0)
                            $scope.ResetStoreMasterForm();
                            window.top.location.href = '../RetailSection/StoreMaster?StoreMaster';
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error("Error saving employee data: " + error);
                    }
                });
            }
        }
    };




    $scope.ShowDivStoreMasterForm = function () {
        $scope.StoreMasterGrid = false;
        $scope.StoreMasterForm = true;
        $scope.IsActionType = 1;
    };
    $scope.BindModuleTypeList = function () {
        var moduleTypeLst = [
            { "Module_Type": "Auditor", "Id": "3" },
            { "Module_Type": "Client", "Id": "4" },
        ];
        $scope.AllModuleTypeList = moduleTypeLst;
    }
    $scope.BindMasters = function (Type, Parentid) {
        if (Type == 2) {
            var collectionobj = {};
            collectionobj.Action = 3;
            collectionobj.ParentId = Parentid;
            var getData = myService.nonasyncmethode('POST', "../RetailSection/GetMasters", '{obj:' + JSON.stringify(collectionobj) + '}');
            getData.then(function (response) {
                $scope.RegionList = response.data.Result;
            });
        }
        var collectionobj = {};
        collectionobj.Action = Type;
        collectionobj.ParentId = Parentid;
        var getData = myService.nonasyncmethode('POST', "../RetailSection/GetMasters", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            if (Type == 1)
                $scope.CityList = response.data.Result;
            else
                $scope.CircleList = response.data.Result;
        });
    }

    $scope.getFileIconClass = function (fileModel) {
        if (fileModel == 'none') {
            return fileModel = 'fa fa-plus';;
        }
        if (fileModel == 'block') {
            return fileModel = 'fa fa-check-square';;
        }
        else {
            return fileModel ? 'fa fa-check-square' : 'fa fa-plus';
        }

    };



    $scope.SetValue = function (ID, fuCandidatePhoto) {
        Index = ID;
        $(fuCandidatePhoto).click();

    }
    $scope._RequiredDocuemntList.push({
        Srno: "",
        DocumentId: "",
        DocumentName: "",
        DisplayName: "",
        DocumentLink: ""
    });

    $scope.AdditionalDocshow = function (input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope.AdditionalDoc = e.target.result;
                $scope.AllDoandAllDATA();
                $scope.$applyAsync();
            }
            filerdr.readAsDataURL(input.files[0]);
        }
        else {
            $scope.Image = '';
            $scope.$applyAsync();
            $(imgfileid).attr('src', '');
            $(imgfileid).attr('value', '');
        }
    }


    $scope.UploadDoBeforeSaveStore = function () {

        $scope.PartyTypeId = 4;
        if (isValidate()) {
            var _isFileValid = true;
            if ($scope.EditId == 0) {
                _isFileValid = IsFileValidation();
            }
            if (_isFileValid) {
                var formData = new FormData();
                formData.append("ActionType", $scope.IsActionType);
                formData.append("Id", $scope.EditId);
                formData.append("PartyTypeId", $scope.PartyTypeId);
                formData.append("StoreCode", $scope.StoreCode);
                formData.append("RefStoreCode", $scope.RefStoreCode);
                formData.append("StoreName", $scope.StoreName);
                formData.append("Category", $scope.Category);
                formData.append("CompleteAddress", $scope.CompleteAddress);
                formData.append("ProposedDate", $scope.ProposedDate.toISOString());
                formData.append("StoreLocation", $scope.StoreLocation);
                formData.append("CityId", $scope.CityId);
                if ($scope.CircleId == "") {
                    $scope.CircleId = 0;
                }
                if ($scope.RegionId == "") {
                    $scope.RegionId = 0;
                }
                formData.append("CircleId", $scope.CircleId);
                formData.append("RegionId", $scope.RegionId);
                formData.append("ZipCode", $scope.ZipCode);
                formData.append("StoreManagerName", $scope.StoreManagerName);
                formData.append("StoreManagerMobileNo", $scope.StoreManagerMobileNo);
                formData.append("StoreManagerEmail", $scope.StoreManagerEmail);
                formData.append("AreaManagerName", $scope.AreaManagerName);
                formData.append("AreaManagerMobileNo", $scope.AreaManagerMobileNo);
                formData.append("AreaManagerEmail", $scope.AreaManagerEmail);
                formData.append("ZonalManagerName", $scope.ZonalManagerName);
                formData.append("ZonalManagerMobileNo", $scope.ZonalManagerMobileNo);
                formData.append("ZonalManagerEmail", $scope.ZonalManagerEmail);
                formData.append("CircleHeadName", $scope.CircleHeadName);
                formData.append("CircleHeadMobileNo", $scope.CircleHeadMobileNo);
                formData.append("CircleHeadEmail", $scope.CircleHeadEmail);
                formData.append("RegionalHeadName", $scope.RegionalHeadName);
                formData.append("RegionalHeadMobileNo", $scope.RegionalHeadMobileNo);
                formData.append("RegionalHeadEmail", $scope.RegionalHeadEmail);
                formData.append("CorporateHeadName", $scope.CorporateHeadName);
                formData.append("CorporateHeadMobileNo", $scope.CorporateHeadMobileNo);
                formData.append("CorporateHeadEmail", $scope.CorporateHeadEmail);
                formData.append("SQFTStoreArea", $scope.SQFTStoreArea);
                formData.append("DaysOfExpire", $scope.DaysOfExpire);
                formData.append("IsActive", $scope.IsActive);
                formData.append("ElectricityBill", $scope.ElectricityBill);
                formData.append("RentAgreement", $scope.RentAgreement);
                formData.append("PropertyTaxPaidReceipt", $scope.PropertyTaxPaidReceipt);
                formData.append("BuildingPlan", $scope.BuildingPlan);
                formData.append("StabilityStructureCertificate", $scope.StabilityStructureCertificate);
                formData.append("CompletionCertificate", $scope.CompletionCertificate);
                formData.append("ElectricityBillPeriodUpTo", $scope.ElectricityBillPeriodUpTo.toISOString());
                formData.append("LeasePaidReceiptPeriodUpTo", $scope.LeasePaidReceiptPeriodUpTo.toISOString());
                formData.append("PropertyTaxPeriodUpTo", $scope.PropertyTaxPeriodUpTo.toISOString());
                formData.append("FireNocPeriodUpTo", $scope.FireNocPeriodUpTo.toISOString());
                formData.append("PollutionPeriodUpTo", $scope.PollutionPeriodUpTo.toISOString());
                formData.append("OwnershipDocPeriodUpTo", $scope.OwnershipDocPeriodUpTo.toISOString());
                formData.append("AdditionalDocPeriodUpTo", $scope.AdditionalDocPeriodUpTo.toISOString());
                formData.append("ElectricityBillRemark", $scope.ElectricityBillRemark);
                formData.append("LeasePaidReceiptRemark", $scope.LeasePaidReceiptRemark);
                formData.append("PropertyTaxRemark", $scope.PropertyTaxRemark);
                formData.append("FireNocRemark", $scope.FireNocRemark);
                formData.append("PollutionRemark", $scope.PollutionRemark);
                formData.append("OwnershipDocRemark", $scope.OwnershipDocRemark);
                formData.append("AdditionalDocRemark", $scope.AdditionalDocRemark);
                formData.append("LeaseFromDate", $scope.LeaseFromDate.toISOString());
                formData.append("LoginId", sessionStorage.getItem('LoginId'));
                $.ajax({
                    url: "../RetailSection/InsertUpdateDelStoreMaster",
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (response) {

                        var data = JSON.parse(response);
                        $scope._StoreId = data.Result;
                        $scope.StoreCode = $scope._StoreId;
                        $scope.AdditionalDocSaveFile();
                        if (showMsgBox('999', 'Alert', ' Store Code Successfully Created:' + data.Result, 'warning', 'btn-warning')) {

                            $scope.FireEmail(5, $scope.StoreManagerEmail, 0)
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error("Error saving employee data: " + error);
                    }
                });
            }
        }
    };







    $scope.AllDoandAllDATA = function () {
        if ($scope.AdditionalDocName == '') {
            showMsgBox('999', 'Alert', 'Please Enter Additonal Doc Name', 'warning', 'btn-warning');
            $scope.AdditionalDocName = "";

        }
        else if ($scope.StoreCode == '') {
            $scope.AdditionalDocName = "";
            showMsgBox('999', 'Alert', 'Oops Please Enter Mandatory Fields then Attach File Again .', 'warning', 'btn-warning');
            $scope.UploadDoBeforeSaveStore();

        }
        else {
            $scope.AdditionalDocSaveFile();
        }

    }

    $scope.AdditionalDocSaveFile = function () {
        if ($scope.StoreCode != '') {
            var collectionobj = {};
            collectionobj.AdditionalDoc = $scope.AdditionalDoc;
            collectionobj.DocumentName = $scope.AdditionalDocName;
            collectionobj.StoreCode = $scope.StoreCode;
            collectionobj.LoginId = LoginId;
            collectionobj.ActionType = 10;
            var getData = myService.methode('POST', "../RetailSection/UpdateStatus", '{obj:' + JSON.stringify(collectionobj) + '}');
            getData.then(function (response) {
                $scope.GETAdditionalDoc();
                //$scope.EditStore($scope.StoreCode);
            });
        }
    }
    $scope.GETAdditionalDoc = function () {
        $scope.AdditionalDocName = "";
        var collectionobj = {};
        collectionobj.StoreCode = $scope.StoreCode;
        collectionobj.ActionType = 9;
        var getData = myService.methode('POST', "../RetailSection/GetStoreMaster", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            $scope.AdditionalDocList = response.data.Result;
        });
    }

    $scope.SaveFile = function (Link, DocumentId) {
        var collectionobj = {};
        collectionobj.UFile = Link;
        collectionobj.Id = DocumentId;
        collectionobj.StoreId = $scope._StoreId;
        collectionobj.ActionType = 7;
        var getData = myService.methode('POST', "../RetailSection/UploadDoc", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            $scope.SHOWDOCUMENT($scope._TId, $scope._LicenseId, 0);
        });
    }
    $scope.show = function (input, imgfileid) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope._RequiredDocuemntList[Index].DocumentLink = e.target.result;
                $scope.SaveFile($scope._RequiredDocuemntList[Index].DocumentLink, $scope._RequiredDocuemntList[Index].DocumentId)
                $scope.$applyAsync();
                $(imgfileid).attr('src', e.target.result);
                $(imgfileid).attr('value', e.target.result);
            }
            filerdr.readAsDataURL(input.files[0]);
        }
        else {
            $scope.Image = '';
            $scope.$applyAsync();
            $(imgfileid).attr('src', '');
            $(imgfileid).attr('value', '');
        }
    };

    $scope.uploadElectricityBill = function (fieldName, input) {
        debugger
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope[fieldName] = e.target.result;
                $scope.$applyAsync();
                var iconClass = $scope.getFileIconClass($scope[fieldName]);
                $scope.uploadedElectricityBill = input.files[0].name; // Use 'input' instead of 'inputElement'
                $scope.Elec = 'block';
                $scope.Electr = 'block';
                $scope.getFileIconClass('block');
            }
            filerdr.readAsDataURL(input.files[0]);
        } else {
            $scope.$applyAsync();
        }
    };



    $scope.uploadBuildingPlan = function (fieldName, input) {
        debugger
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope[fieldName] = e.target.result;
                $scope.$applyAsync();
                var iconClass = $scope.getFileIconClass($scope[fieldName]);
                $scope.uploadBuildingPlans = input.files[0].name; // Use 'input' instead of 'inputElement'
                $scope.Building = 'block';
                $scope.BuildingP = 'block';
                $scope.getFileIconClass('block');
            }
            filerdr.readAsDataURL(input.files[0]);
        } else {
            $scope.$applyAsync();
        }
    };
    $scope.uploadRentAgreement = function (fieldName, input) {
        debugger
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope[fieldName] = e.target.result;
                $scope.$applyAsync();
                //  var iconClass = $scope.getFileIconClass($scope[fieldName]);
                $scope.uploadRentAgreements = input.files[0].name; // Use 'input' instead of 'inputElement'
                $scope.Rent = 'block';
                $scope.RentA = 'block';
                $scope.getFileIconClass('block');

            }
            filerdr.readAsDataURL(input.files[0]);
        } else {
            $scope.$applyAsync();
        }
    };
    $scope.uploadPropertyTaxPaidReceipt = function (fieldName, input) {
        debugger
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope[fieldName] = e.target.result;
                $scope.$applyAsync();
                var iconClass = $scope.getFileIconClass($scope[fieldName]);
                $scope.uploadPropertyTaxPaidReceipts = input.files[0].name; // Use 'input' instead of 'inputElement'
                $scope.Property = 'block';
                $scope.Propertyt = 'block';
                $scope.getFileIconClass('block');
            }
            filerdr.readAsDataURL(input.files[0]);
        } else {
            $scope.$applyAsync();
        }
    };
    $scope.uploadStabilityStructureCertificate = function (fieldName, input) {
        debugger
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope[fieldName] = e.target.result;
                $scope.$applyAsync();
                var iconClass = $scope.getFileIconClass($scope[fieldName]);
                $scope.uploadStabilityStructureCertificates = input.files[0].name; // Use 'input' instead of 'inputElement'
                $scope.Stability = 'block';
                $scope.StabilityS = 'block';
                $scope.getFileIconClass('block');
            }
            filerdr.readAsDataURL(input.files[0]);
        } else {
            $scope.$applyAsync();
        }
    };
    $scope.uploadCompletionCertificate = function (fieldName, input) {
        debugger
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope[fieldName] = e.target.result;
                $scope.$applyAsync();
                var iconClass = $scope.getFileIconClass($scope[fieldName]);
                $scope.uploadCompletionCertificates = input.files[0].name; // Use 'input' instead of 'inputElement'
                $scope.Completion = 'block';
                $scope.CompletionC = 'block';
                $scope.getFileIconClass('block');
            }
            filerdr.readAsDataURL(input.files[0]);
        } else {
            $scope.$applyAsync();
        }
    };

    function IsFileValidation() {

        var modelStateIsvalid = true;
        var firstElement = null;
        $.each($('input:file'), function (index) {

            if ($(this).hasClass('filevalidate')) {
                var _length = $(this).length;
                if (_length > 0) {
                    var _fileValue = $($(this)[0]).val();
                    if (_fileValue == "" || _fileValue == null || _fileValue == undefined) {
                        var _fileUpload = $($(this)[0]).parent('.fileupld');
                        if (_fileUpload != null || _fileUpload != undefined && _fileUpload.length > 0) {
                            $(_fileUpload).addClass("red-validation");
                            modelStateIsvalid = false;
                            if (firstElement == null)
                                firstElement = $(this);
                        }
                        else {
                            $(_fileUpload).removeClass("red-validation");
                        }
                    }
                    else {
                        var _fileUpload = $($(this)[0]).parent('.fileupld');
                        if (_fileUpload != null || _fileUpload != undefined && _fileUpload.length > 0) {
                            $(_fileUpload).removeClass("red-validation");
                        }
                    }
                }
            }
            else {
                $(this).removeClass("red-validation");
            }
        });
        if (firstElement != null) {
            firstElement.focus();
        }
        return modelStateIsvalid;
    }
    $scope.GetLicenseMaster = function (Storeid, UserId,storeCode) {
        $scope._StoreId = Storeid;
        $scope.selectedStoreCode = storeCode;
        $scope.showLoader();
        var collectionobj = {};
        $scope.UserId = UserId;
        collectionobj.ActionType = 1;
        collectionobj.LoginId = UserId;
        collectionobj.LicenseId = 0;
        collectionobj.StoreId = Storeid;
        var getData = myService.methode('POST', ("../RetailSection/GetLicenseMaster"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.LicenseMasterList = response.data.Result;
            var id = response.data.Result;
            var len = response.data.Result.length;
            var count = 0;
            var LDOC = 0;
            $.each(id, function (i, val) {
                if (val.Status == 1) {
                    count = count + 1;
                    LDOC = count;
                }
            });
            $scope.LDOC = LDOC / len * 100;
            $scope.LDOC = Math.trunc($scope.LDOC);
            $scope.$applyAsync();
            $scope.hideLoader();
        });
        $scope.hideLoader();
    }
    $scope.SHOWDOCUMENT = function (Id, _LicenseId, TId) {
        $scope.StoreMasterDocForm = true;
        $scope.StoreMasterGrid = false;
        $scope.StoreMasterForm = false;
        $('#requestForm').modal('hide');
        $scope._LicenseId = _LicenseId;
        $scope._TId = Id;
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Id = Id;
        collectionobj.ActionType = 4;
        collectionobj.LicenseId = _LicenseId;
        collectionobj.StoreId = $scope._StoreId;
        collectionobj.LoginId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetStoreDocumentDetails"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            debugger;
            $scope._RequiredDocuemntList = response.data.Result.Table1;

            $scope.hideLoader();
        });
        $scope.hideLoader();
    }
    $scope.PermissionForSection = function (Id) {
        if (loginType == "1") {
            $scope.Section1 = 'ok'
            $scope.Section2 = 'ok';
            $scope.Section3 = 'ok';
        }
        else {
            $scope.showLoader();
            var collectionobj = {};
            collectionobj.ActionType = 8;
            collectionobj.LicenseId = Id;
            var getData = myService.methode('POST', ("../RetailSection/GetStoreDocumentDetails"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                debugger;
                $scope.IsSessionOpen = response.data.Result.Table[0].PermissionId;
                if ($scope.IsSessionOpen == "1") {
                    $scope.Section1 = 'ok';
                }
                else if ($scope.IsSessionOpen == "2") {
                    $scope.Section2 = 'ok';
                }
                else if ($scope.IsSessionOpen == "3") {
                    $scope.Section3 = 'ok';
                }
                else if ($scope.IsSessionOpen == "23") {
                    $scope.Section2 = 'ok';
                    $scope.Section3 = 'ok';
                }
                else if ($scope.IsSessionOpen == "123") {
                    $scope.Section1 = 'ok';
                    $scope.Section2 = 'ok';
                    $scope.Section3 = 'ok';
                }
                else if ($scope.IsSessionOpen == "13") {
                    $scope.Section1 = 'ok';
                    $scope.Section3 = 'ok';
                }
                else if ($scope.IsSessionOpen == "12") {
                    $scope.Section1 = 'ok';
                    $scope.Section2 = 'ok';
                }
                else {
                    $scope.IsSessionOpen = 'notok';
                }
                $scope.hideLoader();
            });
            $scope.hideLoader();
        }
    }
    $scope.ShowStoreMasterDocForm = function (Id, _LicenseId, TId) {
        $scope.StoreMasterDocForm = true;
        $scope.StoreMasterGrid = false;
        $scope.StoreMasterForm = false;
        $('#requestForm').modal('hide');
        $scope._LicenseId = _LicenseId;
        $scope._TId = Id;
        $scope._StoreId = TId;
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Id = Id;
        collectionobj.ActionType = 4;
        collectionobj.LicenseId = _LicenseId;
        collectionobj.StoreId = $scope._StoreId;
        collectionobj.LoginId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetStoreDocumentDetails"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            debugger;
            $scope._RequiredDocuemntList = response.data.Result.Table1;
            if (response.data.Result.Table.length > 0) {
                $scope.StoreDocumentDetailsList = response.data.Result.Table[0];
                $scope.Id = response.data.Result.Table[0].Id;
                $scope.StoreCode = response.data.Result.Table[0]._StoreId;
                $scope.RefStoreCode = response.data.Result.Table[0].RefStoreCode;
                $scope.DName = response.data.Result.Table[0].Dire_Name;
                $scope.DFatherName = response.data.Result.Table[0].Dire_FatherName;
                $scope.DAddress = response.data.Result.Table[0].Dire_Address;
                $scope.DAadhaarNo = response.data.Result.Table[0].Dire_AadhaarNo;
                $scope.DPanNo = response.data.Result.Table[0].Dire_PanNo;
                $scope.DDateOfBirth = new Date(response.data.Result.Table[0].Dire_DateOfBirth);
                $scope.DEmailId = response.data.Result.Table[0].Dire_EmailId;
                $scope.DMobileNo = response.data.Result.Table[0].Dire_MobileNo;
                $scope.AName = response.data.Result.Table[0].Auth_Name;
                $scope.AFatherName = response.data.Result.Table[0].Auth_FatherName;
                $scope.AAddress = response.data.Result.Table[0].Auth_Address;
                $scope.AAadhaarNo = response.data.Result.Table[0].Auth_AadhaarNo;
                $scope.APanNo = response.data.Result.Table[0].Auth_PanNo;
                $scope.ADateOfBirth = new Date(response.data.Result.Table[0].Auth_DateOfBirth);
                $scope.AEmailId = response.data.Result.Table[0].Auth_EmailId;
                $scope.AMobileNo = response.data.Result.Table[0].Auth_MobileNo;
                $scope.NatureofBusiness = response.data.Result.Table[0].NatureofBusiness;
                $scope.DateofCommencement = new Date(response.data.Result.Table[0].DateofCommencement);
                $scope.ProductCategory = response.data.Result.Table[0].ProductCategory;
                $scope.AadhaarRegisteredofficeAddressNo = response.data.Result.Table[0].AadhaarRegisteredofficeAddressNo;
                $scope.AadhaarCardofDirector = response.data.Result.Table[0].AadhaarCardofDirector;
                $scope.PANCardofDirector = response.data.Result.Table[0].PANCardofDirector
                $scope.PassportSizePhoto1 = response.data.Result.Table[0].PassportSizePhoto1;
                $scope.AuthorizationLetter = response.data.Result.Table[0].AuthorizationLetter;
                $scope.AadhaarCardofAuthorized = response.data.Result.Table[0].AadhaarCardofAuthorized;
                $scope.PANCard = response.data.Result.Table[0].PANCard;
                $scope.PassportSizePhoto2 = response.data.Result.Table[0].PassportSizePhoto2;
                $scope.ElectricityBill = response.data.Result.Table[0].ElectricityBill;
                $scope.SaledeedRentAgreement = response.data.Result.Table[0].SaledeedRentAgreement;
                $scope.FSMSPlan = response.data.Result.Table[0].FSMSPlan;
                $scope.FormIX = response.data.Result.Table[0].FormIX;
                $scope.WaterTestReport = response.data.Result.Table[0].WaterTestReport;
                $scope.Status = response.data.Result.Table[0].Status;
            }
            $scope.hideLoader();
        });
        $scope.hideLoader();
    }
    $scope.SubmitStoreDocumentDetails = function (type) {
        $scope.DName;
        $scope.ActionType = 2;
        var formData = new FormData();
        formData.append("Id", $scope._TId);
        formData.append("ActionType", $scope.ActionType);
        formData.append("StoreId", $scope._StoreId);
        formData.append("LoginId", LoginId);
        formData.append("LicenseId", $scope._LicenseId);
        formData.append("DName", $scope.DName);
        formData.append("DFatherName", $scope.DFatherName);
        formData.append("DAddress", $scope.DAddress);
        formData.append("DAadhaarNo", $scope.DAadhaarNo);
        formData.append("DPanNo", $scope.DPanNo);
        formData.append("DDateOfBirth", $scope.DDateOfBirth.toISOString());
        formData.append("DEmailId", $scope.DEmailId);
        formData.append("DMobileNo", $scope.DMobileNo);
        formData.append("AName", $scope.AName);
        formData.append("AFatherName", $scope.AFatherName);
        formData.append("AAddress", $scope.AAddress);
        formData.append("AAadhaarNo", $scope.AAadhaarNo);
        formData.append("APanNo", $scope.APanNo);
        formData.append("ADateOfBirth", $scope.ADateOfBirth.toISOString());
        formData.append("AEmailId", $scope.AEmailId);
        formData.append("AMobileNo", $scope.AMobileNo);
        formData.append("NatureofBusiness", $scope.NatureofBusiness);
        formData.append("DateofCommencement", $scope.DateofCommencement.toISOString());
        formData.append("ProductCategory", $scope.ProductCategory);
        formData.append("AadhaarRegisteredofficeAddressNo", $scope.AadhaarRegisteredofficeAddressNo);
        formData.append("AadhaarCardofDirector", $scope.AadhaarCardofDirector);
        formData.append("PANCardofDirector", $scope.PANCardofDirector);
        formData.append("PassportSizePhoto1", $scope.PassportSizePhoto1);
        formData.append("AuthorizationLetter", $scope.AuthorizationLetter);
        formData.append("AadhaarCardofAuthorized", $scope.AadhaarCardofAuthorized);
        formData.append("PANCard", $scope.PANCard);
        formData.append("PassportSizePhoto2", $scope.PassportSizePhoto2);
        formData.append("ElectricityBill", $scope.ElectricityBill);
        formData.append("SaledeedRentAgreement", $scope.SaledeedRentAgreement);
        formData.append("FSMSPlan", $scope.FSMSPlan);
        formData.append("FormIX", $scope.FormIX);
        formData.append("WaterTestReport", $scope.WaterTestReport);
        formData.append("IsActive", type);
        $.ajax({
            url: "../RetailSection/InsertUpdateDelStoreDocumentMaster",
            type: 'POST',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                var data = JSON.parse(response);
                if (showMsgBox('999', 'Alert', ' Store Code Successfully Updated:' + data.Result, 'warning', 'btn-warning')) {
                    //if (data.Result == 1) {
                    $scope.FireEmail(7, $scope._LicenseId, $scope._StoreId)
                    $scope.StoreMasterGrid = true;
                    $scope.StoreMasterForm = false;
                    $scope.StoreMasterDocForm = false;
                    $scope.GetStoreMaster();
                }
            },
            error: function (xhr, status, error) {
                console.error("Error saving employee data: " + error);
            }
        });
    }


    $scope.EditStore = function (StoreCode) {
        $scope.showLoader();
        $scope.StoreCode = StoreCode;
        $scope.GETAdditionalDoc();
        var selectedStore = $scope.StoreList.find(function (store) {
            return store.StoreCode === StoreCode;
        });

        $scope.EditId = selectedStore.Id;
        $scope.PartyTypeId = selectedStore.PartyTypeId;
        $scope.StoreCode = selectedStore.StoreCode;
        $scope.StoreName = selectedStore.StoreName;
        $scope.Category = selectedStore.Category;
        $scope.CompleteAddress = selectedStore.CompleteAddress;
        $scope.ProposedDate = new Date(selectedStore.ProposedDate);
        $scope.StartDate = new Date(selectedStore.ProposedDate);
        $scope.StoreLocation = selectedStore.StoreLocation;


        $scope.BindMasters(1, 0);
        if (selectedStore.SATE_CODE != null) {
            $scope.State = selectedStore.SATE_CODE.toString();;
        }

        //$scope.BindMasters(2, $scope.CityId);
        if (selectedStore.RegionId != null) {
            $scope.RegionId = $filter('filter')($scope.RegionList, { 'Id': selectedStore.RegionId })[0].Id.toString();
        }
        // $scope.RegionId = $filter('filter')($scope.RegionList, { 'Id': selectedStore.RegionId })[0].Id.toString();
        $scope.BindMasters(3, $scope.CityId);
        $scope.AllCity();
        setTimeout(function () {
            if (selectedStore.CityId != null) {
                $scope.CityId = selectedStore.CityId.toString();;
            }
            if (selectedStore.CircleId != null) {
                $scope.CircleId = $filter('filter')($scope.CircleList, { 'Id': selectedStore.CircleId })[0].Id.toString();
            }
            //if (selectedStore.RegionId != null || selectedStore.RegionId != 0) {
            //    $scope.RegionId = $filter('filter')($scope.RegionList, { 'Id': selectedStore.RegionId })[0].Id.toString();
            //}


        }, 500);

        $scope.ZipCode = selectedStore.ZipCode;
        $scope.RefStoreCode = selectedStore.RefStoreCode;
        $scope.StoreManagerName = selectedStore.StoreManagerName;
        $scope.StoreManagerMobileNo = selectedStore.StoreManagerMobileNo;
        $scope.StoreManagerEmail = selectedStore.StoreManagerEmail;
        $scope.AreaManagerName = selectedStore.AreaManagerName;
        $scope.AreaManagerMobileNo = selectedStore.AreaManagerMobileNo;
        $scope.AreaManagerEmail = selectedStore.AreaManagerEmail;
        $scope.ZonalManagerName = selectedStore.ZonalManagerName;
        $scope.ZonalManagerMobileNo = selectedStore.ZonalManagerMobileNo;
        $scope.ZonalManagerEmail = selectedStore.ZonalManagerEmail;
        $scope.CircleHeadName = selectedStore.CircleHeadName;
        $scope.CircleHeadMobileNo = selectedStore.CircleHeadMobileNo;
        $scope.AddressofNominee = selectedStore.NomineeAddress;
        $scope.CircleHeadEmail = selectedStore.CircleHeadEmail;
        $scope.RegionalHeadName = selectedStore.RegionalHeadName;
        $scope.RegionalHeadMobileNo = selectedStore.RegionalHeadMobileNo;
        $scope.RegionalHeadEmail = selectedStore.RegionalHeadEmail;
        $scope.CorporateHeadName = selectedStore.CorporateHeadName;
        $scope.CorporateHeadMobileNo = selectedStore.CorporateHeadMobileNo;
        $scope.CorporateHeadEmail = selectedStore.CorporateHeadEmail;
        $scope.SQFTStoreArea = selectedStore.SQFTStoreArea;
        $scope.DaysOfExpire = selectedStore.DaysOfExpire;
        $scope.IsActive = selectedStore.IsActive;
        $scope.ElectricityBill = selectedStore.ElectricityBill;
        $scope.ElectricityBillPeriodUpTo = new Date(selectedStore.ElectricityBillPeriodUpTo) ;
        $scope.LeasePaidReceiptPeriodUpTo = new Date(selectedStore.LeasePaidReceiptPeriodUpTo);
        $scope.PropertyTaxPeriodUpTo = new Date(selectedStore.PropertyTaxPeriodUpTo);
        $scope.FireNocPeriodUpTo = new Date(selectedStore.FireNocPeriodUpTo);
        $scope.PollutionPeriodUpTo = new Date(selectedStore.PollutionPeriodUpTo);
        $scope.OwnershipDocPeriodUpTo = new Date(selectedStore.OwnershipDocPeriodUpTo);
        $scope.AdditionalDocPeriodUpTo = new Date(selectedStore.AdditionalDocPeriodUpTo);
        $scope.LeaseFromDate = new Date(selectedStore.AdditionalDocPeriodUpTo);
        $scope.ElectricityBillRemark = selectedStore.ElectricityBillRemark;
        $scope.LeasePaidReceiptRemark = selectedStore.LeasePaidReceiptRemark;
        $scope.PropertyTaxRemark = selectedStore.PropertyTaxRemark;
        $scope.FireNocRemark = selectedStore.FireNocRemark;
        $scope.PollutionRemark = selectedStore.PollutionRemark;
        $scope.OwnershipDocRemark = selectedStore.OwnershipDocRemark;
        $scope.AdditionalDocRemark = selectedStore.AdditionalDocRemark;
        if ($scope.ElectricityBill == 'none' || $scope.ElectricityBill == null || $scope.ElectricityBill == undefined) {
            $scope.Elec = 'none';
            $scope.Electr = 'none';
        }
        else {
            $scope.Elec = 'block';
            $scope.Electr = 'block';
        }
        $scope.RentAgreement = selectedStore.RentAgreement;
        if ($scope.RentAgreement == 'none' || $scope.RentAgreement == null || $scope.RentAgreement == undefined) {
            $scope.Rent = 'none';
            $scope.RentA = 'none';
        }
        else {
            $scope.Rent = 'block';
            $scope.RentA = 'block';
        }
        $scope.PropertyTaxPaidReceipt = selectedStore.PropertyTaxPaidReceipt;
        if ($scope.PropertyTaxPaidReceipt == 'none' || $scope.PropertyTaxPaidReceipt == null || $scope.PropertyTaxPaidReceipt == undefined) {
            $scope.Property = 'none';
            $scope.Propertyt = 'none';
        }
        else {
            $scope.Property = 'block';
            $scope.Propertyt = 'block';
        }
        $scope.BuildingPlan = selectedStore.BuildingPlan;
        if ($scope.BuildingPlan == 'none' || $scope.BuildingPlan == null || $scope.BuildingPlan == undefined) {
            $scope.Building = 'none';
            $scope.BuildingP = 'none';
        }
        else {
            $scope.Building = 'block';
            $scope.BuildingP = 'block';
        }
        $scope.StabilityStructureCertificate = selectedStore.StabilityStructureCertificate;
        if ($scope.StabilityStructureCertificate == 'none' || $scope.StabilityStructureCertificate == null || $scope.StabilityStructureCertificate == undefined) {
            $scope.Stability = 'none';
            $scope.StabilityS = 'none';
        }
        else {
            $scope.Stability = 'block';
            $scope.StabilityS = 'block';
        }
        $scope.CompletionCertificate = selectedStore.CompletionCertificate;
        if ($scope.CompletionCertificate == 'none' || $scope.CompletionCertificate == null || $scope.CompletionCertificate == undefined) {
            $scope.Completion = 'none';
            $scope.CompletionC = 'none';
        }
        else {
            $scope.Completion = 'block';
            $scope.CompletionC = 'block';
        }
        $scope.LoginId = LoginId;
        $scope.ShowDivStoreMasterForm();
        $scope.IsActionType = 2;
        //$scope.EmployeeUploadDocs = false;
        $scope.ButtonName = 'Update Store';
        $scope.ButtonReset = false;
        $scope.hideLoader();
    };
    $scope.triggerFileInput = function (inputId) {
        document.getElementById(inputId).click();
    };

    $scope.ResetStoreMasterForm = function () {
        $scope.Id = 0;
        $scope.PartyTypeId = '';
        $scope.StoreCode = '';
        $scope.RefStoreCode = '';
        $scope._StoreId = '';
        $scope.Category = '';
        $scope.StoreName = '';
        $scope.CompleteAddress = '';
        $scope.ProposedDate = new Date();
        $scope.StoreLocation = '';
        $scope.CityId = 0;
        $scope.CircleId = 0;
        $scope.RegionId = 0;
        $scope.ZipCode = '';
        $scope.StoreManagerName = '';
        $scope.StoreManagerMobileNo = '';
        $scope.StoreManagerEmail = '';
        $scope.AreaManagerName = '';
        $scope.AreaManagerMobileNo = '';
        $scope.AreaManagerEmail = '';
        $scope.ZonalManagerName = '';
        $scope.ZonalManagerMobileNo = '';
        $scope.ZonalManagerEmail = '';
        $scope.CircleHeadName = '';
        $scope.CircleHeadMobileNo = '';
        $scope.CircleHeadEmail = '';
        $scope.RegionalHeadName = '';
        $scope.RegionalHeadMobileNo = '';
        $scope.RegionalHeadEmail = '';
        $scope.CorporateHeadName = '';
        $scope.CorporateHeadMobileNo = '';
        $scope.CorporateHeadEmail = '';
        $scope.SQFTStoreArea = '';
        $scope.DaysOfExpire = '';
        $scope.IsActive = '';
        $scope.ElectricityBill = '';
        $scope.RentAgreement = '';
        $scope.PropertyTaxPaidReceipt = '';
        $scope.BuildingPlan = '';
        $scope.StabilityStructureCertificate = '';
        $scope.CompletionCertificate = '';
         $scope.ElectricityBillPeriodUpTo = new Date();
    $scope.LeasePaidReceiptPeriodUpTo = new Date();
    $scope.PropertyTaxPeriodUpTo = new Date();
    $scope.FireNocPeriodUpTo = new Date();
    $scope.PollutionPeriodUpTo = new Date();
    $scope.OwnershipDocPeriodUpTo = null;
    $scope.AdditionalDocPeriodUpTo = new Date();
    $scope.LeaseFromDate = new Date();
    $scope.ElectricityBillRemark = "";
    $scope.LeasePaidReceiptRemark = "";
    $scope.PropertyTaxRemark = "";
    $scope.FireNocRemark = "";
    $scope.PollutionRemark = "";
    $scope.OwnershipDocRemark = "";
    $scope.AdditionalDocRemark = "";
    }

    $scope.validate = function () {
        const alphanumericRegex = /^[a-zA-Z0-9]*$/;
        const inputValue = $scope.StoreCode;
        if (!alphanumericRegex.test(inputValue)) {
            $scope.showValidationError = true;
        } else {
            $scope.showValidationError = false;
        }
    };

    $scope.ApproveLicenseMaster = function (LicenseId) {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Id = 0;
        collectionobj.ActionType = 5;
        collectionobj.LicenseId = LicenseId;
        collectionobj.StoreId = $scope._StoreId;
        collectionobj.LoginId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/ApproveLicense"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            debugger;
            if (showMsgBox(response.data.Result)) {
                $scope.FireEmail(6, LicenseId, $scope._StoreId)
                $scope.GetLicenseMaster($scope._StoreId, $scope.UserId,'');
            }
            $scope.hideLoader();
        });
        $scope.hideLoader();

    }
    $scope.BindSidelicence = function (StoreId) {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 5;
        collectionobj.Id = StoreId;
        var getData = myService.methode('POST', ("../RetailSection/StoreComplianceStatusMaster"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            debugger;
            if (response.data.Result.length > 0) {
                $scope.Sidelicence = response.data.Result;
                $scope.SetStore = response.data.Result[0].StoreCode;
                $scope.ModifiedOn = response.data.Result[0].ModifiedOn;
                $scope.TotPerLicence = response.data.Result[0].TotLicence;
            }
            else {
                $scope.Sidelicence = "";
                $scope.SetStore = "";
                $scope.ModifiedOn = "";
                $scope.TotPerLicence = "";
            }
            $scope.hideLoader();
        });
    }
    //-------------------------------------Bulk Store

    $scope.StoreMasterList = [];
    $scope.DisplayExcel = function () {
        $scope.showLoader();
        var reader = new FileReader();
        var fileUploader = $('#input-excel');
        reader.readAsArrayBuffer(fileUploader[0].files[0]);
        reader.onload = function (fileUploader) {
            var data = new Uint8Array(reader.result);
            var wb = XLSX.read(data, { type: 'array' });
            var htmlstr = XLSX.write(wb, { sheet: "Sheet1", type: 'binary', bookType: 'html' });
            $('#wrapper')[0].innerHTML = htmlstr;
            var table = $('#wrapper').find('table');
            table.addClass('table compact table-hover table-striped table-bordered nowrap dataTable tblcss');

            $("tr:first-child td").each(function () {
                $(this).replaceWith('<th>' + $(this).text() + '</th>');
            });
            //$('<thead></thead>').prependTo('table').append($('table tr:first'));
            setTimeout(function () {
                var tr = table.find('tr');
                $.each(tr, function (index) {
                    $scope.StoreMasterData = { 'StoreName': "", 'CompleteAddress': "" };
                    var td = $(this).find('td');
                    if (td.length == 0) return;
                    $scope.StoreMasterData['RefStoreCode'] = $(td[0]).text();
                    $scope.StoreMasterData['StoreName'] = $(td[1]).text();
                    $scope.StoreMasterData['CompleteAddress'] = $(td[2]).text();
                    $scope.StoreMasterData['ProposedDate'] = (new Date()).toISOString().split('T')[0];//$(td[3]).text();
                    $scope.StoreMasterData['StoreLocation'] = $(td[4]).text();
                    $scope.StoreMasterData['ZipCode'] = $(td[5]).text();
                    $scope.StoreMasterData['StoreManagerName'] = $(td[6]).text();
                    $scope.StoreMasterData['StoreManagerMobileNo'] = $(td[7]).text();
                    $scope.StoreMasterData['StoreManagerEmail'] = $(td[8]).text();
                    $scope.StoreMasterData['AreaManagerMobileNo'] = $(td[9]).text();
                    $scope.StoreMasterData['AreaManagerName'] = $(td[10]).text();
                    $scope.StoreMasterData['AreaManagerEmail'] = $(td[11]).text();
                    $scope.StoreMasterData['ZonalManagerName'] = $(td[12]).text();
                    $scope.StoreMasterData['ZonalManagerMobileNo'] = $(td[13]).text();
                    $scope.StoreMasterData['ZonalManagerEmail'] = $(td[14]).text();
                    $scope.StoreMasterData['CircleHeadName'] = $(td[15]).text();
                    $scope.StoreMasterData['CircleHeadMobileNo'] = $(td[16]).text();
                    $scope.StoreMasterData['CircleHeadEmail'] = $(td[17]).text();
                    $scope.StoreMasterData['RegionalHeadName'] = $(td[18]).text();
                    $scope.StoreMasterData['RegionalHeadMobileNo'] = $(td[19]).text();
                    $scope.StoreMasterData['RegionalHeadEmail'] = $(td[20]).text();
                    $scope.StoreMasterData['CorporateHeadName'] = $(td[21]).text();
                    $scope.StoreMasterData['CorporateHeadMobileNo'] = $(td[22]).text();
                    $scope.StoreMasterData['CorporateHeadEmail'] = $(td[23]).text();
                    $scope.StoreMasterData['SQFTStoreArea'] = $(td[24]).text();
                    $scope.StoreMasterData['DaysOfExpire'] = $(td[25]).text();
                    $scope.StoreMasterData['IsActive'] = $(td[26]).text();
                    $scope.StoreMasterData['Category'] = $(td[27]).text();
                    $scope.StoreMasterData['RegionId'] = $(td[28]).text();
                    $scope.StoreMasterList.push($scope.StoreMasterData);
                    $scope.btnValiadte = true;
                })
                if ($scope.StoreMasterList.length == 0) return;
                $scope.disableValiadte = false;
                $scope.$applyAsync();
            }, 1000);
            $scope.hideLoader();
        }
    }
    $scope.btnValiadte = false;

    $scope.SaveRecord = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.StoreMaster = $scope.StoreMasterList;
        collectionobj.ActionType = 8;
        collectionobj.LoginId = LoginId;
        var getData = myService.methode('POST', "../RetailSection/IUDBulkStoreMaster", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            debugger;
            showMsgBox(response.data.Result);
            showMsgBox('999', 'Alert', 'Save Successfully', 'warning', 'btn-warning');
            location.reload();
            //setTimeout(function () {
            //    $scope.GetStoreMaster();

            //}, 500);
            $('#tab1-tab').click();
        });
    }
    //-------------------------------------end bulk
    //------------------------------Download With Name-----------------

    $scope.DownloadWithName = function (DownloadLink, Name) {
        var link = document.createElement('a');
        var extension = '.pdf'
        link.href = DownloadLink;
        link.download = Name + '_' + $scope.StoreCode + extension;
        link.click();
        link.remove();
    }

    $scope.ExportPdf = function () {
        $('#example').DataTable().buttons(0, 1).trigger();
    }
    $scope.ExportExcel = function () {
        $('#example').DataTable().buttons(0, 0).trigger();
    }
    $scope.ViewAllClicked = function () {
        var table = $('#example').DataTable();
        table.page.len(-1).draw(); // Set to show all rows, effectively removing pagination
    }
}