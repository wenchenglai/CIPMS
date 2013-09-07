var PageValidator = {
    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        var inputobjs = document.getElementsByTagName("input");
        var selectobjs = document.getElementsByTagName("select");
        var Q3_1, Q3_2, Q4_1, Q4_2, Q5_1, Q5_2, Q6, Q7_1, Q7_2, Q8_1, Q8_2, Q9, Q10;
        Q9 = new Array();
        var j = 0;
        var valobj = document.getElementById(sender.id);
        var hdnYearCount;
        for (var i = 0; i < inputobjs.length - 1; i++) {
            //for Q3_1
            if (inputobjs[i].id.indexOf("RadioBtnQ3_0") >= 0) {
                Q3_1 = inputobjs[i];
            }
            //for Q3_2
            if (inputobjs[i].id.indexOf("RadioBtnQ3_1") >= 0) {
                Q3_2 = inputobjs[i];
            }

            //for Q4_1
            if (inputobjs[i].id.indexOf("RadioBtnQ4_0") >= 0) {
                Q4_1 = inputobjs[i];
            }

            //for Q4_2
            if (inputobjs[i].id.indexOf("RadioBtnQ4_1") >= 0) {
                Q4_2 = inputobjs[i];
            }

            //for Q5_1
            if (inputobjs[i].id.indexOf("RadioBtnQ5_0") >= 0) {
                Q5_1 = inputobjs[i];
            }

            //for Q5_2
            if (inputobjs[i].id.indexOf("RadioBtnQ5_1") >= 0) {
                Q5_2 = inputobjs[i];
            } 

            //for Q9
            if (inputobjs[i].id.indexOf("RadioBtnQ9") >= 0) {
                Q9[j] = inputobjs[i];
                j = j + 1;
            }

            //for Q10
            if (inputobjs[i].id.indexOf("txtCamperSchool") >= 0) {
                Q10 = inputobjs[i];
            }

        }  //end of for loop

        //to get the <select> objects for Q8 and Q10
        for (var i = 0; i <= selectobjs.length - 1; i++) {
            //for Q6
            if (selectobjs[i].id.indexOf("ddlGrade") >= 0) {
                Q6 = selectobjs[i];
            }
        }

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo'),
            $rdoCongregant = $('#ctl00_Content_rdoCongregant');

        if (!$chkSynagogue.is(':checked') && !$chkJCC.is(':checked') && !$chkNo.is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 4 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($chkSynagogue.is(':checked') && !$chkSynagogue.is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 4 - pleae select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 4 - pleae enter the synagogue name.</li></ul>";
                }
            }

            if (!$rdoCongregant.is(':checked') && !$('#ctl00_Content_rdoNoOne').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 4a - pleae select who did you speak to in your synagogue.</li></ul>";
            }

            if ($rdoCongregant.is(':checked') && $('#ctl00_Content_ddlWho>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 4a - pleae select one person from your synagogue.</li></ul>";
            }

            if ($rdoCongregant.is(':checked') && $('#ctl00_Content_ddlWho>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtWhoInSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 4a - pleae enter the person's name from your synagogue.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 4 - pleae enter the JCC name.</li></ul>";
            }
        }
        //validate Q6
        if (Q6.selectedIndex == 0) {
            valobj.innerHTML = "<li>Please select the Grade</li>";
            args.IsValid = false;
            return;
        }

        //for Question 9
        var bQ9Checked = false;
        for (var j = 0 ; j <= Q9.length - 1; j++) {
            if (Q9[j].checked) //Q9 has been answered
            {
                bQ9Checked = true;
                //for Question 11
                if (trim(Q10.value) == "" && Q9[j].value != 3) {
                    valobj.innerHTML = "<li>Please enter Name of the School</li>";
                    args.IsValid = false;
                    return;
                }
            }
        }

        //if Q9 is not answered
        if (!bQ9Checked) {
            valobj.innerHTML = "<li>Please answer Question No. 6</li>";
            args.IsValid = false;
            return;
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
