<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vCobroCxC.aspx.cs" Inherits="Finanzas.ControlPanel.Reportes.vCobroCxC" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   
    <style type="text/css">
        .auto-style18 {
            height: 385px;
            margin-left:350px;
            margin-top:50px;
        }
       
    </style>
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="auto-style18">
   
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
        <Series>
            <asp:Series Name="Series1" ChartType="Line" XValueMember="IdCobro" YValueMembers="Expr1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinanzasProyectoConnectionString2 %>" SelectCommand="SELECT CobroCxC.IdCobro, CobroCxC.IdCuenta, CobroCxC.Fecha, CobroCxC.Valor, CobroDetalle.IdCobroDetalle, CobroDetalle.IdCxC, CobroDetalle.Valor AS Expr1, CxC.IdCxC AS Expr2, CxC.IdCuenta AS Expr3, CxC.Fecha AS Expr4, CxC.Valor AS Expr5, CxC.Balance, CxC.Descripcion FROM CobroCxC INNER JOIN CobroDetalle ON CobroCxC.IdCobro = CobroDetalle.IdCobro INNER JOIN CxC ON CobroDetalle.IdCxC = CxC.IdCxC"></asp:SqlDataSource>
        </div>
        
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinanzasProyectoConnectionString %>" SelectCommand="SELECT DISTINCT [IdCobro], [IdCuenta], [Fecha], [Valor] FROM [CobroCxC]"></asp:SqlDataSource>
</asp:Content>
