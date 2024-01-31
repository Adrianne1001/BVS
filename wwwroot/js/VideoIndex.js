$(document).ready(function () {
    $("#exportBtn").click(function () {
        exportToCSV();
    });

    function exportToCSV() {
        var csvContent = "data:text/csv;charset=utf-8,";

        var headers = [];
        $("#admin-accounts th:not(:last-child)").each(function () {
            headers.push($(this).text().trim());
        });
        csvContent += headers.join(",") + "\n";

        $("#admin-accounts tbody tr").each(function () {
            var row = [];
            $(this).find('td:not(:last-child)').each(function () {
                row.push($(this).text().trim());
            });
            csvContent += row.join(",") + "\n";
        });

        var encodedUri = encodeURI(csvContent);
        var link = document.createElement("a");
        link.setAttribute("href", encodedUri);
        link.setAttribute("download", "VideosList.csv");

        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
});
