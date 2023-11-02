<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Carrito.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
 
    <link href="../../assets/css/Carrito.css" rel="stylesheet" />
 
    
  <meta name="viewport" content="width=device-width, initial-scale=1">
   
<meta name="theme-color" content="#1885ed">
  <title>ODS Soft - Homepage</title>
</head>
     

<body>
    <form id="form1" runat="server">
<header class="hheader">
  <div class="container header__container">
<div class="hheader__logo"><img src="../../Images/ODS Soft logo_preview_rev_1.png" alt="Logo" class="navbar-brand" style="width:70px" /> </div> 

  
  <div class="header__menu">
    <nav id="navbar" class="header__nav collapse">
      <ul class="hheader__elenco">
        <li class="hheader__el"><a href="#" class="hheader__link">Home</a></li>
        <li class="hheader__el"><a href="#" class="hheader__link">Pricing</a></li>
        <li class="hheader__el"><a href="#" class="hheader__link">Success stories</a></li>
        <li class="hheader__el"><a href="#" class="hheader__link">Blog</a></li>
        <li class="hheader__el"><a href="#" class="hheader__link">Contact us</a></li>
  <asp:Button ID="Button1" runat="server" CssClass="btn btn--white" Text="Sign In →" OnClick="btnLogin_Click" />
      </ul>
    </nav>
  </div>
    </div>
</header>
     
     <div class="contenedorPadre">    
   
      <div class="contenedorHijo" >
 <div class="price-box price-box--purple">
    <div class="price-box__wrap">
      <div class="price-box__img"></div>
      <h1 class="price-box__title text-center">
        Free
      </h1>
      <p class="price-box__people text-center">
       1 User
      </p>
      <h2 class="price-box__discount text-center">
        <span class="price-box__dollar text-center">$</span>0<span class="price-box__discount--light text-center">/mo</span>
      </h2>
      <h3 class="price-box__price text-center">
        Free
      </h3>
          <br />
         <br />
      <p class="price-box__feat text-center">
        Features
      </p>
       
       <p class="text-center">
        <asp:Label ID="lbllicense" CssClass=" price-box__list-el text-center" runat="server" Text=" 1 ODS License"></asp:Label>
    </p>
        <p class="text-center">
        <asp:Label ID="lblcommunity" CssClass="price-box__list-el text-center" runat="server" Text="  Community Blog"></asp:Label>
       </p>
        <p class="text-center">
        <asp:Label ID="lbltast" CssClass="price-box__list-el " runat="server" Text="  tasks limit"></asp:Label>
       </p>
        <p class="text-center">
        <asp:Label ID="lblcontractors" CssClass="price-box__list-el" runat="server" Text=" Contractors limit"></asp:Label>
      </p>
         </div>
  </div>
  </div>
 
        
       <div class="price-box__wrap__texto">
              <h1 class="price-box__title text-center">
         <asp:Label ID="Label1" CssClass="fs-2 " runat="server" Text="Complete los campos"></asp:Label>
      </h1>
              
           <br />
            <asp:Label ID="lblarchivoCliente" CssClass="price-box__feat text-center" runat="server" Text="Por favor, subir el Comprobante con los datos de la empresa"></asp:Label>
            <br /> 
           <asp:FileUpload ID="FileUploadEmpresa" CssClass="btn btn-primary btn-lg btn3d" runat="server" />
            <br />
             <asp:Label ID="lblPayment"  CssClass="price-box__feat text-center" runat="server" Text="Por favor, subir el Comprobante de deposito"></asp:Label>
            <br />  
           <asp:FileUpload ID="FileUploadComprobante" CssClass="btn btn-primary btn-lg btn3d" runat="server" />
            <br />
            <asp:Label ID="lblRepresentantenombre"  CssClass="price-box__feat text-center" runat="server" Text="Nombre Representante Legal :" required></asp:Label>
            <br />
           <asp:TextBox ID="txtrepresentantelegalnombre" CssClass="form__field--half" runat="server"></asp:TextBox>
            <br /> 
           <asp:Label ID="lblRepresentantenombreApellido"  CssClass="price-box__feat text-center" runat="server" Text="Apellido Representante Legal:"></asp:Label>
            <br /> 
           <asp:TextBox ID="txtrepresentantelegalApellido" CssClass="form__field--half" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="lblnumerofiscalempresa"  CssClass="price-box__feat text-center" runat="server" Text="Numero fiscal Empresa:"></asp:Label>
            <br /> 
           <asp:TextBox ID="txtDniEmpresa" CssClass="form__field--half" runat="server"></asp:TextBox>
            <br />  
           <asp:Label ID="lblEmail"  CssClass="price-box__feat text-center" runat="server" Text="Email:"></asp:Label>
            <br /> 
           <asp:TextBox ID="txtemail" CssClass="form__field--half" runat="server" required></asp:TextBox>
          <br />
           <asp:Label ID="lbladdress"  CssClass="price-box__feat text-center" runat="server" Text="Address:"></asp:Label>
            <br />
            <asp:TextBox ID="txtaddress" CssClass="form__field--half" runat="server" required></asp:TextBox>
   <br />
           <asp:Label ID="lblCliente" CssClass="price-box__feat text-center" runat="server" Text="Nombre Empresa : "></asp:Label>
           <br />
           <br />
        <asp:TextBox ID="txtEmpresa" CssClass="form__field--half" runat="server"></asp:TextBox>
        <br />
          
           <br />
         <asp:Button ID="btnCompreas" CssClass="btn btn-primary btn-lg btn3d" runat="server" Text="Solicitar" OnClick="btnCompreas_Click" />
       <br />
         <asp:Button ID="btndownload" runat="server" Visible="false" CssClass="btn btn-primary btn-lg btn3d" OnClick="PRINT_Click" Text="Descargar Comprobante" />

    
                    </div>
        
        </div>
    </form>
</body>
</html>
