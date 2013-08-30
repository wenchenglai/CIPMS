var Validator = {
    OtherOption: "Other (please specify)",

    OnFirstTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            $('#ctl00_Content_divTaste :input').removeAttr('disabled');
        } else {
            $('#ctl00_Content_divTaste :input').attr('disabled', true);
        }
    },

    OnSchoolDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_rdoSchoolType_2').is(':checked')) {
            $('#ctl00_Content_txtSchoolName').attr('disabled', true);
        } else {
            $('#ctl00_Content_txtSchoolName').removeAttr('disabled');
        }
    },

    OnSynagogueCheckboxChange: function (chkboxObject) {
        if ($(chkboxObject).is(':checked')) {
            $('#ctl00_Content_ddlSynagogue').removeAttr('disabled');
            // The other textbox can only be enabled if the synagogue selected item is Other
            Validator.OnSynagogueDropDownChange(null);

            Validator.ToggleTypeWhoInSynagogue(true);
        } else {
            $('#ctl00_Content_ddlSynagogue').attr('disabled', true);
            $('#ctl00_Content_txtOtherSynagogue').attr('disabled', true);

            Validator.ToggleTypeWhoInSynagogue(false)
        }
        $('#ctl00_Content_chkNo').attr('disabled', true);
    },

    ToggleTypeWhoInSynagogue: function (isEnable) {
        if (isEnable) {
            $('#ctl00_Content_rdoCongregant').removeAttr('disabled');
            $('#ctl00_Content_rdoNoOne').removeAttr('disabled');
        } else {
            $('#ctl00_Content_rdoCongregant').attr('disabled', true);
            $('#ctl00_Content_rdoNoOne').attr('disabled', true);
        }
        Validator.ToggleWhoInSyangogue(isEnable);
    },

    OnJCCChekboxChange: function (chkboxObject) {
        if ($(chkboxObject).is(':checked')) {
            $('#ctl00_Content_ddlJCC').removeAttr('disabled');
            // The other textbox can only be enabled if the JCC selected item is Other
            Validator.OnJCCDropDownChange(null);
        } else {
            $('#ctl00_Content_ddlJCC').attr('disabled', true);
            $('#ctl00_Content_txtJCC').attr('disabled', true);
        }
        $('#ctl00_Content_chkNo').attr('disabled', true);
    },

    OnOtherChekboxChange: function (chkboxObject) {
        if ($(chkboxObject).is(':checked')) {
            $('#ctl00_Content_chkSynagogue').attr('disabled', true);
            $('#ctl00_Content_chkSynagogue').attr('checked', false);

            $('#ctl00_Content_chkJCC').attr('disabled', true);
            $('#ctl00_Content_chkJCC').attr('checked', false);

        } else {
            $('#ctl00_Content_pnlSynagogue :input').removeAttr('disabled');
            $('#ctl00_Content_pnlJCC :input').removeAttr('disabled');
        }
        Validator.OnSynagogueCheckboxChange($('#ctl00_Content_chkSynagogue'));
        Validator.OnJCCChekboxChange($('#ctl00_Content_chkJCC'));
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
            Validator.ToggleWhoInSyangogue(true);
        } else {
            Validator.ToggleWhoInSyangogue(false);
        }
    },

    ToggleWhoInSyangogue: function (isEnable) {
        if (isEnable) {
            $('#ctl00_Content_ddlWho').removeAttr('disabled');
            Validator.OnWhoInSynagogueDropDownChange(null);
        } else {
            $('#ctl00_Content_ddlWho').attr('disabled', true);
            $('#ctl00_Content_txtWhoInSynagogue').attr('disabled', true);
        }
    },

    OnWhoInSynagogueDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_ddlWho>option:selected').text() === "Other (please specify)") {
            $('#ctl00_Content_txtWhoInSynagogue').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtWhoInSynagogue').attr('disabled', true);
        }
    },

    OnYouthMovementRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoMemberOfYouthYes').is(':checked')) {
            $('#ctl00_Content_txtMemberOfYouth').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtMemberOfYouth').attr('disabled', true);
        }
    },

    OnParticipateMarchLivingCheckboxChange: function (chkboxObject) {
        if (chkboxObject.id === "ctl00_Content_rdolistParticipateMarchLiving_3") {
            if ($('#ctl00_Content_rdolistParticipateMarchLiving_3').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_2').attr('disabled', true);

                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateMarchLiving_2').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateMarchLiving_2').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateMarchLiving_0") {
            if ($('#ctl00_Content_rdolistParticipateMarchLiving_0').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateMarchLiving_1") {
            if ($('#ctl00_Content_rdolistParticipateMarchLiving_1').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').removeAttr('disabled');
            }
        }
    },

    OnParticipateTaglitCheckboxChange: function (chkboxObject) {
        if (chkboxObject.id === "ctl00_Content_rdolistParticipateTaglit_3") {
            if ($('#ctl00_Content_rdolistParticipateTaglit_3').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_2').attr('disabled', true);

                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateTaglit_2').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateTaglit_0').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateTaglit_1').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateTaglit_2').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateTaglit_0") {
            if ($('#ctl00_Content_rdolistParticipateTaglit_0').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateTaglit_1').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateTaglit_1") {
            if ($('#ctl00_Content_rdolistParticipateTaglit_1').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateTaglit_0').removeAttr('disabled');
            }
        }
    },

    OnBeenToIsraelRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoBeenToIsraelYes').is(':checked')) {
            $('#ctl00_Content_txtBeenToIsrael').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtBeenToIsrael').attr('disabled', true);
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

        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            if (!$('#ctl00_Content_rdoTasteOfCampYes').is(':checked') && !$('#ctl00_Content_rdoTasteOfCampNo').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 - Taste of Camp.</li></ul>";
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
        if (!$('#ctl00_Content_chkSynagogue').is(':checked') && !$('#ctl00_Content_chkJCC').is(':checked') && !$('#ctl00_Content_chkNoneOfAboveSynJcc').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 5 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($('#ctl00_Content_chkSynagogue').is(':checked') && !$('#ctl00_Content_chkSynagogue').is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Other (please specify)") {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae enter the synagogue name.</li></ul>";
                }
            }

            if (!$('#ctl00_Content_rdoCongregant').is(':checked') && !$('#ctl00_Content_rdoNoOne').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae select who did you speak to in your synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlWho>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae select one person from your synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlWho>option:selected').text() === "Other (please specify)") {
                if ($('#ctl00_Content_txtWhoInSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae enter the person's name from your synagogue.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($('#ctl00_Content_chkJCC').is(':checked') && !$('#ctl00_Content_chkJCC').is(':disabled')) {
            if ($('#ctl00_Content_ddlJCC>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae select one JCC.</li></ul>";
            }

            if ($('#ctl00_Content_ddlJCC>option:selected').text() === "Other (please specify)") {
                if ($('#ctl00_Content_txtJCC').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae enter the JCC name.</li></ul>";
                }
            }
        }

        // Any memebers are Youth Movement?
        if (!$('#ctl00_Content_rdoMemberOfYouthYes').is(':checked') && !$('#ctl00_Content_rdoMemberOfYouthNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 6</li></ul>";
        }

        if ($('#ctl00_Content_rdoMemberOfYouthYes').is(':checked')) {
            if ($('#ctl00_Content_txtMemberOfYouth').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 6 - pleae enter your family member.</li></ul>";
            }
        }

        // Participated in March Living?
        if (!$('#ctl00_Content_rdolistParticipateMarchLiving_0').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateMarchLiving_1').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateMarchLiving_2').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateMarchLiving_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 7</li></ul>";
        }

        // Participated in Taglit?
        if (!$('#ctl00_Content_rdolistParticipateTaglit_0').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateTaglit_1').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateTaglit_2').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateTaglit_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 8</li></ul>";
        }

        // been to Israel?
        if (!$('#ctl00_Content_rdoBeenToIsraelYes').is(':checked') && !$('#ctl00_Content_rdoBeenToIsraelNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 9</li></ul>";
        }

        if ($('#ctl00_Content_rdoBeenToIsraelYes').is(':checked')) {
            if ($('#ctl00_Content_txtBeenToIsrael').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 9 - pleae enter your family member.</li></ul>";
            }
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
    Validator.OnSynagogueCheckboxChange($('#ctl00_Content_chkSynagogue'));
    Validator.OnJCCChekboxChange($('#ctl00_Content_chkJCC'));
    Validator.OnOtherChekboxChange($('#ctl00_Content_chkNoneOfAboveSynJcc'));
    Validator.OnFirstTimerChange(null);
    Validator.OnYouthMovementRadioChange(null);
    Validator.OnBeenToIsraelRadioChange(null);

    if ($('#ctl00_Content_rdolistParticipateMarchLiving_3').is(':checked')) {
        Validator.OnParticipateMarchLivingCheckboxChange($('#ctl00_Content_rdolistParticipateMarchLiving_3')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateMarchLiving_0').is(':checked')) {
        Validator.OnParticipateMarchLivingCheckboxChange($('#ctl00_Content_rdolistParticipateMarchLiving_0')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateMarchLiving_1').is(':checked')) {
        Validator.OnParticipateMarchLivingCheckboxChange($('#ctl00_Content_rdolistParticipateMarchLiving_1')[0]);
    }

    if ($('#ctl00_Content_rdolistParticipateTaglit_3').is(':checked')) {
        Validator.OnParticipateTaglitCheckboxChange($('#ctl00_Content_rdolistParticipateTaglit_3')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateTaglit_0').is(':checked')) {
        Validator.OnParticipateTaglitCheckboxChange($('#ctl00_Content_rdolistParticipateTaglit_0')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateTaglit_1').is(':checked')) {
        Validator.OnParticipateTaglitCheckboxChange($('#ctl00_Content_rdolistParticipateTaglit_1')[0]);
    }

})