var PageValidator = {
    OnSiblingRadioChanged: function (rdoObject) {
        $('#siblingContact').hide();
        if ($('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')) {
            $('#ctl00_Content_txtSiblingFirstName').removeAttr('disabled');
            $('#ctl00_Content_txtSiblingLastName').removeAttr('disabled');
        } else if ($('#ctl00_Content_rdolistSiblingAttended_1').is(':checked') || $('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
            $('#ctl00_Content_txtSiblingFirstName').attr('disabled', true);
            $('#ctl00_Content_txtSiblingLastName').attr('disabled', true);
            if ($('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
                $('#siblingContact').show();
            }
        }
    },

    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First Timer camper or not
        if (!$('#ctl00_Content_rdoFirstTimerYes').is(':checked') && !$('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 1</li></ul>";
        }

        // Siblings
        if (!$('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')
            && !$('#ctl00_Content_rdolistSiblingAttended_1').is(':checked')
            && !$('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2</li></ul>";
        }

        if ($('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')) {
            if ($('#ctl00_Content_txtSiblingFirstName').val() === "" || $('#ctl00_Content_txtSiblingLastName').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 3</li></ul>";
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
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 5</li></ul>";
        }

        // Jewish Day School 
        if ($('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            if ($('#ctl00_Content_ddlJewishDaySchool>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 6 - pleae select one Jewish day school.</li></ul>";
            }

            if ($('#ctl00_Content_ddlJewishDaySchool>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtJewishSchool').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 6 - pleae enter the Jewish day school name.</li></ul>";
                }
            }
        }

        // School Name
        if ($('#ctl00_Content_rdoSchoolType_0').is(':checked') || $('#ctl00_Content_rdoSchoolType_1').is(':checked')) {
            if ($('#ctl00_Content_txtSchoolName').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please enter school name</li></ul>";
            }
        }

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo');

        if (!$chkSynagogue.is(':checked') && !$chkJCC.is(':checked') && !$chkNo.is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 8 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($chkSynagogue.is(':checked') && !$chkSynagogue.is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 8 - pleae select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 8 - pleae enter the synagogue name.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 8 - pleae enter the JCC name.</li></ul>";
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
    PageValidator.OnSiblingRadioChanged(null);
})