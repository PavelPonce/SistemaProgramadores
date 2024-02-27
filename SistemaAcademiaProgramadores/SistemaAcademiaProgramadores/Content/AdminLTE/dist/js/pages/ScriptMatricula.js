

$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarMatricula").DataTable();
  })
  
  
    function agregarMatricula (instituto, curso, totalMatricula, totalCuotas, pNombreEstudiante, pApellidoEstudiante,
        fechaNacimientoEstudiante, domicilio, municipio, telefonoEstudiante, DNIEstudiante)
        // , sexoEstudiante,
        // pNombreEncargado, pApellidoEncargado, parentesco, estCivil, sexoEncargado, telefonoEncargado, correoEncargado)
    {
    var nuevotd = "<tr>";
  
    if(instituto == "vacío")
    {
        $("#msgInstituto").removeAttr("hidden")
        $("#slcInstituto").focus()
    }
    else
    {
        $("#msgInstituto").attr("hidden", true)
    }

    if(curso == "vacío")
    {
        $("#msgCurso").removeAttr("hidden")
        $("#slcCurso").focus()
    }
    else
    {
        $("#msgCurso").attr("hidden", true)
    }

    if(totalMatricula == "")
    {
        $("#msgTotalMatricula").removeAttr("hidden")
        $("#txtTotalMatricula").focus()
    }
    else
    {
        $("#msgTotalMatricula").attr("hidden", true)
    }

    if(totalCuotas == "")
    {
        $("#msgTotalCuotas").removeAttr("hidden")
        $("#txtTotalCuotas").focus()
    }
    else
    {
        $("#msgTotalCuotas").attr("hidden", true)
    }

    if(pNombreEstudiante == "")
    {
        $("#msgNombreEstudiante").removeAttr("hidden")
        $("#txtPNombreEstudiante").focus()
    }
    else
    {
        $("#msgNombreEstudiante").attr("hidden", true)
    }

    if(pApellidoEstudiante == "")
    {
        $("#msgApellidoEstudiante").removeAttr("hidden")
        $("#txtPApellidoEstudiante").focus()
    }
    else
    {
        $("#msgApellidoEstudiante").attr("hidden", true)
    }

    if(fechaNacimientoEstudiante == "")
    {
        $("#msgFechaNacimientoEstudiante").removeAttr("hidden")
        $("#txtFechaNacimientoEstudiante").focus()
    }
    else
    {
        $("#msgFechaNacimientoEstudiante").attr("hidden", true)
    }

    if(domicilio == "")
    {
        $("#msgDomicilio").removeAttr("hidden")
        $("#txtDomicilio").focus()
    }
    else
    {
        $("#msgDomicilio").attr("hidden", true)
    }
    if(municipio == "vacío")
    {
        $("#msgMunicipio").removeAttr("hidden")
        $("#slcMunicipio").focus()
    }
    else
    {
        $("#msgMunicipio").attr("hidden", true)
    }

    if(telefonoEstudiante == "")
    {
        $("#msgTelefonoEstudiante").removeAttr("hidden")
        $("#txtTelefonoEstudiante").focus()
    }
    else
    {
        $("#msgTelefonoEstudiante").attr("hidden", true)
    }

    if(DNIEstudiante == "")
    {
        $("#msgDNIEstudiante").removeAttr("hidden")
        $("#txtDNIEstudiante").focus()
    }
    else
    {
        $("#msgDNIEstudiante").attr("hidden", true)
    }

    
    
  
    if(instituto != "vacío" && curso != "vacío" && totalMatricula != "" && totalCuotas != "" && pNombreEstudiante != "" && pApellidoEstudiante  != "" &&
        fechaNacimientoEstudiante != "" && domicilio != "" && municipio != "vacío" && telefonoEstudiante != "" && DNIEstudiante)
    {
        
        nuevotd += "<td>" + instituto + "</td>";
        nuevotd += "<td>" + pNombreEstudiante + " " + pApellidoEstudiante + "</td>";
        nuevotd += "<td>" + DNIEstudiante + "</td>";
        nuevotd += "</tr>";


        $("#agregarMatricula").append(nuevotd);
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
        $("#txtTotalMatricula").val("")
        $("#txtTotalCuotas").val("")
        $("#txtPNombreEstudiante").val("")
        $("#txtPApellidoEstudiante").val("")
        $("#txtFechaNacimientoEstudiante").val("")
        $("#txtDomicilio").val("")
        $("#txtTelefonoEstudiante").val("")
        $("#txtDNIEstudiante").val("")
    }
    
    $("#btnGuardar").click(function(){
        agregarMatricula($("#slcInstituto").val(), $("#slcCurso").val(), $("#txtTotalMatricula").val(), $("#txtTotalCuotas").val(), $("#txtPNombreEstudiante").val(),
        $("#txtPApellidoEstudiante").val(), $("#txtFechaNacimientoEstudiante").val(), $("#txtDomicilio").val(), $("#slcMunicipio").val(),
        $("#txtTelefonoEstudiante").val(), $("#txtDNIEstudiante").val())
    })
