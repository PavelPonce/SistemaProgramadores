

$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarParentesco").DataTable();
  })
  
  
    function agregarParentesco (parentesco)
    {
    var nuevotd = "<tr>";
  
    if(parentesco == "")
    {
        $("#msgParentesco").removeAttr("hidden")
        $("#txtParentesco").focus()
    }
    else
    {
        $("#msgParentesco").attr("hidden", true)
    }    
  
    if(parentesco != "" )
    {
  
        nuevotd += "<td>" + parentesco + "</td>";
        nuevotd += "</tr>";


        $("#agregarParentesco").append(nuevotd);
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
        $("#txtParentesco").val("")
        $("#txtParentesco").focus()
    }
    
    $("#btnGuardar").click(function(){
        agregarParentesco($("#txtParentesco").val())
    })
