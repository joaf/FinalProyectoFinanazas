<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="fCobrosCxC.aspx.cs" Inherits="Finanzas.ControlPanel.Consultas.fCobrosCxC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>

        <div class="container">
            <div class="modal-content">
                <div class="modal-header">
                    <h1>Consulta De Cobros</h1>
                </div>
            <table class="table-condensed">
                <tr>  
                <td>
                    <asp:TextBox ID="TbBuscar" class="form-control" runat="server" placeholder="Texto"></asp:TextBox>
                    </td>
                        <td>
                            <asp:DropDownList ID="TipoDropDownList" Class="form-control" runat="server">
                                <asp:ListItem>IdCobro</asp:ListItem>
                                <asp:ListItem>IdCuenta</asp:ListItem>
                                <asp:ListItem>Fecha</asp:ListItem>
                                <asp:ListItem>Valor</asp:ListItem>
                            </asp:DropDownList>

                    </td>

                        <td>
                        <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Buscar" OnClick="BtnConsulta_Click" />

                    </td>
                </tr>  
                    </table>
           
            <div>
                <asp:GridView ID="GridViewVista" class="scroll" runat="server" Width="84%" height="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="IdCobro" DataNavigateUrlFormatString="~/ControlPanel/Registros/rCobroCxC.aspx?IdCobro={0}" Text="Editar" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>

                </div>

            </div>
            
            <div class="modal-footer"></div>
        </div>
    </div>
   
</asp:Content>
