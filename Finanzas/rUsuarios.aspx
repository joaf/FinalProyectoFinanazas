<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="Finanzas.ControPanel.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="container">
            <div class="modal-content">
                <div class="modal-header">
                    <h1>Registro De Usuarios

                    </h1>
                </div>
                <table class="table-condensed">
                    <tr>
                        <td>IdUsuario</td>
                        <td>
                            <asp:TextBox ID="TbIdUsuario" class="form-control" runat="server" placeholder="IdUsuario"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Consulta" CausesValidation="False" />

                        </td>
                    </tr>
                    <tr>
                        <td>Usuario</td>
                        <td>
                            <asp:TextBox ID="TbUsuario" class="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TbUsuario" ErrorMessage="Usuario No Puede Estar Vacio" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Contraceña</td>
                        <td>
                            <asp:TextBox ID="TbContraceña" class="form-control" runat="server" placeholder="Contraceña" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TbContraceña" ErrorMessage="Contraceña No Puede Estar Vacio" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>E-Mail</td>
                        <td>
                            <asp:TextBox ID="TbEmail" class="form-control" runat="server" placeholder="E-Mail" TextMode="Email"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TbEmail" ErrorMessage="Email No Puede Estar Vacio" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table-condensed"
                    style="float: right; position: absolute; top: 95px; left: 514px;">
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="auto-style19" Width="91px" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <div class="modal-footer">
                    <asp:Button Class=" btn btn-success" ID="BtnLimpiar" runat="server" Text="Limpiar" CausesValidation="False" OnClick="BtnLimpiar_Click1" />
                    <asp:Button Class=" btn btn-success" ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                    <asp:Button Class=" btn btn-success" ID="BtnEliminar" runat="server" Text="Eliminar" />

                </div>
            </div>
        </div>
        <br /><br />


    </div>
</asp:Content>
