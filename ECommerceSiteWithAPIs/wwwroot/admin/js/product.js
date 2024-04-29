function btnUpsert(type) {

    event.preventDefault();
    //** Clear errors **//
    $('#brandVal').text('');
    $('#catVal').text('');
    $('#subCatVal').text('');
    $('#MTypeVal').text('');
    $('#proNameVal').text('');
    $('#descVal').text('');
    $('#orderVal').text('');
    $('#imageVal').text('');
    let brandid = $('#ddBrand').val();
    debugger;
    let catid = $('#ddCategory').val();
    let subcatid = $('#ddSubCategory').val();
    let mType = $('#ddMType').val();
    let proName = $('#proName').val();
    //let desc = $('#desc').val();
    let orderBy = $('#orderby').val();
    let file = $('#file').val();
    let isValid = true;
    if (type == 'save') {
        if (brandid == null || catid == null || subcatid == null || mType == null || proName == '' || /*desc == '' ||*/ orderBy == '' || file == '') {
            isValid = false;
            if (brandid == null) {
                $('#brandVal').text('Brand is required');
            }
            if (catid == null) {
                $('#catVal').text('Category is required');
            }
            if (subcatid == null) {
                $('#subCatVal').text('subCategory is required');
            }
            if (mType == null) {
                $('#MTypeVal').text('Measurment Type is required');
            }
            if (proName == '') {
                $('#proNameVal').text('Product Name is required');
            }
            //if (desc == '') {
            //    $('#descVal').text('Description is required');
            //}
            if (orderBy == '') {
                $('#orderVal').text('Orderby is required');
            }
            if (file == '') {
                $('#imageVal').text('Image is required');
            }
        }
    }
    else if (type == 'update') {
        if (brandid == null || catid == null || subcatid == null || mType == null || proName == '' || /*desc == '' ||*/ orderBy == '') {
            isValid = false;
            if(brandid == null) {
                $('#brandVal').text('Brand is required');
            }
            if (catid == null) {
                $('#catVal').text('Category is required');
            }
            if (subcatid == null) {
                $('#subCatVal').text('subCategory is required');
            }
            if (mType == null) {
                $('#MTypeVal').text('Measurment Type is required');
            }
            if (proName == '') {
                $('#proNameVal').text('Product Name is required');
            }
            //if (desc == '') {
            //    $('#descVal').text('Description is required');
            //}
            if (orderBy == '') {
                $('#orderVal').text('Orderby is required');
            }
        }
    }
    if (isValid) {
        $('#proForm').submit();
    }
}

$(document).ready(function () {
    $('.ddsearch').select2();
});

function getSubCatsById() {
    let catId = $("#ddCategory").val();
    $.ajax({
        url: '/Admin/Product/GetSubCatsByCatId',
        method: 'POST',
        data: { id: catId },
        success: function (response) {
            $('#ddSubCategory').empty();
            $('#ddSubCategory').append('<option value="0" selected>Select SubCategory </option>');
            if (response) {
                response.subCats.forEach(item => {
                    $('#ddSubCategory').append('<option value="' + item.id + '">' + item.name + '</option>');
                });
            }
        }
    });
}