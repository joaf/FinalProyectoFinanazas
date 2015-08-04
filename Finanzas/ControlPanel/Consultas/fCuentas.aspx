<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="fCuentas.aspx.cs" Inherits="Finanzas.ControlPanel.Consultas.fCuentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="container">
            <div class="modal-content">

                <div class="modal-header">
                    <h1>Consulta De Cuentas</h1>
                </div>
                <table class="table-condensed">
                    <tr>
                        <td>Buscar
                        </td>
                        <td class="auto-style21">
                            <asp:TextBox ID="TbBuscar" class="form-control" runat="server" placeholder="Text"></asp:TextBox>
                        </td>
                        <td class="auto-style23">
                            <asp:DropDownList ID="TipoDropDownList" Class="form-control" runat="server">
                                <asp:ListItem>IdCuenta</asp:ListItem>
                                <asp:ListItem>Descripcion</asp:ListItem>
                                <asp:ListItem>Balance</asp:ListItem>
                            </asp:DropDownList>

                        </td>

                        <td class="auto-style22">
                            <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Buscar" OnClick="BtnConsulta_Click" />

                        </td>
                    </tr>

                </table>
                <div class="auto-style25">
                    <asp:GridView ID="GridViewVista" class="scroll" runat="server" Width="84%" Height="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="IdCuenta" DataNavigateUrlFormatString="~/ControlPanel/Registros/rCuentas.aspx?IdCuenta={0}" Text="Editar" />
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
        </div>
        <br /><br />
    </div>
</asp:Content>
