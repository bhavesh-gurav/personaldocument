
const ResponseMsgType = {
    success: 1,
    error: 2,
    warning: 3,
    info: 4
}

function ShowDynamicSwalAlert(title, msg) {
    const myArray = msg.split("||");
    msg = myArray[0];
    var type = myArray[1];
    if (msg != null && msg != '') {
        if (type.toString() == ResponseMsgType.success.toString()) {
            debugger;
            swal({
                title: title,
                text: msg,
                type: "info",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            //}, function () {
            //    window.location = '/home/ApplicationDetails?ApplicationId=7';
            });
        }
        else if (type.toString() == ResponseMsgType.error.toString()) {
            swal({
                title: title,
                text: msg,
                type: "error",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            });
        }
        else if (type.toString() == ResponseMsgType.warning.toString()) {
            swal({
                title: title,
                text: msg,
                type: "warning",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            });
        }
        else if (type.toString() == ResponseMsgType.info.toString()) {
            swal({
                title: title,
                text: msg,
                type: "info",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            });
        }
    }
}

function LoadSchemePartialView(controllerName, actionName, ServiceId, ApplicationId, isFilled) {
    debugger;  
    const ul = document.getElementById('dvtablist');
    const listItems = ul.getElementsByTagName('li');
    // Loop through the NodeList object.

    for (let i = 0; i <= listItems.length - 1; i++) {
       // console.log(listItems[i]);
        var oChild = listItems[i].children;
        var childeleId = oChild[0].id;
        $("#" + childeleId).removeClass('active');
    }
    if (actionName != "") {
        $("#" + actionName).addClass('active');
    }
    $.ajax({
        type: "GET",
        url: "/" + controllerName + "/" + actionName,
        data: { ServiceId: ServiceId, strApplicationId: ApplicationId, isFilled: isFilled },
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        /*dataType: "html",*/
        /* dataType: 'JSON',*/
        success: function (response) {
            $('#dvTabPartialView').html('');
            $('#dvTabPartialView').html(response);
            $("form").removeData("validator").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($("form"));
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}


function GetDistrict() {
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetDistrict",
        //data: { DepartmentId: $('#DepartmentId').val() },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var DistrictList = "";
            DistrictList = DistrictList + '<option value="">--Select--</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                DistrictList = DistrictList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listDistrict').html(DistrictList);
            //$('#PlistDistrict').html(DistrictList);
        }
    });
}

var districtID;
function GetTalukaByDistrictId(districtId) {
    districtID = districtId;
    debugger;
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetTalukaByDistrictId",
        data: { districtId: districtId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            debugger;
            var TalukaList = "";
            console.log(data.data.result.length);
            TalukaList = TalukaList + '<option value="">--Select--</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                TalukaList = TalukaList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listTaluka').html(TalukaList);
        }
    });
}


function GetBenifitByCourseId(courseId) {
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetBenifitByCourseId",
        data: { courseId: courseId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            debugger;
            var Benifitsrs = "";
            console.log(data.data.result.length);
            Benifitsrs = data.data.result[0].benifitsrs;
           
            $('#Benifitsrs').val(Benifitsrs);
            $('#Benifitsrs').attr('disabled', 'disabled');
            //$('#PlistTaluka').html(TalukaList);
        }
    });
}

function GetVillageByDistrictIdAndTalukaId(talukaId) {
    var districtId = districtID;
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetVillageByDistrictIdAndTalukaId",
        data: { districtId: districtId, talukaId: talukaId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var VillageList = "";
            console.log(data.data.result.length);
            VillageList = VillageList + '<option value="">--Select--</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                VillageList = VillageList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listVillage').html(VillageList);
            //$('#PlistVillage').html(VillageList);
        }
    });
}

function GetPDistrict(stateid) {
    var val = $("#PlistState").val();
    if (val != 7) {
        //$('#PlistDistrict').replaceWith($('<input />', { 'type': 'text', 'value': 'Other' }));
        $('#dvGuj').hide();
        $('#dvWithoutGuj').show();
        $('#dvGujTaluka').hide();
        $('#dvWithoutGujTaluka').show();
        $('#dvGujVillage').hide();
        $('#dvWithoutGujVillage').show();

        $('#PlistDistrict').val('0');
        $('#PlistTaluka').val('0');
        $('#PlistVillage').val('0');
    }
    else {
        $('#dvWithoutGuj').hide();
        $('#dvGuj').show();
        $('#dvGujTaluka').show();
        $('#dvWithoutGujTaluka').hide();
        $('#dvGujVillage').show();
        $('#dvWithoutGujVillage').hide();
        $("#PDistrictNameInEng").val('');
        $('#PTalukaNameInEng').val('');
        $('#PVillageNameInEng').val('');

        //GetPDistrict();

    }
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetDistrict",
        //data: {DepartmentId: $('#DepartmentId').val() },
        datatype: "json",
        traditional: true,
        success: function (data) {
            if (stateid == 7) {
                var DistrictList = "";
                DistrictList = DistrictList + '<option value="">--Select--</option>';
                for (var i = 0; i < data.data.result.length; i++) {
                    DistrictList = DistrictList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
                }
                //$('#listDistrict').html(DistrictList);
                $('#PlistDistrict').html(DistrictList);
                $('#PlistTaluka').html('<option value="">--Select--</option>');
                $('#PlistVillage').html('<option value="">--Select--</option>');
            }
        }
    });
}

var PdistrictID;
function GetPTalukaByDistrictId(districtId) {
    PdistrictID = districtId;
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetTalukaByDistrictId",
        data: { districtId: districtId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var TalukaList = "";
            console.log(data.data.result.length);
            TalukaList = TalukaList + '<option value="">--Select--</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                TalukaList = TalukaList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            //$('#listTaluka').html(TalukaList);
            $('#PlistTaluka').html(TalukaList);
        }
    });
}

function GetPVillageByDistrictIdAndTalukaId(talukaId) {
    var districtId = PdistrictID;
    $.ajax({
        type: "get",
        url: "/BOCWSikshanSahayYojana/GetVillageByDistrictIdAndTalukaId",
        data: { districtId: districtId, talukaId: talukaId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var VillageList = "";
            console.log(data.data.result.length);
            VillageList = VillageList + '<option value="">--Select--</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                VillageList = VillageList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            //$('#listVillage').html(VillageList);
            $('#PlistVillage').html(VillageList);
        }
    });
}


function fileValidation(val) {
    alert(val);

    var fileInputsdsdsds = val;
    var fileInput = document.getElementById('file');

    var filePath = fileInput.value;

    // Allowing file type
    var allowedExtensions =
        /(\.jpg|\.jpeg|\.png|\.gif)$/i;

    if (!allowedExtensions.exec(filePath)) {
        alert('Invalid file type');
        fileInput.value = '';
        return false;
    }
    else {

        // Image preview
        if (fileInput.files && fileInput.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById(
                    'imagePreview').innerHTML = '<img src = "' + e.target.result + '" />';
            };

            reader.readAsDataURL(fileInput.files[0]);
        }
    }
}
