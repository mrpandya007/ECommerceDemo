$(document).ready(function () {
    getCategory();
    setValidations();
    var hdnProdId = localStorage.getItem('hdnProdId')
    $("#spanText").text('Add');
    if (hdnProdId != "0") {
        getProductDetailById(hdnProdId);
        $("#spanText").text('Edit');
    }
});
$(document).on("change", "#ddlCategory", function () {
    getAttribute($(this).val());
});
$(document).on("click", "#btnClear", function () {
    clearForm("frmProductCreate");
});
$(document).on("click", "#btnSave", function () {
    var isValid = $('#frmProductCreate').valid();

    if (isValid) {
        saveProduct();
    }
});
function getAttribute(prodCatId) {
    $.ajax({
        type: "GET",
        url: "/api/Product/AttributeByCategoryId",
        data: { "ProdCatID": prodCatId },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            loadDropDownList("ddlAttribute", response.Data, "AttributeName", "AttributeId", true);
        },
        failure: function (response) {
            console.log(response.Message);
        },
        error: function (response) {
            console.log(response.Message);
        }
    });
}
function getProductDetailById(prodId) {
    $.ajax({
        type: "GET",
        url: "/api/Product/ProductDetailById",
        data: { "ProductID": prodId },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonRes = response.Data;
            getAttribute(jsonRes.ProdCatId);
            $("#ddlCategory").val(jsonRes.ProdCatId);
            $("#txtProductDescription").val(jsonRes.ProdDescription);
            $("#txtProductName").val(jsonRes.ProdName);
            setTimeout(function () { $("#ddlAttribute").val(jsonRes.AttributeId); }, 100);

        },
        failure: function (response) {
            console.log(response.Message);
        },
        error: function (response) {
            console.log(response.Message);
        }
    });
}
function getCategory() {
    $.ajax({
        type: "GET",
        url: "/api/Product/ProductCategoryList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            loadDropDownList("ddlCategory", response.Data, "CategoryName", "ProdCatId", true);
        },
        failure: function (response) {
            console.log(response.Message);
        },
        error: function (response) {
            console.log(response.Message);
        }
    });
}
function setValidations() {
    $("#frmProductCreate").validate({
        rules: {
            prodname: {
                required: true,
            },
            proddesc: {
                required: true,
            },
            category: {
                valueNotEquals: "-1"
            },
            attribute: {
                valueNotEquals: "-1"
            }
        },
        messages: {
            prodname: "Product Name is required",
            proddesc: "Product Desc is required",
            category: "Please select a Category",
            attribute: "Please select a Attribute"
        }
    });
}
function saveProduct() {
    var model = {
        ProductId: localStorage.getItem('hdnProdId'),
        ProdCatId: $("#ddlCategory").val(),
        AttributeId: $("#ddlAttribute").val(),
        ProdName: $("#txtProductName").val(),
        ProdDescription: $("#txtProductDescription").val(),
    };
    $.ajax({
        type: "POST",
        url: "/api/Product/InsertUpdateProduct",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        dataType: "json",
        success: function (response) {
            alert(response.Message)
            clearForm("frmProductCreate");
            $("#ddlCategory").val("-1");
            $("#ddlAttribute").val("-1");
        },
        failure: function (response) {
            alert(response.Message)
        },
        error: function (response) {
            alert(response.Message)
        }
    });
}
function clearForm(formId) {
    var validator = $("#" + formId).validate();
    validator.resetForm();
    $("#ddlCategory").val("-1");
    $("#ddlAttribute").val("-1");
    $("#txtProductDescription").val("");
    $("#txtProductName").val("");
    localStorage.setItem('hdnProdId', '0');
    $("#spanText").text('Add');
}
function loadDropDownList(dropDownListId, data, textKeyName, valueKeyName, isAddDefaultItem) {
    var str = "";
    if (isAddDefaultItem != undefined && isAddDefaultItem == true) {
        str += '<option value="-1"> -- Please Select -- </option>';
    }
    if (data != undefined && data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            str += '<option value="' + data[i][valueKeyName] + '">' + data[i][textKeyName] + '</option>';
        }
    }
    $('#' + dropDownListId).html(str);
}
window.setTimeout(function () {
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "This field is required");
}, 1000);