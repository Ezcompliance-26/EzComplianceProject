app.LSDController = function ($scope, $element, $filter, myService) {
    $scope.LicenceS = "";
    $scope.InvoiceSt = "";
    $scope.GetRegion = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 2;
     
        collectionobj.loginType = loginType; 
        collectionobj.UserId = LoginId; 
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.RegionList = response.data.Result; 
            $scope.hideLoader();
        }); 
    };

    $(document).ready(function () {
        setTimeout(function () {
            $(document).on("click", ".badge", function () {
                $(this).removeClass("bg-light").addClass("bg-warning");
                $(".badge").not(this).removeClass("bg-warning").addClass("bg-light");
            });
        }, 2000);  // Delay for 1 second to ensure Angular has rendered everything
    });

    $scope.GetDocumentStatus = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 4; 
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.DocumentListSatus = response.data.Result;
            $scope.hideLoader();
        });
    };
       

    $scope.GetPaymentStatus = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 5;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.PaymentList = response.data.Result;
            $scope.hideLoader();
        });
    };
    $scope.BindLicenceStatus =function()
    {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 5;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.LicenceStatus = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.BindLicenceType=function()
    {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 6;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.LicenseTypeList = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.BindAddress= function ()
    {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 12;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.AddressList = response.data.Result;
            $scope.hideLoader();
        });
        
    }
    $scope.BindClientList = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action =7;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.ClientList = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.BindInvoiceStatus = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 8;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.InvoiceStatusList = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.BindStore = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 9;
        collectionobj.LoginAs = $scope.LoginAs;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.StoreLList = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.BindState = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 10;
        collectionobj.LoginAs = $scope.LoginAs;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.StateList = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.BindLicence = function () {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 11;
        collectionobj.loginType = loginType;
        collectionobj.UserId = LoginId;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            $scope.LicenceList = response.data.Result;
            $scope.hideLoader();
        });
    }
    $scope.FilterLIst = [];
    stringbuilder = "";
    seprator = "";
    $scope.SetRegion = function(RegionId)
    { 
        $scope.dvRegion=1; 
        $scope.RegionId = RegionId;
        $scope.FilterGraph(); 
     
    }
    $scope.SetDocStatus = function (Status) {
        $scope.dvStatus = 1;
      
        $scope.DocStatus = Status;
        $scope.FilterGraph();
    }
   
    $scope.SetLicenceStatus = function (LicenceStatus) {
        
        $scope.dvLicenceStatus = 1;
        $scope.LicenceStatus = LicenceStatus;
        $scope.FilterGraph();
    }
    $scope.SetExpiryStatus = function (ExpiryStatus) {

        $scope.dvExpiryStatus = 1;
        $scope.ExpiryStatus = ExpiryStatus;
        $scope.FilterGraph();
    }

    $scope.SetLicenceType = function (LicenceType) {
       
        $scope.dvFreshRenewal = 1;
        $scope.LicenceType = LicenceType;
        $scope.FilterGraph();
    }
    $scope.SetClient = function (Client) {
       
      
        $scope.dvClient = 1;
      
        $scope.Client = Client;
        $scope.FilterGraph();
    }
    $scope.SetInvoiceStatus = function (InvoiceStatus) {
      
        $scope.dvInvoice = 1;
       
        $scope.InvoiceStatus = InvoiceStatus;
        $scope.FilterGraph();
    }
    $scope.SetPaymentStatus = function (PaymentStatus) {
      
     
        $scope.dvPayment = 1;
      
        $scope.PaymentStatus = PaymentStatus;
        $scope.FilterGraph();
    }
    $scope.SetStore = function (Store) {
      
        $scope.dvOutlet = 1;
      
        $scope.Store = Store;
        $scope.FilterGraph();
    }
    $scope.SetState = function (State) {
   
        $scope.dvState = 1;
    
        $scope.State = State;
        $scope.FilterGraph();
    }
    $scope.SetAddress = function (Address) {
       
        $scope.dvAddress = 1;
        $scope.Address = Address;
        $scope.FilterGraph();
    }
    $scope.SetLicense = function (License) { 

        $scope.dvLicenceType = 1;
        $scope.License = License;
        $scope.FilterGraph();
    }
    $scope.Reset = function()
    {
        $scope.RegionId = "";
        $scope.DocStatus = "";
        $scope.LicenceStatus = "";
        $scope.ExpiryStatus = "";
        $scope.LicenceType = "";
        $scope.Client = "";
        $scope.InvoiceStatus = "";
        $scope.PaymentStatus = "";
        $scope.Store = "";
        $scope.State = "";
        $scope.Address = "";
        $scope.License = "";
        $scope.dvRegion = "";
        $scope.dvOutlet = "";
        $scope.dvStatus = "";
        $scope.dvLicenceStatus = "";
        $scope.dvAddress = "";
        $scope.dvState = "";
        $scope.dvPayment = "";
        $scope.dvInvoice = "";
        $scope.dvClient = "";
        $scope.dvLicenceType = "";
        $scope.dvExpiryStatus = "";
        $scope.dvFreshRenewal = "";
        $scope.FilterGraph();
    }


    $scope.SearchRecord = function () {
        if (isValidate()) {
            $('#CollapseSearchTableList').fadeIn();
            $scope.started();
        }
    };
    $scope.started = function () {

        var collectionobj = {};
        collectionobj.Action = 13;
        collectionobj.RegionId = $scope.RegionId;
        collectionobj.DocStatus = $scope.DocStatus;
        collectionobj.ExpiryStatus = $scope.ExpiryStatus
        collectionobj.LicenceStatus = $scope.LicenceS;
        collectionobj.LicenceType = $scope.LicenceType;
        collectionobj.Client = $scope.Client;
        collectionobj.InvoiceStatus = $scope.InvoiceSt;
        collectionobj.PaymentStatus = $scope.PaymentStatus;
        collectionobj.Store = $scope.Store;
        collectionobj.State = $scope.State;
        collectionobj.Address = $scope.Address;
        collectionobj.License = $scope.License;
        collectionobj.UserId = LoginId;
        collectionobj.loginType = loginType;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            messagevalues =
                  [
                            { "Region": $("#ddlRegion option:selected").text() == 'Select' ? '' : $("#ddlRegion option:selected").text() },
                            { "Document Status": $("#ddlDocument option:selected").text() == 'Select' ? '' : $("#ddlDocument option:selected").text() },
                            { "Licence Status": $("#ddlLicenceStatus option:selected").text() == 'Select' ? '' : $("#ddlLicenceStatus option:selected").text() },
                              { "Fresh/Renewal": $("#ddlFresh option:selected").text() == 'Select' ? '' : $("#ddlFresh option:selected").text() },
                            { "Client": $("#ddlClient option:selected").text() == 'Select' ? '' : $("#ddlClient option:selected").text() },
                             { "Invoice Status": $("#ddlInvoice option:selected").text() == 'Select' ? '' : $("#ddlInvoice option:selected").text() },
                              { "Payment Status": $("#ddlPayment option:selected").text() == 'Select' ? '' : $("#ddlPayment option:selected").text() },
                               { "Store": $("#ddlStore option:selected").text() == 'Select' ? '' : $("#ddlStore option:selected").text() },
                                { "State": $("#ddlState option:selected").text() == 'Select' ? '' : $("#ddlState option:selected").text() },
                                 { "Complete Address": $("#ddlComplete option:selected").text() == 'Select' ? '' : $("#ddlComplete option:selected").text() },
                                  { "Type of Licence": $("#ddlTypeofLicence option:selected").text() == 'Select' ? '' : $("#ddlTypeofLicence option:selected").text() },

                  ];

            var tblheader =
             [
                { "HeaderText": "Sr.No.", "Value": "Id", "HeaderValue": "Id", "Width": "50px", "ShowColumn": "Yes", "ImageColumn": "No", "CssClass": "srno" },
                { "HeaderText": "RegionName", "HeaderValue": "RegionName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Document Status", "HeaderValue": "DocumentStatus", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Allication Status", "HeaderValue": "LApplicationStatus", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Licence Status", "HeaderValue": "LicenseStatus", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Fresh/Renewal", "HeaderValue": "FreshReneval", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },

                { "HeaderText": "Client Name", "HeaderValue": "PARTYNAME", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
               { "HeaderText": "Outlet", "HeaderValue": "StoreName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Invoice Status", "HeaderValue": "InvoiceStatus", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Payment Status", "HeaderValue": "PaymentStatus", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                  { "HeaderText": "Type of Licence", "HeaderValue": "LicenseName", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },
                { "HeaderText": "Address", "HeaderValue": "Address", "Width": "100%", "ShowColumn": "Yes", "ImageColumn": "No" },

             ];

            loadDataUsingPreDefinedColumn(tblheader, response.data.Result);

        });
    }


    $scope.FilterGraph= function()
    {
        $scope.showLoader();
        var collectionobj = {};
        collectionobj.Action = 1;
        collectionobj.RegionId=$scope.RegionId;
        collectionobj.DocStatus=$scope.DocStatus;
        collectionobj.LicenceStatus = $scope.LicenceStatus;
        collectionobj.ExpiryStatus = $scope.ExpiryStatus;
        collectionobj.LicenceType=$scope.LicenceType;
        collectionobj.Client=$scope.Client;
        collectionobj.InvoiceStatus=$scope.InvoiceStatus;
        collectionobj.PaymentStatus=$scope.PaymentStatus;
        collectionobj.Store=$scope.Store;
        collectionobj.State=$scope.State;
        collectionobj.Address=$scope.Address;
        collectionobj.License=$scope.License;
        collectionobj.UserId = LoginId;
        collectionobj.loginType = loginType;
        var getData = myService.methode('POST', ("../RetailSection/GetLSDashboard"), JSON.stringify(collectionobj));
        getData.then(function (response) {
            res = response.data.Result;
            var xAxis = []
            var series = []
            angular.forEach(res, function (obj) {
                xAxis.push(obj.LicenseName)
                series.push(obj.Number)
            }) 
            $scope.BindGraph(xAxis, series);
            $scope.hideLoader();
        });
    }
    $scope.BindGraph=function (Licence, Number) { 
        var chartDom = document.getElementById('main');
        var myChart = echarts.init(chartDom);
        var option;

        option = {
            title: {
                text: 'Number of Licenses',
                x: 'center'
            },
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    type: 'shadow'
                }
            },
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'category',
                axisTick: {
                    alignWithLabel: true
                },
                axisLabel: {
                    rotate: 60
                },
                data: Licence
            },
            yAxis: {
                type: 'value'
            },
            series: [
                {
                    name: 'Value',
                    type: 'bar',
                    stack: 'Total',
                    label: {
                        show: true,
                        position: 'top'
                    },
                    data: Number
                }
            ]
        };

        option && myChart.setOption(option);


    }
}