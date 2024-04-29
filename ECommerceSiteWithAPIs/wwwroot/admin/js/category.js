function btnUpsert(type) {

    event.preventDefault();
    //** Clear errors **//
    $('#catNameVal').text('');
    $('#orderVal').text('');
    $('#ddcatVal').text('');
    $('#imageVal').text('');
    debugger;
    let catName = $('#catName').val();
    let orderBy = $('#orderby').val();
    let catVal = $('#ddCategory').val();
    let file = $('#file').val();
    let isValid = true;
    if (type == 'savesubcat') {
        if (catName == '' || orderBy == '' || catVal == 0 || file == '') {
            isValid = false;
            if (catName == '') {
                $('#catNameVal').text('Category name is required');
            }
            if (catVal == 0) {
                $('#ddcatVal').text('Category is required');
            }
            if (orderBy == '') {
                $('#orderVal').text('Orderby is required');
            }
            if (file == '') {
                $('#imageVal').text('Image is required');
            }
        }
    }
    else if (type == 'updatesubcat') {
        if (catName == '' || catVal == 0 || orderBy == '') {
            isValid = false;
            if (catName == '') {
                $('#catNameVal').text('Category name is required');
            }
            if (catVal == 0) {
                $('#ddcatVal').text('Category is required');
            }
            if (orderBy == '') {
                $('#orderVal').text('Orderby is required');
            }
        }
    }

    if (type == 'savecat') {
        if (catName == '' || orderBy == '' || file == '') {
            isValid = false;
            if (catName == '') {
                $('#catNameVal').text('Category name is required');
            }
            if (orderBy == '') {
                $('#orderVal').text('Orderby is required');
            }
            if (file == '') {
                $('#imageVal').text('Image is required');
            }
        }
    }
    else if (type == 'updatecat') {
        if (catName == '' || orderBy == '') {
            isValid = false;
            if (catName == '') {
                $('#catNameVal').text('Category name is required');
            }
            if (orderBy == '') {
                $('#orderVal').text('Orderby is required');
            }
        }
    }
    if (isValid) {
        $('#catForm').submit();
    }
}