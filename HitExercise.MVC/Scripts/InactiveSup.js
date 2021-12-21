$('#Supplier_Inactive').change(function () {
    if (this.checked) {
        $('#getName').attr('readonly', 'true');
        $('#getAfm').attr('readonly', 'true');
    }
    else {
        $('#getName').removeAttr('readonly');
        $('#getAfm').removeAttr('readonly');
    }
});

$('#Supplier_Inactive').trigger("change");