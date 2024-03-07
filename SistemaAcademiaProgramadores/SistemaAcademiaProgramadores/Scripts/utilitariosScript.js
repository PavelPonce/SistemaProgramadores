
function cargarDDLCursos(id) {
    $.ajax({
        url: "/Home/cargarDDLCursos",
        method: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ id }),
        success: function (data) {
            $.each(data, function (key, value) {
                var option = $('<option></option>')
                    .text(value.Curso_Nombre)
                    .val(value.Curso_Id);

                $('#ddlCursos').append(option);
            })
        },
    })
}

