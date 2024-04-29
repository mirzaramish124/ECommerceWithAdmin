function btnUpsert(type) {
    debugger;
    event.preventDefault();
    //** Clear errors **//
    $('#brandNameVal').text('');
    $('#orderVal').text('');
    $('#imageVal').text('');

    let brandName = $('#brandName').val();
    let orderBuy = $('#orderby').val();
    let file = $('#file').val();
    let isValid = true;
    if (type == 'save') {
        if (brandName == '' || orderBuy == '' || file == '') {
            isValid = false;
            if (brandName == '') {
                $('#brandNameVal').text('Brand name is required');
            }
            if (orderBuy == '') {
                $('#orderVal').text('Orderby is required');
            }
            if (file == '') {
                $('#imageVal').text('Image is required');
            }
        }
    }
    else {
        if (brandName == '' || orderBuy == '') {
            isValid = false;
            if (brandName == '') {
                $('#brandNameVal').text('Brand name is required');
            }
            if (orderBuy == '') {
                $('#orderVal').text('Orderby is required');
            }
        }
    }
    if (isValid) {
        $('#brandForm').submit();
    }
}