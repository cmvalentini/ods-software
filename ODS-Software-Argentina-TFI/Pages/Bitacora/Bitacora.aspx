<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Bitacora.Bitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Bitacora
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="bodycontent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mx-auto" style="width: 300px">
        <h2>Gestor de Usuarios</h2>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col align-self-end">

                <asp:Button runat="server" OnClick="ConsultarBitacora_click" Text="Consultar Bitacora" ID="btnConsultarBitacora" CssClass="btn btn-success form-control-sm" />
            </div>

        </div>
    </div>
    <br />
    <div class="container row">
        <div class="table small">
            <asp:GridView runat="server" ID="dvgBitacora" AllowSorting="True" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table  table-bordered table-hover">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Image" ShowCancelButton="False" SelectImageUrl="Images/Select.png" ItemStyle-Height="10" ItemStyle-Width="10">
                        <ControlStyle BorderStyle="None" />
                        <HeaderStyle BorderStyle="None" Wrap="False" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle BackColor="#3A4A5B" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="pagination-ys" />
                <SelectedRowStyle BackColor="#CC0099" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
