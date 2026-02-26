app.DepartmentMasterController = function ($scope, $element, $filter, myService) {
    $scope.disableDelete = true;
    $scope.disablePrint = true;
    debugger
    $scope.BindModuleTypeList = function () {
        var moduleTypeLst = [
            { "Module_Type": "Auditor", "Id": "3" },
            { "Module_Type": "Client", "Id": "4" },
        ];
        $scope.AllModuleTypeList = moduleTypeLst;
    }

    $scope.AllPartySiteLoad = function () {
        var collectionobj = {};
        collectionobj.ActionType = 5;
        var type = "";
        if ($scope.PartyType == 3) {
            type = "Auditor";
        } else if ($scope.PartyType == 4) {
            type = "Client";
        }
        else { type = ""; }
        collectionobj.PartyType = type;
        var getData = myService.methode('POST', "../PartyMaster/GetPartyMasterDT", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            $scope.AllPartyList = response.data.Result;
        });
    }
    $scope.SaveRecord = function () {
        debugger;
        if (isValidate()) {
            $scope.showLoader();
            var collectionobj = {};
            const FORMAT = "DD-MM-YYYY";
            collectionobj.PartyType = $scope.PartyType;
            collectionobj.PartyId = $scope.PartyId;
            collectionobj.PartyName = $scope.DepartmentName;
            collectionobj.Description = $scope.Description;
            collectionobj.StartDate = moment($scope.StartDate).format(FORMAT);
            collectionobj.EndDate = moment($scope.EndDate).format(FORMAT);
            collectionobj.Description = $scope.Description;
            collectionobj.CreatedBy = LoginId;
            if ($scope.Save == "Save") {
                collectionobj.ActionType = 1;
            }
            else {
                collectionobj.ActionType = 2;
                collectionobj.Id = $scope.hfId;
            }
            var getData = myService.methode('POST', ("../Retail/InsertUpdateDelDepartmentMaster"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                if (showMsgBox(response.data.Result)) {
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
        debugger;
        $scope.disableDelete = true;
        $scope.disablePrint = true;
        $scope.PartyType = "";
        $scope.PartyId = "";
        $scope.DepartmentName = "";
        $scope.StartDate = "";
        $scope.EndDate = "";
        $scope.Description = "";
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

    $scope.started = function () {
        debugger
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.ActionType = 4;
        debugger;
        var getData = myService.methode('POST', ("../Retail/SearchDepartmentMaster"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            var tblheader =
            [
                    { "HeaderText": "Sr.No.", "Value": "DepartmentId", "HeaderValue": "DepartmentId", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "srno" },
                    { "HeaderText": "Party Type", "HeaderValue": "PartyType", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Party Name", "HeaderValue": "PartyName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Department Name", "HeaderValue": "DepartmentName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Description", "HeaderValue": "Description", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "StartDate", "HeaderValue": "Startfrom", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "EndDate", "HeaderValue": "LastDate", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },

            ];
            debugger
            $scope.MasterList = response.data.Result;
            loadDataUsingPreDefinedColumn(tblheader, response.data.Result);
            $('#example tbody').on('dblclick', 'tr', function () {
                $scope.showLoader();
                var row = $('#example').DataTable().row(this).data();
                $scope.hfId = $(this).find('input[type="hidden"]').val();
                $scope.MasterList = $filter('filter')($scope.MasterList, { 'DepartmentId': $scope.hfId });
                $scope.PartyType = $scope.MasterList[0].DPartyType;
                $scope.AllPartySiteLoad();
                setTimeout(function () {
                    $scope.PartyId = $scope.MasterList[0].DPartyId
                }, 500);
                $scope.$applyAsync();
                const FORMAT = "DD-MM-YYYY";
                $scope.DepartmentName = $scope.MasterList[0].DepartmentName;
                $scope.Description = $scope.MasterList[0].Description;
                $scope.StartDate = new Date($scope.MasterList[0].StartDate);
                $scope.EndDate = new Date($scope.MasterList[0].EndDate);

                $scope.Save = "Edit";
                $scope.$applyAsync();
                $scope.disableDelete = false;
                $scope.disableAdd = false;
                $scope.disableDelete = true;
                $scope.disablePrint = true;
                $scope.$apply();
                //collapse box
                $('.br-pageheader').fadeIn();
                $('#collapseinputbox').fadeIn();
                $('#CollapseSearchTableList').fadeOut();

                $scope.SetFocus('#ddlState', true);
                $scope.hideLoader();


            });
        });
        $scope.hideLoader();
    };
}
