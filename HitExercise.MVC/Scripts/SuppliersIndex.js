    var dataTable = $("#suppliers").DataTable({
        ajax: {
            url: "/api/suppliers",
            dataSrc: ""
        },
        columns: [
            {
                title: "Supplier's Name",
                data: "name",

            },
            {
                title: "Category",
                data: "category.title"


            },
            {
                title: "AFM",
                data: "afm"

            },
            {
                title: "Address",
                data: "address"

            },
            {
                title: "Telephone",
                data: "telephone"

            },
            {
                title: "Εmail",
                data: "email"

            },
            {
                title: "Country Code",
                data: "country.code"

            },
            {
                data: "id",
                render: function (data, type, supplier) {
                    return "<a href='/suppliers/edit/" + supplier.id + "' class='btn btn-default btn-sm'><i class='fa fa-pencil'></i> Edit</a>" +
                        "<a class='btn btn-danger btn-sm js-delete-sup' data-sup-Id='" + supplier.id + "'><i class='fa fa-trash'></i> Delete</a>"
                },
                orderable: false,
                width: '150px'
            }
        ],
        language: {
            emptyTable: "No data found, Please click on <b>Add New</b> Button"
        }
    });

$("#suppliers").on("click",".js-delete-sup", function (e) {
    var link = $(e.target);
    bootbox.dialog({
        title: "Confirm",
        message: 'Are you sure you want to delete this supplier?',
        size: 'large',
        buttons: {
            no: {
                label: "No",
                className: 'btn-default',
                callback: function () {
                    bootbox.hideAll();
                }
            },
            yes: {
                label: "Yes",
                className: 'btn-danger',
                callback: function () {
                    $.ajax({
                        url: '/api/suppliers/' + link.attr("data-sup-id"),
                        method: 'Delete'
                    }).done(function () {
                        dataTable.ajax.reload();
                    }).fail(function (error) {
                        alert("Something went wrong");
                    });
                }
            }
        }
    })
})


