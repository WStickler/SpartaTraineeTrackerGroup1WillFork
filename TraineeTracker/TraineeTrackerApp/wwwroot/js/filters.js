﻿function OrderByDateAscending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 0; i < (rows.length -1); i++) {
            shouldSwitch = false
            x = rows[i].getElementsByTagName("td")[0]
            y = rows[i + 1].getElementsByTagName("td")[0]
            if (x.innerHTML > y.innerHTML) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}

function OrderByDateDescending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 0; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].getElementsByTagName("TD")[0];
            y = rows[i + 1].getElementsByTagName("TD")[0];
            if (x.innerHTML > y.innerHTML) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}