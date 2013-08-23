var Validator = {

    OnSynagogueCheckboxChange: function (chkboxObject) {
        if ($(chkboxObject).is(':checked')) {
            $('#ctl00_Content_ddlSynagogue').removeAttr('disabled');
            // The other textbox can only be enabled if the synagogue selected item is Other
            if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Other (please specify)") {
                $('#ctl00_Content_txtOtherSynagogue').removeAttr('disabled');
            }

            // Who is in Sysnagogue that refer this camper?
            $('#divReferBy').show();
        } else {
            $('#ctl00_Content_ddlSynagogue').attr('disabled', true);
            $('#ctl00_Content_txtOtherSynagogue').attr('disabled', true);
            $('#divReferBy').hide();
        }
        $('#ctl00_Content_chkNo').attr('disabled', true);
    },

    OnJCCChekboxChange: function (chkboxObject) {
        if ($(chkboxObject).is(':checked')) {
            $('#ctl00_Content_ddlJCC').removeAttr('disabled');
            // The other textbox can only be enabled if the JCC selected item is Other
            if ($('#ctl00_Content_ddlJCC>option:selected').text() === "Other (please specify)") {
                $('#ctl00_Content_txtJCC').removeAttr('disabled');
            }
        } else {
            $('#ctl00_Content_ddlJCC').attr('disabled', true);
            $('#ctl00_Content_txtJCC').attr('disabled', true);
        }
        $('#ctl00_Content_chkNo').attr('disabled', true);
    },

    OnOtherChekboxChange: function (chkboxObject) {
        if ($(chkboxObject).is(':checked')) {
            $('#ctl00_Content_Pnl9a :input').attr('disabled', true);
            $('#ctl00_Content_Pnl10a :input').attr('disabled', true);
        } else {
            $('#ctl00_Content_Pnl9a :input').removeAttr('disabled');
            $('#ctl00_Content_Pnl10a :input').removeAttr('disabled');
        }
    },

    OnSynagogueDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Other (please specify)") {
            $('#ctl00_Content_txtOtherSynagogue').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtOtherSynagogue').attr('disabled', true);
        }
    },

    OnJCCDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_ddlJCC>option:selected').text() === "Other (please specify)") {
            $('#ctl00_Content_txtJCC').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtJCC').attr('disabled', true);
        }
    },

    OnWhoRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoCongregant').is(':checked')) {
            $('#divWhoInSynagogue').show();
        } else {
            $('#divWhoInSynagogue').hide();
        }
    },

    OnWhoInSynagogueDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_ddlWho>option:selected').text() === "Other") {
            $('#ctl00_Content_txtWhoInSynagogue').show();
            $('#ctl00_Content_txtWhoInSynagogue').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtWhoInSynagogue').attr('disabled', true);
        }
    }
};