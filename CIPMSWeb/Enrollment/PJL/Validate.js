var PageValidator = {
    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First name and last name
        if ($('#ctl00_Content_txtFirstName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 - First Name</li></ul>";
        }

        if ($('#ctl00_Content_txtLastName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 - Last Name</li></ul>";
        }

        errorMsg.innerHTML += CommonValidator.OnSubmitClick(1, 3, 4, 5);

        args.IsValid = errorMsg.innerHTML === "";

        return;
    }
};

$(function() {

});
