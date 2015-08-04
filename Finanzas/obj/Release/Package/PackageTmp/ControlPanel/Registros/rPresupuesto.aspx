<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPresupuesto.aspx.cs" Inherits="Finanzas.ControlPanel.Registros.rPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="container">
            <div class="modal-content" style="height:750px;">
                <div class="modal-header">
                    <h1>Registor De Presupuesto

                    </h1>
                    <table class="table-condensed">
                        <tr>
                            <td>IdIPresupuesto</td>
                            <td>
                                <asp:TextBox ID="TbIdPresupuesto" class="form-control" runat="server" placeholder="IdCobro"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" Text="Consulta" CausesValidation="False" />

                            </td>
                            <td>
                                &nbsp;</td>

                        </tr>

                        <tr>
                            <td>Fecha</td>
                            <td>
                                <asp:TextBox ID="TbFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TbFecha" ErrorMessage="Fecha No Puede Estar Vacia" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td rowspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td>Descripcion</td>
                            <td>
                                <asp:TextBox ID="TbDescripcion" class="form-control" runat="server" placeholder="Valor"></asp:TextBox>
                            </td>

                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TbDescripcion" ErrorMessage="Descripcion No Puede Estar Vacia" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>

                        </tr>

                    </table>



                </div>



                <div style="height: 1px">
                    <table class="table-condensed"
                        style="float: right; position: absolute; top: 53px; left: 553px;">
                        <tr>
                            <td>IdPresupuestoDetalle</td>
                            <td>
                                <asp:TextBox ID="TbIdPresupuestoDetalle" class="form-control" runat="server" placeholder="IdCobroDetalle"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                               <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Consulta" CausesValidation="False" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                                IdCategoria</td>
                            <td>
                            <asp:DropDownList ID="DdIdCategoria" runat="server" Class="form-control">
                                </asp:DropDownList>  
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Valor</td>
                            <td>
                                <asp:TextBox ID="TbValor" class="form-control" runat="server" placeholder="Valor"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TbValor" ErrorMessage="Valor No Puede Estar Vacio" ForeColor="Red" ValidationGroup="detalle">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button Class=" btn btn-success" ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" ValidationGroup="detalle" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" ValidationGroup="detalle" />
                            </td>
                        </tr>
                    </table>

                    <div class="container"
                        
                        style="float: right; position: absolute; top: 392px; left: 56px; overflow: auto; width:900px; height:150px; right: 1026px;">
                        <asp:GridView ID="VistaGridView" runat="server" Height="84px" Width="670px" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>


                    </div>
                </div>
                <div class="modal-footer" style="margin-top:280px;">
                    <asp:Button Class=" btn btn-success" ID="BtnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click" CausesValidation="False" />
                    <asp:Button Class=" btn btn-success" ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnSiguiente_Click" />
                    <asp:Button Class=" btn btn-success" ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" CausesValidation="False" />
                </div>
            </div>
        </div>
        <div class="container"> <br /><br /></div>
        </div>
  
</asp:Content>
