$(document).ready(function() {
  $('#optional').hide();
  $('#edit-sendmail').attr('checked',false);
  $('#edit-sendmail').click(function(e) {
    if($('#edit-sendmail').attr('checked'))
      $('#optional').fadeIn();
    else
      $('#optional').fadeOut();
  });
});

function manage_types(elem){
  if(elem.value == "fjc"){
    document.getElementById("contact_form").style.display = "block";
    document.getElementById("contact_content").style.display = "none";
  }
  else if(elem.value == "ohc"){
    document.getElementById("contact_form").style.display = "none";
    document.getElementById("contact_content").style.display = "block";
  }
}