$dataTableObject = null;
$SaveUpdate = "SAVE";

$(document).ready(function () {
    $dataTableObject = $('#tblProductos').DataTable({
        "language":
        {
            "lengthMenu": "Mostrar _MENU_ entradas",
            "info": "Registros del _START_ al _END_ de un total de _TOTAL_",
            "infoEmpty": "Mostrando 0 de 0 de un total de 0 entradas",
            "emptyTable": "No hay datos en la tabla",
            "infoFiltered": "(Filtradas de un total de _MAX_ registros)",
            "search": "Buscar:",
            "paginate": {
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });

    $('#tblProductos tbody').on("click", ".update", function () {
        $SaveUpdate = "UPDATE";
        $("#dvId").prop("hidden", false);

        var json = $dataTableObject.row($(this).parents('tr')).data();
        LoadModal(json);
    });

    $('#tblProductos tbody').on('click', '.delete', function () {
        var json = $dataTableObject.row($(this).parents('tr')).data();
        if (confirm("¿Seguro que deseas eliminar? \n" + "Sku: " + json.sku + "\nModelo: " + json.modelo)) {           
            Delete(json);
        }
    });

    $('#btnNew').click(function () {
        $SaveUpdate = "SAVE";
        $("#dvId").prop("hidden", true);
        LoadModal(null);
    });

    $('#btnSave').click(function () {
        var producto = GetModel();
        if ($SaveUpdate === "SAVE") {
            Insert(producto);
            //console.log(JSON.stringify(producto));
        }
        else {
            Update(producto);
        }
    });

    Select();
});

function Select() {
    $.ajax({
        type: "GET"
        , url: "https://localhost:44372/api/Post"
        , contentType: "application/json; charset=utf-8"
        , dataType: "json"
        , success: function (json) {
            if (json != null) {
                if (json.length > 0) {
                    BuildTable(json);
                }
            }
        }
        , failure: function (e) {
            alert(e);
        }
    });
}

function BuildTable(json) {
    if ($dataTableObject != null) {
        $dataTableObject.destroy();
    }

    $dataTableObject = $('#tblProductos').DataTable({
        data: json,
        columns: [
            { defaultContent: "<button class='update btn btn-primary' data-toggle='tooltip' title='Editar'>Editar</button>", "searchable": false  },
            { data: "id"           },
            { data: "sku"          },
            { data: "fert"         },
            { data: "modelo"       },
            { data: "tipo"         },
            { data: "numeroSerie"  },
            { data: "fechar" },
            { defaultContent: "<button class='delete btn btn-danger' data-toggle='tooltip' title='Borrar'>Borrar</button>", "searchable": false },
        ],
        "language":
        {
            "lengthMenu": "Mostrar _MENU_ entradas",
            "info": "Registros del _START_ al _END_ de un total de _TOTAL_",
            "infoEmpty": "Mostrando 0 de 0 de un total de 0 entradas",
            "emptyTable": "No hay datos en la tabla",
            "infoFiltered": "(Filtradas de un total de _MAX_ registros)",
            "search": "Buscar:",
            "paginate": {
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });
}

function ClearModal() {
    $("#txtId").val(0);
    $("#txtSku").val('');
    $("#txtFert").val('');
    $("#txtModelo").val('');
    $("#txtNoSerie").val('');
    $("#txtTipo").val('');
    $("#txtFecha").val('');
}

function LoadModal(json) {
    ClearModal();

    if (json != null)
    {
        $("#txtId").val(json.id);
        $("#txtSku").val(json.sku);
        $("#txtFert").val(json.fert);
        $("#txtModelo").val(json.modelo);
        $("#txtNoSerie").val(json.tipo);
        $("#txtTipo").val(json.numeroSerie);
        $("#txtFecha").val(json.fechar);
    }
   
    $("#btnLoadModal").trigger("click");
}

function Insert(producto) {
    try {
        $.ajax({
            url: "https://localhost:44372/api/Post/SPInsert"
            , type: "POST"
            , contentType: "application/json; charset=utf-8"
            , dataType: "json"
            , data: JSON.stringify(producto)
            , success: function (json) {
                if (json != null) {
                    if (json == true) {
                        ClearModal();
                        Select();
                        $("#btnClose").trigger("click");

                        alert("Se inserto correctamente");
                       
                    } else {
                        alert("¡No se inserto correctamente!");
                    }
                } else {
                    alert("Ocurrio algo inesperado un Error");
                }
            }
        });

    } catch (ex) {
        Console.log(ex.Message);
    }
}

function Update(producto) {
    try {
        $.ajax({
            url: "https://localhost:44372/api/Post/Update"
            , type: "POST"
            , contentType: "Application/json; charset-utf-8"
            , dataType: "json"
            , data: JSON.stringify(producto)
            , success: function (json) {
                if (json != null) {
                    if (json == true) {
                        Select();
                        $("#btnClose").trigger("click");
                        alert("Se actualizo Correctamente");                       
                    } else {
                        alert("No se actualizo corectamente");
                    }
                } else {
                    alert("Ocurrio algun Error");
                }
            }
        });
    } catch (ex) {
        alert(ex.Message);
    }
}

function Delete(producto) {
    try {
        $.ajax({
            url: "https://localhost:44372/api/Post/Delete"
            , type: "POST"
            , contentType: "application/json; charset-utf-8"
            , dataType: "json"
            , data: JSON.stringify(producto) 
            , success: function (response) {
                if (response == true) {
                    Select();
                    alert("Se borro el registro!!!");
                }
                else {
                    alert("No se borro el registro");
                }
            }
        });

    } catch (ex) {
        alert(ex.Message);
    }
}

function GetModel() {
    var model = {};
    model.id = parseInt($("#txtId").val());
    model.sku            = $("#txtSku").val();
    model.fert           = $("#txtFert").val();
    model.modelo         = $("#txtModelo").val();
    model.tipo          = $("#txtNoSerie").val();
    model.numeroSerie   = $("#txtTipo").val();
    model.fechar        = $("#txtFecha").val();

    return model;
}
