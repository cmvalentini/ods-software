<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Login" %>

<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script src="../js/ValidarCampos.js" type="text/javascript" ></script>
    <link href="../assets/css/Login.css" rel="stylesheet" />
    <form runat="server">
        <br />
        
       
        <div class=" login-box" >
            <div class="mx-auto" style="width:500px">
            <h2 style="color: #ffffff">Login</h2>
        </div>
             <br />
            <div class="mb-3" >
                <asp:Label CssClass="texto-color user-box" ID="Label1" runat="server" Text="Usuario : " ></asp:Label>
                <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" required></asp:TextBox>
                <br />
                <asp:Label CssClass="texto-color user-box" ID="Label2" runat="server" Text="Clave : "></asp:Label>
                <asp:TextBox ID="txtclave" runat="server" CssClass="form-control" required TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button Text="Aceptar" runat="server" CssClass="btn form-control btn-sm btn-outline-info" BackColor="#3A9FF" ID="btnaceptar" OnClick="btnaceptar_Click"  />
                <br />
                 <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Para cambiar su Contraseña, ingrese Aquí</asp:LinkButton>
                <asp:ImageButton ID="imgenglish" ImageUrl="~/Images/american.png" runat="server" OnClick="imgEnglish_Click" />
                <asp:ImageButton ID="imgspanish" ImageUrl="~/Images/espico.png" runat="server" OnClick="imgSpanish_Click" />
            </div>

        </div>
       


        <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
    </form>


</asp:Content>