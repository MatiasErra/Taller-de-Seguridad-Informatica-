<%@ Page Language="C#" Title="Promociones" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Promociones.aspx.cs" Inherits="TallerSeguridadInformatica.Paginas.Promociones" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br/>
        <br/>
        <div id="formulario" >
            <label for="titulo">Titulo:</label>
            <asp:TextBox runat="server" id="titulo" placeholder="Titulo" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"/><br/>
            <label for="desc">Descripcion:</label>
            <asp:TextBox id="desc" runat="server" placeholder="Descripcion" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/>
            <label for="preO">Precio Original:</label>
            <asp:TextBox id="preO" runat="server" placeholder="00" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/>
            <label for="preP">Precio Promocion:</label>
            <asp:TextBox id="preP" runat="server" placeholder="00" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/>
            <label for="descuento">Porcentaje de Descuento:</label>
            <asp:TextBox id="descuento" runat="server" placeholder="100" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/>
            <label for="img">Imagen:</label>
            <asp:FileUpload id="img" runat="server" /><br/>
            <label for="dtlls">Detalles:</label>
            <asp:TextBox id="dtlls" runat="server" placeholder="Detalles" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/>
            <label for="condic">Condiciones:</label>
            <asp:TextBox id="condic" runat="server" placeholder="Condiciones" onkeydown = "return(!(event.keyCode>=90) && event.keyCode!=32);"></asp:TextBox><br/><br/>
            <asp:Button runat="server" Text="Registrar Promocion" OnClick="altaPromocion" CssClass="boton btn btn-dark" />
            
        </div>
        <div id="lista">
            <asp:Label id="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

     </div>
</asp:Content>
