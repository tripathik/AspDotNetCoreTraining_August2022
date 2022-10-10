$.get("https://localhost:7115/api/Employee", function (data, status) {

    let code = "";
    for (let x in data) {
        code += "<tr>"
        code += "<td>" + data[x].employeeID + "</td>"
        code += "<td>" + data[x].name + "</td>"
        code += "<td>" + data[x].status + "</td>"
        code += "<td>" + data[x].manager + "</td>"
        code += "<td>" + data[x].wfm_Manager + "</td>"
        code += "<td>" + data[x].email + "</td>"
        code += "<td>" + data[x].experience + "</td>"
        code += "<td>"
        for (let s in data[x].skills)
            code += data[x].skills[s] + "  "
        code += "</td>"
        code += "<td> <a href= SoftLockRequestData?employee_ID class=btn btn-primary> RequestLock </a> </td> </tr>"
    }
    $('#tbody').html(code)
})

