var SJValidator = {
    OtherOption: "other (please specify)",

    OnSynagogueCheckboxChange: function (chkboxObject) {
        var $ddlSynagogue = $('#ctl00_Content_ddlSynagogue');

        if ($(chkboxObject).is(':checked')) {
            $ddlSynagogue.removeAttr('disabled');
            SJValidator.OnSynagogueDropDownChange(null);
            SJValidator.ToggleTypeWhoInSynagogue(true);
        } else {
            $ddlSynagogue.attr('disabled', true);
            $('#ctl00_Content_txtOtherSynagogue').attr('disabled', true);
            SJValidator.ToggleTypeWhoInSynagogue(false)
        }
    },

    ToggleTypeWhoInSynagogue: function (isEnable) {
        var $rdoCongregant = $('#ctl00_Content_rdoCongregant'),
            $rdoNoOne = $('#ctl00_Content_rdoNoOne');

        if (isEnable) {
            $rdoCongregant.removeAttr('disabled');
            $rdoNoOne.removeAttr('disabled');
        } else {
            $rdoCongregant.attr('disabled', true);
            $rdoNoOne.attr('disabled', true);
        }
        SJValidator.ToggleWhoInSyangogue(isEnable);
    },

    ToggleWhoInSyangogue: function (isEnable) {
        var $ddlWho = $('#ctl00_Content_ddlWho'),
            $txtWhoInSynagogue = $('#ctl00_Content_txtWhoInSynagogue');

        if (isEnable) {
            $ddlWho.removeAttr('disabled');
            SJValidator.OnWhoInSynagogueDropDownChange(null);
        } else {
            $ddlWho.attr('disabled', true);
            $txtWhoInSynagogue.attr('disabled', true);
        }
    },

    OnWhoInSynagogueDropDownChange: function (ddlObject) {
        var $txtWhoInSynagogue = $('#ctl00_Content_txtWhoInSynagogue');

        if ($('#ctl00_Content_ddlWho>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $txtWhoInSynagogue.removeAttr('disabled');
        } else {
            $txtWhoInSynagogue.attr('disabled', true);
        }
    },

    OnJCCChekboxChange: function (chkboxObject) {
        var $ddlJCC = $('#ctl00_Content_ddlJCC'),
            $txtOtherJCC = $('#ctl00_Content_txtOtherJCC')

        if ($ddlJCC.length === 0) {
            // some programs don't have pre-defined list of JCC
            if ($(chkboxObject).is(':checked')) {
                $txtOtherJCC.removeAttr('disabled');
            } else {
                $txtOtherJCC.attr('disabled', true);
            }
        } else {
            if ($(chkboxObject).is(':checked')) {
                $ddlJCC.removeAttr('disabled');
                SJValidator.OnJCCDropDownChange(null);
            } else {
                $ddlJCC.attr('disabled', true);
                $txtOtherJCC.attr('disabled', true);
            }
        }
    },

    OnOtherChekboxChange: function (chkboxObject) {
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC');

        if ($(chkboxObject).is(':checked')) {
            $chkSynagogue.attr('disabled', true);
            $chkSynagogue.attr('checked', false);

            $chkJCC.attr('disabled', true);
            $chkJCC.attr('checked', false);
        } else {
            // Uncheck the None of Above box
            $chkSynagogue.removeAttr('disabled');
            $chkJCC.removeAttr('disabled');
        }

        SJValidator.OnSynagogueCheckboxChange($chkSynagogue);
        SJValidator.OnJCCChekboxChange($chkJCC);
    },

    OnSynagogueDropDownChange: function (ddlObject) {
        var $txtOtherSynagogue = $('#ctl00_Content_txtOtherSynagogue');

        if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $txtOtherSynagogue.removeAttr('disabled');
        } else {
            $txtOtherSynagogue.attr('disabled', true);
        }
    },

    OnJCCDropDownChange: function (ddlObject) {
        var $txtOtherJCC = $('#ctl00_Content_txtOtherJCC');

        if ($('#ctl00_Content_ddlJCC>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $txtOtherJCC.removeAttr('disabled');
        } else {
            $txtOtherJCC.attr('disabled', true);
        }
    },

    OnWhoRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoCongregant').is(':checked')) {
            SJValidator.ToggleWhoInSyangogue(true);
        } else {
            SJValidator.ToggleWhoInSyangogue(false);
        }
    }
};

var SchoolValidator = {
    OnSchoolDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_rdoSchoolType_2').is(':checked')) {
            $('#ctl00_Content_txtSchoolName').attr('disabled', true);
        } else {
            $('#ctl00_Content_txtSchoolName').removeAttr('disabled');
        }
    }
};

var CommonValidator = {
    OnSubmitClick: function (sender, args, qGradeNo, qSchoolTypeNo) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First Timer camper or not
        if (!$('#ctl00_Content_rdoFirstTimerYes').is(':checked') && !$('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 1</li></ul>";
        }

        // Grade
        if ($('#ctl00_Content_ddlGrade>option:selected').val() === "0") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. " + qGradeNo + "</li></ul>";
        }

        // School Type
        if (!$('#ctl00_Content_rdoSchoolType_0').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_1').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_2').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. " + qSchoolTypeNo + "</li></ul>";
        }

        // School Name
        if ($('#ctl00_Content_rdoSchoolType_0').is(':checked') || $('#ctl00_Content_rdoSchoolType_1').is(':checked')) {
            if ($('#ctl00_Content_txtSchoolName').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please enter school name</li></ul>";
            }
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