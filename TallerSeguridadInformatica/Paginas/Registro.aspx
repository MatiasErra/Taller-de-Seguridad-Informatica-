<%@ Page Language="C#" Title="Registro" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TallerSeguridadInformatica.Paginas.Registro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br/>
        <br/>
        <div id="formulario" >

            <label for="usuario">Usuario:</label>
            <asp:TextBox runat="server" id="usuario" placeholder="Usuario" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"/><br/>
            <label for="contrasenia">Contraseña:</label>
            <asp:TextBox id="contrasenia" runat="server" TextMode="Password" placeholder="Contraseña" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/><br/>

            <asp:Button Text="Registrarse" runat="server" OnClick="registro" CssClass="btn btn-dark" />

            <a runat="server" href="javascript: history.go(-1)">Volver</a>
            
        </div>
        <div id="lista">
            <asp:Label id="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

        </div>

</asp:Content>
