<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Login" %>

<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script src="../js/ValidarCampos.js" type="text/javascript" ></script>
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:500px">
            <h2>Login</h2>
        </div>
        <br />
        <div class="container" style="width:500px">
            <div class="mb-3" >
                <asp:Label ID="Label1" runat="server" Text="Usuario: " ></asp:Label>
                <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" required></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Clave: "></asp:Label>
                <asp:TextBox ID="txtclave" runat="server" CssClass="form-control" required></asp:TextBox>
                <br />
                <asp:Button Text="Aceptar" runat="server" CssClass="btn form-control btn-success btn-sm" ID="btnaceptar" OnClick="btnaceptar_Click"  />
               
            </div>

        </div>
       


        <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
    </form>


</asp:Content>


 
