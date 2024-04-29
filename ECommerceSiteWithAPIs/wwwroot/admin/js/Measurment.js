function btnUpsert(type) {
    event.preventDefault();
    //** Clear errors **//
    $('#measurNameVal').text('');

    let measurName = $('#measurName').val();
    let isValid = true;
    if (type == 'save') {
        if (measurName == '') {
            isValid = false;
            if (measurName == '') {
                $('#measurNameVal').text('Name is required');
            }
        }
    }
    else {
        if (measurName == '') {
            isValid = false;
            if (measurName == '') {
                $('#measurNameVal').text('Name is required');
            }
        }
    }
    if (isValid) {
        $('#measurmentForm').submit();
    }
}