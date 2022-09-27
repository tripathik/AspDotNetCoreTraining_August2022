$(document).ready(
    function () {
        $('#submit').click(function () {


            $.ajax({
                url: 'http://localhost:42019/Users/authenticate',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json',
                data: JSON.stringify({
                    username: $('#uname').val(),
                    password: $('#psw').val()
                }),
                processData: false,
                success: function (data, textStatus, jQxhr) {
                    alert("User successfully authenticated")
                    if (data.Role == "Manager")
                    {
                        window.location.replace('~/Pages//Manager.html')
                    }
                    else
                    {
                        window.location.replace('~/Pages//Wfm_Manager.html')
                    }
                   

                },
                error: function (jqXhr, textStatus, errorThrown) {
                    alert("User Failed to authenticate")   
                }
            });



        })

    }
)