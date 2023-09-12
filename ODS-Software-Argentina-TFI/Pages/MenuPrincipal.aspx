<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_operaciones.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.MenuPrincipal" %>

 <asp:Content ID="bodycontent" ContentPlaceHolderID="MainContent" runat="server">
          <nav class="navbar navbar-light bg-light fixed-top">
                <div class="container-fluid">
                    <img src="../Images/ODS Soft logo_preview_rev_1.png" alt="Logo" class="navbar-brand" style="width:70px" />
                    <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNavbar" aria-labelledby="offcanvasNavbarLabel">
                        <div class="offcanvas-header">
                            <h5 class="offcanvas-title" id="offcanvasNavbarLabel">Menu Principal</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close">
                            </button>
                        </div>
                        <div class="offcanvas-body">
                            <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">
                                <li class="nav-item"><a class="nav-link active" aria-current="page" href="#">Home</a>
          </li>
          		          
                                    <asp:Button UseSubmitBehavior="false" ID="btnBackUp" Visible="false" CssClass="btn btn-secondary" runat="server" Text="Back Up" Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="btnBitacora" runat="server" Text="Bitacora" Visible="false" OnClick="btnBitacora_Click" CssClass="btn btn-secondary"  Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="Button3" runat="server" Visible="false" CssClass="btn btn-secondary"  Text="Respuestas" Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="btnUsuarios" CssClass="btn btn-secondary" runat="server" Text="Usuarios" Height="35px" Width="231px" OnClick="btnUsuarios_Click"  />
                                    <asp:Button UseSubmitBehavior="False" ID="BtnPermisos" CssClass="btn btn-secondary" Visible="false" runat="server" Text="Permisos" Height="35px" Width="231px" OnClick="BtnPermisos_Click" />
                                    <asp:Button UseSubmitBehavior="False" ID="BtnasignarPermisos" CssClass="btn btn-secondary" Visible="false" runat="server" Text="Asignar Permisos a Familia" OnClick="BtnasignarPermisos_Click" Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="Button7" CssClass="btn btn-secondary" Visible="false" runat="server" Text="Seguridad" Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="Button8" CssClass="btn btn-secondary" Visible="false" runat="server" Text="Facturacion" Height="35px" Width="231px" />
                                    <asp:Button UseSubmitBehavior="False" ID="Button9" CssClass="btn btn-dark"  runat="server" Text="LogOut" />
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

</asp:Content>