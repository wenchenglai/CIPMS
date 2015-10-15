var PageValidator = {
    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        errorMsg.innerHTML += CommonValidator.OnSubmitClick(1, 2, 3, 4);

        args.IsValid = errorMsg.innerHTML === "";

        return;
    }
};

$(function() {
    SchoolValidator.OnSchoolDropDownChange();
});
