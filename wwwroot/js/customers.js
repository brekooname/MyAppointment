var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#customers").DataTable({
        "ajax": {
            url: "/Customers/GetAll",
        },
        "columns": [
            { "data": "customerName", "width": "20%" },
            { "data": "partNumber", "width": "20%" },
            { "data": "partDescription", "width": "20%" },
            {
                "data": "returnDate", "width": "20%",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            {
                "data": "statusOfWorkOrder",
                "width": "20%",
                "render": function (data, type, row) {
                    if (row.statusOfWorkOrder == 0) {
                        return 'un completed'
                    } else {
                        return 'completed'
                    }
                }
            },
            {
                "data": "id",
                "render": function (data, type, row) {
                    return `<div class="text-center">
                            <a href="/Customers/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i> &nbsp;
                            </a>
                            <a href="/Customers/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash-alt"></i> &nbsp;
                            </a>
                            </div>`;
                }, "width": "40%"
            }
        ]
    });
}
function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangeMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    });
}