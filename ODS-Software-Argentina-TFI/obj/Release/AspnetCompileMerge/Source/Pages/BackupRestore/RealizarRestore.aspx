<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="RealizarRestore.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.BackupRestore.RealizarRestore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="right_col" role="main">
        <div class="">
            <div class="row">
                <div class="col-md-12 col-sm-12 ">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav panel_toolbox">
                                <asp:Label ID="lblTitulo" runat="server" CssClass="h2" Text="Restore" Font-Bold="True" ForeColor="#003366"></asp:Label>
                                <asp:Label ID="lblError" CssClass="text-danger" runat="server" Text=""></asp:Label>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            
                            <div class="form-horizontal form-label-left">
                                <div class="item form-group">
                                    <asp:TextBox ID="txtPath" CssClass="text-body" Height="35px" Width="300px" runat="server" Enabled="false" Text="C:\Users\Public\Desktop\BackUp" ></asp:TextBox>
                                    <asp:Label ID="lblRutarestore" runat="server" Text="  Ruta por defecto"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblRestore" CssClass="col-form-label label-align" runat="server" Text="" Font-Size="Medium"></asp:Label>
                                </div>
                                <div class="ln_solid"></div>
                                <br />
                                <div class="item form-group">
                                    <div class="col-md-6 col-sm-6 offset-md-3">

                                        <asp:Button ID="btnRestore" CssClass="btn btn-primary" runat="server" Text="Realizar Restore"  OnClick="btnRestore_Click"/>
                                        <asp:Button ID="btnVolver" CssClass="btn btn-dark" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
