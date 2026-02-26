app.ComplianceDocController = function ($scope, $element, $filter, myService) {

    $scope.FolderLocation =  "C:\ComplianceFolder";
    
    $scope.LoadData = function () { 
        var StoreId = window.location.href.slice(window.location.href.indexOf('?') + 1).split('%');
        $scope.BindReort(StoreId[0]);
        $scope.SectionMenuName = "Compliance Report";
    }
    $scope.BindReort = function (StoreId) {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.ActionType = 14; 
        collectionobj.StoreCode = StoreId
        var getData = myService.methode('POST', ("../RetailSection/SearchCompliance"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.ReportList = response.data.Result;
            $scope.hideLoader();
        });
        $scope.hideLoader();
    };
    $scope.fileList = [];
    $scope.curFile;
    $scope.ImageProperty = {
        file: ''
    }





    $scope.selectedOptions = [];

    $scope.toggleSelection = function(option) {
        var idx = $scope.selectedOptions.indexOf(option);

        if (idx > -1) {
            $scope.selectedOptions.splice(idx, 1);
        } else {
            $scope.selectedOptions.push(option);
        }
     
        var x = document.getElementById("IsOpenAct");
        if (idx == 0)
        {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    };

    $scope.isChecked = false;
    $scope.toggleSelectAll = function () {
        if ($scope.isChecked) {
            // If checkbox is checked, select all parties
            $scope.selectedOptions = $scope.ActList.map(function (act) {
                return act;
            });
            var x = document.getElementById("IsOpenAct");
            x.style.display = "block";
        } else {
            // If checkbox is unchecked, clear all selections
            $scope.selectedOptions = [];
            var x = document.getElementById("IsOpenAct");
            x.style.display = "none";
        }
        //   console.log($scope.selecteAll);
    };

    $scope.setFile = function (element) {
        $scope.fileList = [];
        // get the files
        var files = element.files;
        for (var i = 0; i < files.length; i++) {
            fileName = files[i].name;
            if (fileName != "") 
            {

                FormatFile = files[i].type;
                if (FormatFile == "application/vnd.ms-excel") {
                    $scope.ImageProperty.file = files[i];
                    $scope.fileList.push($scope.ImageProperty);
                    $scope.ImageProperty = {};
                    $scope.$apply();
                }
                else if (FormatFile = "application/pdf")
                {
                    $scope.ImageProperty.file = files[i];
                    $scope.fileList.push($scope.ImageProperty);
                    $scope.ImageProperty = {};
                    $scope.$apply();
                }
                else if (FormatFile == 'image/png')
                { 
                    $scope.ImageProperty.file = files[i];
                    $scope.fileList.push($scope.ImageProperty);
                    $scope.ImageProperty = {};
                    $scope.$apply();
                }
                else if (FormatFile == 'image/jpeg')
                {
                    $scope.ImageProperty.file = files[i];
                    $scope.fileList.push($scope.ImageProperty);
                    $scope.ImageProperty = {};
                    $scope.$apply();
                }
                else if (FormatFile == 'image/jpg')
                {
                    $scope.ImageProperty.file = files[i];
                    $scope.fileList.push($scope.ImageProperty);
                    $scope.ImageProperty = {};
                    $scope.$apply();
                }
                else {
                    showMsgBox('999', 'Rejected', 'File Not Correct Format,please Upload in jpg or png format', 'warning', 'btn-warning');
                    return;
                } 
            }
            else {
                showMsgBox('999', 'Rejected', 'File Not Correct Format,please Upload in ' + FormatFile + ' format', 'warning', 'btn-warning');
                return;
            }
        }  
    }

    $scope.UploadFile = function () {

        for (var i = 0; i < $scope.fileList.length; i++)
        {
            $scope.UploadFileIndividual($scope.fileList[i].file, $scope.fileList[i].file.name, $scope.fileList[i].file.type, $scope.fileList[i].file.size, i, $scope.StoreId);
        }

    }
  
    $scope.ComplianceMasterList = [];
    $scope.DisplayExcel = function ()
    {
        debugger;
        $scope.showLoader();
        var reader = new FileReader();
        var fileUploader = $('#file');

        for (var i = 0; i < fileUploader[0].files.length; i++)
        {
            if (fileUploader[0].files[i].type == "application/vnd.ms-excel")
            {
                var newuploader = fileUploader[0].files[i]; 
            }

        }


        reader.readAsArrayBuffer(newuploader);
        reader.onload = function (newuploader) {
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
                    $scope.ComplianceMaster = { 'DocumentNo': "", 'DocumentName': "" };
                    var td = $(this).find('td');
                    if (td.length == 0) return;
                    $scope.ComplianceMaster['Act'] = $(td[1]).text();
                    $scope.ComplianceMaster['DocumentNo'] = $(td[2]).text();
                    $scope.ComplianceMaster['DocumentName'] = $(td[3]).text();
                    $scope.ComplianceMaster['Type'] = $(td[4]).text();
                    $scope.ComplianceMaster['Frequency'] = $(td[5]).text();
                    $scope.ComplianceMaster['FilePath'] = $(td[6]).text();

                 
                    $scope.ComplianceMasterList.push($scope.ComplianceMaster);
                    $scope.btnValiadte = true;
                })
                if ($scope.ComplianceMasterList.length == 0) return;
                $scope.disableValiadte = false;
                $scope.$applyAsync();
            }, 1000);
            $scope.hideLoader();
        }

       
    }
    $scope.UploadFileIndividual = function (fileToUpload, name, type, size, index, StoreId) {
        //Create XMLHttpRequest Object
        var reqObj = new XMLHttpRequest();

        //event Handler
        reqObj.upload.addEventListener("progress", uploadProgress, false)
        reqObj.addEventListener("load", uploadComplete, false)
        reqObj.addEventListener("error", uploadFailed, false)
        reqObj.addEventListener("abort", uploadCanceled, false) 
        reqObj.open("POST", "/RetailSection/UploadFiles", true); 
        reqObj.setRequestHeader("Content-Type", "multipart/form-data"); 
        reqObj.setRequestHeader('X-File-Name', name);
        reqObj.setRequestHeader('X-File-Type', type);
        reqObj.setRequestHeader('X-File-Size', size);
        reqObj.setRequestHeader('StoreId', StoreId); 
        reqObj.send(fileToUpload); 
        function uploadProgress(evt) {
            //if (evt.lengthComputable)
            //{

            //    var uploadProgressCount = Math.round(evt.loaded * 100 / evt.total);

            //    //document.getElementById('P' + index).innerHTML = uploadProgressCount;

            //    if (uploadProgressCount == 100) {
            //        document.getElementById('P' + index).innerHTML =
            //       '<i class="fa fa-refresh fa-spin" style="color:maroon;"></i>';
            //    }

            //}
        }

        function uploadComplete(evt) { 
            document.getElementById('P' + index).innerHTML = 'Saved';
            $scope.NoOfFileSaved++;
            $scope.$apply();
        }

        function uploadFailed(evt) {
            document.getElementById('P' + index).innerHTML = 'Upload Failed..';
        }

        function uploadCanceled(evt) { 
            document.getElementById('P' + index).innerHTML = 'Canceled....';
        }

    }


    $scope.Saveexcelfile = function ()
    {
        if ($scope.ComplianceMasterList.length == 0)
        {
            showMsgBox('999', 'Alert', 'Excel not Fetching ,please refresh page, or load again.', 'warning', 'btn-warning');
            return;
        }
        else if ($scope.StoreId==null||$scope.StoreId==undefined)
        {
            showMsgBox('999', 'Alert', 'Please Select Store Code.', 'warning', 'btn-warning');
            return;
        }
        else if ($scope.FY == null || $scope.FY == undefined) {
            showMsgBox('999', 'Alert', 'Please Select Financial Year.', 'warning', 'btn-warning');
            return;
        }
        else if ($scope.CMonth == null || $scope.CMonth == undefined) {
            showMsgBox('999', 'Alert', 'Please Select Month.', 'warning', 'btn-warning');
            return;
        }
        else
           {
            $scope.showLoader();
        var collectionobj = {};
        collectionobj.ComplianceList = $scope.ComplianceMasterList;
        collectionobj.StoreCode = $scope.StoreId; 
        collectionobj.ExecuterId = LoginId; 
        collectionobj.FY = $scope.FY;
        collectionobj.CMonth = $scope.CMonth;
        collectionobj.ActionType = 12;
     
        var getData = myService.methode('POST', "../RetailSection/IUDExcel", '{obj:' + JSON.stringify(collectionobj) + '}');
        getData.then(function (response) {
            debugger;
            showMsgBox(response.data.Result);
            showMsgBox('999', 'Alert', 'Save Successfully', 'warning', 'btn-warning');
            setTimeout(function () {
                $scope.SearchRecord();

            }, 500);
         
        });
    }
    }

    $scope.downloadAll = function () {
        $scope.selectedone = [];

        for (let i = 0; i < $scope.RetailDocumentList.length; i += 1)
        { 
            setTimeout(function () {
                
                var check=$('input:checkbox[Id=checkbox'+i+']').is(':checked');
                if(check==true)
                    {
                    $scope.selectedone.push($scope.RetailDocumentList[i].DocumentPath);
                    $scope.id = $scope.RetailDocumentList[i].DocumentName;
                    var link = document.createElement('a');
                    var ext = /^.+\.([^.]+)$/.exec($scope.RetailDocumentList[i].DocumentPath);
                    var extension = '';

                    if (ext[1] == 'pdf') {
                        extension = '.pdf'
                        link.href = $scope.RetailDocumentList[i].DocumentPath;
                        link.download = $scope.RetailDocumentList[i].DocumentName + extension;
                        link.click();
                        link.remove();

                    }
                    else{ 
                        link.href = $scope.RetailDocumentList[i].DocumentPath;
                        link.download = $scope.RetailDocumentList[i].DocumentName + '.'+ext[1];
                        link.click();
                        link.remove();
                    }
                    //else if (ext[1] == 'jpeg') {
                    //    extension = '.jpeg'
                    //    link.href = $scope.RetailDocumentList[i].DocumentPath;
                    //    link.download = $scope.RetailDocumentList[i].DocumentName + extension;
                    //    link.click();
                    //    link.remove();
                    //}

                }
            }
                , i * 200);
        }

    }


    
  
    $scope.SetStoreCode=function(StoreId)
    {
        $scope.StoreCode = $filter('filter')($scope.StoreList, { 'StoreId': StoreId });
        $scope.StoreCode = $scope.StoreCode[0].StoreCode;
    }
    $scope.OpenBulkpannel = false;
    $scope.forexecuter = false;
    $scope.BindStore = function () {
     
        $scope.forexecuter = false;
        $scope.showLoader();
        var collectionobj = {};
        if ($scope.LoginAs == 'Executer')
        {
            collectionobj.ActionType = 5;
          
        }
        else if ($scope.LoginAs == 'Client')
        {
            collectionobj.ActionType = 3;
           
        }
        else{}
     
        collectionobj.Id = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/SearchCompliance"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.StoreList = response.data.Result;
            $scope.hideLoader();
        });
        $scope.hideLoader();
    };
    $scope.BindExecuter = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.ActionType = 10;
        collectionobj.Id = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/SearchCompliance"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.LoginAs = response.data.Result[0].LoginAs;
            $scope.hideLoader();
            $scope.BindStore();
        });
        $scope.hideLoader();
    };


 
    $scope.BindAct = function (StoreCode) {
        $scope.showLoader();
        var collectionobj = {};
      
       if ($scope.LoginAs == 'Client') {
            $scope.forexecuter = false;

       }
       else{
           $scope.forexecuter = true; 
       } 
        collectionobj.ActionType = 4;
        collectionobj.Id = LoginId;
        collectionobj.StoreCode = StoreCode
        var getData = myService.methode('POST', ("../RetailSection/SearchCompliance"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.ActList = response.data.Result;
            $scope.IsOpenAct = true;
            $scope.hideLoader();
        });
        $scope.hideLoader();
    };
   
    $scope.BindFinacialYear = function () {
        var getData = myService.methode('POST', ("../VenInvoice/GetVenInvoiceListDT"), { "ActionType": 6 });
        getData.then(function (response) {
            debugger;
            $scope.finacialyearList = response.data;
        });
    }
    $scope.BindMonth = function () {
        var getData = myService.methode('POST', ("../VenInvoice/GetVenInvoiceListDT"), { "ActionType": 7 });
        getData.then(function (response) {
            debugger;
            $scope.MonthList = response.data;
        });
    }
    $scope.OpenPanel = function () {
        $scope.OpenBulkpannel = true;
    }
    $scope.closePanel = function () {
        $scope.OpenBulkpannel = false;
    }
    $scope.Redirecttoreport = function ()
    {
        window.top.location.href = '../RetailSection/ComplianceHistory?'+$scope.StoreId;
    }
     

    
    $scope.SearchRecord = function () {


        if (isValidate()) {
            if ($scope.selectedOptions.length == 0) {
                showMsgBox('999', 'Alert', 'Please Select Act', 'warning', 'btn-warning');
                return;
            }
            else {
                var collectionobj = {};
                collectionobj.StoreId = $scope.StoreId;
                collectionobj.ActList = $scope.selectedOptions;
                collectionobj.FY = $scope.FY;
                collectionobj.CMonth = $scope.CMonth;
                collectionobj.ActionType = 6;
                collectionobj.LoginId = LoginId;
                var getData = myService.methode('POST', ("../RetailSection/BulkActSave"), JSON.stringify(collectionobj));
                getData.then(function (response) {

                    if (response.data.Result[0].ExecuterId == '-1') {
                        if ($scope.LoginAs == 'Executer') {

                            ComplianceConfirmation("Add New Record", function () { $scope.SaveRecord(); });
                        }
                        else if ($scope.LoginAs == 'Client') {
                            showMsgBox('999', 'Alert', 'Executer Not Submitted data, please wait', 'warning', 'btn-warning');
                            return;
                        }
                        else { return; }
                    }
                    else {
                        $scope.RetailDocumentList = response.data.Result;
                        var lastline = response.data.Result.length - 1;
                        $scope.LastUpdate = $scope.RetailDocumentList[lastline].UpdatedON;



                    }
                });
            }
        }
    }
    $scope.exportReportToExcel = function () { 

        
     
        var uri = 'data:application/vnd.ms-excel;base64,',
     template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>',
     base64 = function (s) {
         return window.btoa(unescape(encodeURIComponent(s)))
     },
     format = function (s, c) {
         return s.replace(/{(\w+)}/g, function (m, p) {
             return c[p];
         })
     }
        var toExcel = document.getElementById("example1").innerHTML;
        var ctx = {
            worksheet: name || '',
            table: toExcel
        };
        var link = document.createElement("a");
        link.download = "export.xls";
        link.href = uri + base64(format(template, ctx))
        link.click();
 
    }
    $scope.aftersaveRecord = function () {
        if (isValidate()) {
            var collectionobj = {};
            collectionobj.StoreId = $scope.StoreId;
            collectionobj.ActList = $scope.selectedOptions;
            collectionobj.FY = $scope.FY;
            collectionobj.CMonth = $scope.CMonth;
            collectionobj.ActionType = 6;
            collectionobj.LoginId = LoginId;
            var getData = myService.methode('POST', ("../RetailSection/BulkActSave"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                $scope.RetailDocumentList = response.data.Result;
                var lastline = response.data.Result.length-1;
                $scope.LastUpdate = $scope.RetailDocumentList[lastline].UpdatedON;
            });
        }
    }
    $scope.Filter = function (filter) {
        if (isValidate()) {
            var collectionobj = {};
            collectionobj.StoreId = $scope.StoreId;
            collectionobj.Act = $scope.Act;
            collectionobj.FY = $scope.FY;
            collectionobj.CMonth = $scope.CMonth;
            collectionobj.ActionType = 9;
            collectionobj.LoginId = LoginId;
            collectionobj.Id = filter;
            var getData = myService.methode('POST', ("../RetailSection/SearchRETAILCompliance"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                $scope.RetailDocumentList = response.data.Result;
                var lastline = response.data.Result.length - 1;
                $scope.LastUpdate = $scope.RetailDocumentList[lastline].UpdatedON;
            });
        }
    }
    
    $scope.ExistsFile = function () { 
            var collectionobj = {};  
            collectionobj.StoreId = $scope.StoreId;
            collectionobj.Act = $scope.Act;
            collectionobj.FY = $scope.FY;
            collectionobj.CMonth = $scope.CMonth;
            collectionobj.ActionType = 6;
            collectionobj.LoginId = LoginId;
            collectionobj.FolderLocation = $scope.FolderLocation;
            var getData = myService.methode('POST', ("../RetailSection/Download"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                
                $scope.exportReportToExcel();
            });
        } 
    $scope.SaveRecord = function () {

        if (isValidate()) {

            var collectionobj = {};
            collectionobj.StoreId = $scope.StoreId;
            collectionobj.ActList = $scope.selectedOptions;
            collectionobj.FY = $scope.FY;
            collectionobj.CMonth = $scope.CMonth;
      
            collectionobj.ActionType = 15;
            collectionobj.LoginId = LoginId;
            var getData = myService.methode('POST', ("../RetailSection/BulkActSave"), JSON.stringify(collectionobj));
            //var getData = myService.methode('POST', ("../RetailSection/IUDRetailcompliance"), JSON.stringify(collectionobj));
            getData.then(function (response) { 
                showMsgBox('999', 'Save', 'Save Successfully', 'warning', 'btn-success');
                    $scope.aftersaveRecord();
                    $scope.FireEmail(12, $scope.StoreId, $scope.Act);
                
            });
        }
    }
    $scope.UploadDocument = function (Id) {

        if (isValidate()) { 
            var collectionobj = {};
            collectionobj.StoreId = $scope.StoreId;
            collectionobj.Act = $scope.Act;
            collectionobj.FY = $scope.FY;
            collectionobj.CMonth = $scope.CMonth;
            collectionobj.ActionType = 8;
            collectionobj.LoginId = LoginId;
            collectionobj.DocumentPath = $scope.FileDoc;
            collectionobj.Id = Id;
            var getData = myService.methode('POST', ("../RetailSection/IUDRetailUpdatecompliance"), JSON.stringify(collectionobj));
            getData.then(function (response) {
                if (showMsgBox(response.data.Result))
                {
                    $scope.aftersaveRecord();
                    $scope.FireEmail(13, $scope.StoreId, Id);
                }
            });
        }
    } 
    $scope.show = function (input, Id, format) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $scope.FileDoc = e.target.result; 
                $scope.$applyAsync();
            }
            filerdr.readAsDataURL(input.files[0]);
        }
        else {
            $scope.Image = '';
            $scope.$applyAsync();
        }
    };
    $scope.ValidateFileDoc = function (index, FormatFile,Id) {
        fileName = document.querySelector('#fuCandidatePhoto' + index).value;
        if (fileName != "") {
            extension = fileName.substring(fileName.lastIndexOf('.') + 1);
            if (FormatFile == extension) {
                $scope.UploadDocument(Id);
            }
            else if (FormatFile == 'image') {
                if (extension == 'jpg') {
                    $scope.UploadDocument(Id);
                }
                else if (extension == 'png') {
                    $scope.UploadDocument(Id);
                }
                else {
                    showMsgBox('999', 'Rejected', 'File Not Correct Format,please Upload in jpg or png format', 'warning', 'btn-warning');
                    return;
                }
            }
            else {
                showMsgBox('999', 'Rejected', 'File Not Correct Format,please Upload in ' + FormatFile + ' format', 'warning', 'btn-warning');
                return;
            }
        } else {
            showMsgBox('999', 'OOps !', 'File Not Found,Please Upload in proper way.', 'warning', 'btn-warning');
            return;
        }

    }


}
    
function ComplianceConfirmation(confirmText, functions) {
    swal({
        title: "Record Not Found?",
        text: confirmText,
        type: "error",
        showCancelButton: true,
        confirmButtonClass: 'btn-danger',
        confirmButtonText: "Add it",
        closeOnConfirm: false
    }, functions);
}