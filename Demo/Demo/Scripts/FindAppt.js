findApptButton = document.getElementById("find-appt");


function findApptFunction(patientId) {
    startDate = document.getElementById("start-date").value;
    endDate = document.getElementById("end-date").value;
    console.log(patientId);
    console.log(startDate);
    console.log(endDate);
    $.ajax({
        type: "POST",
        url: "../../Appointment/Select",
        data: { patientId: patientId, startDate: startDate, endDate: endDate },
        //cache: false,
        //dataType: "json",
        //contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log("success");
            window.location.href = "../../Appointment/Select/" + patientId + "/" + startDate + "/" + endDate;
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}

