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

function OrderByOverallSkillAscending() {
    var rows, table, switching, i, technicalValue, consultantValue, technicalValue2, consultantValue2, xOverallValue, yOverallValue, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false

            technicalValue = rows[i].querySelectorAll("div.technicalValue")[0];
            consultantValue = rows[i].querySelectorAll("div.consultantValue")[0];

            technicalValue2 = rows[i + 1].querySelectorAll("div.technicalValue")[0];
            consultantValue2 = rows[i + 1].querySelectorAll("div.consultantValue")[0];

            technicalValue = GetTechnicalValue(technicalValue);
            consultantValue = GetConsultantValue(consultantValue);

            technicalValue2 = GetTechnicalValue(technicalValue2);
            consultantValue2 = GetConsultantValue(consultantValue2);

            xOverallValue = technicalValue + consultantValue;
            yOverallValue = technicalValue2 + consultantValue2;
            if (xOverallValue > yOverallValue) {
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

function OrderByOverallSkillDescending() {
    var rows, table, switching, i, technicalValue, consultantValue, technicalValue2, consultantValue2, xOverallValue, yOverallValue, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false

            technicalValue = rows[i].querySelectorAll("div.technicalValue")[0];
            consultantValue = rows[i].querySelectorAll("div.consultantValue")[0];

            technicalValue2 = rows[i + 1].querySelectorAll("div.technicalValue")[0];
            consultantValue2 = rows[i + 1].querySelectorAll("div.consultantValue")[0];

            technicalValue = GetTechnicalValue(technicalValue);
            consultantValue = GetConsultantValue(consultantValue);

            technicalValue2 = GetTechnicalValue(technicalValue2);
            consultantValue2 = GetConsultantValue(consultantValue2);

            xOverallValue = technicalValue + consultantValue;
            yOverallValue = technicalValue2 + consultantValue2;
            if (xOverallValue < yOverallValue) {
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

function GetTechnicalValue(technicalDiv) {
    var technicalValue
    switch (technicalDiv.innerText) {
        case "Skilled":
            technicalValue = 4;
            break;
        case "Partially Skilled":
            technicalValue = 3;
            break;
        case "Low Skilled":
            technicalValue = 2;
            break;
        case "Unskilled":
            technicalValue = 1;
            break;
    }
    return technicalValue
}

function GetConsultantValue(consultantDiv) {
    var consultantValue
    switch (consultantDiv.innerText) {
        case "Skilled":
            consultantValue = 4;
            break;
        case "Partially Skilled":
            consultantValue = 3;
            break;
        case "Low Skilled":
            consultantValue = 2;
            break;
        case "Unskilled":
            consultantValue = 1;
            break;
    }
    return consultantValue
}