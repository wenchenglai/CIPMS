var PageValidator = {
    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        var inputobjs = document.getElementsByTagName("input");
        var selectobjs = document.getElementsByTagName("select");
        var Q3_1, Q3_2, Q4, Q5, Q6, bValid = true, Q5CheckedValue;
        var Q5 = new Array();
        var j = 0;
        var valobj = document.getElementById(sender.id);
        var Synagogue_0, Synagogue_1, SynagogueOther;
        var SynagogueComboValue;
        var SynRefCode;

        for (var i = 0; i < inputobjs.length - 1; i++) {
            //for Q3_1
            if (inputobjs[i].id.indexOf("RadioBtnQ31") >= 0)
                Q3_1 = inputobjs[i];
            //for Q3_2
            if (inputobjs[i].id.indexOf("RadioBtnQ32") >= 0)
                Q3_2 = inputobjs[i];
            //for Q5
            if (inputobjs[i].id.indexOf("RadioButtionQ5") >= 0) {
                Q5[j] = inputobjs[i];
                j = j + 1;
            }
            //for Q6
            if (inputobjs[i].id.indexOf("txtCamperSchool") >= 0)
                Q6 = inputobjs[i];
        }  //end of for loop   


        //to get the select objects (ddlgrade) for Q4
        for (var k = 0; k <= selectobjs.length - 1; k++) {
            if (selectobjs[k].id.indexOf("ddlGrade") >= 0) {
                Q4 = selectobjs[k];
                break;
            }
        }

        //validate Q3
        if (Q3_1.checked == false && Q3_2.checked == false) {
            valobj.innerHTML = "<ul><li>Please answer Question No. 1</li></ul>";
            args.IsValid = false;
            return;
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

        //validate Q4
        if (bValid && Q4.selectedIndex == 0) {
            valobj.innerHTML = "<ul><li>Please select a Grade</li></ul>";
            args.IsValid = false;
            return;
        }
        else {

            //validate Q5
            var bChecked = false;

            for (var k = 0; k <= Q5.length - 1; k++) {
                if (Q5[k].checked == true) {
                    Q5CheckedValue = Q5[k].value;
                    bChecked = true;
                    break;
                }
            }

            if (!bChecked) {
                valobj.innerHTML = "<ul><li>Please answer Question No. 4</li></ul>";
                args.IsValid = false;
                return;
            }
            else if (Q5CheckedValue != "3" && trim(Q6.value) == "")//validate Q6 (if it is not home school)
            {
                valobj.innerHTML = "<ul><li>Please enter Name of the School</li></ul>";
                args.IsValid = false;
                return;
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
