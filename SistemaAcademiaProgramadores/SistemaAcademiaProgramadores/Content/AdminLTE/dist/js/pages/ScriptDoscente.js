
$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarDoscente").DataTable();
  })