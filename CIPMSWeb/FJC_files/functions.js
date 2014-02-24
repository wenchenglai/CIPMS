// JavaScript Document
function ClearEmailText(fld) {
  if(fld.value == fld.title)
  {
    fld.style.color = "#555555";
    fld.value="";
  }
}
function SetEmailText(fld){
  if(fld.value=="") {
    fld.style.color = "#D1D3D4";
    fld.value = fld.title;
  }
}

$(document).ready(function(){
  $(".inline").colorbox({
    inline:true
  //width:"50%"
  });
});


// toggle used in Faq pages
$(window).load(function(){
  $("#faqs h2").click(function () {
    $(this).siblings().toggle("200");
  });
  $(".faqs li .close").click(function () {
    $(this).next().siblings().toggle("200");
  });
});

function checkboxes_check(checkboxId){
  var currentCheckBox='#'+checkboxId;
  var checkBoxs =$('[id*="edit-checkboxes-options-"]');
  if($(currentCheckBox).is(':checked'))
  {
    $(checkBoxs).removeAttr('checked');
    $(currentCheckBox).attr('checked','checked');
  }
}