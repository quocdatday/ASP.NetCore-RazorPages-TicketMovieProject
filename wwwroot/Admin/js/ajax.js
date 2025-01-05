$(document).ready(function () {
    //$("#tbody").on("click", `button[data-group="edit"]`, function () {
    //    Edit();
    //    var id = $(this).attr("data-id");
    //    alert(id);
    //    var name = $(`td[data-name="${id}"]`).text();
    //    alert(name);
    //    $("#Name").val(name);
    //});
    $(`button[data-group="edit"]`).on('click', function () {
        Edit();
        if ($(this).attr("data-type") == "ban") {
            var id = $(this).attr("data-id");
            var name = $(`td[data-name="${id}"]`).text();
            $("#ID").val(id);
            $("#Name").val(name);
            return;
        }
        if ($(this).attr("data-type") == "cate") {
            var id = $(this).attr("data-id");
            var type = $(`td[data-type="${id}"]`).text();
            var age = $(`td[data-age="${id}"]`).text();
            $("#ID").val(id);
            $("#Type").val(type);
            $("#Age").val(age);
            return;
        }
    });
});
