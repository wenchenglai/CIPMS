var PageValidator = {
    OnFirstTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            $("#1a").show();
            this._toggleSecondTimer(false);
            this._toggleReceivedGrant(false);
        } else {
            $("#1a").hide();
            this._toggleSecondTimer(true);
            this._toggleReceivedGrant(true);
        }
    },

    OnSecondTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoSecondTimerYes').is(':checked')) {
            this._toggleReceivedGrant(false);
        } else {
            this._toggleReceivedGrant(true);
        }
    },

    _toggleSecondTimer: function(flag) {
        $('#ctl00_Content_rdoSecondTimerYes').attr('disabled', flag);
        $('#ctl00_Content_rdoSecondTimerNo').attr('disabled', flag);
    },

    _toggleReceivedGrant: function(flag) {
        $('#ctl00_Content_rdoReceivedGrantYes').attr('disabled', flag);
        $('#ctl00_Content_rdoReceivedGrantNo').attr('disabled', flag);
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

        // Second Timer
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            if (!$('#ctl00_Content_rdoSecondTimerYes').is(':checked') && !$('#ctl00_Content_rdoSecondTimerNo').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question 2</li></ul>";
            }
        }

        // Received Grant before
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked') && $('#ctl00_Content_rdoSecondTimerYes').is(':checked')) {
            if (!$('#ctl00_Content_rdoReceivedGrantYes').is(':checked') && !$('#ctl00_Content_rdoReceivedGrantNo').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question 3</li></ul>";
            }
        }

        // Grade
        if ($('#ctl00_Content_ddlGrade>option:selected').val() === "0") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 4</li></ul>";
        }

        // School Type
        if (!$('#ctl00_Content_rdoSchoolType_0').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_1').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_2').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 5</li></ul>";
        }

        // School Name
        if (!$('#ctl00_Content_rdoSchoolType_2').is(':checked') && $('#ctl00_Content_txtSchoolName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 6</li></ul>";
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
    PageValidator.OnSecondTimerChange();
    SchoolValidator.OnSchoolDropDownChange();
})
