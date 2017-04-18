$(function () {
    $('div#loading').hide();
    var page = 0;
    var _inCallback = false;

    function loadItems() {
        if (page > -1 && !_inCallback) {
            var category = $('#category').text();
            var name = $('#searchString').val();
            _inCallback = true;
            page++;
            $('div#loading').show();

            $.ajax({
                type: 'GET',
                url: '/Home/List/',
                data: {
                    category: category,
                    page: page,
                    name: name
                },
                success: function (data, textstatus) {
                    if (data != '') {
                        $("#scrolList").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                    $("div#loading").hide();
                }
            });
        }
    }

    // обработка события скроллинга
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {

            loadItems();
        }
    });

    $(window).scroll(function() {
        if ($(this).scrollTop() > 200) {
            $('#moveTop').css('visibility', 'visible');
        } else {
            $('#moveTop').css('visibility', 'hidden');
        }
    });

    $('#moveToLogin').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 500);
        return false;
    });

    $('#moveTop').click(function() {
        $('html, body').animate({ scrollTop: 0 }, 500);
        return false;
    });

    function readURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#image').attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#imgInput").change(function () {
        readURL(this);
    });
})