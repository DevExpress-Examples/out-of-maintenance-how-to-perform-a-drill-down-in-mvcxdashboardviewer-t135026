<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128579340/14.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T135026)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [_DashboardViewerPartial.cshtml](./CS/Dashboard_PerformDrillDown_MVC/Views/Home/_DashboardViewerPartial.cshtml)
* [Index.cshtml](./CS/Dashboard_PerformDrillDown_MVC/Views/Home/Index.cshtml)
<!-- default file list end -->
# How to perform a drill-down in MVCxDashboardViewer
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t135026)**
<!-- run online end -->


<strong>Note:</strong> <em>Starting with v17.1, we recommend using the <a href="https://documentation.devexpress.com/Dashboard/CustomDocument16976.aspx">ASPxDashboard control</a> or a corresponding <a href="https://documentation.devexpress.com/Dashboard/CustomDocument16977.aspx">ASP.NET MVC extension</a> to display dashboards within web applications.</em><br><br>The following example demonstrates how to perform a drill-down in MVCxDashboardViewer on the client side.
<p>In this example, the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_PerformDrillDowntopic">ASPxClientDashboardViewer.PerformDrillDown</a> method is used to perform a drill-down for a specified row in a <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument15150">Grid</a> dashboard item. The dxSelectBox widget contains categories for which a drill-down can be performed. These categories are obtained using the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_GetAvailableDrillDownValuestopic">ASPxClientDashboardViewer.GetAvailableDrillDownValues</a> method. Select a required category and click the <strong>PerformDrillDown</strong> button to perform a drill-down by the selected category.</p>
<p>When the Grid displays a list of products (the bottom-most detail level), you can only perform a drill-up action that returns you to the top detail level. The <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_PerformDrillUptopic">ASPxClientDashboardViewer.PerformDrillUp</a> method is called to do this.</p>

<br/>


