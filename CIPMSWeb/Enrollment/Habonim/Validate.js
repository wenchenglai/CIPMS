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
                $('#ctl00_Content_btnNext').hide();
            } else {
                $('#ctl00_Content_btnNext').show();
            }
        }
    },

    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0],
            $rdolistSiblingAttended = $('#ctl00_Content_rdolistSiblingAttended_0'),
            qGradeNo = "",
            qSchoolTypeNo = "";

        errorMsg.innerHTML = "";

        if ($rdolistSiblingAttended.length) {
            qGradeNo = "4";
            qSchoolTypeNo = "5";
        } else {
            qGradeNo = "2";
            qSchoolTypeNo = "3";
        }

        CommonValidator.OnSubmitClick(sender, args, qGradeNo, qSchoolTypeNo);

        if (!args.IsValid)
            return;

        // Siblings
        if ($rdolistSiblingAttended.length) {
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