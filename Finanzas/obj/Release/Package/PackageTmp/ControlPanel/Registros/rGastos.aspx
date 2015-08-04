<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rGastos.aspx.cs" Inherits="Finanzas.ControPanel.Registros.rGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="container">
            <div class="modal-content">
                <div class="modal-header">

                    <h1>Registros  De Gastos

                    </h1>
                </div>

                <table class="table-condensed">
                    <tr>
                        <td>IdGasto</td>
                        <td>
                            <asp:TextBox ID="TbIdGasto" class="form-control" runat="server" placeholder="IdGasto"></asp:TextBox>
                        </td>
                        <td></td>
                        <td>
                            <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Consulta" CausesValidation="False" OnClick="BtnConsulta_Click" />

                        </td>

                    </tr>
                    <tr>
                        <td>IdCuenta</td>
                        <td>
                            <asp:DropDownList ID="DdIdCuenta" runat="server" Class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td rowspan="5">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>IdCategoria</td>
                        <td>
                            <asp:DropDownList ID="DdIdCategoria" runat="server" Class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Fecha</td>
                        <td>
                            <asp:TextBox ID="TbFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TbFecha" CssClass="auto-style19" 
                                ErrorMessage="Fecha No Puede Estar Vacia" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <td>Descripcion</td>
                        <td class="auto-style24">
                            <asp:TextBox ID="TbDescripcion" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TbDescripcion" 
                                ErrorMessage="Descripcion No Puede Estar Vacio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                 <table class="table-condensed" 
                    style=" float:right; position:absolute; top: 95px; left: 514px;">
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
