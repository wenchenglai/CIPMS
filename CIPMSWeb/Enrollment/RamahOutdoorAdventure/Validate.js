var PageValidator = {
    OnFirstTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            this._toggleSecondTimer(false);
            this._toggleReceivedGrant(false);
        } else {
            this._toggleSecondTimer(true);
            this._toggleReceivedGrant(true);
        }
    },

    _toggleSecondTimer: function (flag) {
        $('#ctl00_Content_rdoSecondTimerYes').attr('disabled', flag);
        $('#ctl00_Content_rdoSecondTimerNo').attr('disabled', flag);
    },

    _toggleReceivedGrant: function (flag) {
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

        errorMsg.innerHTML += CommonValidator.OnSubmitClick(1, 4, 5, 6);

        args.IsValid = errorMsg.innerHTML === "";
        return;
    }
};

$(function() {
    PageValidator.OnFirstTimerChange();
    PageValidator.OnSecondTimerChange();
    SchoolValidator.OnSchoolDropDownChange();
});
