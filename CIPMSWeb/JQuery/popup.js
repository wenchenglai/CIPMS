/***************************/
//@Author: Adrian "yEnS" Mato Gondelle
//@website: www.yensdesign.com
//@email: yensamg@gmail.com
//@license: Feel free to use it, but keep this credits please!					
/***************************/

//SETTING UP OUR POPUP
//0 means disabled; 1 means enabled;
var popupStatus = 0;

//loading popup with jQuery magic!
function loadPopup(){
	//loads popup only if it is disabled
	if(popupStatus==0){
		$("#popupContact").fadeIn();
		popupStatus = 1;
	}
}

//disabling popup with jQuery magic!
function disablePopup(){
	//disables popup only if it is enabled
	if(popupStatus==1){
		$("#popupContact").fadeOut();
		popupStatus = 0;
	}
}

//centering popup
function centerPopup(){
	//request data for centering
	var windowWidth = $(window).width();//document.documentElement.clientWidth;
	var windowHeight = $(window).height();//document.documentElement.clientHeight;
	var popupHeight = $("#popupContact").height();
	var popupWidth = $("#popupContact").width();
	//centering	
	$("#popupContact").css({
		"position": "absolute",
		"top": windowHeight/2-popupHeight/2,
		"left": windowWidth/2-popupWidth/2
	});	
}

function SetTitle(popupTitle)
{
    var titleSpan = $('#hdrSpan');
    if(popupTitle != "")
    titleSpan.text(popupTitle);
}

function EnablePanel(messageSpanID)
{
    var parent = $('#contactArea');
    
    $('span', parent).each(
    function() {
        var spanElement = $(this);
        var id = spanElement.attr('id');
        
        if(id == messageSpanID)
            spanElement.show();
        else if(spanElement.is(':visible'))
            spanElement.hide();
             
    });    
}
function doThis() {
}
//LOADING POPUP
//Event!
function popupCall(invokedObj, messageSpanID, popupTitle, isPnl8ToBeDisabled, pageName, allowNoCamp) {
    //To give a message for JWest second timers
    if(pageName == "step1_Questions")
    {
        if(messageSpanID == "JWestFirstTimerQuestionMessage")
        {
            
             //load or disable popup
	        var bCheckedValue = false;
    	
	        if(invokedObj != null)
	        switch (invokedObj.value)
            {
                case "3":
                    bCheckedValue=true;
                    break;
                default:
                    bCheckedValue = false;
                    break;
            }
	        //If yes is selected
	        if(bCheckedValue == false)
	            disablePopup();
	        else
	        {
	            //centering with css
	            centerPopup();
	            //load Popup
	            loadPopup();
	            //Set Title
	            SetTitle(popupTitle);	
	            //Enable message
	            EnablePanel(messageSpanID);	
	        }	
        }
    }
    else if (pageName != undefined && pageName == "step1") {
        if (messageSpanID == "ChicagoSiblingNotSure") {
            debugger;
            var bCheckedValue = false;
            var benableSchoolTextBox = true;
            if (invokedObj != null)
                switch (invokedObj.value) {
                case "4":
                    bCheckedValue = true; benableSchoolTextBox = false;
                    break;
                case "3":
                    bCheckedValue = false; benableSchoolTextBox = true;
                    break;
                default:
                    bCheckedValue = false; benableSchoolTextBox = false;
                    break;
            }

            //added to enable the next button for valid pj code and jewishday school selected by sandhya
            var hdnValid = document.getElementById("ctl00_Content_hdnValid");
            if (hdnValid.value == 1) {
                bCheckedValue = false;
            }

            if (bCheckedValue) {
                //centering with css
                centerPopup();
                //load Popup
                loadPopup();
                //Set Title
                SetTitle(popupTitle);
                //Enable message
                EnablePanel(messageSpanID);

            }
            else {
                disablePopup();
            }
            var lblQ6star = document.getElementById("ctl00_Content_lblQ6star");
            var lblQ6 = document.getElementById("ctl00_Content_lblQ6");
            var PnlQ6 = document.getElementById("ctl00_Content_PnlQ6");
            var label15 = document.getElementById("ctl00_Content_Label15");
            var txtCamperSchool = document.getElementById("ctl00_Content_txtCamperSchool");
            label15.removeAttribute("disabled");
            txtCamperSchool.removeAttribute("disabled");
            lblQ6.removeAttribute("disabled");
            lblQ6star.removeAttribute("disabled");
            PnlQ6.removeAttribute("disabled");
            label15.disabled = benableSchoolTextBox ? "disabled" : "";

            if (benableSchoolTextBox) {
                txtCamperSchool.disabled = "disabled"; txtCamperSchool.value = ""; lblQ6.disabled = lblQ6star.disabled = PnlQ6.disabled = "disabled";
            }
            else {
                txtCamperSchool.disabled = lblQ6.disabled = lblQ6star.disabled = PnlQ6.disabled = "";
                //txtCamperSchool.setAttribute("className","txtbox"); label15.removeAttribute("className"); label15.setAttribute("className","QuestionText");
            }
            document.getElementById("ctl00_Content_btnNext").disabled = bCheckedValue;

        } else if (messageSpanID == "PJLJewishDaySchoolMessage") {
            var bCheckedValue = false;
            var benableSchoolTextBox = true;
            if (invokedObj != null)
                switch (invokedObj.value) {
                case "4":
                    bCheckedValue = true; benableSchoolTextBox = false;
                    break;
                case "3":
                    bCheckedValue = false; benableSchoolTextBox = true;
                    break;
                default:
                    bCheckedValue = false; benableSchoolTextBox = false;
                    break;
            }
            //If Jewish Day School is selected is selected
            //load or disable popup

            //added to enable the next button for valid pj code and jewishday school selected by sandhya
            var hdnValid = document.getElementById("ctl00_Content_hdnValid");
            if (hdnValid.value == 1) {
                bCheckedValue = false;
            }

            if (bCheckedValue) {
                //centering with css
                centerPopup();
                //load Popup
                loadPopup();
                //Set Title
                SetTitle(popupTitle);
                //Enable message
                EnablePanel(messageSpanID);

            }
            else {
                disablePopup();
            }
            var lblQ6star = document.getElementById("ctl00_Content_lblQ6star");
            var lblQ6 = document.getElementById("ctl00_Content_lblQ6");
            var PnlQ6 = document.getElementById("ctl00_Content_PnlQ6");
            var label15 = document.getElementById("ctl00_Content_Label15");
            var txtCamperSchool = document.getElementById("ctl00_Content_txtCamperSchool");
            label15.removeAttribute("disabled");
            txtCamperSchool.removeAttribute("disabled");
            lblQ6.removeAttribute("disabled");
            lblQ6star.removeAttribute("disabled");
            PnlQ6.removeAttribute("disabled");
            label15.disabled = benableSchoolTextBox ? "disabled" : "";

            if (benableSchoolTextBox) {
                txtCamperSchool.disabled = "disabled"; txtCamperSchool.value = ""; lblQ6.disabled = lblQ6star.disabled = PnlQ6.disabled = "disabled";
            }
            else {
                txtCamperSchool.disabled = lblQ6.disabled = lblQ6star.disabled = PnlQ6.disabled = "";
                //txtCamperSchool.setAttribute("className","txtbox"); label15.removeAttribute("className"); label15.setAttribute("className","QuestionText");
            }
            document.getElementById("ctl00_Content_btnNext").disabled = bCheckedValue;

        } else if (messageSpanID == "RamahDoromSecondTimerWarning") {
            var showPopup = false,
                YES_I_RECEIVED_GRANT_LAST_SUMMER = "1";

            if (invokedObj.value === YES_I_RECEIVED_GRANT_LAST_SUMMER) {
                showPopup = true;
            }

            if (showPopup) {
                centerPopup();
                loadPopup();
                SetTitle(popupTitle);
                EnablePanel(messageSpanID);

                $(':submit').attr("disabled", "true");
                $(':submit').fadeTo(500, 0.2); 
            } else {
                disablePopup();
                $(':submit').removeAttr("disabled");
                $(':submit').fadeTo(500, 1);               
            }
        } else {
            //centering with css
            centerPopup();
            //load Popup
            loadPopup();
            //Set Title
            SetTitle(popupTitle);
            //Enable message
            EnablePanel(messageSpanID);
        }
    }
    else
    {
	    //load or disable popup
	    var bCheckedValue = false;
    	
	    if(invokedObj != null)
	    switch (invokedObj.value)
        {
            case "1":
                bCheckedValue=true;
                break;
            default:
                bCheckedValue = false;
                break;
        }
	    //If yes is selected
	    if(bCheckedValue == false)
	        disablePopup();
	    else
	    {
	        //centering with css
	        centerPopup();
	        //load Popup
	        loadPopup();
	        //Set Title
	        SetTitle(popupTitle);	
	        //Enable message
	        EnablePanel(messageSpanID);	
	    }	
    	
	    //This is for disabling/enabling the controls on the page
	    if(isPnl8ToBeDisabled == undefined)
	        isPnl8ToBeDisabled = false;
    	    
	    CampRegistrationSelection(bCheckedValue, isPnl8ToBeDisabled, allowNoCamp, 'PnlQ7','PnlQ8','PnlQ9','PnlQ10');
	}	
}


function CampRegistrationSelection()
{
    var arguments = CampRegistrationSelection.arguments;
    var RadioObj, k=0;
    var divctlsid = new Array();
    var bCheckedValue, bPnl8Disable, allowNoCamp = false;
    
    //to get the input parameters passed to this method
    //1st parameter - Radiobutton obj
    //rest parameters - divobjects separated by comma
    for (var j=0; j<=arguments.length-1; j++)
    {
        switch (j)
        {
            case 0:
                bCheckedValue = arguments[j];
                break;
            case 1:
                bPnl8Disable = arguments[j];
                break;
            case 2:
                allowNoCamp = arguments[j];
                break;
            default:
                divctlsid[k] = arguments[j];
                k=k+1;
                break;
        }
    }
    
    var divobjs = new Array();
    divobjs = document.getElementsByTagName("div");

    if (!allowNoCamp) {
        if (bCheckedValue) {
            $("#ctl00_Content_btnChkEligibility").hide();
        } else {
            $("#ctl00_Content_btnChkEligibility").show();
        }
    }
    //to disable the child nodes
    for (var i=0; i < divobjs.length; i++)
    {
        //to disable all the childnode of the panel        
        for (var l=0; l<=divctlsid.length; l++)
        {   
            //alert(divobjs[i].id.indexOf(divctlsid[l]) + " ," + divobjs[i].id + " ," + divctlsid[l] );
            if(divobjs[i].id.indexOf(divctlsid[l])>=0)
            {               
                //debugger; 
                if(bPnl8Disable == false || (bPnl8Disable == true && divobjs[i].id.indexOf("PnlQ8")==-1))
                {
                    divobjs[i].disabled=bCheckedValue;
                    var child = new Array();
                    child = divobjs[i].childNodes;
                    for (var j=0; j<child.length-1; j++)
                    {   
                        if (child[j].id !=undefined) 
                        {                            
                            child[j].disabled = bCheckedValue;
                            //to set the value in the textbox and dropdown to the default value
                            if (child[j].type!=null && bCheckedValue==true)
                            {
                                if (child[j].type.indexOf("select")>=0) {child[j].selectedIndex=0; }//if it is dropdown
                                else child[j].value=""; //for text box
                            }
                            //this is used for Jwest (Step 2 - Page 3 where the start date and end date are displayed in labels)
                            if ((child[j].id.indexOf("lblStartDate")>=0 || child[j].id.indexOf("lblEndDate")>=0))
                            {
                                if (bCheckedValue) child[j].innerHTML="";
                            }
                        }
                    }
                }
            }
        }
    }
} 


//CONTROLLING EVENTS IN jQuery
$(document).ready(function(){	
				
	//CLOSING POPUP
	//Click the x event!
	$("#popupContactClose").click(function(){
		disablePopup();
	});
	//Click out event!
	$("#backgroundPopup").click(function(){
		disablePopup();
	});
	//Press Escape event!
	
	$(document).keyup(function(e){
	    if(e.keyCode==27 && popupStatus==1){
			disablePopup();
	    }
	});

	if ($("#ctl00_Content_RegControls1_RadioButtonQ7Option1").prop("checked")) {
	    $("#ctl00_Content_btnChkEligibility").hide();
	} else {
	    $("#ctl00_Content_btnChkEligibility").show();
	}

});

