    $(document).ready(function() {
        $("#PrintReportsBtn").printPage();
    });

function PrintReport(exportMode) {
    var startDate = $("#startDate").val();
    var endDate = $("#endDate").val();
    var printLink = $("#printLink").val();
    var merchantId = $("#merchantId").val();
    var invoiceId = $("#invoiceId").val();
    var alertsMode = $("#alertsMode").val();
    
    var exportUrl = printLink +"?";
    
    if (alertsMode != null) {
        exportUrl += "alertsMode=" + alertsMode + "&";
    }

    if (startDate != null) {
        exportUrl += "startDate=" + startDate + "&";
    }
    if (endDate != null) {
        exportUrl += "endDate=" + endDate + "&";
    }
    if (merchantId != null) {
        exportUrl += "merchantId=" + merchantId + "&";
    }
    if (invoiceId != null) {
        exportUrl += "invoiceId=" + invoiceId + "&";
    }
    exportUrl += "&exportMode=" + exportMode;

    if (exportMode) {
        $("#exportButton").attr('href', exportUrl);
    } else {
        $("#PrintReportsBtn").attr('href', exportUrl);
    }

    
}

function getReportParams() {

    var outPut = JSON.stringify(getOutPut());

    var saveOutPutConfig = document.getElementById("saveOutputAsDefault").checked;

    var s = $("#status").val();

    return {
        outPut: outPut,
        saveOutPut: saveOutPutConfig,
        agentId: $("#agentId").val(),
        startDate: $("#startDate").val(),
        endDate: $("#endDate").val(),
        merchantId: $("#merchantId").val(),
        invoiceId: $("#invoiceId").val(),
        alertsMode: $("#alertsMode").val(),
        status: $("#status").val(),
        columnName: $("#columnName").val(),
    };
}


//function getParamsCreditLimit() {
//    var dirtyOnes = [{merchant_pk : -1, dailylimit_max : -1, creditlimit_max: -1 }];
//    var rows = $("table tbody tr");
//    for (var i = 0; i < rows.length; i++) {
//        var tr = rows[i];
//        for (var j = 0; j < tr.cells.length; j++) {
//            var td = tr.cells[j];
//            if (td.className.indexOf("k-dirty-cell") > -1) {
//                dirtyOnes.push({ merchant_pk: tr, dailylimit_max: tr, creditlimit_max: tr });
//                break;
//            }
//        }
//    }
//
//
//    return dirtyOnes;
//}


function UpdateReportConfiguration() {

    var url = 'Reports/UpdateReportConfiguration")';

    var saveOndesktop = document.getElementById("ShouldBeShownAtDesktop").checked;

    $.post(url, { reportId: $("#ReportId").val(), saveOnDesktop: saveOndesktop }, myAccountShowResultMessage);
}

function UpdateDataProjection() {

    var checkboxes = $("input:checkbox");

    for (var i = 0; i < checkboxes.length; i++) {
        var checkboxName = checkboxes[i].name;
        if (checkboxName.indexOf('columnName') !== -1) {

            var tokens = checkboxName.split('^');

            var columnName = tokens[1];

            if (checkboxes[i].checked) {

                ShowColumnFromKendo(columnName);
            } else {
                HideColumnFromKendo(columnName);
            }
        }
    }

}

function HideColumnFromKendo(columnName) {

    var grid = $("#Reports").data("kendoGrid");

    grid.hideColumn(columnName);

}

function ShowColumnFromKendo(columnName) {

    var grid = $("#Reports").data("kendoGrid");

    grid.showColumn(columnName);
}

function getUserFilters() {

    var filters = [];

    var inputs = document.getElementsByTagName('select');

    for (var i = 0; i < inputs.length; i++) {

        var userFilter = inputs[i];

        if (userFilter.name.indexOf('userFilter') !== -1) {

            var tokens = userFilter.name.split('^');

            var filterColumnName = tokens[1];

            var values = [];

            for (var j = 0; j < userFilter.options.length; j++)
                if (userFilter.options[j].selected)
                    values.push(userFilter.options[j].value);

            var filter = {
                Options: filterColumnName,
                Value: values
            };

            filters.push(filter);
        }
    }
    return filters;
}

function applyUserfilters() {
    $("#Reports").data("kendoGrid").dataSource.read();
}

function getOutPut() {
    var checkboxes = $("input:checkbox");
    var outPut = [];
    for (var i = 0; i < checkboxes.length; i++) {
        var checkboxName = checkboxes[i].name;
        if (checkboxName.indexOf('columnName') !== -1) {

            var tokens = checkboxName.split('^');

            var columnName = tokens[1];

            if (checkboxes[i].checked) {

                outPut.push(columnName);
            }

        }
    }

    return outPut;
}

function saveNewOutPutOrder(e) {

    var newIndex = e.newIndex;

    var oldIndex = e.oldIndex;

    var columnName = e.column.field;

    var updateOrderUrl = 'Reports/UpdateColumnOrder';

    $.post(updateOrderUrl, { reportId: $("#ReportId").val(), columnName: columnName, oldIndex: oldIndex, newIndex: newIndex });
}

function saveColumnWidth(e) {
    var columnName = e.column.field;

    var newWidth = e.newWidth;

    var updateWidthUrl = '/VirtualOffice/UpdateColumnWidth';

    console.log(updateWidthUrl);

    $.post(updateWidthUrl, { storeProcedureName: $("#storeProcedure").val(), columnName: columnName, width: newWidth });

}

function changeCheckBoxedNames_Values(column, otherColumn) {

    var checkboxes = $("input:checkbox");

    for (var i = 0; i < checkboxes.length; i++) {
        var checkboxName = checkboxes[i].name;
        if (checkboxName.indexOf('columnName') !== -1) {

            var tokens = checkboxName.split('^');

            var columnName = tokens[1];

            if (columnName === column) {
                checkboxes[i].name = 'columnName^' + otherColumn;
                checkboxes[i].id = 'columnName^' + otherColumn;
                checkboxes[i].value = otherColumn;
                continue;
            }
            if (columnName === otherColumn) {
                checkboxes[i].name = 'columnName^' + column;
                checkboxes[i].id = 'columnName^' + column;
                checkboxes[i].value = column;
            }

        }
    }
}

function changeLabelsText(column, otherColumn) {

    var labels = $("label");

    for (var i = 0; i < labels.length; i++) {
        var labelId = labels[i].id;
        if (labelId.indexOf('label') !== -1) {

            var tokens = labelId.split('^');

            var columnName = tokens[1];

            if (columnName === column) {
                labelId[i].id = 'label^' + otherColumn;
                labelId[i].InnerHTML = otherColumn;
                continue;
            }
            if (columnName === otherColumn) {
                labelId[i].id = 'label^' + column;
                labelId[i].InnerHTML = column;
            }

        }
    }
}

function myAccountShowResultMessage(result) {
    var response = result.Result;
    var message = result.Message;

    if (response == "Success") {
        $("#myAccountSuccessMessageText").text(message);
        $("#myAccountSuccessMessageConfirmation").fadeIn();
        setTimeout(timeOut("#myAccountSuccessMessageConfirmation", 3000));
    } else {
        $("#myAccountFailedMessageText").text(message);
        $("#myAccountFailedMessageConfirmation").fadeIn();
        setTimeout(timeOut("#myAccountFailedMessageConfirmation", 3000));
    }
}

function timeOut(id, time) {
    $(id).fadeOut(time);
}


function getLocalDate(date) {
    var utcDate = new Date(date.getTime() + date.getTimezoneOffset() * 60000)
    return utcDate;
}