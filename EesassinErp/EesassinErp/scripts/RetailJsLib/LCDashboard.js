//$(document).ready(function () {
//    var settings121 = {
//        "url": ("../RetailSection/GetLSDashboard"),
//        "method": "POST",
//        "timeout": 0,
//        "headers": {
//            "Content-Type": "application/json"
//        },
//        "data": JSON.stringify({
//            Updatedby: MapId,
//            Action: 1
//        }),
//    };
//    var LName = "";
//    var LNumber = "";
//    var seprator = "";
//    $.ajax(settings121).done(function (response) {
//        if (response.length > 0) {
//            res = (JSON.parse(response)).Result
//            var xAxis = []
//            var series = []
//            angular.forEach(res,function (obj) {
//                xAxis.push(obj.LicenseName)
//                series.push(obj.Number)
//            })
//            //my_array = Object.entries(res.Result).map(function (entry) {
//            //    key = entry[1].LicenseName;
//            //    value = entry[1].Number;

//            //    nested_object = value;
//            //    nested_object.key = key;
//            //    LName += seprator + key;
//            //    LNumber += seprator + value;
//            //        seprator = ","
//            //    return nested_object;
//            ////});

//            //console.log(my_array);
//            //for (var i = 0; i < res.Result.length; i++) {
//            //    
//            //}
//            //LName = Object.values(LName);
//            //LNumber = Object.values(LNumber);
//            BindGraph(xAxis, series);

//        }
//    });
//});
//function BindGraph(Licence,Number)
//{ 
 
    
//    var chartDom = document.getElementById('main');
//    var myChart = echarts.init(chartDom);
//    var option;

//    option = {
//        title: {
//            text: 'Number of Licenses',
//            x: 'center'
//        },
//        tooltip: {
//            trigger: 'axis',
//            axisPointer: {
//                type: 'shadow'
//            }
//        },
//        grid: {
//            left: '3%',
//            right: '4%',
//            bottom: '3%',
//            containLabel: true
//        },
//        xAxis: {
//            type: 'category',
//            axisTick: {
//                alignWithLabel: true
//            },
//            axisLabel: {
//                rotate: 60
//            },
//            data: Licence
//        },
//        yAxis: {
//            type: 'value'
//        },
//        series: [
//            {
//                name: 'Value',
//                type: 'bar',
//                stack: 'Total',
//                label: {
//                    show: true,
//                    position: 'top'
//                },
//                data: Number
//            }
//        ]
//    };

//    option && myChart.setOption(option);

     
//}
//function FilterGraph() {
//    alert(Id)
//}