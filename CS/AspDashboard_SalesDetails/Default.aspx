<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspDashboard_SalesDetails.Default" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Dashboard - Sales Details</title>
    <script type="text/javascript" src="Scripts/SalesDetailsData.js"></script>
    <script type="text/javascript" src="Scripts/SalesDetailsPopup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position:absolute;left:0;right:0;top:0;bottom:0;">
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server"
                    ClientInstanceName = "clientDashboard1"
                    Height = "100%"
                    WorkingMode = "ViewerOnly"
                    AllowExportDashboardItems ="True"
                    IncludeDashboardIdToUrl = "True"
                    IncludeDashboardStateToUrl = "True"
                    OnDataLoading="OnDataLoading"
                    OnConfigureItemDataCalculation="ASPxWebDashboard1_ConfigureItemDataCalculation"
                    ClientSideEvents-ItemClick="function(s, e) { onItemClick(s, e); }"
                    ClientSideEvents-ItemVisualInteractivity="function(s, e) { onItemVisualInteractivity(s, e); }"
                    ClientSideEvents-Init="function(s, e) { initPopup(); }"  
                >
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>
