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
//  $(".close").click(function () {
//    $(this).siblings().toggle("200");
//  });

});

