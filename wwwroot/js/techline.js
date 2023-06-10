var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#techlines").DataTable({
        "ajax": {
            "url": "/techlines/getall"
        },
        "columns": [
            { "data": "brandName", "width": "50%" },
            { "data": "accountNumber", "width": "30%" },
            { "data": "phoneNumber", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/techlines/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i> &nbsp;
                            </a>
                            <a onclick=Delete('/techlines/Delete/${data}') class="btn btn-danger text-white" style="cursor:pointer">
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








/*$(document).ready(function () {
    $.get("/api/techlines", techlineslist);
});
function techlineslist(data) {
    var techlines = document.getElementById("techlines");
    for (var i = 0; i < data.length; i++) {
        var techline = data[i];
        techlines.innerHTML += `
                                     <tr>
                                          <td>${techline.brandName}</td>
                                          <td>${techline.accountNumber}</td>
                                          <td>${techline.phoneNumber}</td>
                                      </tr>
                               `
    }
}*/