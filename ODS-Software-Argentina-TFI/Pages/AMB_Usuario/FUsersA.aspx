<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="FUsersA.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.AMB_Usuario.FUsersA" %>
<%@ Register Src="~/Pages/ExceptionModal.ascx" TagPrefix="uc1" TagName="ExceptionModal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
     Crud
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
      <div class="card mb-3">

    <div class="mx-auto" style="width:250px" >
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
       <br />
          <div class="card-body">
        <div class="mx-auto d-flex flex-column align-items-center justify-content-center" >
                 <div class="mb-3">
            <label class="form-label" id="lblusuario">Usuario</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" ></asp:TextBox>
                                   <asp:RegularExpressionValidator ID="RegexUsuario" Display="Dynamic" runat="server" CssClass="validadores" ControlToValidate="txtUsuario"
                                        ErrorMessage="Only Characters Please. Mínimo 6 caracteres [0003]" ValidationExpression="^[a-zA-Z ]*$" />          
         
        </div>

        <div class="mb-3">
            <label class="form-label" id="lblnombre">Nombre</label>
                      <asp:RegularExpressionValidator ID="rvUser" Display="Dynamic" runat="server" CssClass="validadores" ControlToValidate="txtnombre"
                                        ErrorMessage="Only Characters Please. Mínimo 6 caracteres [0003]" ValidationExpression="^[a-zA-Z ]*$" />          
            <asp:TextBox runat="server" CssClass="form-control" ID="txtnombre" ></asp:TextBox>
        </div>
          <div class="mb-3">
            <label class="form-label" id="lblapellido">Apellido</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtapellido"></asp:TextBox>
               <asp:RegularExpressionValidator ID="rvlastname" Display="Dynamic" runat="server" CssClass="validadores" ControlToValidate="txtapellido"
                                        ErrorMessage="Only Letters Please. Mínimo 6 caracteres [0003]" ValidationExpression="^[a-zA-Z ]*$" />  
        </div>
        <div class="mb-3">
            <label class="form-label" id="lblmail">Mail</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtemail"></asp:TextBox>
                          <asp:RegularExpressionValidator ID="remail" Display="Dynamic" runat="server" CssClass="validadores" ControlToValidate="txtemail"
                                        ErrorMessage="Please,check email" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" />  
      
      
        </div>
     
        <div class="mb-3">
            <label class="form-label" id="lblhabilitado">Habilitado : </label>
            <asp:CheckBox Text="" ID="chkHabilitado" runat="server" />    
        </div>
        <asp:Button Text="Crear" ID="BtnCreate" CssClass="btn form-control-sm btn-info" Visible="false" runat="server" OnClick="BtnCreate_Click" />  
        <asp:Button Text="Actualizar" ID="BtnUpdate" CssClass="btn form-control-sm btn-danger" Visible="false"  runat="server" OnClick="BtnUpdate_Click"/>  
        <asp:Button Text="Eliminar" ID="BtnDelete" CssClass="btn form-control-sm btn-danger" Visible="false"  runat="server" OnClick="BtnDelete_Click"/>  
        <asp:Button Text="Leer" ID="btnRead" CssClass="btn form-control-sm btn-info" Visible="false"  runat="server" OnClick="BtnRead_Click"/>  
        
            <asp:Button Text="Volver" ID="BtnBack" CssClass="btn btn-primary btn-dark" Visible="true"  runat="server" OnClick="BtnBack_Click"/>  
        </div>
        </div>
          </div>
        <uc1:ExceptionModal runat="server" ID="ExceptionModal" />
    


</asp:Content>
