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

    //var modal = $('#modal'),
    //    close = modal.find('.close'),
    //    modContent = modal.find('.modal-content');

    //// open modal when click on open modal button 
    //modal.css('display', 'block');
    //modContent.removeClass('modal-animated-out').addClass('modal-animated-in');

    //$(document).on('click', function (e) {
    //    var target = $(e.target);
    //    if (target.is(modal) || target.is(close)) {
    //        modContent.removeClass('modal-animated-in').addClass('modal-animated-out').delay(300).queue(function (next) {
    //            modal.css('display', 'none');
    //            next();
    //        });
    //    }
    //});
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