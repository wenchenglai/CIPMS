﻿var PageValidator = {
    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo'),
            $rdoCongregant = $('#ctl00_Content_rdoCongregant');

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
            if ($('#ctl00_Content_ddlJCC>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 2 - please select one JCC.</li></ul>";
            }

            if ($('#ctl00_Content_ddlJCC>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 2 - please enter the JCC name.</li></ul>";
                }
            }
        }

        errorMsg.innerHTML += CommonValidator.OnSubmitClick(1, 3, 4, 5);

        args.IsValid = errorMsg.innerHTML === "";

        return;
    }
};

$(function() {
    SJValidator.OnSynagogueCheckboxChange($('#ctl00_Content_chkSynagogue'));
    SJValidator.OnJCCChekboxChange($('#ctl00_Content_chkJCC'));
    SJValidator.OnOtherChekboxChange($('#ctl00_Content_chkNo'));
});
