function exportApptFunction() {
    $.ajax({
        type: "GET",
        url: "../Appointment/Export",
        dataType: "xml",
        success: function (data) {
            console.log("success");
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}