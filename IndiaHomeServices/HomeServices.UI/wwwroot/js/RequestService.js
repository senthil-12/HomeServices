var baseApiUrl = "https://localhost:44343/api/";

$(function () {
    GetServiceDetails();
    GetCategoryLookupDetails();
});

$(document).ready(function () {
    $(document).off("click", "#btnSubmit").on("click", "#btnSubmit", function () {
        var inputData = {};
        inputData["ServiceName"] = $('#txtRequestName').val();
        inputData["CategoryLkpId"] = $('#drpCategory').val();
        inputData["CategoryLkpName"] = $('#drpCategory').text();
        inputData["ServiceType"] = $('#txtServiceInput').val();
        inputData["Timing"] = $('#txtTiming').val();
        
        $.ajax({
            url: baseApiUrl + "service/",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(inputData),
            success: function (data) {
                $('#txtRequestName').val('');
                $('#drpCategory').val('0');
                $('#txtServiceInput').val('');
                $('#txtTiming').val('');
                alert(data);
            }
        });
    });
});

function GetCategoryLookupDetails() {
    $.ajax({
        url: baseApiUrl + "service/CategoryLookup",
        type: "GET",
        contentType: 'application/json',
        success: function (data) {
            if (data != null) {
                $('#drpCategory').html('');
                $('#drpCategory').append("<option value='0'>Please Select</option>");
                $.each(data, function () {
                    $('#drpCategory').append("<option value=" + $(this)[0].CommonLkpId + ">" + $(this)[0].CommonLkpName + "</option>");
                });
            }
            else {
                $('#drpCategory').html('');
                $('#drpCategory').append("<option value='0'>Please Select</option>");
            }
        }
    });
}

function GetServiceDetails() {
    $.ajax({
        url: baseApiUrl + "service/",
        type: "GET",
        contentType: 'application/json',
        success: function (data) {
            if (data != null) {
                var trVal = '';
                $.each(data, function () {
                    trVal += "<tr><td>" +
                        $(this)[0].ServiceName + "</td><td>" +
                        $(this)[0].CategoryLkpName + "</td><td>" +
                        $(this)[0].ServiceType + "</td><td>" +
                        $(this)[0].Timing + "</td><td>";
                });
                $('#tblListDetail tbody').html('');
                $('#tblListDetail tbody').html(trVal);
            }
            else {
                $('#tblListDetail tbody').html('');
                $('#tblListDetail tbody').html('<tr><td colspan="4" >No Record Found</td></tr>');
            }
        }
    });
}