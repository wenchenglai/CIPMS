//*****************************BEGIN OF VALIDATION FOR Cleveland**********************************
//to validate the Step2 (Page 2) for NY /////////////////////////
function ValidatePage2Step2_Cleveland(sender, args) {
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
        //        if (inputobjs[i].id.indexOf("RadioBtnQ4_0")>=0)
        //        {
        //            Q4_1 = inputobjs[i];
        //        }
        //        
        //        //for Q4_2
        //        if (inputobjs[i].id.indexOf("RadioBtnQ4_1")>=0)
        //        {
        //            Q4_2 = inputobjs[i];
        //        }

        //for Q5_1
        //        if (inputobjs[i].id.indexOf("RadioBtnQ5_0")>=0)
        //        {
        //            Q5_1 = inputobjs[i];
        //        }
        //        
        //        //for Q5_2
        //        if (inputobjs[i].id.indexOf("RadioBtnQ5_1")>=0)
        //        {
        //            Q5_2 = inputobjs[i];
        //        }

        //for Q7_1
        //        if (inputobjs[i].id.indexOf("RadioBtnQ7_0")>=0)
        //        {
        //            Q7_1 = inputobjs[i];
        //        }
        //        
        //        //for Q7_2
        //        if (inputobjs[i].id.indexOf("RadioBtnQ7_1")>=0)
        //        {
        //            Q7_2 = inputobjs[i];
        //        }  
        //        
        // for txtSynagogueReferral 

        //        if (inputobjs[i].id.indexOf("txtOtherSynagogue")>=0)
        //        {
        //            Q8_2 = inputobjs[i];
        //        }      

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

        //for Q8
        //        if (selectobjs[i].id.indexOf("ddlSynagogue")>=0)
        //        {
        //            Q8_1 = selectobjs[i];
        //        }         

    }

    //validate Q3
    if (Q3_1.checked == false && Q3_2.checked == false) {
        valobj.innerHTML = "<ul><li>Please answer Question No. 1</li></ul>";
        args.IsValid = false;
        return;
    }
    //    else if (Q3_1.checked) // if yes is checked
    if (Q3_1.checked == true || Q3_2.checked == true) {
        //For Synagogue and JCC Question
        var returnVal = ValidateSynagogueAndJCCQuestion(inputobjs, selectobjs, valobj, false);
        if (returnVal == false) {
            args.IsValid = false;
            return;
        }

        //         //for Question 7
        //        if (Q7_1.checked==false && Q7_2.checked==false)
        //        {
        //             valobj.innerHTML = "<li>Please answer Question No. 5</li>";
        //             args.IsValid=false;
        //             return;
        //        }
        //        if(Q7_1.checked==true)
        //        {
        //           //validate synagogue
        //            if (Q8_1.selectedIndex==0)
        //            {
        //                valobj.innerHTML = "<li>Please select the Synagogue</li>";
        //                args.IsValid=false;
        //                return;
        //            }  
        //            else if(Q8_1.options[Q8_1.selectedIndex].text == "OTHER")
        //            {
        //                //referral code
        //                if (trim(Q8_2.value)=="")
        //                {
        //                    valobj.innerHTML = "<li>Please enter the Synagogue name.</li>";
        //                    args.IsValid=false;
        //                    return;
        //                }
        //            }
        //        }
    }
    //    else if (Q3_2.checked)  //if "no" is checked
    //    {
    //        //to validate for Q4 and Q5
    //        if (Q4_1.checked==false && Q4_2.checked==false)
    //        {
    //             valobj.innerHTML = "<li>Please answer Question No. 3</li>";
    //             args.IsValid=false;
    //             return;
    //        }
    //        else if (Q4_1.checked)
    //        {
    //            if (Q5_1.checked==false && Q5_2.checked==false)
    //            {
    //                 valobj.innerHTML = "<li>Please answer Question No. 4</li>";
    //                 args.IsValid=false;
    //                 return;
    //            }
    //            else if (Q5_1.checked)
    //            {
    //             //For Synagogue and JCC Question
    //                var returnVal = ValidateSynagogueAndJCCQuestion(inputobjs,selectobjs,valobj,false);
    //                if(returnVal == false)
    //                {
    //                    args.IsValid = false;
    //                    return;
    //                }
    ////                //for Question 7
    ////                if (Q7_1.checked==false && Q7_2.checked==false)
    ////                {
    ////                     valobj.innerHTML = "<li>Please answer Question No. 5</li>";
    ////                     args.IsValid=false;
    ////                     return;
    ////                }
    ////                //validate synagogue
    ////                if (Q8_1.selectedIndex==0 && Q7_1.checked)
    ////                {
    ////                    valobj.innerHTML = "<li>Please select the Synagogue</li>";
    ////                    args.IsValid=false;
    ////                    return;
    ////                }  
    ////                //referral code
    ////                if (trim(Q8_2.value)=="" && Q8_1.options[Q8_1.selectedIndex].text == "OTHER")
    ////                {
    ////                    valobj.innerHTML = "<li>Please enter the Synagogue name.</li>";
    ////                    args.IsValid=false;
    ////                    return;
    ////                }
    //            }
    //        }

    //    }
    //    
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

    // Referral code must be 4 digits
    /*  if (!(trim(Q8_2.value)==""))
     {
         if (!IsNumeric(trim(Q8_2.value)))
         {
             valobj.innerHTML = "<ul><li>Please enter valid referal code </li></ul>";
             args.IsValid=false;
             return;
  
         }   
     }
     
     // Referral code must be 4 digits
    if (!(trim(Q8_2.value)==""))
     {
         var refcode;
         refcode=trim(Q8_2.value);
         if (refcode.length<4)
         {
             valobj.innerHTML = "<ul><li>Please enter valid 4 digit referal code </li></ul>";
             args.IsValid=false;
             return;
  
         }   
     }
 */


    //if Q9 is not answered
    if (!bQ9Checked) {
        valobj.innerHTML = "<li>Please answer Question No. 4</li>";
        args.IsValid = false;
        return;
    }

    args.IsValid = true;
    return;
}
//*****************************END OF VALIDATION FOR Cleveland**********************************
