var PageValidator = {
    OnFirstTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            $("#1a").show();
            PageValidator.OnGrandfatherRuleChange();
            PageValidator.OnLastYearChange();
        } else {
            $("#1a").hide();
            $("#1b").hide();
            $("#1c").hide();
        }
    },

    OnGrandfatherRuleChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoDays19').is(':checked')) {
            $("#1b").show();
            PageValidator.OnLastYearChange();
        } else {
            $("#1b").hide();
            $("#1c").hide();
        }
    },

    OnLastYearChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoLastYearYes').is(':checked') && $('#ctl00_Content_rdoDays19').is(':checked')) {
            $("#1c").show();
        } else {
            $("#1c").hide();
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

        // 1b 
        if ($('#ctl00_Content_rdoDays19').is(':checked')) {
            if (!$('#ctl00_Content_rdoLastYearYes').is(':checked') && !$('#ctl00_Content_rdoLastYearNo').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question 1b</li></ul>";
            }
        }

        // 1c
        if ($('#ctl00_Content_rdoLastYearYes').is(':checked')) {
            if (!$('#ctl00_Content_rdoYes160').is(':checked') && !$('#ctl00_Content_rdoNo160').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question 1c</li></ul>";
            }
        }

        // Grade
        if ($('#ctl00_Content_ddlGrade>option:selected').val() === "0") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2</li></ul>";
        }

        // School Type
        if (!$('#ctl00_Content_rdoSchoolType_0').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_1').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_2').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 3</li></ul>";
        }

        // School Name
        if (!$('#ctl00_Content_rdoSchoolType_2').is(':checked') && $('#ctl00_Content_txtSchoolName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 4</li></ul>";
        }

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo'),
            $rdoCongregant = $('#ctl00_Content_rdoCongregant');

        if (!$chkSynagogue.is(':checked') && !$chkJCC.is(':checked') && !$chkNo.is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 5 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($chkSynagogue.is(':checked') && !$chkSynagogue.is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - please select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - please enter the synagogue name.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_ddlJCC>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - please select one JCC.</li></ul>";
            }

            if ($('#ctl00_Content_ddlJCC>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - please enter the JCC name.</li></ul>";
                }
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

$(function () {
    SJValidator.OnSynagogueCheckboxChange($('#ctl00_Content_chkSynagogue'));
    SJValidator.OnJCCChekboxChange($('#ctl00_Content_chkJCC'));
    SJValidator.OnOtherChekboxChange($('#ctl00_Content_chkNo'));

    PageValidator.OnFirstTimerChange();
    PageValidator.OnGrandfatherRuleChange();
    PageValidator.OnLastYearChange();
})