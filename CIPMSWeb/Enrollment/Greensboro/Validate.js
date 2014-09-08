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

        if ($('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            $('#ctl00_Content_ddlQ10').removeAttr('disabled');
            $('#ctl00_Content_txtJewishSchool').removeAttr('disabled');
            $('#ctl00_Content_txtSchoolName').attr('disabled', true);
        } else {
            $('#ctl00_Content_ddlQ10').attr('disabled', true);
            $('#ctl00_Content_txtJewishSchool').attr('disabled', true);
        }
    },

    OnJewishSchoolDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_ddlQ10>option:selected').val() === "3") {
            $('#ctl00_Content_txtJewishSchool').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtJewishSchool').attr('disabled', true);
        }
    },

    OnSubmitClick: function (sender, args) {
        // Make sure everything must be selected
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

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo');

        if (!$chkSynagogue.is(':checked') && !$chkJCC.is(':checked') && !$chkNo.is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($chkSynagogue.is(':checked') && !$chkSynagogue.is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 2 - please select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 2 - please enter the synagogue name.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_txtJCC').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 2 - please enter the JCC name.</li></ul>";
            }
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

        // Jewish Day School selection
        if ($('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            if ($('#ctl00_Content_ddlQ10>option:selected').val() === "0")
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 5 - Please select a jewish day school from the dropdown</li></ul>";

            if ($('#ctl00_Content_ddlQ10>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtJewishSchool').val() === "")
                    errorMsg.innerHTML += "<ul><li>Please answer Question No. 5 - Please enter the Jewish day school name</li></ul>";
            }
        }

        // School Name
        if (!($('#ctl00_Content_rdoSchoolType_2').is(':checked') || $('#ctl00_Content_rdoSchoolType_3').is(':checked')) && $('#ctl00_Content_txtSchoolName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 6</li></ul>";
        }

        if (errorMsg.innerHTML === "") {
            args.IsValid = true;
        } else {
            args.IsValid = false;
        }
        return;
    }
};

$(function () {
    SJValidator.OnSynagogueCheckboxChange($('#ctl00_Content_chkSynagogue'));
    SJValidator.OnJCCChekboxChange($('#ctl00_Content_chkJCC'));
    SJValidator.OnOtherChekboxChange($('#ctl00_Content_chkNo'));
    PageValidator.OnFirstTimerChange();
    PageValidator.OnSchoolDropDownChange();
})