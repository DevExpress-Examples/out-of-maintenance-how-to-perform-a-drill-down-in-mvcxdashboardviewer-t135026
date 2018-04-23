using DevExpress.DashboardWeb.Mvc;
using DevExpress.DataAccess.ConnectionParameters;
using System.Web.Mvc;

namespace MVCxDashboardViewer_PerformDrillDown.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DashboardViewerPartial()
        {
            return PartialView("_DashboardViewerPartial", DashboardViewerSettings.Model);
        }
        public FileStreamResult DashboardViewerPartialExport()
        {
            return DashboardViewerExtension.Export("DashboardViewer", DashboardViewerSettings.Model);
        }
    }
    class DashboardViewerSettings
    {
        public static DashboardSourceModel Model
        {
            get
            {
                DashboardSourceModel model = new DashboardSourceModel();
                model.DashboardSource = System.Web.Hosting.HostingEnvironment.MapPath(@"~\App_Data\Dashboard.xml");

                model.ConfigureDataConnection = (sender, e) => {
                    if (e.ConnectionName == "nwindConnection")
                    {
                        Access97ConnectionParameters parameters = (Access97ConnectionParameters)e.ConnectionParameters;
                        string databasePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~\App_Data\nwind.mdb");
                        parameters.FileName = databasePath;
                    }
                };
                return model;
            }
        }
    }
}