<%@ Page Language="C#" Title="Ingreso" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="TallerSeguridadInformatica.Paginas.Ingreso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br/>
        <br/>
        <div id="formulario" >
            <label for="usuario">Usuario:</label>
            <asp:TextBox runat="server" id="usuario" placeholder="Usuario" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"/><br/>
            <label for="contrasenia">Contraseña:</label>
            <asp:TextBox id="contrasenia" runat="server" TextMode="Password" placeholder="Contraseña" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/><br/>
            <asp:Button runat="server" Text="Iniciar Sesion" OnClick="inicioSesion" CssClass="boton btn btn-dark" />
            <p>¿No tienes una cuenta?</p>
            <a runat="server" href="~/Paginas/Registro">¡Crea una!</a><br />
            <a runat="server" href="javascript: history.go(-1)">Volver</a>
            
        </div>
        <div id="lista">
            <asp:Label id="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

     </div>
</asp:Content>
