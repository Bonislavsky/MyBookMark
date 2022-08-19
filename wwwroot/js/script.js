function RefreshFolder() {
    var data = $('#folderFormId').serialize();
    debugger;
    $.ajax({
        type: 'POST',
        url: '@Url.Action("AddBookMark", "Profile")',
        data: JSON.parse(JSON.stringify(data)),
        success: function (response) {
            $("#demo").html(response);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}