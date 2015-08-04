<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Finanzas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <meta name="viewport" content="width-divice-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link href="Css/Bootstrap/bootstrap.min.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            position: relative;
            padding: 15px;
            left: 42px;
            top: -24px;
            width: 241px;
        }
        .auto-style2 {
            width: 510px;
            position:absolute;
            float:right;
            left: 412px;
            top: 17px;
        }
        </style>

</head>
<body style="height: 500px; margin-right: 60px">
    <form id="form1" runat="server">

        <div class="container" style="margin-top: 60px; width:580px;">
   
            <div class="modal-content" >

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"></span></button>
                    <h1 class="modal-title" id="myModalLabel">Registro De Categorias</h1>

                </div>
                <div class="auto-style1">
                 
                     
                    <div class="auto-style17">
                      
                        <table class="table-condensed">
                            <tr>
                                <td>IdCategora</td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="TbIdCategoria" runat="server" class="form-control" 
                                        meta:resourcekey="TbIdCategoriaResource1" placeholder="IdCategoria"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="BtnConsulta" runat="server" 
                                        class="btn btn-default" meta:resourcekey="BtnConsultaResource1" 
                                        Text="Consulta" />
                                </td>
                            </tr>
                            <tr>
                                <td>Descripcion</td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="TbDescripcion" runat="server" class="form-control" 
                                        meta:resourcekey="TbDescripcionResource1" placeholder="Descripcion"></asp:TextBox>
                                </td>
                                <td class="auto-style20">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="TbDescripcion" CssClass="auto-style21" 
                                        ErrorMessage="Descripcion No Puedes Estar Vacio" 
                                        meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style19" rowspan="2">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        CssClass="auto-style21" meta:resourcekey="ValidationSummary1Resource1" />
                                </td>
                            </tr>
                            <tr>
                                <td>Tipo </td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="TbTipo" runat="server" class="form-control" 
                                        meta:resourcekey="TbTipoResource1" placeholder="Tipo" TextMode="Number"></asp:TextBox>
                                </td>
                                <td class="auto-style20">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="TbTipo" CssClass="auto-style21" 
                                        ErrorMessage="Tipo No Puede Estar Vacio" 
                                        meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>



                        <div id="divBtn" class="auto-style18">

                            <asp:Button Class=" btn btn-success" ID="BtnLimpiar" runat="server" Text="Limpiar" CausesValidation="False" />
                            <asp:Button Class=" btn btn-success" ID="BtnGuardar" runat="server" Text="Guardar" />
                            <asp:Button Class=" btn btn-success" ID="BtnEliminar" runat="server" Text="Eliminar" CausesValidation="False" />

                        </div>


                    </div>
        </div>
       
        <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Atras</button>
            <button type="button" class="btn btn-primary">Siguiente</button>
        </div>

        </div><!-- /.modal-content -->

        <script src="js/bootstrap.min.js"></script>
        <script src="Scripts/jquery-1.11.3.min.js"></script>
        </div>

   
    </form>
</body>
</html>
