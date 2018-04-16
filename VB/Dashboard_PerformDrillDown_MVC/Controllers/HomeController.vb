Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DevExpress.DashboardWeb.Mvc
Imports DevExpress.DataAccess.ConnectionParameters

Namespace Dashboard_PerformDrillDown_MVC.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        <ValidateInput(False)> _
        Public Function DashboardViewerPartial() As ActionResult
            Return PartialView("_DashboardViewerPartial", DashboardViewerSettings.Model)
        End Function
        Public Function DashboardViewerPartialExport() As FileStreamResult
            Return DashboardViewerExtension.Export("DashboardViewer", DashboardViewerSettings.Model)
        End Function
    End Class
    Friend Class DashboardViewerSettings
        Public Shared ReadOnly Property Model() As DashboardSourceModel
            Get

                Dim model_Renamed As New DashboardSourceModel()
                model_Renamed.DashboardSource = System.Web.Hosting.HostingEnvironment.MapPath("~\App_Data\Dashboard.xml")

                model_Renamed.ConfigureDataConnection = Sub(sender, e)
                    If e.ConnectionName = "nwindConnection" Then
                        ' Gets connection parameters used to establish a connection to the database.
                        Dim parameters As Access97ConnectionParameters = CType(e.ConnectionParameters, Access97ConnectionParameters)
                        Dim databasePath As String = System.Web.Hosting.HostingEnvironment.MapPath("~\App_Data\nwind.mdb")
                        ' Specifies the path to a database file.  
                        parameters.FileName = databasePath
                    End If
                End Sub
                Return model_Renamed
            End Get
        End Property
    End Class
End Namespace