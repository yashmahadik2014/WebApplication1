$(document).on('change','#ProductGroupId',function () {
    $.ajax({
        type: "POST",
        url: "/Agreement/GetProduct",
        data: JSON.stringify({ ProductGroupId: $(this).val() }),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(data)
            $('#ProductId').empty();
            $.each(data.Constituency, function (i, value) {
                console.log(value)
                $('#ProductId').append('<option value="' + value.Value + '">' + value.Text + '</option>');
            })
        },
        error: function () {
            alert("Error occured!!")
        }
    });
    return false;
})

$(document).ready(function () {
    $('input[type=datetime]').datepicker({
        dateFormat: "dd/M/yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-60:+0"
    });

});

$(document).on('click', '.delete-agreement', function () {
    var id = $.trim($(this).attr('resource'));
    if (confirm("Do You Want to Delete Agreement? ")) {
        window.location.href = "/Agreement/Delete?Id=" + id;
    }
    return false;
})