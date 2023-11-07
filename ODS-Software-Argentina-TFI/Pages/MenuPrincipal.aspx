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
         <a class="weatherwidget-io" href="https://forecast7.com/en/n34d60n58d38/buenos-aires/" data-label_1="BUENOS AIRES" data-label_2="WEATHER" data-theme="original" >BUENOS AIRES WEATHER</a>
<script>
!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src='https://weatherwidget.io/js/widget.min.js';fjs.parentNode.insertBefore(js,fjs);}}(document,'script','weatherwidget-io-js');
</script>

     </div>
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
                <asp:Label ID="lblActiveUsers" CssClass="mb-0 h3 " runat="server" Text="0"></asp:Label>
                <span class="d-block ms-2 h3">Users</span>
              </div>
              <p class="fs-normal mb-0">Usuarios Activos</p>
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
    
     <svg display="none" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
<defs>
<symbol id="icon-bubble" viewBox="0 0 1024 1024">
	<title>bubble</title>
	<path class="path1" d="M512 224c8.832 0 16 7.168 16 16s-7.2 16-16 16c-170.464 0-320 89.728-320 192 0 8.832-7.168 16-16 16s-16-7.168-16-16c0-121.408 161.184-224 352-224zM512 64c-282.784 0-512 171.936-512 384 0 132.064 88.928 248.512 224.256 317.632 0 0.864-0.256 1.44-0.256 2.368 0 57.376-42.848 119.136-61.696 151.552 0.032 0 0.064 0 0.064 0-1.504 3.52-2.368 7.392-2.368 11.456 0 16 12.96 28.992 28.992 28.992 3.008 0 8.288-0.8 8.16-0.448 100-16.384 194.208-108.256 216.096-134.88 31.968 4.704 64.928 7.328 98.752 7.328 282.72 0 512-171.936 512-384s-229.248-384-512-384zM512 768c-29.344 0-59.456-2.24-89.472-6.624-3.104-0.512-6.208-0.672-9.28-0.672-19.008 0-37.216 8.448-49.472 23.36-13.696 16.672-52.672 53.888-98.72 81.248 12.48-28.64 22.24-60.736 22.912-93.824 0.192-2.048 0.288-4.128 0.288-5.888 0-24.064-13.472-46.048-34.88-56.992-118.592-60.544-189.376-157.984-189.376-260.608 0-176.448 200.96-320 448-320 246.976 0 448 143.552 448 320s-200.992 320-448 320z"></path>
</symbol>
<symbol id="icon-star" viewBox="0 0 1024 1024">
	<title>star</title>
	<path class="path1" d="M1020.192 401.824c-8.864-25.568-31.616-44.288-59.008-48.352l-266.432-39.616-115.808-240.448c-12.192-25.248-38.272-41.408-66.944-41.408s-54.752 16.16-66.944 41.408l-115.808 240.448-266.464 39.616c-27.36 4.064-50.112 22.784-58.944 48.352-8.8 25.632-2.144 53.856 17.184 73.12l195.264 194.944-45.28 270.432c-4.608 27.232 7.2 54.56 30.336 70.496 12.704 8.736 27.648 13.184 42.592 13.184 12.288 0 24.608-3.008 35.776-8.992l232.288-125.056 232.32 125.056c11.168 5.984 23.488 8.992 35.744 8.992 14.944 0 29.888-4.448 42.624-13.184 23.136-15.936 34.88-43.264 30.304-70.496l-45.312-270.432 195.328-194.944c19.296-19.296 25.92-47.52 17.184-73.12zM754.816 619.616c-16.384 16.32-23.808 39.328-20.064 61.888l45.312 270.432-232.32-124.992c-11.136-6.016-23.424-8.992-35.776-8.992-12.288 0-24.608 3.008-35.744 8.992l-232.32 124.992 45.312-270.432c3.776-22.56-3.648-45.568-20.032-61.888l-195.264-194.944 266.432-39.68c24.352-3.616 45.312-18.848 55.776-40.576l115.872-240.384 115.84 240.416c10.496 21.728 31.424 36.928 55.744 40.576l266.496 39.68-195.264 194.912z"></path>
</symbol>
</defs>
</svg>

<div class="blog-container">
  
  <div class="blog-header">
    <div class="blog-cover">
      <div class="blog-author">
        <h3>Russ Beye</h3>
      </div>
    </div>
  </div>

  <div class="blog-body">
    <div class="blog-title">
      <h1><a href="#">Promover el crecimiento económico sostenido, inclusivo y sostenible</a></h1>
    </div>
    <div class="blog-summary">
      <p>El desarrollo sostenible ha sido el objetivo general de la comunidad internacional desde la Conferencia de las Naciones Unidas sobre el Medio Ambiente y el Desarrollo (CNUMAD) de 1992. Entre numerosos compromisos, la Conferencia pidió a los Gobiernos que elaboraran estrategias nacionales para el desarrollo sostenible incorporando las medidas en materia de políticas esbozadas en la Declaración de Río y el Programa 21. A pesar de los esfuerzos de muchos Gobiernos de todo el mundo por poner en práctica dichas estrategias, así como de la cooperación internacional en apoyo de los Gobiernos nacionales, la evolución global de la situación económica y ambiental sigue siendo motivo de preocupación en numerosos países. Estas preocupaciones se han visto intensificadas por las recientes y prolongadas crisis energéticas, alimentarias y financieras a nivel global, y subrayadas por las continuas advertencias de científicos de todo el mundo de que la sociedad está transgrediendo una serie de límites planetarios o ecológicos.</p>
    </div>
    <div class="blog-tags">
      <ul>
        <li><a href="#">sustainable development</a></li>
        <li><a href="#">web design</a></li>
        <li><a href="#">ODS Software</a></li>
        <li><a href="https://twitter.com/russbeye">twitter</a></li>
      </ul>
    </div>
  </div>
  
  <div class="blog-footer">
    <ul>
      <li class="published-date">2 days ago</li>
      <li class="comments"><a href="#"><svg class="icon-bubble"><use xlink:href="#icon-bubble"></use></svg><span class="numero">4</span></a></li>
      <li class="shares"><a href="#"><svg class="icon-star"><use xlink:href="#icon-star"></use></svg><span class="numero">1</span></a></li>
    </ul>
  </div>

</div>

<div class="blog-container">
  
  <div class="blog-header">
    <div class="blog-author--no-cover">
        <h3>Russ Beye</h3>
    </div>
  </div>

  <div class="blog-body">
    <div class="blog-title">
      <h1><a href="#">Trabajos sustentables</a></h1>
    </div>
    <div class="blog-summary">
      <p>Ahora que las autoridades gubernamentales buscan formas eficaces de sacar a sus naciones de estas crisis conexas, habida cuenta también de esos límites planetarios, se ha propuesto la economía verde (en sus diversas formas) como un medio para catalizar el desarrollo de políticas nacionales renovadas y la cooperación y el apoyo internacionales en favor del desarrollo sostenible. El concepto ha recibido una importante atención internacional en los últimos años como herramienta para hacer frente a la crisis financiera de 2008 y como uno de los dos temas de la Conferencia de las Naciones Unidas sobre Desarrollo Sostenible de 2012 (Río+20). Esto ha dado lugar a una bibliografía en rápida expansión que incluye publicaciones nuevas sobre economía verde procedentes de diversas organizaciones internacionales influyentes, Gobiernos nacionales, grupos de reflexión, expertos, organizaciones no gubernamentales, etc.</p>
    </div>
    <div class="blog-tags">
      <ul>
        <li><a href="#">ODS Software</a></li>
        <li><a href="#">web dev</a></li>
        <li><a href="#">css</a></li>
      </ul>
    </div>
  </div>
  
  <div class="blog-footer">
    <ul>
      <li class="published-date">12 days ago</li>
      <li class="comments"><a href="#"><svg class="icon-bubble"><use xlink:href="#icon-bubble"></use></svg><span class="numero">8</span></a></li>
      <li class="shares"><a href="#"><svg class="icon-star"><use xlink:href="#icon-star"></use></svg><span class="numero">3</span></a></li>
    </ul>
  </div>

</div>


</asp:Content>