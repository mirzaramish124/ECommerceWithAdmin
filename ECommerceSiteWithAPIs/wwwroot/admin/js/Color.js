function btnUpsert(type) {
    event.preventDefault();
    //** Clear errors **//
    $('#colorNameVal').text('');

    let colorName = $('#colorName').val();
    let isValid = true;
    if (type == 'save') {
        if (colorName == '') {
            isValid = false;
            if (colorName == '') {
                $('#colorNameVal').text('Color name is required');
            }
        }
    }
    else {
        if (colorName == '') {
            isValid = false;
            if (colorName == '') {
                $('#colorNameVal').text('Color name is required');
            }
        }
    }
    if (isValid) {
        $('#measurmentForm').submit();
    }
}