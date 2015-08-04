<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPagosCxP.aspx.cs" Inherits="Finanzas.ControlPanel.Registros.rPagosCxP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>


        <div class="container">

            <div class="modal-content" style="height: 750px;">
                <div class="modal-header">
                    <h1>Registro De Pagos

                    </h1>
                </div>
                <table class="table-condensed">
                    <tr>
                        <td>IdIPago</td>
                        <td>
                            <asp:TextBox ID="TbIdPago" class="form-control" runat="server" placeholder="IdPago"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button class="btn btn-default" ID="BtnConsulta" runat="server" 
                                Text="Consulta" CausesValidation="False" OnClick="BtnConsulta_Click" />

                        </td>

                    </tr>
                    <tr>
                        <td>IdCuenta</td>
                        <td>
                            <asp:DropDownList ID="DdIdCuenta" runat="server" Class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td rowspan="3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </td>
                    </tr>

                    <tr>
                        <td>Fecha</td>
                        <td>
                            <asp:TextBox ID="TbFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TbFecha" ErrorMessage="Fecha No Puede Estar Vacio" 
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

                </table>

           


            <div style="height: 1px">
                <table class="table-condensed"
                    
                    
                    style="float: right; position: absolute; top: 78px; left: 495px; height: 250px;">
                    <tr>
                        <td>IdPagoDetalle</td>
                        <td>
                            <asp:TextBox ID="TbIdPagoDetalle" class="form-control" runat="server" placeholder="IdPagoDetalle"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                        <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Consulta" 
                                CausesValidation="False" />   
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>IdCxP</td>
                        <td>
                            <asp:DropDownList ID="DdIdCxP" runat="server" Class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Valor</td>
                        <td>
                            <asp:TextBox ID="TbValorDetalle" class="form-control" runat="server" placeholder="Valor" OnTextChanged="TbValorDetalle_TextChanged" TextMode="Number"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TbValorDetalle" ErrorMessage="Valor No Puede Estar Vacio" 
                                ForeColor="Red" ValidationGroup="detalle">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button Class=" btn btn-success" ID="BtnAgregar" runat="server" 
                                Text="Agregar" OnClick="BtnAgregar_Click" ValidationGroup="detalle" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" 
                                ValidationGroup="detalle" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <div class="container"
                    
                    style="float: right; position: absolute; top: 420px; left: 99px; overflow: auto; width: 900px; height: 150px; right: 84px;">
                    <asp:GridView ID="VistaGridView" runat="server" Height="82px" Width="744px" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <asp:Button Class=" btn btn-success" ID="BtnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click" />
                <asp:Button Class=" btn btn-success" ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                <asp:Button Class=" btn btn-success" ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />

            </div>

        </div>

</div>

        <div class="container"> <br /><br /></div>

    </div>
</asp:Content>
