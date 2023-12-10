<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="AsignarPermisosUsuario.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Familia.AsignarPermisosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Asignar Permisos a Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <div class="card mb-3">

    <br />
     <div class="card-body">
          <div class="mx-auto d-flex flex-column align-items-center justify-content-center" >
        <table class="auto-style7">
            <tr class="table">
                <td>
                    <strong>
                        <asp:Label ID="lblseleccionarfamilia" runat="server" Text="Seleccionar Familia"></asp:Label>
                    </strong>
                    <br />
                        <asp:DropDownList ID="ddlRolList" class="auto-style4" runat="server" OnSelectedIndexChanged="ddlRolList_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                    <br />
                    <asp:Button ID="btnaplicarfamilia" runat="server" Text="Aplicar Familia" CssClass="btn btn-primary" OnClick="btnAplicarFamilia_Click" />
                    <br />
                    <br />
                    <strong>
                        <asp:Label ID="lblseleccionarusuario" runat="server" Text="Seleccionar Usuario"></asp:Label>
                    </strong>
                     <br />
                        <asp:DropDownList ID="ddlUserList" class="auto-style4" runat="server" OnSelectedIndexChanged="ddlUserList_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                    <br />

                    <br/>
                 

                </td>
            </tr>
             
            <tr>
                <td>
                    <strong>
                        <asp:Label ID="lblpermisosnoasignados" runat="server" Text="PERMISOS NO ASIGNADOS"></asp:Label>
                        <br />
                    </strong>
                </td>
                
                <td class="auto-style1"></td>
                <td>
                    <strong>
                        <asp:Label ID="lblpermisosasignados" runat="server" Text="PERMISOS ASIGNADOS"></asp:Label>
                        <br />
                    </strong>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="auto-style10">                    
                        <asp:ListBox ID="listNotAssing" class="table table-hover" Height="325px" Width="338px" runat="server"></asp:ListBox>
                    </div>
                </td>
                <td class="auto-style2">
                       <div class="auto-style10">   

                           <br />
                           <br />
                           <br />
                           <br />

                    <asp:Button ID="btnasignar" class="btn btn-primary" runat="server" Text="--&gt; Asignar Permiso" Width="232px" OnClick="btnAsignar_Click" />
                           <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btndesasignar" class="btn btn-primary" runat="server" Text="&lt;-- Desasignar permiso" Width="232px" OnClick="btnDesasignar_Click" />
                      </div>                

                </td>
                <td>                   
                    <div class="auto-style10">     
                       <asp:ListBox ID="listAssing" class="table table-hover" Height="325px" Width="338px" runat="server"></asp:ListBox>
                    </div>
                </td>
            </tr>
          
        </table>
     <div>
                        <asp:Button ID="btnupdate" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnupdate_Click" />
                        <asp:Button ID="btnback" CssClass="btn btn-dark" runat="server" Text="Volver" OnClick="btnback_Click" />
                                           
     </div>
         </div>
          </div>
           </div>

    
</asp:Content>
