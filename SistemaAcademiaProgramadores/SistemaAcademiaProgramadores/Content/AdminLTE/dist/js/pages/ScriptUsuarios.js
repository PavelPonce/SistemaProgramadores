

$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarUsuarios").DataTable();
  })
  
  
    function agregarUsuario (usuario, contrasenia, correo, docente)
    {
    var nuevotd = "<tr>";
  
    if(usuario == "")
    {
        $("#msgUsuario").removeAttr("hidden")
        $("#txtNombreUsuario").focus()
    }
    else
    {
        $("#msgUsuario").attr("hidden", true)
    }

    if(contrasenia == "")
    {
        $("#msgContrasenia").removeAttr("hidden")
        $("#txtContrasenia").focus()
    }
    else
    {
        $("#msgContrasenia").attr("hidden", true)
    }

    if(correo == "")
    {
        $("#msgMail").removeAttr("hidden")
        $("#txtMail").focus()
    }
    else
    {
        $("#msgMail").attr("hidden", true)
    }

    if(docente == "vacío")
    {
        $("#msgDocente").removeAttr("hidden")
        $("#slcDocente").focus()
    }
    else
    {
        $("#msgDocente").attr("hidden", true)
    }
    
  
    if(usuario != "" && contrasenia != "" && correo != "" && docente != "vacío")
    {
  
        nuevotd += "<td>" + usuario + "</td>";
        nuevotd += "<td>" + correo + "</td>";
        nuevotd += "<td>" + docente + "</td>";
        nuevotd += "</tr>";


        $("#agregarUsuarios").append(nuevotd);
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
        $("#txtNombreUsuario").val("")
        $("#txtContrasenia").val("")
        $("#txtMail").val("")
        $("#txtNombreUsuario").focus()
    }
    
    $("#btnGuardar").click(function(){
        agregarUsuario($("#txtNombreUsuario").val(), $("#txtContrasenia").val(), $("#txtMail").val(), $("#slcDocentes").val())
    })
