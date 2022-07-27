// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


/**
 * Global Functions
 */
function Login() {
    window.location.href = "/Account/Login";
}

function Logout() {
    localStorage.removeItem("jwtAuthToken");
    window.location.href = "/Account/Logout";
}

function Register() {
    window.location.href = "/Account/Register";
}

function StoreJwtToken(token) {
    localStorage.setItem("jwtAuthToken", token);
    $.api.auth.GetLoggedInUser(function (user) {
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
    auth: {
        Register: function (user, success, error) {
            ajaxCall(
                "api/auth/Register",
                "POST",
                user,
                success,
                error,
                true
            );
        },
        Login: function (user, success, error) {
            ajaxCall(
                "api/auth/Login",
                "POST",
                user,
                success,
                error,
                true
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
function ajaxCall(_url, _type, _data, _success, _error, _loading) {
    if (_loading == true) {
        $.loading(true);
    }

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
        },
        complete: function () {
            if (_loading == true) {
                $.loading(false);
            }
        }
    });
}

function handleAjaxError(_error) {
    var message = typeof _error === "string" ? _error : "There was an error sending the request to the server!";
    $._toast.error(message);
}



/**
 * Global Events
 */
$("#Login").click(Login);
$("#Logout").click(Logout);
$("#Register").click(Register);
$("form").keydown(function (event) {
    if (event.which == 13) {
        $(this).find("button[type=button].submit").click();
    }
});



/**
 * Helpers
 */
$.loading = function (x) {
    if (x == null) {
        if ($("#Loading").is(":visible")) {
            $("#Loading").fadeOut();
        } else {
            $("#Loading").fadeIn();
        }
    } else {
        if (x == true) {
            $("#Loading").fadeIn();
        } else {
            $("#Loading").fadeOut();
        }
    }
}

$.getFormData = function ($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

$.addErrorsToForm = function ($form, errorResponse) {
    if (errorResponse.responseJSON == null) {
        handleAjaxError(errorResponse);
        return;
    }

    let fields = errorResponse.responseJSON.errors;
    if (fields == null) {
        handleAjaxError(errorResponse);
        return;
    }

    for (const field in fields) {
        let $field = $form.find("[name=" + field.toLowerCase() + "]");
        $field.change(function () {
            $(this).removeClass("is-invalid");
        });

        var validationFeedback = "";
        for (const error of fields[field]) {
            validationFeedback += error + "<br />";
        }

        let $fieldFeedback = $field.siblings(".invalid-feedback");
        $fieldFeedback.html(validationFeedback);

        $field.addClass("is-invalid");
    }

    $._toast.error("Invalid data entered, please fix the errors and try again!");
}

$.addError = function ($form, field, error) {
    let $field = $form.find("[name=" + field.toLowerCase() + "]");
    $field.change(function () {
        $(this).removeClass("is-invalid");
    });

    let $fieldFeedback = $field.siblings(".invalid-feedback");
    $fieldFeedback.html(error);

    $field.addClass("is-invalid");

    $._toast.error("Invalid data entered, please fix the errors and try again!");
}

$._toast = {
    error: function (message) {
        $.toast({
            heading: 'Error',
            text: `Error ${message}`,
            showHideTransition: 'slide',
            position: 'top-center',
            icon: 'error'
        })
    },
    success: function (message) {
        $.toast({
            heading: 'Success',
            text: `Error ${message}`,
            showHideTransition: 'slide',
            position: 'top-center',
            icon: 'success'
        })
    },
    warning: function (message) {
        $.toast({
            heading: 'Warning',
            text: `Error ${message}`,
            showHideTransition: 'slide',
            position: 'top-center',
            icon: 'warning'
        })
    },
    Info: function (message) {
        $.toast({
            heading: 'Information',
            text: `Error ${message}`,
            showHideTransition: 'slide',
            position: 'top-center',
            icon: 'info'
        })
    }
}

$(document).ready(function () {
    if ($.validator != null) {
        $.validator.addMethod(
            "regex",
            function (value, element, regexp) {
                var re = new RegExp(regexp);
                return this.optional(element) || re.test(value);
            },
            "Please check your input."
        );
    }
});


