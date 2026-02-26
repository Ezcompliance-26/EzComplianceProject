app.PartySiteManagerController = function ($scope, $element, $filter, myService) {
    $scope.SetFocus('#txtSiteName');
    $scope.ValidFrom = new Date();
    $scope.ValidTo = new Date();
 
    $scope.Adminshow = function (input, imgfileid) {
        if ($('#fuCandidatePhoto').val().split('.').pop().toLowerCase() == 'pdf')
        {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $scope.AdminFileDoc = e.target.result;

                    $scope.$applyAsync();
                }
                filerdr.readAsDataURL(input.files[0]);
            }
            else {
                $scope.Image = '';
                $scope.$applyAsync();
            }
        }
        else {
            showMsgBox('999', 'Warning', 'Please Select only Pdf', 'warning', 'btn-warning');
            $('#fuCandidatePhoto').val('');
            return;
        }
      
    };
    $scope.Vendorshow = function (input, imgfileid) {

        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope.VendorFileDoc = e.target.result;

                $scope.$applyAsync();
            }
            filerdr.readAsDataURL(input.files[0]);
        }
        else {
            $scope.Image = '';
            $scope.$applyAsync();
        }
    };
    $scope.AllParty = function () {
        var getData = myService.methode('POST', ("../PartyMaster/GetPartyMasterDT"), { "ActionType": 5, "PartyType": $scope.PartyType });
        getData.then(function (response) {
            debugger;
            $scope.AllPartyList = response.data.Result;
        });
    }
    $scope.BindManpower = function () {
        var collectionobj = {};
        collectionobj.ActionType = 10;
        var getData = myService.methode('POST', ("../VenInvoice/GetValidateInvoice"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            debugger;
            $scope.ManpowerList = response.data;

        });
    }
    $scope.AllCountry = function () {
        var getData = myService.methode('POST', ("../PartyMaster/GetPartyMasterDT"), { "ActionType": 27 });
        getData.then(function (response) {
            debugger;
            $scope.AllCountryList = response.data.Result;
        });
    }
    $scope.AllState = function () {
        var getData = myService.methode('POST', ("../PartyMaster/GetPartyMasterDT"), { "ActionType": 28, "PartyId": $scope.CountryId });
        getData.then(function (response) {
            debugger;
            $scope.AllStateList = response.data.Result;
        });
    }
    $scope.AllCity = function () {
        var getData = myService.methode('POST', ("../PartyMaster/GetPartyMasterDT"), {"ActionType": 29, "PartyId": $scope.StateId});
        getData.then(function (response) {
            debugger;
            $scope.AllCityList = response.data.Result;
        });
    }
    $scope.AllPincode = function () {
        $scope.showLoader();
        if ($("#txtpincode").val().length == 6)
        { 
            var getData = myService.methode('POST', (APIURLPath + "UserSubscription/GetPinCodeList"), { "ActionType": 30, "PinCode": $scope.Pincode });
            getData.then(function (responsest) {
                debugger;
                if (responsest.data.length > 0)
                {
                    $("#ddlcity").empty();
                    $("#ddlstate").empty();
                    $("#ddlcountry").val(1);
                    for (var i = 0; i < responsest.data.length; i++) {
                        if (responsest.data[i].ty == 1) {
                            $("#ddlcity").append('<option value="' + responsest.data[i].val + '">' + responsest.data[i].txt + '</option>');
                        } else if (responsest.data[i].ty == 2) {
                            $("#ddlstate").append('<option value="' + responsest.data[i].val + '">' + responsest.data[i].txt + '</option>');
                        }
                    }
                }
              
            });
        }
        else if($("#txtpincode").val().length == 0)
        {
              
         
            $scope.CountryId = "";
            $scope.StateId = ""; 
            $scope.CityId = "";
            $("#ddlcity").empty();
            $("#ddlstate").empty();
            $("#ddlstate").append('<option value="">Select State</option>');
            $("#ddlcity").append('<option value="">Select City</option>');
          
        }
        $scope.hideLoader();
    }
    $scope.SaveRecord= function ()
    {
        if($scope.CLRARC=='1')
        {
            if ($scope.AdminFileDoc == '' || $scope.AdminFileDoc == undefined)
            {
                showMsgBox('999', 'Warning', 'Please Select Attachment', 'warning', 'btn-warning');
                return;
            }
            else
            { $scope.AfterSave(); }
        }
        else
        {
            $scope.AfterSave();
        }
    }
    $scope.AfterSave = function () {
        debugger;
        if (isValidate()) {
            $scope.showLoader();
            var collectionobj = {}; 
            collectionobj.PartyId = $scope.PartyId;
            collectionobj.PartyType = $scope.PartyType;
            collectionobj.SiteId = $scope.hfId;
            collectionobj.SiteName = $scope.SiteName; 
            collectionobj.Address = $scope.Address;   
            collectionobj.LocationCode = $scope.LocationCode;
            collectionobj.EmailId = $scope.EmailId;
            collectionobj.ContactNo = $scope.MobileNo;
            collectionobj.BankDetails = $scope.BankDetails;
            collectionobj.AccountNo = $scope.AccountNo;
            collectionobj.Description = $scope.Description;
            collectionobj.Panitno = $scope.Panitno;
            collectionobj.Gstinuin = $scope.Gstinuin;
            collectionobj.CreatedBy = LoginId;
            collectionobj.Pincode = $scope.Pincode; 
            collectionobj.CountryId = $("#ddlcountry").val();
            collectionobj.StateId = $("#ddlstate").val();
            collectionobj.CityId = $("#ddlcity").val();


            collectionobj.CLRARC = $scope.CLRARC;
            collectionobj.CLRLIC = $scope.CLRLIC;
            collectionobj.ContactPerson = $scope.ContactPerson;
            collectionobj.ContactMobile = $scope.ContactMobile;
            collectionobj.Descritpion = $scope.Descritpion;
            collectionobj.ValidFrom = $scope.ValidFrom;
            collectionobj.ValidTo = $scope.ValidTo;
            collectionobj.VendorFileDoc = $scope.VendorFileDoc;
            collectionobj.AdminFileDoc = $scope.AdminFileDoc;
            collectionobj.Manpowertype = $scope.Manpowertype;
            collectionobj.ManPowerCount = $scope.ManPowerCount; 



            if ($scope.Save == "Save") {
                collectionobj.ActionType = 1;
            }
            else {
                collectionobj.ActionType = 2; 
            }
            var getData = myService.methode('POST', ("../SiteManager/InsertUpdateDelSiteManager"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                if (showMsgBox(response.data.Result)) {
                    $scope.ClearControl(1);
                }
            });
        } 
    }
    $scope.DeleteRecord = function () {
        deleteConfirmbox("Do you want to delete this record?", $scope.deleteRecord);
    };

    $scope.deleteRecord = function () {
        debugger;
        var collectionobj = {};
        collectionobj.ActionType = 3;
        collectionobj.SiteId = $scope.hfId;  
        collectionobj.PartyId = $scope.hfId1;  
        var getData = myService.methode('POST', ("../SiteManager/InsertUpdateDelSiteManager"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            if (showMsgBox(response.data)) {
                $scope.ClearControl(1);
            }
        });
    };
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
        $scope.Save = "Save";
        $scope.disableAdd = false;
        $scope.disableEdit = false;
        $scope.disableDelete = true;
        $scope.disablePrint = true;
        $scope.disableClear = false;
        $scope.IsAdd = true;
        $scope.IsEdit = true;
        $scope.IsDelete = true;
        $scope.IsPrint = true;
        $scope.SiteName = ""; 
        $scope.Address = "";
        $scope.EmailId = "";
        $scope.MobileNo = "";
        $scope.Description = "";
        $scope.LocationCode = "";
        $scope.BankDetails = "";
        $scope.AccountNo = "";
        $scope.Panitno = "";
        $scope.Gstinuin = "";
        $scope.Pincode = "";
        $scope.CLRARC = "";
        $scope.CLRLIC = "";
        $scope.ContactPerson = "";
        $scope.ContactMobile = "";
        $scope.Descritpion = "";
        $scope.ValidFrom = "";
        $scope.ValidTo = "";
        $scope.Manpowertype = "";
        $scope.ManPowerCount = "";

        $scope.AdminFileDoc = "";
        $scope.VendorFileDoc = "";
        
        $("#txtpincode").val('');
        //$("#ddlcountry").val(0).change();
        //$("#ddlstate").val(0).change();
        //$("#ddlcity").val(0);
        $scope.CountryId = "";
        $scope.StateId = "";
        $scope.CityId = "";
        $scope.SetFocus('#txtSiteName');
        $scope.hfId = 0;
        $scope.hfId1 = 0;
        $scope.PartyMasterList = [];
        if (flag == 0) {
            showMsgBox('4');
        };

    }
    $scope.PartyMasterList = [];
    /*Search Button Click Event*/
    $scope.SearchRecord = function () {
        $('#collapseinputbox').attr('class', 'collapse in');
        $('#CollapseSearchTableList').attr('class', 'collapse');
        $scope.started();
    };

    $scope.started = function () {
        $scope.showLoader(); 
        var collectionobj = {};
        collectionobj.ActionType = 4; 
        debugger;
        var getData = myService.methode('POST', ("../SiteManager/GetSiteManagerListDT"), JSON.stringify(collectionobj));
        getData.then(function (response) { 
            var tblheader =
            [
                    { "HeaderText": "Sr.No.", "Value": "Id", "HeaderValue": "SiteId", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "srno" },
                    { "HeaderText": "Party Type", "HeaderValue": "PartyType", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Party Name", "Value": "PartyID", "HeaderValue": "PartyName", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "Site Name", "HeaderValue": "SiteName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    { "HeaderText": "Address", "HeaderValue": "Address", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Pincode", "HeaderValue": "Pincode", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    { "HeaderText": "Country", "Value": "CountryID", "HeaderValue": "CountryName", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "State", "Value": "StateID", "HeaderValue": "STATE_NM", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "City", "Value": "CityID", "HeaderValue": "CITY_NAME", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" }, 
                    { "HeaderText": "Email Id", "HeaderValue": "EmailId", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Contact No", "HeaderValue": "ContactNo", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    //{ "HeaderText": "BankDetails", "HeaderValue": "BankDetails", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    //{ "HeaderText": "Account No", "HeaderValue": "AccountNo", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    //{ "HeaderText": "Description", "HeaderValue": "Description", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    { "HeaderText": "PANIT NO", "HeaderValue": "PANITNO", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "GSTINUIN", "HeaderValue": "GSTINUIN", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    { "HeaderText": "Location", "HeaderValue": "LocationCode", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Manpower type", "HeaderValue": "Manpowertype", "Width": "100%", "ShowColumn": "No", "ImageColumn": "No" },
                    { "HeaderText": "ManPower Count", "HeaderValue": "ManPowerCount", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },

            ];

            $scope.PartySiteMasterList = response.data.Result;
            loadDataUsingPreDefinedColumn(tblheader, response.data.Result);
            $('#example tbody').on('dblclick', 'tr', function () {
                $scope.showLoader(); 
                var row = $('#example').DataTable().row(this).data(); 
                $scope.hfId = row[0];

             //   $scope.hfId = $(this).find('input[type="hidden"]').val();
                $scope.PartySiteMasterList = $filter('filter')($scope.PartySiteMasterList, { 'SiteId': $scope.hfId });
                $scope.hfId1 = row[2];

               $scope.PartyType = row[1]; 
         
                $scope.SiteName = row[3]; 
                $scope.Address = row[4];
                $scope.Pincode = row[5];
                $("#txtpincode").change();
                $scope.EmailId = row[9]
                $scope.MobileNo = row[10]; 
                //$scope.BankDetails = row[11];
                //$scope.AccountNo = row[12];
                $scope.Description = $scope.PartySiteMasterList[0].Description;
                $scope.Panitno = $scope.PartySiteMasterList[0].PANITNO;
                $scope.Gstinuin = $scope.PartySiteMasterList[0].GSTINUIN;
                $scope.LocationCode = $scope.PartySiteMasterList[0].LocationCode;


                $scope.CLRARC = $scope.PartySiteMasterList[0].CLRARC;
                $scope.CLRLIC = $scope.PartySiteMasterList[0].CLRLIC;
                $scope.ContactPerson = $scope.PartySiteMasterList[0].ContactPerson;
                $scope.ContactMobile = $scope.PartySiteMasterList[0].ContactMobile;
                $scope.Descritpion = $scope.PartySiteMasterList[0].Descritpion;
                $scope.ValidFrom = new Date($scope.PartySiteMasterList[0].ValidFrom);
                $scope.ValidTo = new Date($scope.PartySiteMasterList[0].ValidTo) ;
                $scope.Manpowertype = $scope.PartySiteMasterList[0].Manpowertype;
                $scope.ManPowerCount = $scope.PartySiteMasterList[0].ManPowerCount;

                $scope.AdminFileDoc = $scope.PartySiteMasterList[0].AdminFileDoc;
                $scope.VendorFileDoc = $scope.PartySiteMasterList[0].VendorFileDoc;

               
                setTimeout(function () {
                    $scope.AllParty();
                    $scope.PartyId = $scope.PartySiteMasterList[0].PartyId;
                    $scope.CountryId = $scope.PartySiteMasterList[0].CountryId;
                    $scope.AllState();
                    $scope.StateId = $scope.PartySiteMasterList[0].StateId;
                    $scope.AllCity();
                    $scope.CityId = $scope.PartySiteMasterList[0].CityId;
                }, 1000);

                $scope.Save = "Edit";
                $scope.disableDelete = false;
                $scope.disableAdd = false;
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
     
    /*Refresh Search Table Record*/
    $(document).on("click", ".RefreshSearchTable", function (e) {
        debugger;
        var panelToRefresh = $(this).closest('.panel').find('.refresh-container');
        var dataToRefresh = $(this).closest('.panel').find('.panel-wrapper');
        var loadingAnim = panelToRefresh.find('.loading-progress');
        panelToRefresh.show();
        setTimeout(function () {
            loadingAnim.addClass('la-animate');
        }, 100);
        $scope.started();
        return false;
    });

    $scope.PrintRecord = function () {
        var tblheader =
       [
                    { "HeaderText": "Sr.No.", "Value": "Id", "HeaderValue": "SiteId", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "srno" },
                    { "HeaderText": "Party Type", "HeaderValue": "PartyType", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Party Name", "Value": "PartyID", "HeaderValue": "PartyName", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "Site Name", "HeaderValue": "SiteName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Address", "HeaderValue": "Address", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Pincode", "HeaderValue": "Pincode", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Country", "Value": "CountryID", "HeaderValue": "CountryName", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "State", "Value": "StateID", "HeaderValue": "STATE_NM", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "City", "Value": "CityID", "HeaderValue": "CITY_NAME", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "" },
                    { "HeaderText": "Email Id", "HeaderValue": "EmailId", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Contact No", "HeaderValue": "ContactNo", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    //{ "HeaderText": "BankDetails", "HeaderValue": "BankDetails", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    //{ "HeaderText": "Account No", "HeaderValue": "AccountNo", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    //{ "HeaderText": "Description", "HeaderValue": "Description", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" }, 
                    { "HeaderText": "PANIT NO", "HeaderValue": "PANITNO", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "GSTINUIN", "HeaderValue": "GSTINUIN", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Location", "HeaderValue": "LocationCode", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                    { "HeaderText": "Manpower type", "HeaderValue": "Manpowertype", "Width": "100%", "ShowColumn": "No", "ImageColumn": "No" },
                    { "HeaderText": "ManPower Count", "HeaderValue": "ManPowerCount", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },

       ];
        $scope.PrintMaster(tblheader, $scope.PartyMasterList, window.document.title);
    };
}