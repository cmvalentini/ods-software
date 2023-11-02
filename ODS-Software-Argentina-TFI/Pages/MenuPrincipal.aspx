<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.MenuPrincipal" %>

 <asp:Content ID="bodycontent" ContentPlaceHolderID="MainContent" runat="server">
          <nav class="navbar navbar-light bg-light fixed-top">
                <div class="container-fluid">
                    <img src="../Images/ODS Soft logo_preview_rev_1.png" alt="Logo" class="navbar-brand" style="width:70px" />
                    <asp:Label ID="lblPerfil" runat="server" Visible="false" Text="WebMaster"></asp:Label>
                    <asp:ImageButton ID="imgbutton" ImageUrl="~/Images/info-icon-svg-27.jpg" style="width:50px" runat="server" OnClick="imgbutton_Click" />
                    <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNavbar" style="width:auto" aria-labelledby="offcanvasNavbarLabel">
                        <div class="offcanvas-header">
                            <h5 class="offcanvas-title" id="offcanvasNavbarLabel">Menu Principal</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close">
                            </button>
                        </div>
                        <div class="offcanvas-body">
                            <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">
                       		          
                                    <asp:Button UseSubmitBehavior="false" ID="btnBackUp" Visible="false" CssClass="btn btn-outline-primary" runat="server" Text="Back Up" Height="35px" Width="231px" OnClick="btnBackUp_Click" />
                                    <asp:Button UseSubmitBehavior="False" ID="btnBitacora" runat="server" Text="Bitacora" Visible="false" OnClick="btnBitacora_Click" CssClass="btn btn-outline-primary"  Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="BtnRestore" runat="server" Visible="false" CssClass="btn btn-outline-primary"  Text="Hacer Restore" Height="35px" Width="231px" OnClick="BtnRestore_Click" />
                                    <asp:Button UseSubmitBehavior="False" ID="btnUsuarios" CssClass="btn btn-outline-primary" runat="server" Text="Usuarios" Height="35px" Width="231px" OnClick="btnUsuarios_Click"  />
                                    <asp:Button UseSubmitBehavior="False" ID="BtnPermisos" CssClass="btn btn-outline-primary" Visible="false" runat="server" Text="Permisos" Height="35px" Width="231px" OnClick="BtnPermisos_Click" />
                                    <asp:Button UseSubmitBehavior="False" ID="BtnasignarPermisos" CssClass="btn btn-outline-primary" Visible="false" runat="server" Text="Asignar Permisos a Familia" OnClick="BtnasignarPermisos_Click" Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="BtnasignarPermisosusuario" CssClass="btn btn-outline-primary" Visible="false" runat="server" Text="Asignar permisos a Usuario" Height="35px" Width="231px" OnClick="BtnasignarPermisosusuario_Click" />
                                    <asp:Button UseSubmitBehavior="False" ID="btnDigitosverificadores" CssClass="btn btn-outline-primary" Visible="false" runat="server" Text="Digitos Verificadores" Height="35px" Width="231px" OnClick="btnDigitosverificadores_Click" />
                                    <asp:Button UseSubmitBehavior="False" ID="btnlogout" CssClass="btn btn-dark"  Height="35px" Width="231px"  runat="server" Text="LogOut" OnClick="btnlogout_Click" />
                                <li class="nav-item"><a class="nav-link" href="#">Link</a> </li>
                                <li class="nav-item dropdown"><a class="nav-link dropdown-toggle" href="#" id="offcanvasNavbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dropdown </a>
                                    <ul class="dropdown-menu" aria-labelledby="offcanvasNavbarDropdown">
                                        <li><a class="dropdown-item" href="#">Action</a></li>
                                        <li><a class="dropdown-item" href="#">Another action</a></li>
                                        <li>
                                            <hr class="dropdown-divider"></li>
                                        <li><a class="dropdown-item" href="#">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </nav>
     <br />
     <br />
     <link href="../assets/css/MenuPrincipal.css" rel="stylesheet" />
     <div>
          <section class="statistics mt-4">
      <div class="row">
        <div class="col-lg-4">
          <div class="box d-flex rounded-2 align-items-center mb-4 mb-lg-0 p-3">
            <i class="uil-envelope-shield fs-2 text-center bg-primary rounded-circle"></i>
            <div class="ms-3">
              <div class="d-flex align-items-center">
                
                  <asp:Label ID="lblServicio" CssClass="mb-0 h3" runat="server" Text="S"></asp:Label>
              </div>
              <p class="fs-normal mb-0">Servicio mas Vendido</p>
            </div>
          </div>
        </div>
        <div class="col-lg-4">
          <div class="box d-flex rounded-2 align-items-center mb-4 mb-lg-0 p-3">
            <i class="uil-file fs-2 text-center bg-danger rounded-circle"></i>
            <div class="ms-3">
              <div class="d-flex align-items-center">
               <asp:Label ID="lblticketssoporte" CssClass="m-0 h3" runat="server" Text="0"></asp:Label>
              <span class="d-block ms-2 h3">Tickets</span>
              </div>
              <p class="fs-normal mb-0">Tickets de soporte no Leídos</p>
            </div>
          </div>
        </div>
        <div class="col-lg-4">
          <div class="box d-flex rounded-2 align-items-center p-3">
            <i class="uil-users-alt fs-2 text-center bg-success rounded-circle"></i>
            <div class="ms-3">
              <div class="d-flex align-items-center">
                <h3 class="mb-0">5,245</h3> <span class="d-block ms-2">Users</span>
              </div>
              <p class="fs-normal mb-0">Lorem ipsum dolor sit amet</p>
            </div>
          </div>
        </div>
      </div>
    </section>
     </div>
      <br />
     <br />
            <asp:Panel ID="panelErrores" Visible="false" runat="server">
            <div class="container p-5 bg-light bg-opacity-75 text-light border-0 shadow-lg rounded-3 my-5 mt-5">
                <asp:Label class="h1" ID="lblTituloErrores" runat="server" Text="Digitos Verificadores Corrompidos"></asp:Label>
                <table class="table table-danger my-5">
                    <thead>
                        <tr>
                            <th scope="col">
                                <asp:Label ID="columnaNro" runat="server" Text="#"></asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="columnaErr" runat="server" Text="Error Detectado"></asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="columnaTabla" runat="server" Text="Tabla"></asp:Label>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptErrores">
                            <ItemTemplate>
                                <tr class="table-danger">
                                    <td><%#Container.ItemIndex + 1%></td>
                                    <td><%# Eval("Item2") %></td>
                                    <td><%# Eval("Item1") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
</asp:Content>