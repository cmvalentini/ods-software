<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Carrito.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <link href="../../assets/css/landing.css" rel="stylesheet" />
    <script src="../../assets/js/landing.js"></script>
  <meta name="viewport" content="width=device-width, initial-scale=1">
   
<meta name="theme-color" content="#1885ed">
  <title>ODS Soft - Homepage</title>
</head>
     

<body>
    <form id="form1" runat="server">
    <header class="header">
  <div class="container header__container">
<div class="header__logo"><img src="../../Images/ods_soft_logo.png" alt="Logo" class="navbar-brand" style="width:70px" /> </div> 
     <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
  
  <div class="header__menu">
    <nav id="navbar" class="header__nav collapse">
      <ul class="header__elenco">
        <li class="header__el"><a href="#" class="header__link">Home</a></li>
        <li class="header__el"><a href="#" class="header__link">Pricing</a></li>
        <li class="header__el"><a href="#" class="header__link">Success stories</a></li>
        <li class="header__el"><a href="#" class="header__link">Blog</a></li>
        <li class="header__el"><a href="#" class="header__link">Contact us</a></li>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn--white" Text="Sign In →" OnClick="btnLogin_Click" />
      </ul>
    </nav>
  </div>
    </div>
</header>
     
        
  <div>
 <div class="price-box price-box--purple">
    <div class="price-box__wrap">
      <div class="price-box__img"></div>
      <h1 class="price-box__title">
        Startup
      </h1>
      <p class="price-box__people">
       1 User
      </p>
      <h2 class="price-box__discount">
        <span class="price-box__dollar">$</span>49<span class="price-box__discount--light">/mo</span>
      </h2>
      <h3 class="price-box__price">
        Free
      </h3>
      <p class="price-box__feat">
        Features
      </p>
       
        <asp:Label ID="lbllicense" CssClass="price-box__list-el" runat="server" Text=" 1 ODS License"></asp:Label>
      <asp:Label ID="lblcommunity" CssClass="price-box__list-el" runat="server" Text="  Community Blog"></asp:Label>
       <asp:Label ID="lbltast" CssClass="price-box__list-el" runat="server" Text="  tasks limit"></asp:Label>
       <asp:Label ID="lblcontractors" CssClass="price-box__list-el" runat="server" Text=" Contractors limit"></asp:Label>
         
       
  </div>
  </div>

        </div>
        <div class="mb-3">
            <asp:Label ID="lblarchivoCliente" runat="server" Text="Por favor, subir el Comprobante con los datos de la empresa"></asp:Label>
            <asp:FileUpload ID="FileUploadEmpresa" runat="server" />
            <br />
             <asp:Label ID="lblPayment" runat="server" Text="Por favor, subir el Comprobante de deposito"></asp:Label>
             <asp:FileUpload ID="FileUploadComprobante" runat="server" />
            
            <asp:Label ID="lblRepresentantenombre" runat="server" Text="Nombre Representante Legal :" required></asp:Label>
            <asp:TextBox ID="txtrepresentantelegalnombre" runat="server"></asp:TextBox>
             <asp:Label ID="lblRepresentantenombreApellido" runat="server" Text="Apellido Representante Legal:"></asp:Label>
            <asp:TextBox ID="txtrepresentantelegalApellido" runat="server" ></asp:TextBox>

            <asp:Label ID="lblnumerofiscalempresa" runat="server" Text="Numero fiscal Empresa:"></asp:Label>
            <asp:TextBox ID="txtDniEmpresa" runat="server"></asp:TextBox>
              <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtemail" runat="server" required></asp:TextBox>

        </div>
    <div>
        
       
         <asp:Button ID="btnCompreas" runat="server" Text="Solicitar" OnClick="btnCompreas_Click" />
        <asp:Label ID="lblCliente" runat="server" Text="Nombre Empresa : "></asp:Label>
        <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>
    </div>

    </form>
</body>
</html>
