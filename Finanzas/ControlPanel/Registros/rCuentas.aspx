<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentas.aspx.cs" Inherits="Finanzas.rCuentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style18 {
          width: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container">
            <div class="modal-content">
                <div class="modal-header">
                        <h1>Registro De Cuentas

                        </h1>
                    </div>
                <table class="table-condensed">
                    
                    <tr>
                        <td class="auto-style18">IdCuenta</td>
                        <td class="auto-style25">
                            <asp:TextBox ID="TbIdCuenta" class="form-control" runat="server" placeholder="IdCuenta"></asp:TextBox>
                        </td>
                        <td class="auto-style26">&nbsp;</td>
                        <td>

                            <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Consulta" CausesValidation="False" OnClick="BtnConsulta_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Descripcion</td>
                        <td class="auto-style25">
                            <asp:TextBox ID="TbDescripcion" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                        </td>
                        <td class="auto-style26">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TbDescripcion" CssClass="auto-style19" 
                                ErrorMessage="La Descripcion  No Puede  Estar Vacio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Balance
                        </td>
                        <td class="auto-style25">
                            <asp:TextBox ID="TbBalence" class="form-control" runat="server" placeholder="Balance" TextMode="Number"></asp:TextBox>
                        </td>
                        <td class="auto-style26">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TbBalence" CssClass="auto-style19" 
                                ErrorMessage="El Balance No Puede Estar Vacio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table-condensed" 
                    style=" float:right; position:absolute; top: 95px; left: 514px;">
                    <tr>
                        <td>


                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="auto-style19" ForeColor="Red" />


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
