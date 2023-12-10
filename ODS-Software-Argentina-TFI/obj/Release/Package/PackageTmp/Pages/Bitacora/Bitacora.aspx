<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Bitacora.Bitacora" %>

   <%@ Register Src="~/Controllers/CalendarControl.ascx" TagPrefix="uc1" TagName="CalendarControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Logs
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="bodycontent" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="mx-auto" style="width: 300px">
        <h2 class="h2 align-content-center">Bitacora</h2>
    </div>
    
   
    <div class="col-sm-10">
     
    </div>
    <br />
        <uc1:CalendarControl ID="CalendarC" runat="server" />
    <br />
     <div class="container">
        <div class="row">
            <div class="col align-self-end">

                <asp:Button runat="server" OnClick="ConsultarBitacora_click" Text="Consultar Bitacora" ID="btnConsultarBitacora" CssClass="btn btn-success form-control-sm" />
                <asp:Button runat="server" OnClick="btnback_Click" Text="Volver" ID="btnback" CssClass="btn btn-dark form-control-sm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-info form-control-sm" Text="Exportar XML" Visible="false" OnClick="btnExport_Click" />
                <asp:Button ID="btnexportxls" runat="server" Visible="false" Text="Button Excel" OnClick="btnexportxls_Click" />
                </div>

        </div>
    </div >
    <br />
    <div class="container row">
        <div class="table small table-striped">
            <asp:GridView runat="server" ID="dvgBitacora" AllowSorting="True" OnSorting="GridView1_Sorting" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table  table-bordered table-hover">
                  <HeaderStyle BackColor="#47a176" Font-Bold="True" ForeColor="Black" />
                <Columns>
                     
                </Columns>
               
                <PagerStyle CssClass="pagination pagination-lg" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#c3e0cf" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
