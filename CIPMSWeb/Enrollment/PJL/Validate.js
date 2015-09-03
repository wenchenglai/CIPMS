var PageValidator = {
    OnFirstTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            $("#1a").show();
        } else {
            $("#1a").hide();
        }
    },

    OnSchoolDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_rdoSchoolType_2').is(':checked')) {
            $('#ctl00_Content_txtSchoolName').attr('disabled', true);
        } else {
            $('#ctl00_Content_txtSchoolName').removeAttr('disabled');
        }
    },

    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First Timer camper or not
        if (!$('#ctl00_Content_rdoFirstTimerYes').is(':checked') && !$('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 1</li></ul>";
        }

        // 1a Grandfather rule
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            if (!$('#ctl00_Content_rdoDays12').is(':checked') && !$('#ctl00_Content_rdoDays19').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question 1a</li></ul>";
            }
        }

        // First name and last name
        if ($('#ctl00_Content_txtFirstName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 - First Name</li></ul>";
        }

        if ($('#ctl00_Content_txtLastName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 - Last Name</li></ul>";
        }

        // Grade
        if ($('#ctl00_Content_ddlGrade>option:selected').val() === "0") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 3</li></ul>";
        }

        // School Type
        if (!$('#ctl00_Content_rdoSchoolType_0').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_1').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_2').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 4</li></ul>";
        }

        // School Name
        if (!$('#ctl00_Content_rdoSchoolType_2').is(':checked') && $('#ctl00_Content_txtSchoolName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 5</li></ul>";
        }

        args.IsValid = true;

        if (errorMsg.innerHTML === "") {
            args.IsValid = true;
        } else {
            args.IsValid = false;
        }

        return;
    }
};

$(function () {
    PageValidator.OnFirstTimerChange();
    SchoolValidator.OnSchoolDropDownChange();
})
