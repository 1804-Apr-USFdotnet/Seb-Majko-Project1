$(document).ready(function () {
    $('#list').click(function (event) { event.preventDefault(); $('#products .item').addClass('list-group-item'); });
    $('#grid').click(function (event) {
        event.preventDefault();
        $('#products .item').removeClass('list-group-item');
        $('#products .item').addClass('grid-group-item');
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