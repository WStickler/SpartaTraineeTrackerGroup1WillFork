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
    var rows, table, switching, i, x, y, consultantValueX, consultantValueY, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.consultantValue")[0];
            y = rows[i + 1].querySelectorAll("div.consultantValue")[0];
            consultantValueX = GetSkillValue(x);
            consultantValueY = GetSkillValue(y);

            if (consultantValueX > consultantValueY) {
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
    var rows, table, switching, i, x, y, consultantValueX, consultantValueY, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.consultantValue")[0];
            y = rows[i + 1].querySelectorAll("div.consultantValue")[0];
            consultantValueX = GetSkillValue(x);
            consultantValueY = GetSkillValue(y);

            if (consultantValueX < consultantValueY) {
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
    var rows, table, switching, i, x, y, technicalValueX, technicalValueY, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.technicalValue")[0];
            y = rows[i + 1].querySelectorAll("div.technicalValue")[0];
            technicalValueX = GetSkillValue(x);
            technicalValueY = GetSkillValue(y);

            if (technicalValueX < technicalValueY) {
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
    var rows, table, switching, i, x, y, technicalValueX, technicalValueY, shouldSwitch
    table = document.getElementById("table")
    switching = true
    while (switching) {
        switching = false
        rows = table.rows
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false
            x = rows[i].querySelectorAll("div.technicalValue")[0];
            y = rows[i + 1].querySelectorAll("div.technicalValue")[0];

            technicalValueX = GetSkillValue(x);
            technicalValueY = GetSkillValue(y);

            if (technicalValueX < technicalValueY) {
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

            technicalValue = GetSkillValue(technicalValue);
            consultantValue = GetSkillValue(consultantValue);

            technicalValue2 = GetSkillValue(technicalValue2);
            consultantValue2 = GetSkillValue(consultantValue2);

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

            technicalValue = GetSkillValue(technicalValue);
            consultantValue = GetSkillValue(consultantValue);

            technicalValue2 = GetSkillValue(technicalValue2);
            consultantValue2 = GetSkillValue(consultantValue2);

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

function GetSkillValue(skillDiv) {
    var skillValue
    switch (skillDiv.innerText) {
        case "Skilled":
            skillValue = 4;
            break;
        case "Partially Skilled":
            skillValue = 3;
            break;
        case "Low Skilled":
            skillValue = 2;
            break;
        case "Unskilled":
            skillValue = 1;
            break;
    }
    return skillValue
}