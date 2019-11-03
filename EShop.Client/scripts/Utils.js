Utils_js = {
    AjaxPost: function (loadFrom, parameters, async = false, successfunc, errorfunc) {
        $.ajax({
            async: async,
            url: loadFrom,
            data: parameters,
            contentType: 'application/json',
            type: 'POST',
            success: successfunc,
            error: errorfunc
        });
    }
}