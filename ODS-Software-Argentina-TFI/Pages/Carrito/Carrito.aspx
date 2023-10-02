<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.Carrito.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<<head>
  
  <meta name="viewport" content="width=device-width, initial-scale=1">
   
<meta name="theme-color" content="#1885ed">
  <title>ODS Soft - Homepage</title>
</head>
     

<body>
     <link href="../assets/css/landing.css" rel="stylesheet" />
    <script src="../assets/js/landing.js"></script>
    <form id="form1" runat="server">
    <header class="header">
  <div class="container header__container">
<div class="header__logo"><img src="../Images/ODS%20Soft%20logo_preview_rev_1.png" alt="Logo" class="navbar-brand" style="width:70px" /> <h1 class="header__title">Bricks<span class="header__light">.io</span></h1></div> 
     <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
  <div class="row row--center row--margin">
  <div class="header__menu">
    <nav id="navbar" class="header__nav collapse">
      <ul class="header__elenco">
        <li class="header__el"><a href="#" class="header__link">Home</a></li>
        <li class="header__el"><a href="#" class="header__link">Pricing</a></li>
        <li class="header__el"><a href="#" class="header__link">Success stories</a></li>
        <li class="header__el"><a href="#" class="header__link">Blog</a></li>
        <li class="header__el"><a href="#" class="header__link">Contact us</a></li>
        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn--white" Text="Sign In →" OnClick="btnLogin_Click" />
      </ul>
    </nav>
  </div>
    </div>
      </div> 
</header>
        
        <div>
 <div class="col-md-4 col-sm-4 price-box price-box--purple">
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
      <ul class="price-box__list">
        <li class="price-box__list-el">1 ODS License</li>
        <li class="price-box__list-el">Community Blog</li>
        <li class="price-box__list-el">tasks limit</li>
        <li class="price-box__list-el">contractors limit </li>
      </ul>
       <div class="price-box__btn">
       
    </div>
  </div>
  </div>

        </div>
    </form>
</body>
</html>
