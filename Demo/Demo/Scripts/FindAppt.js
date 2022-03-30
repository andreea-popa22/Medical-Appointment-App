findApptButton = document.getElementById("find-appt");


function findApptFunction(patientId) {
    startDate = document.getElementById("start-date").value;
    endDate = document.getElementById("end-date").value;
    debugger;
    console.log(findApptButton);
    console.log(startDate);
    console.log(endDate);
    $.ajax({
        type: "POST",
        url: "../../Appointment/Select/",
        data: { patientId: patientId, startDate: startDate, endDate: endDate},
        success: function (data) {
            alert('Data: ' + data);
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}

