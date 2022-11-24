function OrderByDateAscending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length -1); i++) {
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
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].getElementsByTagName("TD")[0];
            y = rows[i + 1].getElementsByTagName("TD")[0];
            if (x.innerHTML < y.innerHTML) {
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

function OrderByConsultantSkillAscending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.consultantValue")[0];
            y = rows[i + 1].querySelectorAll("div.consultantValue")[0];
            switch (x.innerText) {
                case "Skilled":
                    x = 4;
                    break;
                case "Partially Skilled":
                    x = 3;
                    break;
                case "Low Skilled":
                    x = 2;
                    break;
                case "Unskilled":
                    x = 1;
                    break;
            }
            switch (y.innerText) {
                case "Skilled":
                    y = 4;
                    break;
                case "Partially Skilled":
                    y = 3;
                    break;
                case "Low Skilled":
                    y = 2;
                    break;
                case "Unskilled":
                    y = 1;
                    break;
            }
            if (x > y) {
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

function OrderByConsultantSkillDescending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.consultantValue")[0];
            y = rows[i + 1].querySelectorAll("div.consultantValue")[0];
            switch (x.innerText) {
                case "Skilled":
                    x = 4;
                    break;
                case "Partially Skilled":
                    x = 3;
                    break;
                case "Low Skilled":
                    x = 2;
                    break;
                case "Unskilled":
                    x = 1;
                    break;
            }
            switch (y.innerText) {
                case "Skilled":
                    y = 4;
                    break;
                case "Partially Skilled":
                    y = 3;
                    break;
                case "Low Skilled":
                    y = 2;
                    break;
                case "Unskilled":
                    y = 1;
                    break;
            }
            if (x < y) {
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

function OrderByTechnicalSkillAscending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.technicalValue")[0];
            y = rows[i + 1].querySelectorAll("div.technicalValue")[0];
            switch (x.innerText) {
                case "Skilled":
                    x = 4;
                    break;
                case "Partially Skilled":
                    x = 3;
                    break;
                case "Low Skilled":
                    x = 2;
                    break;
                case "Unskilled":
                    x = 1;
                    break;
            }
            switch (y.innerText) {
                case "Skilled":
                    y = 4;
                    break;
                case "Partially Skilled":
                    y = 3;
                    break;
                case "Low Skilled":
                    y = 2;
                    break;
                case "Unskilled":
                    y = 1;
                    break;
            }
            if (x > y) {
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

function OrderByTechnicalSkillDescending() {
    var rows, table, switching, i, x, y, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.technicalValue")[0];
            y = rows[i + 1].querySelectorAll("div.technicalValue")[0];
            switch (x.innerText) {
                case "Skilled":
                    x = 4;
                    break;
                case "Partially Skilled":
                    x = 3;
                    break;
                case "Low Skilled":
                    x = 2;
                    break;
                case "Unskilled":
                    x = 1;
                    break;
            }
            switch (y.innerText) {
                case "Skilled":
                    y = 4;
                    break;
                case "Partially Skilled":
                    y = 3;
                    break;
                case "Low Skilled":
                    y = 2;
                    break;
                case "Unskilled":
                    y = 1;
                    break;
            }
            if (x < y) {
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