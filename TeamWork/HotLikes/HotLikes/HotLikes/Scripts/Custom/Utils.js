var HotLikes = HotLikes || {};

HotLikes.utils = (function ($) {
    var emailSend = false;

    function emailResendSuccessfull(emailAddress) {
        if (emailAddress != null && emailAddress != "") {
            $("#resend").remove();

            $("#email-send").append("New email was send. " +
                                    "Check your <a  class='link' href=http://www." + emailAddress + ">" + emailAddress + "</a> account")
            $("#email-send").show('slow');
            
        }

        emailSend = true;
    }

    function checkEmailIsSend() {
        return !emailSend
    }

    return {

        emailResendSuccessfull: function (emailAddress) {
            emailResendSuccessfull(emailAddress)
        },
        checkEmailIsSend: function () {
            var result = checkEmailIsSend();
            return result;
        }
    }
}(jQuery));