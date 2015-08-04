<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCategorias.aspx.cs" Inherits="Finanzas.rCategorias" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style18 {
          width: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <div class="container">
            <div class=" modal-content">
                <div class="modal-header">
                    <h1 >Registro De Categoriass

                    </h1>
                    
                </div>
                <table class="table-condensed">
                    <tr>
                        <td>IdCategora</td>
                        <td>
                            <asp:TextBox ID="TbIdCategoria" class="form-control" runat="server" placeholder="IdCategoria" meta:resourcekey="TbIdCategoriaResource1"></asp:TextBox>
                        </td>
                        <td colspan="3">
                            <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Consulta" CausesValidation="False" OnClick="BtnConsulta_Click" meta:resourcekey="BtnConsultaResource1" />

                        </td>
                    </tr>
                    <tr>
                        <td>Descripcion</td>
                        <td>
                            <asp:TextBox ID="TbDescripcion" class="form-control" runat="server" placeholder="Descripcion" meta:resourcekey="TbDescripcionResource1"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TbDescripcion" CssClass="auto-style21" 
                                ErrorMessage="Descripcion No Puedes Estar Vacio" 
                                meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="2">
                            &nbsp;</td>
                        <td rowspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Tipo
                        </td>
                        <td>
                            <asp:TextBox ID="TbTipo" class="form-control" runat="server" placeholder="Tipo" TextMode="Number" meta:resourcekey="TbTipoResource1"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TbTipo" CssClass="auto-style21" 
                                ErrorMessage="Tipo No Puede Estar Vacio" 
                                meta:resourcekey="RequiredFieldValidator2Resource1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table-condensed" 
                    style=" float:right; position:absolute; top: 95px; left: 514px;">
                    <tr>
                        <td>

                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="auto-style21" meta:resourcekey="ValidationSummary1Resource1" 
                                ForeColor="Red" />

                        </td>
                    </tr>
                </table>
                <div class="modal-footer">
                    <asp:Button Class=" btn btn-success" ID="BtnLimpiar" runat="server" Text="Limpiar" CausesValidation="False" OnClick="BtnLimpiar_Click" meta:resourcekey="BtnLimpiarResource1" />
                    <asp:Button Class=" btn btn-success" ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" meta:resourcekey="BtnGuardarResource1" />
                    <asp:Button Class=" btn btn-success" ID="BtnEliminar" runat="server" Text="Eliminar" CausesValidation="False" OnClick="BtnEliminar_Click" meta:resourcekey="BtnEliminarResource1" />

                </div>
            </div>

        </div>
                <div class="container"> <br /><br /></div>

    </div>
</asp:Content>
