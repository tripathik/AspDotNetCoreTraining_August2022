$(document).ready(
    function () {
        $('#submit').click(function () {

            var Username = $("#uname").val();
            var Password = $("#psw").val();
         
            console.log(Username);
            $.ajax({
                url: 'http://localhost:7222/api/User/authenticate',
                dataType: "json",
                type: "GET",
                contentType: "application/json",
                data: 'username=' + Username + '&password=' + Password,
                processData: false,
                success: function (data, textStatus, jQxhr) {
                    alert("You have been Logged In Successfully")
                    if (data.Role == "Manager") {
                        window.location.replace('EmployeeData')
                    }
                    else {
                        window.location.replace('SoftLockData')
                    }


                },
                error: function (jqXhr, textStatus, errorThrown) {
                    alert("You have been Logged In Successfully")
                }
            });



        })

    }
);