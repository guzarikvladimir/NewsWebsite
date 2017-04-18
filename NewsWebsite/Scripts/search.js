$(function () {
    var page = 0;

    function searchItems() {
        var category = $('#category').text();
        var name = $('#searchString').val();

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
                    $("#scrolList").empty();
                    $("#scrolList").append(data);
                }
                else {
                    $("#scrolList").text('No items');
                }
            }
        });
    }

    $('#search').click(function () {
        page = 0;
        searchItems();
    });
})