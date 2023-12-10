<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="ModalHeader.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Controllers.ModalHeader" %>

<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
     <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="modal" class="modal-fade">
        
        </div>

</asp:Content>
