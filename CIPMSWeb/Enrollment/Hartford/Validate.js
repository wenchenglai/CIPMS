var PageValidator = {
    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        var inputobjs = document.getElementsByTagName("input"),
            selectobjs = document.getElementsByTagName("select"),
            valobj = document.getElementById(sender.id),
            QFirstTimerYes, QFirstTimerNo, QGrade, QSchoolName, QHomeSchoolRadio;

        for (var i = 0; i < inputobjs.length - 1; i++) {
            if (inputobjs[i].id.indexOf("RadioBtnQ31") >= 0) {
                QFirstTimerYes = inputobjs[i];
            } else if (inputobjs[i].id.indexOf("RadioBtnQ32") >= 0) {
                QFirstTimerNo = inputobjs[i];
            } else if (inputobjs[i].id.indexOf("RadioButtionQ5_2") >= 0) {
                QHomeSchoolRadio = inputobjs[i];
            } else if (inputobjs[i].id.indexOf("txtCamperSchool") >= 0) {
                QSchoolName = inputobjs[i];
            }
        }

        for (var i = 0; i <= selectobjs.length - 1; i++) {
            if (selectobjs[i].id.indexOf("ddlGrade") >= 0) {
                QGrade = selectobjs[i];
            }
        }

        //validate QFirstTime
        if (QFirstTimerYes.checked == false && QFirstTimerNo.checked == false) {
            valobj.innerHTML = "<ul><li>Please answer Question No. 1</li></ul>";
            args.IsValid = false;
            return;
        }

        //validate Grade
        if (QGrade.selectedIndex == 0) {
            valobj.innerHTML = "<li>Please select the Grade</li>";
            args.IsValid = false;
            return;
        }

        //for Question School Name
        if (trim(QSchoolName.value) == "") {
            if (QHomeSchoolRadio.checked == false) {
                valobj.innerHTML = "<li>Please enter Name of the School</li>";
                args.IsValid = false;
                return;
            }
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
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae enter the synagogue name.</li></ul>";
                }
            }

            if (!$rdoCongregant.is(':checked') && !$('#ctl00_Content_rdoNoOne').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5a - pleae select who did you speak to in your synagogue.</li></ul>";
            }

            if ($rdoCongregant.is(':checked') && $('#ctl00_Content_ddlWho>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5a - pleae select one person from your synagogue.</li></ul>";
            }

            if ($rdoCongregant.is(':checked') && $('#ctl00_Content_ddlWho>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtWhoInSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 5a - pleae enter the person's name from your synagogue.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 5 - pleae enter the JCC name.</li></ul>";
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
})