// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


/**
 * Global Functions
 */
function Login() {
   /* window.location.href = "/Account/Login";*/

    $.api.Auth.Register({
        Username: "Ahmed",
        Password: "Hello"
    },
        function (result) {
            console.log(result);
            $.api.Auth.Login({
                Username: "Ahmed",
                Password: "Hello"
            },
                function (result) {
                    console.log(result);
                    localStorage.setItem("jwtAuthToken", result);
                    $.api.Auth.GetLoggedInUser(function (user) {
                        $.ajax({
                            url: "/Account/Login?Id=" + user.id + "&Username=" + user.username + "&FullName=" + user.fullName + "&FullAddress=" + user.fullAddress
                                + "&Email=" + user.email + "&PhoneNumber=" + user.phoneNumber + "&BirthDate=" + user.birthDate + "&Role=" + user.role,
                            type: "POST",
                            success: function () {
                                window.location.href = "/Home";
                            },
                            error: function (error) {
                                if (typeof _error === "function") {
                                    _error(error);
                                } else {
                                    handleAjaxError(error);
                                }
                            }
                        });
                    });
                }
            );
        }
    );
}

function Logout() {
    localStorage.removeItem("jwtAuthToken");
    window.location.href = "/Account/Logout";
}

function Register() {
    window.location.href = "/Account/Register";
}



/**
 * Interceptor
 */
$.ajaxSetup({
    beforeSend: function (xhr) {
        var token = localStorage.getItem("jwtAuthToken");
        if (token != null) {
            xhr.setRequestHeader('Authorization', 'bearer ' + token);
        } else if (!anonymous) {
            window.location.href = "/Account/Logout";
        }
    },
    statusCode: {
        401: function () {
            Logout();
        }
    }
});

/**
 * API
 */
$.api = {
    Auth: {
        Register: function (user, success, error) {
            ajaxCall(
                "api/auth/Register",
                "POST",
                user,
                success,
                error
            );
        },
        Login: function (user, success, error) {
            ajaxCall(
                "api/auth/Login",
                "POST",
                user,
                success,
                error
            );
        },
        IsAuthenticated: function (success, error) {
            ajaxCall(
                "api/auth/IsAuthenticated",
                "GET",
                null,
                success,
                error
            );
        },
        GetLoggedInUser: function (success, error) {
            ajaxCall(
                "api/auth/GetLoggedInUser",
                "GET",
                null,
                success,
                error
            );
        }
    }
};

/**
 * API Helpers
 */
function ajaxCall(_url, _type, _data, _success, _error) {
    $.ajax({
        url: apiBaseUrl + _url,
        type: _type,
        contentType: "application/json; charset=utf-8",
        data: _data != null ? JSON.stringify(_data) : "",
        success: function (data) {
            var result = "";
            try {
                JSON.parse(data);
            } catch (e) {
                result = data;
            }
            if (result === "") {
                result = JSON.stringify(data);
            }
            if (typeof _success === "function") {
                _success(result);
            }
        },
        error: function (error) {
            if (typeof _error === "function") {
                _error(error);
            } else {
                handleAjaxError(error);
            }
        }
    });
}


function handleAjaxError(_error) {
    console.log(`Error ${_error}`);
}


/**
 * Events
 */
$("#Login").click(Login);
$("#Logout").click(Logout);
$("#Register").click(Register);


