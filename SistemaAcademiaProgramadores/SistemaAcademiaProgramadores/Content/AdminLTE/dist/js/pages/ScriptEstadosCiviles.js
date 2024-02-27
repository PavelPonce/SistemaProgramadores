

$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarEstCivil").DataTable();
  })
  
  
    function agregarEstCivil (estCivil)
    {
    var nuevotd = "<tr>";
  
    if(estCivil == "")
    {
        $("#msgEstCivil").removeAttr("hidden")
        $("#txtEstCivil").focus()
    }
    else
    {
        $("#msgEstCivil").attr("hidden", true)
    }    
  
    if(estCivil != "" )
    {
  
        nuevotd += "<td>" + estCivil + "</td>";
        nuevotd += "</tr>";


        $("#agregarEstCivil").append(nuevotd);
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
        $("#txtEstCivil").val("")
        $("#txtEstCivil").focus()
    }
    
    $("#btnGuardar").click(function(){
        agregarEstCivil($("#txtEstCivil").val())
    })
