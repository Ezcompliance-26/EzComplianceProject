//const { swal } = require("../../compliance/js/sweetalert2");

app.LicenseMasterController = function ($scope, $element, $filter, myService) {
    $scope.hfLicenseId = 0;
    $scope.selectedDocuments = [];
    $scope.selectedUsers = [];
    $scope.disableCheckall = true;
    $scope.selectAll == false; 

    $scope.BindAllDocumentList =   function () {
        var getData = myService.nonasyncmethode('GET', "../Retail/GetLicenseMasterDocumentList");
        getData.then(function (response) {
            $scope.AllDocumentList = response.data.Result; 
            $scope.chk = []; 
        });
    }

    $scope.chk = [];
   
     
    $scope.disableDelete = true;
    $scope.disablePrint = true;
    $scope.BindModuleTypeList = function () {
        var moduleTypeLst = [
            { "Module_Type": "Auditor", "Id": "3" },
            { "Module_Type": "Client", "Id": "4" },
        ];
        $scope.AllModuleTypeList = moduleTypeLst;
    }
    $scope.DefaultBind = function () {
        $scope.PartyTypeId = '4';
        var collectionobj = {};
        collectionobj.ActionType = 5; 
        collectionobj.PartyType = "Client";
        var getData = myService.nonasyncmethode('POST', "../PartyMaster/GetPartyMasterDT", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            $scope.AllPartyList = response.data.Result;
            $scope.disableCheckall = false;
            $scope.selectAll = false;
        });
    }

    $scope.AllPartySiteLoad =   function () {
        var collectionobj = {};
        collectionobj.ActionType = 5;
        var type = "";
        if ($scope.PartyTypeId == 3) {
            type = "Auditor";
        } else if ($scope.PartyTypeId == 4) {
            type = "Client";
        }
        else { type = ""; }
        collectionobj.PartyType = type;
        var getData = myService.nonasyncmethode('POST', "../PartyMaster/GetPartyMasterDT", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            $scope.AllPartyList = response.data.Result;
            $scope.disableCheckall = false;
            $scope.selectAll =  false;
        });
    }
    $scope.SaveRecord = function () {

        if ($scope.selectedUsers.length == 0) {
            showMsgBox('Please select atleast one user') ;
            return false;
        }
        else if ($scope.selectedDocuments.length == 0) {
            showMsgBox('Please select atleast one document') ; 
            return false;
        }

        if (isValidate()) {
            $scope.showLoader();
            var collectionobj = {};
            const FORMAT = "DD-MM-YYYY";
            collectionobj.PartyTypeId = $scope.PartyTypeId;
            collectionobj.PermissionId = $scope.PermissionId
            if ($scope.selectedUsers.includes(',') == false) {
                if ($scope.selectedUsers.length <=2)
                {
                    collectionobj.selectedUsersList = $scope.selectedUsers[0];
                }
                else {

                    collectionobj.selectedUsersList = $scope.selectedUsers.join(',');
                }
            }
            else {
                collectionobj.selectedUsersList = $scope.selectedUsers;
            }
            
            if ($scope.selectedDocuments.includes(',') == false) {
                if ($scope.selectedDocuments.length <=2) {
                    collectionobj.selectedDocumentsList = $scope.selectedDocuments[0];
                }
                else {

                    collectionobj.selectedDocumentsList = $scope.selectedDocuments.join(',');
                }
               
            }
            else {
                collectionobj.selectedDocumentsList = $scope.selectedDocuments;
            }
            //collectionobj.selectedUsersList = $scope.selectedUsers.includes(',') == false ? $scope.selectedUsers.join(',') : $scope.selectedUsers;
            //collectionobj.selectedDocumentsList = $scope.selectedDocuments.join(',') == false ? $scope.selectedDocuments.join(',') : $scope.selectedDocuments;
            collectionobj.LicenseName = $scope.LicenseName;
            collectionobj.StartDate = moment($scope.StartDate).format(FORMAT);
            collectionobj.EndDate = moment($scope.EndDate).format(FORMAT);
            collectionobj.CreatedBy = LoginId;
            collectionobj.LicenseMasterType = $scope.selectAll == true ? "Default" : "Manual";
            if ($scope.Save == "Save") {
                collectionobj.ActionType = 1;
            }
            else {
                collectionobj.ActionType = 1;
                collectionobj.LicenseId = $scope.hfLicenseId;
            }
            var getData = myService.methode('POST', ("../Retail/InsertUpdateDelLicenseDocumentMaster"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                if (showMsgBox(response.data.Result))
                {
                    $scope.BindAllDocumentList();
                    $scope.ClearControl(1);
                 
                }
            });
        }
    }

    $scope.ClearControl = function (flag) {
        if (flag == 1) {
            $scope.ResetControl(flag);
        }
        else {
            clearConfirmbox("Do you want to clear fields?", function () { $scope.ResetControl(0); });
        }
    };

    $scope.ResetControl = function (flag) {

        $scope.disableDelete = true;
        $scope.disablePrint = true;
        $scope.PartyTypeId = "";
        $scope.selectedUsers = [];
        $scope.LicenseName = "";
        $scope.selectedDocuments = [];
        $scope.StartDate = "";
        $scope.EndDate = "";
        $scope.Save = "Save";
        if (flag == 0) {
            showMsgBox('4');
        };
    }

    $scope.SearchRecord = function () {
        $('#collapseinputbox').attr('class', 'collapse in');
        $('#CollapseSearchTableList').attr('class', 'collapse');
        $scope.started();
    };


    $scope.change = function (index) {
        if ($scope.chk[index] == true) {
            $scope.chk[index] = false;
        }
        else {
            $scope.chk[index] = true;
        }

        seprator = ""
        stringbuilder = "";
        var count = 0;
        var chkflag = 0;
        $.each($scope.chk, function (index, val) {
            if (val === true) {
                stringbuilder = stringbuilder + seprator;
                stringbuilder = stringbuilder + index;
                $scope.selectedDocuments = stringbuilder;
                seprator = ","
                count += 1; 
            }
            else {
                chkflag = 1;
            }
        });
        if (chkflag == 1)
        { $scope.ChkAll = false } else { $scope.ChkAll = true }
        if ($scope.AllDocumentList.length == count) {
            $scope.ChkAll = true
        }
        else {
            $scope.ChkAll = false
        } 
        $scope.$applyAsync();
    }

    $scope.started = function () {
        $scope.AllPartySiteLoad();
        $scope.BindAllDocumentList();
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.ActionType = 5;
       
        var getData = myService.methode('POST', ("../Retail/SearchLicenseDocumentMaster"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            var tblheader =
                [
                    { "HeaderText": "LicenseId", "HeaderValue": "LicenseId", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "LicenseName", "HeaderValue": "LicenseName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "StartDate", "HeaderValue": "StartDate", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "EndDate", "HeaderValue": "EndDate", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "AssignTo", "HeaderValue": "AssignTo", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "PermissionFor", "HeaderValue": "PermissionFor", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                  
                ];

            $scope.LicenseMasterList = response.data.Result;
            loadDataUsingPreDefinedColumn(tblheader, response.data.Result);
            $('#example tbody').on('dblclick', 'tr', function () {
                $scope.showLoader();
                var row = $('#example').DataTable().row(this).data();
              
                $scope.hfLicenseId = row[0];
                $scope.hfLicenseName = row[1];
                $scope.hfStartDate = row[2];
                $scope.hfEndDate = row[3];
                $scope.LicenseMasterList = $filter('filter')($scope.LicenseMasterList, { 'LicenseId': $scope.hfLicenseId });
                $scope.PermissionId = $scope.LicenseMasterList[0].PermissionId;
                var collectionobj = {};
                collectionobj.ActionType = 4;
                collectionobj.Id = $scope.hfLicenseId;

                var getData = myService.methode('POST', ("../Retail/SearchLicenseDocumentMaster"), JSON.stringify(collectionobj));
                getData.then(function (dt) {
                    $scope.LicenseDocumentMasterList = dt.data.Result;
                    $scope.LicenseName = $scope.hfLicenseName;
                    $scope.StartDate = new Date($scope.hfStartDate);
                    $scope.EndDate = new Date($scope.hfEndDate);
                    $scope.PartyTypeId = $filter('filter')($scope.AllModuleTypeList, { 'Id': $scope.LicenseDocumentMasterList[0].PartyTypeId })[0].Id;
                    $scope.selectedUsers = $scope.LicenseDocumentMasterList[0].UserIds;
                  
                    var List = $scope.LicenseDocumentMasterList[0].DocumentsId;
                    var List1 = List.split(',');
                    seprator = "";
                    stringbuilder = ""; 
                    var count = 0;
                    for (let i = 0; i < List1.length; i++) {
                        stringbuilder = stringbuilder + seprator + List1[i];
                        seprator = ",";
                        $scope.chk[List1[i]] = true;
                        $scope.selectedDocuments = stringbuilder;
                    } 
                    $scope.Save = "Edit";
                    $scope.disableAdd = false;
                    $scope.disableDelete = false;
                    $scope.$applyAsync();
                    $('.br-pageheader').fadeIn();
                    $('#collapseinputbox').fadeIn();
                    $('#CollapseSearchTableList').fadeOut();
                    $scope.hideLoader();
                });
            });
        });
        $scope.hideLoader();
    };

    $scope.SelectAllUser = function () {
        if ($scope.selectAll) {
            $scope.selectedUsers = $scope.AllPartyList.map(function (user) {
                return user.PartyId;
            });
            $scope.disableUserDropdown = true;
        } else {
            $scope.disableUserDropdown = false;
            $scope.selectedUsers = [];
        }
    };
}
