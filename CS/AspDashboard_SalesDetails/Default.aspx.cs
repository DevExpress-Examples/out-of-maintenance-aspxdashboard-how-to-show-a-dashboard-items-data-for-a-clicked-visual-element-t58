using DevExpress.DashboardWeb;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspDashboard_SalesDetails {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardStorage = new DashboardFileStorage(@"~/App_Data/Dashboards");
            ASPxDashboard1.SetDashboardStorage(dashboardStorage);
        }

        protected void OnDataLoading(object sender, DataLoadingWebEventArgs e) {
            SalesDetailsDataGenerator salesDetailsDataGenerator = new SalesDetailsDataGenerator(LoadData("DashboardSales"));
            salesDetailsDataGenerator.Generate();
            e.Data = salesDetailsDataGenerator.Data;
        }

        static string GetRelativePath(string name) {
            return Path.Combine(HostingEnvironment.MapPath("~"), "App_Data", "Data", name);
        }
        static DataSet LoadData(string fileName) {
            string path = GetRelativePath(string.Format("{0}.xml", fileName));
            DataSet ds = new DataSet();
            ds.ReadXml(path, XmlReadMode.ReadSchema);
            return ds;
        }

        protected void ASPxWebDashboard1_ConfigureItemDataCalculation(object sender, ConfigureItemDataCalculationWebEventArgs e) {
            e.CalculateAllTotals = true;
        }
    }
}