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

    OnSchoolDropDownChange: function (ddlObject) {
        $('#ctl00_Content_txtSchoolName').attr('disabled', true);
        $('#ctl00_Content_ddlJewishDaySchool').attr('disabled', true);

        if ($('#ctl00_Content_rdoSchoolType_0').is(':checked') || $('#ctl00_Content_rdoSchoolType_2').is(':checked')) {
            $('#ctl00_Content_txtSchoolName').removeAttr('disabled');
        } else if ($('#ctl00_Content_rdoSchoolType_1').is(':checked')) {
            $('#ctl00_Content_ddlJewishDaySchool').removeAttr('disabled');
        }

        PageValidator.OnJDSchoolDropDownChange(null);
    },

    OnJDSchoolDropDownChange: function (ddlObject) {
        $('#ctl00_Content_txtJewishSchool').attr('disabled', true);

        if (!$('#ctl00_Content_ddlJewishDaySchool').is(':disabled') && $('#ctl00_Content_ddlJewishDaySchool>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $('#ctl00_Content_txtJewishSchool').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtJewishSchool').attr('disabled', true);
        }
    },

    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First Timer camper or not
        if (!$('#ctl00_Content_rdoFirstTimerYes').is(':checked') && !$('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer question No. 1</li></ul>";
        }

        // Siblings
        if (!$('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')
            && !$('#ctl00_Content_rdolistSiblingAttended_1').is(':checked')
            && !$('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer question No. 2</li></ul>";
        }

        if ($('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')) {
            if ($('#ctl00_Content_txtSiblingFirstName').val() === "" || $('#ctl00_Content_txtSiblingLastName').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer question No. 3</li></ul>";
            }
        }

        // Grade
        if ($('#ctl00_Content_ddlGrade>option:selected').val() === "0") {
            errorMsg.innerHTML += "<ul><li>Please answer question No. 4</li></ul>";
        }

        // School Type
        if (!$('#ctl00_Content_rdoSchoolType_0').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_1').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_2').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer question No. 5</li></ul>";
        }

        // Jewish Day School 
        if ($('#ctl00_Content_rdoSchoolType_1').is(':checked')) {
            if ($('#ctl00_Content_ddlJewishDaySchool>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Please answer question No. 6 - select one Jewish day school.</li></ul>";
            }

            if ($('#ctl00_Content_ddlJewishDaySchool>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtJewishSchool').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Please answer question No. 6 - enter the Jewish day school name.</li></ul>";
                }
            }
        }

        // School Name
        if ($('#ctl00_Content_rdoSchoolType_0').is(':checked') || $('#ctl00_Content_rdoSchoolType_2').is(':checked')) {
            if ($('#ctl00_Content_txtSchoolName').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer question No. 7 - school name</li></ul>";
            }
        }

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo');

        if (!$chkSynagogue.is(':checked') && !$chkJCC.is(':checked') && !$chkNo.is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer question No. 8 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($chkSynagogue.is(':checked') && !$chkSynagogue.is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Please answer question No. 8 - please select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Please answer question No. 8 - please enter the synagogue name.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer question No. 8 - please enter the JCC name.</li></ul>";
            }
        }

        args.IsValid = errorMsg.innerHTML === "";

        return;
    },

    OnSubmitChicagoCouponPageClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First question
        if (!$('#ctl00_Content_rdoYes1').is(':checked') && !$('#ctl00_Content_rdoNo1').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 1</li></ul>";
        }

        if ($('#ctl00_Content_rdoYes1').is(':checked')) {
            if ($('#ctl00_Content_txtCampName1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 Name of Pre-School </li></ul>";
            }

            if ($('#ctl00_Content_txtAddress1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 Address</li></ul>";
            }

            if ($('#ctl00_Content_ddlCountry1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 Country</li></ul>";
            }

            if ($('#ctl00_Content_ddlState1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 State</li></ul>";
            }

            if ($('#ctl00_Content_txtCity1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 City</li></ul>";
            }

            if ($('#ctl00_Content_txtZipCode1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 Zip Code</li></ul>";
            }

            if ($('#ctl00_Content_ddlYearAttended1').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 Last Year Attended</li></ul>";
            }
        }

        // second question
        if (!$('#ctl00_Content_rdoYes2').is(':checked') && !$('#ctl00_Content_rdoNo2').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 2</li></ul>";
        }

        if ($('#ctl00_Content_rdoYes2').is(':checked')) {
            if ($('#ctl00_Content_txtCampName2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 Day Camp Name</li></ul>";
            }

            if ($('#ctl00_Content_txtAddress2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 Address</li></ul>";
            }

            if ($('#ctl00_Content_ddlCountry2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 Country</li></ul>";
            }

            if ($('#ctl00_Content_ddlState2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 State</li></ul>";
            }

            if ($('#ctl00_Content_txtCity2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 City</li></ul>";
            }

            if ($('#ctl00_Content_txtZipCode2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 Zip Code</li></ul>";
            }

            if ($('#ctl00_Content_ddlYearAttended2').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 2 Last Year Attended</li></ul>";
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
    PageValidator.OnSchoolDropDownChange(null);

    $('#ctl00_Content_rdoNo1').bind('click', function() {
        $('#ctl00_Content_txtCampName1').attr("disabled", true);
        $('#ctl00_Content_txtAddress1').attr("disabled", true);
        $('#ctl00_Content_ddlCountry1').attr("disabled", true);
        $('#ctl00_Content_ddlState1').attr("disabled", true);
        $('#ctl00_Content_txtCity1').attr("disabled", true);
        $('#ctl00_Content_txtZipCode1').attr("disabled", true);
        $('#ctl00_Content_ddlYearAttended1').attr("disabled", true);
    });

    $('#ctl00_Content_rdoYes1').bind('click', function () {
        $('#ctl00_Content_txtCampName1').removeAttr('disabled');
        $('#ctl00_Content_txtAddress1').removeAttr('disabled');
        $('#ctl00_Content_ddlCountry1').removeAttr('disabled');
        $('#ctl00_Content_ddlState1').removeAttr('disabled');
        $('#ctl00_Content_txtCity1').removeAttr('disabled');
        $('#ctl00_Content_txtZipCode1').removeAttr('disabled');
        $('#ctl00_Content_ddlYearAttended1').removeAttr('disabled');
    });

    $('#ctl00_Content_rdoNo2').bind('click', function() {
        $('#ctl00_Content_txtCampName2').attr("disabled", true);
        $('#ctl00_Content_txtAddress2').attr("disabled", true);
        $('#ctl00_Content_ddlCountry2').attr("disabled", true);
        $('#ctl00_Content_ddlState2').attr("disabled", true);
        $('#ctl00_Content_txtCity2').attr("disabled", true);
        $('#ctl00_Content_txtZipCode2').attr("disabled", true);
        $('#ctl00_Content_ddlYearAttended2').attr("disabled", true);
    });

    $('#ctl00_Content_rdoYes2').bind('click', function () {
        $('#ctl00_Content_txtCampName2').removeAttr('disabled');
        $('#ctl00_Content_txtAddress2').removeAttr('disabled');
        $('#ctl00_Content_ddlCountry2').removeAttr('disabled');
        $('#ctl00_Content_ddlState2').removeAttr('disabled');
        $('#ctl00_Content_txtCity2').removeAttr('disabled');
        $('#ctl00_Content_txtZipCode2').removeAttr('disabled');
        $('#ctl00_Content_ddlYearAttended2').removeAttr('disabled');
    });

    if ($('#ctl00_Content_rdoNo1').is(':checked')) {
        $('#ctl00_Content_rdoNo1').trigger('click');
    }

    if ($('#ctl00_Content_rdoNo2').is(':checked')) {
        $('#ctl00_Content_rdoNo2').trigger('click');
    }
})