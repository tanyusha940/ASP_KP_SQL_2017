
$(document).ready(function () {
    $("#City_ID").prop("disabled", true);
    $("#Country").change(function () {
        if ($("#country").val() != "Please select") {
            var options = {};
            var country = $("#Country").val();
            options.url = "/Restaurant/GetInfo";
            options.type = "GET";
            options.data = { country: country };
            options.dataType = "json";
            options.contentType = "application/json";
            options.success = function (city) {
                $("#City_ID").empty();
                $("#City_ID").append("<option>" + country[0] + "</option>");
                $("#City_ID").prop("disabled", false);
            };
            options.error = function () { alert("Error retrieving hotel!"); };
            $.ajax(options);
        }
        else {
            $("#City_ID").empty();
            $("#City_ID").prop("disabled", true);
        }
    });
});