<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="BlanquearClave.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.BlanquearClave" %>

<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Blanquear Contraseña
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

     <script src="../js/ValidarCampos.js" type="text/javascript" ></script>
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:500px">
            <h2>Cambiar Clave</h2>
        </div>
        <br />
        <div class="container" style="width:500px">
            <div class="mb-3" >
                <asp:Label ID="lblusuomail" runat="server" Text="Ingrese su usuario o Mail: " ></asp:Label>
                <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" required></asp:TextBox>
                <br />
                <asp:Label ID="lblingreseclaveactual" runat="server" Text="Ingrese su clave actual: "></asp:Label>
                <asp:TextBox ID="txtclavevieja" runat="server" CssClass="form-control" required TextMode="Password"></asp:TextBox>
                <br />
                 <asp:Label ID="lblclavenueva" runat="server" Text="Ingrese su clave nueva: "></asp:Label>
                <asp:TextBox ID="txtclavenueva" runat="server" CssClass="form-control" required TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button Text="Aceptar" runat="server" CssClass="btn form-control btn-success btn-sm" ID="btncambiar" OnClick="btncambiar_Click"  />
             
                </div>

        </div>
       

        <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
         
    </form>
</asp:Content>
