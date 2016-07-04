function ValidateStep4(sender, args) {
    var Q7_1, Q7_2, hasRegistered_Option3, Q7_3, Q7_4, Q8_State, Q8_Camp, Q9_CampSession, Q10_StartDate, Q10_EndDate;
    var inputobjs = document.getElementsByTagName("input");
    var selectobjs = document.getElementsByTagName("select");
    var valObj = document.getElementById(sender.id);
    var dt = new Date();
    var currentDt = dt.getMonth() + 1 + "/" + dt.getDate() + "/" + dt.getYear();
    var bValid = false;
    var strErrorMsg = "";
    var startDate = document.getElementById("ctl00_hdnCampSessionStartDate");
    var endDate = document.getElementById("ctl00_hdnCampSessionEndDate");
    var campSeasonErrorMessage = document.getElementById("ctl00_hdncampSeasonErrorMessage");

    for (var i = 0; i < inputobjs.length - 1; i++) {
        if (inputobjs[i].id.indexOf("RadioButtonQ7Option1") >= 0)
            Q7_1 = inputobjs[i];
        else if (inputobjs[i].id.indexOf("RadioButtonQ7Option2") >= 0) {
            Q7_2 = inputobjs[i];
        } else if (inputobjs[i].id.indexOf("RadioButtonQ7Option3") >= 0) {
            hasRegistered_Option3 = inputobjs[i];
        } else if (inputobjs[i].id.indexOf("RadioButtonQ7Option2") >= 0)
            Q7_2 = inputobjs[i];
        else if (inputobjs[i].id.indexOf("txtCampSession") >= 0)
            Q9_CampSession = inputobjs[i];
        else if (inputobjs[i].id.indexOf("txtStartDate") >= 0)
            Q10_StartDate = inputobjs[i];
        else if (inputobjs[i].id.indexOf("txtEndDate") >= 0)
            Q10_EndDate = inputobjs[i];
    } //end of for loop

    //to select the dropdown objs
    for (var j = 0; j <= selectobjs.length - 1; j++) {
        if (selectobjs[j].id.indexOf("ddlState") >= 0)
            Q8_State = selectobjs[j];
        else if (selectobjs[j].id.indexOf("ddlCamp") >= 0)
            Q8_Camp = selectobjs[j];
    }

    //validation for Question 7
    if (Q7_1.checked) {
        bValid = true;
    } else if (Q7_2.checked || hasRegistered_Option3.checked) {
        Q9_CampSession.value = trim(Q9_CampSession.value);
        Q10_StartDate.value = trim(Q10_StartDate.value);
        Q10_EndDate.value = trim(Q10_EndDate.value);
        //validation for the rest of the questions
        //for Question 10 
        debugger;
        if (Q8_Camp.selectedIndex == 0) {
            strErrorMsg = "Please select a camp.";
            bValid = false;
        }
        else if (Q9_CampSession.value == "") //for Question 11
        {
            strErrorMsg = "Please enter a camp session.";
            bValid = false;
        }
        else if (Q10_StartDate.value == "" || Q10_EndDate.value == "") //for Question 12
        {
            strErrorMsg = "Error in session date.  The accepted format is mm/dd/yyyy.";
            bValid = false;
        }
        else if (!ValidateDate(Q10_StartDate.value)) {
            strErrorMsg = "Error in start session date.  The accepted format is mm/dd/yyyy.";
            bValid = false;
        }
        else if (!ValidateDate(Q10_EndDate.value)) {
            strErrorMsg = "Error in end session date.  The accepted format is mm/dd/yyyy.";
            bValid = false;
        }
        else if (!CompareDates(Q10_StartDate.value, Q10_EndDate.value)) {
            strErrorMsg = "Start date should be prior than the end date.";
            bValid = false;
        }
            //Added by Ram (10/15/2009) related to allow "May, Jun, Jul, Aug, Sep" as session months

        else if (!CompareDates(startDate.value, Q10_StartDate.value)) {
            strErrorMsg = "" + campSeasonErrorMessage.value + "";
            bValid = false;
        }
        else if (!CompareDates(Q10_StartDate.value, endDate.value)) {
            strErrorMsg = "" + campSeasonErrorMessage.value + "";
            bValid = false;
        }
        else if (!CompareDates(startDate.value, Q10_EndDate.value)) {
            strErrorMsg = "" + campSeasonErrorMessage.value + "";
            bValid = false;
        }
        else if (!CompareDates(Q10_EndDate.value, endDate.value)) {
            strErrorMsg = "" + campSeasonErrorMessage.value + "";
            bValid = false;
        }
        else
            bValid = true;
    }//end of else if
    else  //Camp registration Question  is not answered
    {
        strErrorMsg = "Please answer the Camp registration Question ";
        bValid = false;
    }

    valObj.innerHTML = strErrorMsg;
    args.IsValid = bValid;
    return;
}