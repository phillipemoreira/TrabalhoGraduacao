$(function () {

    $container = $("#dataTable");

    var config = itensPlan;

    var lock = false;

    $container.handsontable({
        rows: config.Rows,
        cols: config.Cols,
        minSpareRows: 1, //always keep at least 1 spare row at the bottom
        fillHandle: true,
        legend: [
            {
                match: function (row, col, data) {
                    return (row === 0); //if it is first row
                },
                style: {
                    fontWeight: 'bold'
                },
                title: 'Perfis', //make some tooltip
                readOnly: true //make it read-only
            },
            {
                match: function (row, col, data) {
                    return true;
                },
                style: {
                    background: 'LightGrey'
                },
                readOnly: true
            }

        ],
        undo: true
    });

    $container.handsontable("loadData", config.data);


});