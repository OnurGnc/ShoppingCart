var Core = {
    StartLoadingCount: 0,
    CallAPI: function (method, url, data, onSuccess, isAsync) {
        return Core.CallAPI_Base(method, url, data, onSuccess, isAsync);
    },
    CallAPI_Base: function (method, url, data, onSuccess, isAsync) {
        return $.ajax({
            method: method,
            url: url,
            data: data,
            async: isAsync,
            success: onSuccess,
            //error: function (xhr) {
            //    if (xhr.status === 401) {
            //        if (Const.AuthStatus !== false) {
            //            Const.AuthStatus = false;
            //            Core.GiveErrorMessage(Options.Messages.Forbidden, function () {
            //                //localStorage.setItem("LastUrl", window.location.href.split('?')[0]);
            //                window.location.href = root + "Account/Login";
            //            });
            //        }
            //    }
            //    else {
            //        Core.StopLoading();
            //        Core.GiveErrorMessage(xhr.responseText, null);
            //    }
            //},
        });
    },
};
$(document).ready(function () {

});
$(window).on("load", function () {
    $(".se-pre-con").fadeOut("slow");
});