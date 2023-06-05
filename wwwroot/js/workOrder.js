var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#customers").DataTable({
        "ajax": {
            url: "/WorkOrder/GetAll",
        },
        "columns": [
            { "data": "customerName", "width": "20%" },
            { "data": "partNumber", "width": "15%" },
            { "data": "partDescription", "width": "15%" },
            {
                "data": "returnDate", "width": "15%",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            {
                "data": "statusOfWorkOrder",
                "width": "15%",
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
                    return `<div class="w-75 btn-group">
                            <a href="/WorkOrder/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i> &nbsp;
                            </a>
                            <a onClick=Delete('/WorkOrder/Delete/${data}') class="btn btn-primary mx-2" style="cursor:pointer">
                                <i class="fas fa-trash-alt"></i> &nbsp;
                            </a>
                            </div>`;
                }, "width": "40%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}