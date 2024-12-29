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
        var id = $(this).attr("data-id");
        var name = $(`td[data-name="${id}"]`).text();
        $("#ID").val(id);
        $("#Name").val(name);
    });
});
