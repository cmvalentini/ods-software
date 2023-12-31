﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.AMB_Usuario.Usuarios" %>
 
 
<asp:Content ID="bodycontent" ContentPlaceHolderID="MainContent" runat="server">
   
    
        <div   class="mx-auto" style="width:300px">
            <h2>
                <asp:Label ID="lblGestorUsuarios" runat="server" Text="Gestor de Usuarios"></asp:Label>

            </h2>          
        </div>
        <br />
        <div  class="container">
            <div  class="row">
                <div   class="col align-self-end">              
                    <asp:Button  runat="server" Text="Alta Usuarios" ID="btnCreateUser" CssClass="btn btn-success form-control-sm"  OnClick="btnCreateUser_Click" />
                    <asp:Button ID="btnback" runat="server" Text="Volver" CssClass="btn btn-dark form-control-sm" OnClick="btnback_Click" />
                    </div>

            </div>
        </div>
        <br />
        <div   class="container row">
            <div   class="table small">
                <asp:GridView runat="server" ID="dvgUsers" CssClass="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del Administrador">
                            <ItemTemplate>
                                <asp:Button Text="Update" ID="btnUpdateUser" CssClass="btn form-control-sm btn-warning" runat="server" OnClick="btnUpdateUser_Click" />
                            <asp:Button Text="Read" ID="btnReadUser" CssClass="btn form-control-sm btn-info" runat="server" OnClick="btnReadUser_Click" />
                                <asp:Button Text="Delete" ID="btnDeleteUser" CssClass="btn form-control-sm btn-danger" runat="server" OnClick="btnDeleteUser_Click" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                    
                </asp:GridView>
            </div>
        </div>
 
        
</asp:Content>
 