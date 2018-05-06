$(document).ready(function () {
    $('#list').click(function (event) {
        event.preventDefault();
        $('#products .item').addClass('list-group-item');
        $('#products .but').removeClass('col-md-3');
        $('#products .but').addClass('col-md-6');
        $("#products .but").css("margin-bottom", 10);
    });
    $('#grid').click(function (event) {
        event.preventDefault();
        $('#products .item').removeClass('list-group-item');
        $('#products .item').addClass('grid-group-item');
        $("#products .but").css("margin-bottom", 0);
        $('#products .but').removeClass('col-md-6');
        $('#products .but').addClass('col-md-3');
    });
});

$(function () {
    $(':radio[name="name"]').change(function () {
        $.ajax({
            url: 'RestaurantSort',
            type: 'POST',
            data: { name: $(':radio[name="name"]:checked').val() },
            success: function (xhr_data) {
                alert(xhr_data.someValue);
            }
        });
    });
});