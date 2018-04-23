Imports DevExpress.DashboardWeb
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.Hosting
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace AspDashboard_SalesDetails
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardStorage As New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboard1.SetDashboardStorage(dashboardStorage)
        End Sub

        Protected Sub OnDataLoading(ByVal sender As Object, ByVal e As DataLoadingWebEventArgs)
            Dim salesDetailsDataGenerator As New SalesDetailsDataGenerator(LoadData("DashboardSales"))
            salesDetailsDataGenerator.Generate()
            e.Data = salesDetailsDataGenerator.Data
        End Sub

        Private Shared Function GetRelativePath(ByVal name As String) As String
            Return Path.Combine(HostingEnvironment.MapPath("~"), "App_Data", "Data", name)
        End Function
        Private Shared Function LoadData(ByVal fileName As String) As DataSet
            Dim path As String = GetRelativePath(String.Format("{0}.xml", fileName))
            Dim ds As New DataSet()
            ds.ReadXml(path, XmlReadMode.ReadSchema)
            Return ds
        End Function

        Protected Sub ASPxWebDashboard1_ConfigureItemDataCalculation(ByVal sender As Object, ByVal e As ConfigureItemDataCalculationWebEventArgs)
            e.CalculateAllTotals = True
        End Sub
    End Class
End Namespace