$(document).ready(function () {
    getProductList();
});
$(document).on("click", "#btnEditProduct", function () {
    var ProductId = $(this).parents('td').find('.hdnProdId').val();
    localStorage.setItem('hdnProdId', ProductId);
    window.location.href = '/Home/ProductCreate';
});
$(document).on("click", "#btnDeleteProduct", function () {
    var ProductId = $(this).parents('td').find('.hdnProdId').val();
    $.ajax({
        type: "GET",
        url: "/api/Product/DeleteProduct",
        data: { "ProductID": ProductId },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            getProductList();
        },
        failure: function (response) {
            console.log(response.Message);
        },
        error: function (response) {
            console.log(response.Message);
        }
    });
});
function getProductList() {
    var url = '/api/Product/ProductList';
    $('#tblProductList').DataTable().destroy();
    $('#tblProductList tbody').empty();

    var table = $('#tblProductList').dataTable({
        "ajax": url,
        columns: [
            {
                data: "ProductId",
                render: function (data, type, row, meta) {
                    var index = meta.row + meta.settings._iDisplayStart + 1;
                    var str = '<button class="btn btn-primary btn-sm" name="editproduct" type="button" title="Edit" id="btnEditProduct">Edit</button>';
                    str += '&nbsp;&nbsp;&nbsp;&nbsp;<button class="btn btn-danger btn-sm" name="deleteproduct" type="button" title="Delete" id="btnDeleteProduct">Delete</button>';
                    str += "<input type='hidden' class='hdnProdId' value='" + row.ProductId + "' />";
                    return str;
                }
            },
            { data: 'CategoryName' },
            { data: 'AttributeName' },
            { data: 'ProdName' },
            { data: 'ProdDescription' }
        ],
        searching: true,
        paging: true,
        ordering: true
    });
}



