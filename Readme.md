# How to perform a drill-down in MVCxDashboardViewer


<strong>Note:</strong> <em>Starting with v17.1, we recommend using the <a href="https://documentation.devexpress.com/Dashboard/CustomDocument16976.aspx">ASPxDashboard control</a> or a corresponding <a href="https://documentation.devexpress.com/Dashboard/CustomDocument16977.aspx">ASP.NET MVC extension</a> to display dashboards within web applications.</em><br><br>The following example demonstrates how to perform a drill-down in MVCxDashboardViewer on the client side.
<p>In this example, the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_PerformDrillDowntopic">ASPxClientDashboardViewer.PerformDrillDown</a> method is used to perform a drill-down for a specified row in a <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument15150">Grid</a> dashboard item. The dxSelectBox widget contains categories for which a drill-down can be performed. These categories are obtained using the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_GetAvailableDrillDownValuestopic">ASPxClientDashboardViewer.GetAvailableDrillDownValues</a> method. Select a required category and click the <strong>PerformDrillDown</strong> button to perform a drill-down by the selected category.</p>
<p>When the Grid displays a list of products (the bottom-most detail level), you can only perform a drill-up action that returns you to the top detail level. The <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_PerformDrillUptopic">ASPxClientDashboardViewer.PerformDrillUp</a> method is called to do this.</p>

<br/>


