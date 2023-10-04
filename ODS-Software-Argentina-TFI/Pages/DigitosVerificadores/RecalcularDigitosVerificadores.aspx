<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="RecalcularDigitosVerificadores.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.DigitosVerificadores.RecalcularDigitosVerificadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Recalcular Digitos Verificadores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <div class="mx-auto" style="width: 300px">
        <h2 class="h2 align-content-center">Recalcular Digitos Verificadores</h2>
        </div>
<br />
    <br />
    <div class="container">
    <asp:Button ID="btnRecalcularDigitos" runat="server" Text="RecalcularDigitos" CssClass="btn btn-success align-content-center" OnClick="btnRecalcularDigitos_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-dark align-content-center" OnClick="btnVolver_Click" />
        </div>
</asp:Content>
