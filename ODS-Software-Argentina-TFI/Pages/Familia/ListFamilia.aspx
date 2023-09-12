<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="ListFamilia.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Familia.ListFamilia" %>

<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
 Gestor de Familias
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <div   class="mx-auto" style="width:300px">
            <h2>Gestor de Familias</h2>          
        </div>
        <br />
        <div  class="container">
            <div  class="row">
                <div   class="col align-self-end">              
                    <asp:Button runat="server" Text="Alta Familia" ID="btnCreateFamily" CssClass="btn btn-success form-control-sm" OnClick="btnCreateFamily_Click" />
                    <asp:Button ID="btnback" runat="server" Text="Volver" CssClass="btn btn-dark form-control-sm" OnClick="btnback_Click" />
                    </div>

            </div>
        </div>
        <br />
        <div   class="container row">
            <div   class="table small">
                <asp:GridView runat="server" ID="dvgFamilys" CssClass="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del Administrador">
                            <ItemTemplate>
                                <asp:Button Text="Modificar" ID="btnUpdateFamily" CssClass="btn form-control-sm btn-warning" runat="server" OnClick="btnUpdateFamily_Click" />
                              <asp:Button Text="Eliminar" ID="btnDeleteFamily" CssClass="btn form-control-sm btn-danger" runat="server" OnClick="btnDeleteFamily_Click" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                    
                </asp:GridView>
            </div>
        </div>
    <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
</asp:Content>
