﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="AsignarPermisosFamilia.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Familia.AsignarPermisosFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Asignación de permisos Familia
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
    <br />
    
        <table class="auto-style7">
            <tr>
                <td>
                    <strong>
                        <asp:Label ID="LblSeleccionarFamilia" runat="server" Text="SELECCIONAR FAMILIA"></asp:Label>
                    </strong>
                    <br />
                        <asp:DropDownList ID="ddlRolList" class="auto-style4" runat="server" OnSelectedIndexChanged="ddlRolList_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                    <br />
                    <br/>
                 

                </td>
            </tr>
             
            <tr>
                <td>
                    <strong>
                        <asp:Label ID="lblpermisosNOasignados" runat="server" Text="PERMISOS NO ASIGNADOS"></asp:Label>
                        <br />
                    </strong>
                </td>
                
                <td class="auto-style1"></td>
                <td>
                    <strong>
                        <asp:Label ID="lblpermisosAsignados" runat="server" Text="PERMISOS ASIGNADOS"></asp:Label>
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

                    <asp:Button ID="btnAsignar" class="btn btn-primary" runat="server" Text="--&gt; Asignar Permiso" Width="232px" OnClick="btnAsignar_Click" />
                           <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnDesasignar" class="btn btn-primary" runat="server" Text="&lt;-- Desasignar permiso" Width="232px" OnClick="btnDesasignar_Click" />
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
                        <asp:Button ID="BtnUpdate" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnUpdate_Click" />
                        <asp:Button ID="BtnBack" CssClass="btn btn-dark" runat="server" Text="Volver" OnClick="btnBack_Click" />
                                           
     </div>
         <br />
         <br />
    </div>


</asp:Content>
