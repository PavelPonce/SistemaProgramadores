

$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarDepartamento").DataTable();
  })
  
  
    function agregarDepartamento (departamento)
    {
    var nuevotd = "<tr>";
  
    if(departamento == "")
    {
        $("#msgDepartamento").removeAttr("hidden")
        $("#txtDepartamento").focus()
    }
    else
    {
        $("#msgDepartamento").attr("hidden", true)
    }    
  
    if(departamento != "" )
    {
  
        nuevotd += "<td>" + departamento + "</td>";
        nuevotd += "</tr>";


        $("#agregarDepartamento").append(nuevotd);
        nuevotd = "";
  
        iziToast.info({
            title: 'Información',
            message: 'Operación realizada con Éxito'
        })
        limpiar()
        $("#formCard").attr("hidden", true)
        $("#tableCard").removeAttr("hidden")
    }
    }
    function limpiar()
    {
        $("#txtDepartamento").val("")
        $("#txtDepartamento").focus()
    }
    
    $("#btnGuardar").click(function(){
        agregarDepartamento($("#txtDepartamento").val())
    })
