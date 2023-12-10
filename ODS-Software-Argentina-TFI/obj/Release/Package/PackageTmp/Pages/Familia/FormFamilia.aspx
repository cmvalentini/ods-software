<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="FormFamilia.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Familia.FormFamilia" %>
<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Crud
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <br />
   
   
    <div class="card mb-3">
    
    
        
             <div class="card-title align-content-center" style="width: 18rem; margin-left:14px" >
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
            <br />
                 <div class="card-body">
            <label class="form-label">Nombre de Familia:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombrePerfil" required ></asp:TextBox>
                      <asp:RegularExpressionValidator ID="rvUser" Display="Dynamic" runat="server" CssClass="validadores" ControlToValidate="txtNombrePerfil"
                                        ErrorMessage="Solamente números y letras. Mínimo 6 caracteres [0003]" ValidationExpression="^[a-zA-Z0-9]{6,}$" />
        </div>
 
         
        <div class="card-body">
            <label id="lbldescfamilia" class="form-label">Descripcion de la familia:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtDescPerfil" Height="100px" MaxLength="200" TextMode="MultiLine" required ></asp:TextBox>
        </div>
            <div class="card-body">
        <asp:Button Text="Crear" ID="BtnCreate" CssClass="btn form-control-sm btn-info" Visible="false" runat="server" OnClick="BtnCreate_Click" />  
        <asp:Button Text="Actualizar" ID="BtnUpdate" CssClass="btn form-control-sm btn-danger" Visible="false"  runat="server" OnClick="BtnUpdate_Click"/>  
        <asp:Button Text="Eliminar" ID="BtnDelete" CssClass="btn form-control-sm btn-danger" Visible="false"  runat="server" OnClick="BtnDelete_Click"/>  
        
            <asp:Button Text="Volver" ID="BtnBack" CssClass="btn btn-primary btn-dark" Visible="true"  runat="server" OnClick="BtnBack_Click"/>  
        </div>
        </div>
     
        <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
  
</asp:Content>
