<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCxP.aspx.cs" Inherits="Finanzas.ControPanel.Registros.rCxP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>


        <div class="container">
            <div class="modal-content">
                <div class="modal-header">
                    <h1>Registro De Cuenta Por Pagar

                    </h1>
                </div>
                <table class="table-condensed">
                    <tr>
                        <td>IdCxP</td>
                        <td>
                            <asp:TextBox ID="TbIdCxP" class="form-control" runat="server" placeholder="IdCxP"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button class="btn btn-default" ID="BtnConsultas" runat="server" Text="Consulta" CausesValidation="False" OnClick="BtnConsultas_Click" />

                        </td>

                    </tr>
                    <tr>
                        <td>IdCuenta</td>
                        <td>
                            <asp:DropDownList ID="DdIdCuenta" runat="server" Class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td rowspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Fecha</td>
                        <td>
                            <asp:TextBox ID="TbFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>

                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="TbFecha" ErrorMessage="Fecha No Puede Estar Vacia"
                                ForeColor="Red">*</asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>Valor</td>
                        <td>
                            <asp:TextBox ID="TbValor" class="form-control" runat="server" placeholder="Valor" TextMode="Number"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="TbValor" ErrorMessage="Valor No Puede Estar Vacio"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Balance</td>
                        <td>
                            <asp:TextBox ID="TbBalance" class="form-control" runat="server" placeholder="Balance" TextMode="Number"></asp:TextBox>
                        </td>

                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="TbBalance" ErrorMessage="Balance No Puede Estar Vacio"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>Descripcion</td>
                        <td>
                            <asp:TextBox ID="TbDescripcion" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="TbDescripcion"
                                ErrorMessage="Descripcion No Puede Estar Vacio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table-condensed"
                    style="float: right; position: absolute; top: 4px; left: 502px;">
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <div class="modal-footer">
                    <asp:Button Class=" btn btn-success" ID="BtnLimpiar" runat="server" Text="Limpiar" CausesValidation="False" OnClick="BtnLimpiar_Click" />
                    <asp:Button Class=" btn btn-success" ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                    <asp:Button Class=" btn btn-success" ID="BtnEliminar" runat="server" Text="Eliminar" CausesValidation="False" OnClick="BtnEliminar_Click" />

                </div>
            </div>
        </div>
        <div class="container"> <br /><br /></div>
    </div>
</asp:Content>
