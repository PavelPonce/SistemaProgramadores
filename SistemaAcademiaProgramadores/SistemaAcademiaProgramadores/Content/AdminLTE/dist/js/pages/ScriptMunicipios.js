

$("#btnShowForm").click(function(){
    $("#formCard").removeAttr("hidden")
    $("#tableCard").attr("hidden", true)
  })
  
  $("#btnHiddenForm").click(function(){
    $("#formCard").attr("hidden", true)
    $("#tableCard").removeAttr("hidden")
  })
  
  
  
  
  $(document).ready(function(){
    $("#agregarMunicipios").DataTable();
  })
  
  
    function agregarMunicipio (municipio, departamento)
    {
    var nuevotd = "<tr>";

    if(municipio == "")
    {
        $("#msgMunicipio").removeAttr("hidden")
        $("#txtMunicipio").focus()
    }
    else
    {
        $("#msgMunicipio").attr("hidden", true)
    }   
  
    if(departamento == "vacío")
    {
        $("#msgDepartamento").removeAttr("hidden")
        $("#slcDepartamento").focus()
    }
    else
    {
        $("#msgDepartamento").attr("hidden", true)
    }    
  
    if(municipio != "" && departamento != "vacío" )
    {
  
        nuevotd += "<td>" + municipio + "</td>";
        nuevotd += "<td>" + departamento + "</td>";
        nuevotd += "</tr>";


        $("#agregarMunicipios").append(nuevotd);
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
        $("#txtMunicipio").val("")
        $("#txtMunicipio").focus()
    }
    
    $("#btnGuardar").click(function(){
        agregarMunicipio($("#txtMunicipio").val(), $("#slcDepartamento").val())
    })
