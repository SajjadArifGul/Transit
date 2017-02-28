
var vehicleTypesTable;
var newRecord;
var SelectedRow;

var vehicleTypeId;
var vehicleTypeName;
var vehicleTypeIsActive;

$(document).ready(function () {
    //setting up DataTable and Column Rendering and Getting All the required Data
    vehicleTypesTable = $("#VehicleTypesTable").DataTable({
        paging: true,
        sort: true,
        searching: true,
        ajax: {
            url: ('/' + vehicleTypesURL + 'GetAllVehicleTypesAJAX'),
            method: 'get',
            dataType: 'json',
            dataSrc: "VehicleTypesList"
        },
        columns: [
            {
                'data': 'ID'
            },
            {
                'data': 'Name',
                'render': function (Name) {
                    return "<strong>" + Name + "</strong>";
                }
            },
            {
                'data': 'IsActive',
                'render': function (status) {
                    return GetFormattedStatus(status);
                }
            },
            {
                'data': 'CreatedBy',
                'render': function (CreatedBy, type, row) {
                    return CreatedBy + "<br />" + GetFormattedDate(row["CreatedOn"]);
                }
            },
            {
                'data': 'CreatedOn',
                "visible": false,
                "searchable": false
            },
            {
                'data': 'ModifiedBy',
                'render': function (ModifiedBy, type, row) {
                    return ModifiedBy + "<br />" + GetFormattedDate(row["ModifiedOn"]);
                }
            },
            {
                'data': 'ModifiedOn',
                "visible": false,
                "searchable": false
            },
            {
                'data': 'ID',
                'render': function (ID, type, row, meta) {
                    return "<button onClick=\"ShowVehicleTypeModal('" + ID + "','" + row["Name"] + "','" + row["IsActive"] + "', '" + meta.row + "')\" class=\"btn btn-warning btn-lable-wrap left-label\"> <span class=\"btn-label\"><i class=\"fa fa-pencil\"></i> </span><span class=\"btn-text\">Edit</span></button> <button onClick=\"DeleteRecord('" + ID + "','" + row["Name"] + "', '" + meta.row + "')\" class=\"btn btn-danger btn-lable-wrap left-label\"> <span class=\"btn-label\"><i class=\"fa fa-trash\"></i> </span><span class=\"btn-text\">Delete</span></button>"
                },
                "searchable": false,
                "sortable": false
            },
        ],

    });

    $.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        swal("Error!", "An error occured while trying to get Vehicle Types data. Please check URL or report to Admin.", "error");
    };
});

$("#newVehicleTypeButton").click(function () {
    ShowVehicleTypeModal();
});

function ShowVehicleTypeModal(ID, Name, Status, RowIndex) {
    var vehicleTypeModal = $('#vehicleTypeModal');

    if (ID) {
        newRecord = false; //this means it is not a new record
        SelectedRow = RowIndex;

        $('#vehicleTypeModalID').val(ID);

        if (Name != undefined && Name.length > 0) {
            $('#vehicleTypeModalName').val(Name);
        }

        if (Status == true || Status == "true") {
            $("#vehicleTypeModalIsActive").prop('checked', true);
        }
        else {
            $("#vehicleTypeModalIsActive").prop('checked', false);
        }

        $('#vehicleTypeModal').find('.modal-title').text('Update Vehicle Type');
        $('#vehicleTypeModal').find('#vehicleTypeModalSubmitIcon').removeClass('fa-plus').addClass('fa-pencil');
        $('#vehicleTypeModal').find('#vehicleTypeModalSubmitText').text('Update');
    }
    else {
        newRecord = true; //this means it is a new record

        $('#vehicleTypeModal').find('.modal-title').text('Add New Vehicle Type');
        $('#vehicleTypeModal').find('#vehicleTypeModalSubmitIcon').removeClass('fa-pencil').addClass('fa-plus');
        $('#vehicleTypeModal').find('#vehicleTypeModalSubmitText').text('Save');
    }

    $('#vehicleTypeModal').modal('toggle');
}

$("#vehicleTypeModalForm").on('submit', (function (event) {

    if ($("#vehicleTypeModalForm").valid()) {
        vehicleTypeId = $('#vehicleTypeModalID').val();
        vehicleTypeName = $('#vehicleTypeModalName').val();
        vehicleTypeIsActive = $("#vehicleTypeModalIsActive").is(':checked');

        if (newRecord) {
            SaveNewRecord(vehicleTypeName, vehicleTypeIsActive, event);
        }
        else {
            UpdateRecord(vehicleTypeId, vehicleTypeName, vehicleTypeIsActive, event);
        }
    }
    else {
        DisplayError("Please fill the required form fields.");
    }
}));

function RefreshFields() {
    $("#vehicleTypeModalID").val("");
    $("#vehicleTypeModalName").val("");
    $("#vehicleTypeModalIsActive").prop('checked', false);

    newRecord = false;
    SelectedRow = null;

    $("#vehicleTypeModalFormErrorsMessages").html("");
}

function DisplayError(error) {
    $("#vehicleTypeModalFormErrors").show();
    $("#vehicleTypeModalFormErrorsMessages").html(error);

    $("#vehicleTypeModalFormErrors").delay(5000).fadeOut('slow', function () {
        $("#vehicleTypeModalFormErrorsMessages").html("");
    });
}

function SaveNewRecord(name, status, event) {
    event.preventDefault();
    var jqxhr = $.ajax(
                {
                    type: "post",
                    data: {
                        Name: name,
                        IsActive: status //$("#vehicleTypeModalIsActive").is(':checked')
                    },
                    url: ('/' + vehicleTypesURL + 'AddNewVehicleTypeAJAX'),
                })
                    .done(function (data) {
                        if (data.Successful) {
                            vehicleTypesTable.row.add(data.VehicleType).draw(false);

                            $('#vehicleTypeModal').modal('toggle');
                            RefreshFields();
                        }
                        else {
                            DisplayError(data.Exception);
                        }
                    })
                    .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                        DisplayError(errorThrown);
                    })
                    .always(function () {
                    });
}

function UpdateRecord(id, name, status, event) {

    event.preventDefault();
    var jqxhr = $.ajax(
                {
                    type: "post",
                    data: {
                        ID: id,
                        Name: name,
                        IsActive: status
                    },
                    url: ('/' + vehicleTypesURL + 'UpdateVehicleTypeAJAX'),

                })
                    .done(function (data) {
                        if (data.Successful) {
                            vehicleTypesTable.row(SelectedRow).data(data.VehicleType).invalidate().draw();

                            $('#vehicleTypeModal').modal('toggle');
                            RefreshFields();
                        }
                        else {
                            DisplayError(data.Exception);
                        }
                    })
                    .fail(function (XMLHttpRequest, textStatus, errorThrown) {

                        DisplayError(errorThrown);
                    })
                    .always(function () {
                    });
}

function DeleteRecord(ID, Name, RowIndex) {
    swal({
        title: "Warning!",
        text: "Are you sure you want to delete '" + Name + "' Vehicle Type record?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#fcb03b",
        confirmButtonText: "Delete",
        cancelButtonText: "Cancel",
        closeOnConfirm: false,
        closeOnCancel: true
    }, function (isConfirm) {
        if (isConfirm) {
            ConfirmedDelete(ID, Name, RowIndex);
        }
    });
}

function ConfirmedDelete(id, Name, RowIndex) {
    var jqxhr = $.ajax(
                {
                    type: "post",
                    data: {
                        ID: id
                    },
                    url: ('/' + vehicleTypesURL + 'DeleteVehicleTypeAJAX'),

                })
                    .done(function (data) {
                        if (data.Successful) {
                            vehicleTypesTable.row(RowIndex).remove();
                            vehicleTypesTable.rows().invalidate().draw();

                            swal("Deleted!", Name + " Vehicle Type Delete.", "success");
                        }
                        else {
                            swal("Error!", "Unable to Delete " + Name + " Vehicle Type. Error:" + data.Exception, "error");
                        }
                    })
                    .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                        swal("Error!", errorThrown, "error");
                    })
                    .always(function () {
                    });
}
