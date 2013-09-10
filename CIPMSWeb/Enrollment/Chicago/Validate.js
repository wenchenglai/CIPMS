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

        //var inputobjs = document.getElementsByTagName("input");
        //var selectobjs = document.getElementsByTagName("select");
        //var Q3_1, Q3_2, Q4_1, Q4_2, Q4_3, Q5_1, Q5_2, Q6, Q9, Q10_1, Q10_2, Q11, QSiblingFirstName, QSiblingLastName;
        //Q9 = new Array();
        //var j = 0;
        //var valobj = document.getElementById(sender.id);
        //var hdnYearCount;
        //for (var i = 0; i < inputobjs.length - 1; i++) {
        //    //for Q3_1
        //    if (inputobjs[i].id.indexOf("RadioBtnQ3_0") >= 0) {
        //        Q3_1 = inputobjs[i];
        //    }
        //    //for Q3_2
        //    if (inputobjs[i].id.indexOf("RadioBtnQ3_1") >= 0) {
        //        Q3_2 = inputobjs[i];
        //    }

        //    //for QSiblingJoinedYes
        //    if (inputobjs[i].id.indexOf("RadioBtnQ4_0") >= 0) {
        //        Q4_1 = inputobjs[i];
        //    }

        //    //for QSiblingJoinedNo
        //    if (inputobjs[i].id.indexOf("RadioBtnQ4_1") >= 0) {
        //        Q4_2 = inputobjs[i];
        //    }

        //    //for QSiblingJoinedNotSure
        //    if (inputobjs[i].id.indexOf("RadioBtnQ4_2") >= 0) {
        //        Q4_3 = inputobjs[i];
        //    }

        //    //for QSiblingFirstName
        //    if (inputobjs[i].id.indexOf("txtSiblingFirstName") >= 0) {
        //        QSiblingFirstName = inputobjs[i];
        //    }

        //    //for QSiblingLastName
        //    if (inputobjs[i].id.indexOf("txtSiblingLastName") >= 0) {
        //        QSiblingLastName = inputobjs[i];
        //    }

        //    //for Q5_1
        //    if (inputobjs[i].id.indexOf("RadioBtnQ5_0") >= 0) {
        //        Q5_1 = inputobjs[i];
        //    }

        //    //for Q5_2
        //    if (inputobjs[i].id.indexOf("RadioBtnQ5_1") >= 0) {
        //        Q5_2 = inputobjs[i];
        //    }

        //    //for Q9
        //    if (inputobjs[i].id.indexOf("RadioBtnQ9") >= 0) {
        //        Q9[j] = inputobjs[i];
        //        j = j + 1;
        //    }

        //    //for Q10_2
        //    if (inputobjs[i].id.indexOf("txtJewishSchool") >= 0) {
        //        Q10_2 = inputobjs[i];
        //    }

        //    //for Q11
        //    if (inputobjs[i].id.indexOf("txtCamperSchool") >= 0) {
        //        Q11 = inputobjs[i];
        //    }

        //}  //end of for loop

        ////to get the <select> objects for Q8 and Q10
        //for (var i = 0; i <= selectobjs.length - 1; i++) {
        //    //for Q6
        //    if (selectobjs[i].id.indexOf("ddlGrade") >= 0) {
        //        Q6 = selectobjs[i];
        //    }

        //    //for Q10
        //    if (selectobjs[i].id.indexOf("ddlQ10") >= 0) {
        //        Q10_1 = selectobjs[i];
        //    }
        //}

        ////validate Q3
        //if (Q3_1.checked == false && Q3_2.checked == false) {
        //    valobj.innerHTML = "<ul><li>Please answer Question No. 1</li></ul>";
        //    args.IsValid = false;
        //    return;
        //}
        //else if (Q3_2.checked)  //if "no" is checked
        //{
        //    //to validate for Q4 and Q5
        //    if (Q4_1.checked == false && Q4_2.checked == false) {
        //        valobj.innerHTML = "<li>Please answer Question No. 2</li>";
        //        args.IsValid = false;
        //        return;
        //    }
        //    else if (Q4_1.checked) {
        //        if (Q5_1.checked == false && Q5_2.checked == false) {
        //            valobj.innerHTML = "<li>Please answer Question No. 3</li>";
        //            args.IsValid = false;
        //            return;
        //        }
        //    }

        //}

        //if (Q4_1.checked == false && Q4_2.checked == false && Q4_3.checked == false) {
        //    valobj.innerHTML = "<li>Please answer Question No. 2</li>";
        //    args.IsValid = false;
        //    return;
        //}

        //if (Q4_1.checked == true) {
        //    if (trim(QSiblingLastName.value) == "" || trim(QSiblingFirstName.value) == "") {
        //        valobj.innerHTML = "<li>Please answer Question No. 3</li>";
        //        args.IsValid = false;
        //        return;
        //    }
        //}

        ////validate Q6
        //if (Q6.selectedIndex == 0) {
        //    valobj.innerHTML = "<li>Please select the Grade</li>";
        //    args.IsValid = false;
        //    return;
        //}

        ////for Question 9
        //var bQ9Checked = false;
        //for (var j = 0 ; j <= Q9.length - 1; j++) {
        //    if (Q9[j].checked && Q9[j].value == 4) {
        //        bQ9Checked = true;
        //        if (trim(Q10_2.value) == "" && Q10_1.selectedIndex == 0) {
        //            valobj.innerHTML = "<li>Please answer Question No. 6</li>";
        //            args.IsValid = false;
        //            return;
        //        }
        //        else if (trim(Q10_2.value) == "" && Q10_1.options[Q10_1.selectedIndex].text == "Other")  //others is selected
        //        {
        //            valobj.innerHTML = "<li>Please type in the Jewsish Day School</li>";
        //            Q10_2.focus();
        //            args.IsValid = false;
        //            return;
        //        }
        //        else if (trim(Q10_2.value) != "") {
        //            for (i = 0; i < Q10_1.length; i++) {
        //                if (Q10_1.options[Q10_1.selectedIndex].text == "Other")
        //                    Q10_1.selectedIndex = Q10_1.selectedIndex;
        //            }
        //        }
        //    }
        //    else if (Q9[j].checked) //Q9 has been answered
        //    {
        //        bQ9Checked = true;
        //        //for Question 11
        //        if (trim(Q11.value) == "" && Q9[j].value != 3) {
        //            valobj.innerHTML = "<li>Please enter Name of the School</li>";
        //            args.IsValid = false;
        //            return;
        //        }
        //    }
        //}

        ////if Q9 is not answered
        //if (!bQ9Checked) {
        //    valobj.innerHTML = "<li>Please answer Question No. 5</li>";
        //    args.IsValid = false;
        //    return;
        //}

        //// Check JCC and Synagogue
        //var returnVal = ValidateSynagogueAndJCCQuestion(inputobjs, selectobjs, valobj, false);
        //if (returnVal == false) {
        //    args.IsValid = false;
        //    return;
        //}

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