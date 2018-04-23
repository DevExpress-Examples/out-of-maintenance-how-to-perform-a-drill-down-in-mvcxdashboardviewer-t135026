function createControls() {
    var drillDownTuples = webViewer.GetAvailableDrillDownValues("gridDashboardItem1"),
        drillDownValues = [];

    $.each(drillDownTuples, function (index, value) {
        drillDownValues.push(value.GetAxisPoint().GetValue());
    });

    var performDrillAction = function () {
        var tuple = webViewer.GetItemData("gridDashboardItem1").CreateTuple([{
            AxisName: DashboardDataAxisNames.DefaultAxis,
            Value: [$("#selectBox").data("dxSelectBox").option("value")]
        }]);
        if (webViewer.CanPerformDrillDown("gridDashboardItem1")) {
            webViewer.PerformDrillDown("gridDashboardItem1", tuple);
        }
        else {
            webViewer.PerformDrillUp("gridDashboardItem1");
        }
    };

    $("#buttonContainer").dxButton({
        onClick: performDrillAction,
        text: "PerformDrillDown"
    });

    $("#selectBox").dxSelectBox({
        dataSource: drillDownValues
    });
};

function setState() {
    if (webViewer.CanPerformDrillDown("gridDashboardItem1")) {
        $("#buttonContainer").dxButton({
            disabled: false,
            text: "PerformDrillDown"
        });
        $("#selectBox").dxSelectBox({
            disabled: false
        });
    }
    if (webViewer.CanPerformDrillUp("gridDashboardItem1")) {
        $("#buttonContainer").dxButton({
            disabled: false,
            text: "PerformDrillUp"
        });
        $("#selectBox").dxSelectBox({
            disabled: true
        });
    }
    if (!webViewer.CanPerformDrillDown("gridDashboardItem1") && !webViewer.CanPerformDrillUp("gridDashboardItem1")) {
        $("#buttonContainer").dxButton({
            disabled: true
        });
        $("#selectBox").dxSelectBox({
            disabled: true
        });
    }
};