var HowDidYouHearUsValidator = {
    OnMemberDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_ddlStaffNames>option:selected').text().toLowerCase() === "other") {
            $('#ctl00_Content_txtOtherName').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtOtherName').attr('disabled', true);
        }
    },

    OnSubmitClick: function (sender, args) {
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // Q3a Who is the member?
        if ($('#ctl00_Content_ddlStaffNames').length) {
            if ($('#ctl00_Content_ddlStaffNames>option:selected').text().toLowerCase() === "other") {
                if ($('#ctl00_Content_txtOtherName').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 3a - pleae select staff member/recruiter.</li></ul>";
                }
            }
        }

        if (errorMsg.innerHTML === "") {
            args.IsValid = true;
        } else {
            args.IsValid = false;
        }

        if (args.IsValid) {
            ValidateHowDidYouHearUsPage(sender, args);
        }

        return;
    }
};

$(function () {
    HowDidYouHearUsValidator.OnMemberDropDownChange(null);

})

function ValidateHowDidYouHearUsPage(sender, args) {
    var inputobjs = new Array();
    var txtbox, bChecked = false, bValid = false, bReferralCode = true;
    var strErrorMsg;
    var valObj = document.getElementById(sender.id);
    valObj.innerText = "";
    inputobjs = document.getElementsByTagName("input");
    var message = "<li>Please check any one option for Question 1</li>";
    var spanobjs = document.getElementsByTagName("span");
    var lblErrorMessage;

    for (var i = 0; i < spanobjs.length - 1; i++) {
        if (spanobjs[i].id.indexOf("lblErrorMessage") >= 0) {
            lblErrorMessage = document.getElementById(spanobjs[i].id);
            lblErrorMessage.style.display = 'none';
        }
    }

    // 2012-09-23 Check three main questions
    // Question 1
    var selectObjs = document.getElementsByTagName("select"),
        Q1WhatYear, Q2Research, Q3aStaffNames;

    for (var i = 0; i <= selectObjs.length - 1; i++) {
        if (selectObjs[i].id.indexOf("ddlWhatYear") >= 0) {
            Q1WhatYear = selectObjs[i];
        } else if (selectObjs[i].id.indexOf("ddlResearch") >= 0) {
            Q2Research = selectObjs[i];
        } else if (selectObjs[i].id.indexOf("ddlStaffNames") >= 0) {
            Q3aStaffNames = selectObjs[i];
        }
    }

    if (Q1WhatYear.selectedIndex == 0) {
        valObj.innerHTML = "<li>Please select from Question 1</li>";
        args.IsValid = false;
        return;
    }

    if (Q2Research.selectedIndex == 0) {
        valObj.innerHTML = "<li>Please select from Question 2</li>";
        args.IsValid = false;
        return;
    }

    var isQ3bPass = true,
        isQ3aPass = true;
    var isQ3Pass = false;
    for (var i = 0; i < inputobjs.length - 1; i++) {
        if ((inputobjs[i].id.indexOf("chkStaff1") >= 0 || inputobjs[i].id.indexOf("chkStaff2") >= 0 || inputobjs[i].id.indexOf("chkStaff3") >= 0) && inputobjs[i].checked) {
            isQ3Pass = true; //a checkbox is checked
            if (Q3aStaffNames.selectedIndex == 0) {
                valObj.innerHTML = "<li>Please select from Question 3a</li>";
                args.IsValid = false;
                return;
            } else if (Q3aStaffNames.selectedIndex == 12) {
                var txtbox = document.getElementById("ctl00_Content_txtOtherName");
                if (txtbox.value == "") {
                    isQ3aPass = false;
                }
            }
        } else if (inputobjs[i].id.indexOf("chkHearFromAd") >= 0 && inputobjs[i].checked) {
            isQ3bPass = false;
            isQ3Pass = true; //a checkbox is checked
            for (var j = 0; j < inputobjs.length - 1; j++) {
                if (inputobjs[j].id.indexOf("chk22") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                } else if (inputobjs[j].id.indexOf("chk23") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                } else if (inputobjs[j].id.indexOf("chk24") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                } else if (inputobjs[j].id.indexOf("chk25") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                } else if (inputobjs[j].id.indexOf("chk26") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                } else if (inputobjs[j].id.indexOf("chk27") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                } else if (inputobjs[j].id.indexOf("chk28") >= 0 && inputobjs[j].checked) {
                    isQ3bPass = true;
                }
            }
        } else if (inputobjs[i].id.indexOf("chk16") >= 0 && inputobjs[i].checked) {
            isQ3Pass = true;
        } else if (inputobjs[i].id.indexOf("chk17") >= 0 && inputobjs[i].checked) {
            isQ3Pass = true;
        } else if (inputobjs[i].id.indexOf("chk18") >= 0 && inputobjs[i].checked) {
            isQ3Pass = true;
        } else if (inputobjs[i].id.indexOf("chk19") >= 0 && inputobjs[i].checked) {
            isQ3Pass = true;
        } else if (inputobjs[i].id.indexOf("chk20") >= 0 && inputobjs[i].checked) {
            isQ3Pass = true;
        } else if (inputobjs[i].id.indexOf("chk21") >= 0 && inputobjs[i].checked) {
            isQ3Pass = true;
        }
    } //end of for loop

    if (!isQ3Pass) {
        args.IsValid = false;
        valObj.innerHTML = "<li>Please enter the name from Question 3</li>";
        return;
    }

    if (!isQ3aPass) {
        args.IsValid = false;
        valObj.innerHTML = "<li>Please select from Question 3a</li>";
        return;
    }

    if (!isQ3bPass) {
        args.IsValid = false;
        valObj.innerHTML = "<li>Please select from Question 3b</li>";
        return;
    }

    args.IsValid = true;
    return;
}