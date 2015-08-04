<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="Finanzas.LogOn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    

	
  
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>INICIO DE SESION</title>

    <!-- Bootstrap core CSS -->
    
    <link href="Css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="Css/signin.css" rel="stylesheet">

  
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>


  </head>
 
	<body>

    <div class="container">

      <form runat="server" class="form-signin">
        <h2 class="form-signin-heading">Inicio De Sesion</h2>
        <label for="inputEmail" class="sr-only">Email address</label>
          <asp:TextBox ID="TbUsuario" runat="server"  class="form-control" placeholder="Usuario "></asp:TextBox>
        <label for="inputPassword" class="sr-only">Password</label>
          <asp:TextBox ID="TbContra" runat="server" class="form-control" placeholder="Contraceña" ></asp:TextBox>
        <div class="checkbox">
          <asp:label ID="label" runat="server"> 
            <asp:CheckBox ID="recordarme" runat="server" />Recordarme
          </asp:label>
            <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
        </div>
        <asp:button ID="btnInicio" runat="server" Text="Inicio Sesion"  class="btn btn-lg btn-success btn-block" OnClick="btnInicio_Click" ></asp:button>
          <br />
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrame"  class="btn btn-lg btn-success btn-block" OnClick="btnRegistrar_Click"></asp:Button>
      </form>

    </div> <!-- /container -->
        
     
  

</body>

</html>
