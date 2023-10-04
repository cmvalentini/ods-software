﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="ODS_Software_Argentina_TFI.Pages.LandingPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link href="../assets/css/landing.css" rel="stylesheet" />
    <script src="../assets/js/landing.js"></script>
  <meta name="viewport" content="width=device-width, initial-scale=1">
   
<meta name="theme-color" content="#1885ed">
  <title>ODS Soft - Homepage</title>
</head>

<body>
    <form runat="server" >
<header class="header">
  <div class="container header__container">
<div class="header__logo"><img src="../Images/ODS%20Soft%20logo_preview_rev_1.png" alt="Logo" class="navbar-brand" style="width:70px" /> </div> 
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
        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn--white" Text="Sign In →" OnClick="btnLogin_Click" />
      </ul>
    </nav>
  </div>
    </div>
</header>

<div class="sect sect--padding-top">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
    <div class="site">
      <h1 class="site__title">A quick way to grow your business sustainably</h1>
      <h2 class="site__subtitle">Manage your future like a boss</h2>
      <div class="site__box-link">
        <a class="btn btn--width" href="">Pricing</a>
        <a class="btn btn--revert btn--width" href="">Contact</a>
      </div>
      <img class="site__img" src="https://image.ibb.co/c7grYb/image3015.png">
    </div>
    </div>
    </div>
  </div>
</div>

<div class="sect sect--padding-bottom">
<div class="container">
<div class="row row--center">
  <h1 class="row__title">
    Pricing
  </h1>
  <h2 class="row__sub">What fits your business the best?</h2>
</div>
<div class="row row--center row--margin">
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
       <asp:Button ID="btnBuyFree" runat="server" CssClass="btn btn--purple btn--width" Text="Start now" OnClick="btnBuyFree_Click" />
      
    </div>
  </div>
  </div>
  <!-- second -->
  <div class="col-md-4 col-sm-4 price-box price-box--violet">
  <div class="price-box__wrap">
      <div class="price-box__img"></div>
      <h1 class="price-box__title">
        Standard
      </h1>
      <p class="price-box__people">
        100 - 500 people
      </p>
      <h2 class="price-box__discount">
      <span class="price-box__dollar">$</span>149<span class="price-box__discount--light">/mo</span>
      </h2>
      <h3 class="price-box__price">
        $225/mo
      </h3>
      <p class="price-box__feat">
        Features
      </p>
      <ul class="price-box__list">
        <li class="price-box__list-el">1 License</li>
        <li class="price-box__list-el">24h helpcenter</li>
        <li class="price-box__list-el">No tasks limit</li>
        <li class="price-box__list-el">No contractors limit </li>
      </ul>
      <div class="price-box__btn">
         <asp:Button ID="btnbuystandard" CssClass="btn btn--purple btn--width" runat="server" Text="Start now" OnClick="btnbuystandard_Click" />
      
    </div>
  </div>
  </div>

<!-- terzo -->
  <div class="col-md-4 col-sm-4 price-box price-box--blue row--center">
  <div class="price-box__wrap">
      <div class="price-box__img"></div>
      <h1 class="price-box__title">
        Corporate
      </h1>
      <p class="price-box__people">
        500+ people
      </p>
      <h2 class="price-box__discount">
      <span class="price-box__dollar">$</span>399<span class="price-box__discount--light">/mo</span>
      </h2>
      <h3 class="price-box__price">
        $499/mo
      </h3>
      <p class="price-box__feat">
        Features
      </p>
      <ul class="price-box__list">
        <li class="price-box__list-el">1 License</li>
        <li class="price-box__list-el">24h helpcenter</li>
        <li class="price-box__list-el">No tasks limit</li>
        <li class="price-box__list-el">No contractors limit </li>
      </ul>
    <div class="price-box__btn">
     <asp:Button ID="btnbuyPremium" CssClass="btn btn--purple btn--width" runat="server" Text="Start now" OnClick="btnbuyPremium_Click" />
      
    </div>
  </div>
  </div>
  
  

</div>
</div>
</div>
    <br />
 
<div class="sect sect--white sect--no-padding">
<div class="container">
  <div class="row row--center">
    <div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/mOtHRw/fblogo.png">
      </a>
    </div>
    
<div class="col-md-3  col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/nfpXRw/twitterlogo.png">
      </a>
    </div>
    
    
<div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/imgOYb/googlelogo.png">
      </a>
    </div>
    
<div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/ebGAeG/dribbblelogo.png">
      </a>
    </div>
        
    
  </div>
  <div class="row row--center">
    <div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/npV8Yb/gitlogo.png">
      </a>
    </div>
    
        <div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/cGyZ6w/stacklogo.png">
      </a>
    </div>
    
    
        <div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/ij03zG/inlogo.png">
      </a>
    </div>
    
        <div class="col-md-3 col-xs-6 col-sm-6 partner">
      <a href="#" class="partner__link">
      <img class="partner_img" src="https://image.ibb.co/ekqdzG/codepenlogo.png">
      </a>
    </div>
  </div>
</div>    
</div>

<div class="sect sect--white">
<div class="container">
  <div class="row">
   <h1 class="row__title">
    Our blog
  </h1>
  <h2 class="row__sub">Build a better future with us</h2>
  </div>
  
  <div class="row row--margin">
    <div class="col-md-6 article-pre__col">
      <a href="#" class="article-pre ">
        <div class="article-pre__img article-pre__img--first"></div>
        <h2 class="article-pre__info">
          <span class="article-pre__cat">Protips • </span><span class="article-pre__aut"> by Ann Timothy</span> <span class="article-pre__date"> - 5 mins read</span>
        </h2>
        <h1 class="article-pre__title">How to improve analytics using few tools<span class="article-pre__arrow--purple"> →</span></h1>
      </a>
    </div>
    
        <div class="col-md-6 article-pre__col">
      <a href="#" class="article-pre ">
        <div class="article-pre__img article-pre__img--second"></div>
        <h2 class="article-pre__info">
          <span class="article-pre__cat">Pricing • </span><span class="article-pre__aut"> by Josh Ford</span> <span class="article-pre__date"> - 5 mins read</span>
        </h2>
        <h1 class="article-pre__title">Rich Thornett & Dan Coderholm about Dribbble in early 2023<span class="article-pre__arrow--purple">→</span></h1>
      </a>
    </div>    
 </div>
  <div class="row">
     <div class="col-md-6 article-pre__col">
      <a href="#" class="article-pre ">
        <div class="article-pre__img article-pre__img--fourth"></div>
        <h2 class="article-pre__info">
          <span class="article-pre__cat">Success Stories • </span><span class="article-pre__aut"> by Andrew Lincoln</span> <span class="article-pre__date"> - 5 mins read</span>
        </h2>
        <h1 class="article-pre__title">Steward Butterfield told us about his startup Slack<span class="article-pre__arrow--purple"> →</span></h1>
      </a>
    </div>
    
        <div class="col-md-6 article-pre__col">
      <a href="#" class="article-pre ">
        <div class="article-pre__img article-pre__img--third"></div>
        <h2 class="article-pre__info">
          <span class="article-pre__cat">Protips • </span><span class="article-pre__aut"> by Ann Timothy</span> <span class="article-pre__date"> - 5 mins read</span>
        </h2>
        <h1 class="article-pre__title">How to improve analytics using few tools in ODS Soft<span class="article-pre__arrow--purple"> →</span></h1>
      </a>
    </div>     
  </div>
</div>
</div>

<div class="sect sect--padding-bottom">
  <div class="container">
    <div class="row">
     <h1 class="row__title">
    Contact Us </h1>
  <h2 class="row__sub">Feel free to ask any questions</h2>
    </div>
    <div class="row row--margin">
      <div class="col-md-1"></div>
      <div class="col-md-4">
        <div class="contacts">
          <a href="#" class="contacts__link"><img src="https://image.ibb.co/kcVou6/path3000.png"><h1 class="contacts_title-ag">Bricks<span class="contacts--light">.io</span></h1></a>
          <p class="contacts__address">
            431 Broadway, Floor 1-2<br>
            New York NY 10013<br>
            United States
          </p>
          <p class="contacts__info">
            tel. <a href="#" class="contacts__info-link">+1 234 567 890</a>
          </p>
          <p class="contacts__info">
            m. <a href="#"class="contacts__info-link">info@ODSsoft.com</a>
          </p>
        </div>
      </div>
      <div class="col-md-6">
        <form id="contact" class="form">
          <div class="form-group">
            <select class="form__field form__select">
              <option selected value>Choose topic*</option>
              <option value=1>Pricing</option>
             
            </select>
            </div>
           <div class="form-group">
             <div class="form__field--half">
            <input type="text" placeholder="Name*" class="form__field form__text"></input>
             </div>
          <div class="form__field--half">
          <input type="text" placeholder="Surname" class="form__field form__text"></input>
          </div>
          </div>
      
        <div class="form-group">
          <div class="form__field--half">
            <input type="text" placeholder="Email address*" class="form__field form__text"></input>
          </div>
         <div class="form__field--half">
          <input type="text" placeholder="Phone number" class="form__field form__text"></input>
    </div>
          </div>
  
          <div class="form-group">
            <textarea type="text" placeholder="Your messsage*" class="form__field form__textarea"></textarea>
            <button class="btn btn--up btn--width" type="submit">Submit</button>
          </div>
        </form>
      </div>   
<div class="col-md-1"></div>
    </div>
  </div>
</div>

<div class="sect sect--violet ">
  <img src="https://image.ibb.co/fWyVtb/path3762.png" class="career-img">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <h1 class="career_title">Oh! Your have digged our website in search for the new job?</h1>
        <h1 class="career_sub">We will pleased to have you onboard! Check open positions.</h1>
        <a href="#" class="btn btn--white btn--width">Careers</a>
      </div>
    </div>
  </div>
  
</div>

<footer class="footer">
  <div class="container">
    <div class="row">
      <div class="col-md-2 col-xs-6">
          
       <img src="../Images/ODS%20Soft%20logo_preview_rev_1.png" width="100px" /> 
          <h1 class="footer__title">ODS SOFT<span class="footer__light">.io</span></h1></div>
      <div class="col-md-10 col-xs-6 row--center">
        <div class="footer__social">
          <a href="#" class="footer__social-l">
            <img src="data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTguMS4xLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgdmlld0JveD0iMCAwIDYxMiA2MTIiIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDYxMiA2MTI7IiB4bWw6c3BhY2U9InByZXNlcnZlIiB3aWR0aD0iMTZweCIgaGVpZ2h0PSIxNnB4Ij4KPGc+Cgk8Zz4KCQk8cGF0aCBkPSJNNjEyLDExNi4yNThjLTIyLjUyNSw5Ljk4MS00Ni42OTQsMTYuNzUtNzIuMDg4LDE5Ljc3MmMyNS45MjktMTUuNTI3LDQ1Ljc3Ny00MC4xNTUsNTUuMTg0LTY5LjQxMSAgICBjLTI0LjMyMiwxNC4zNzktNTEuMTY5LDI0LjgyLTc5Ljc3NSwzMC40OGMtMjIuOTA3LTI0LjQzNy01NS40OS0zOS42NTgtOTEuNjMtMzkuNjU4Yy02OS4zMzQsMC0xMjUuNTUxLDU2LjIxNy0xMjUuNTUxLDEyNS41MTMgICAgYzAsOS44MjgsMS4xMDksMTkuNDI3LDMuMjUxLDI4LjYwNkMxOTcuMDY1LDIwNi4zMiwxMDQuNTU2LDE1Ni4zMzcsNDIuNjQxLDgwLjM4NmMtMTAuODIzLDE4LjUxLTE2Ljk4LDQwLjA3OC0xNi45OCw2My4xMDEgICAgYzAsNDMuNTU5LDIyLjE4MSw4MS45OTMsNTUuODM1LDEwNC40NzljLTIwLjU3NS0wLjY4OC0zOS45MjYtNi4zNDgtNTYuODY3LTE1Ljc1NnYxLjU2OGMwLDYwLjgwNiw0My4yOTEsMTExLjU1NCwxMDAuNjkzLDEyMy4xMDQgICAgYy0xMC41MTcsMi44My0yMS42MDcsNC4zOTgtMzMuMDgsNC4zOThjLTguMTA3LDAtMTUuOTQ3LTAuODAzLTIzLjYzNC0yLjMzM2MxNS45ODUsNDkuOTA3LDYyLjMzNiw4Ni4xOTksMTE3LjI1Myw4Ny4xOTQgICAgYy00Mi45NDcsMzMuNjU0LTk3LjA5OSw1My42NTUtMTU1LjkxNiw1My42NTVjLTEwLjEzNCwwLTIwLjExNi0wLjYxMi0yOS45NDQtMS43MjFjNTUuNTY3LDM1LjY4MSwxMjEuNTM2LDU2LjQ4NSwxOTIuNDM4LDU2LjQ4NSAgICBjMjMwLjk0OCwwLDM1Ny4xODgtMTkxLjI5MSwzNTcuMTg4LTM1Ny4xODhsLTAuNDIxLTE2LjI1M0M1NzMuODcyLDE2My41MjYsNTk1LjIxMSwxNDEuNDIyLDYxMiwxMTYuMjU4eiIgZmlsbD0iIzcyOTNiMyIvPgoJPC9nPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+Cjwvc3ZnPgo=" />
          </a>
          <a href="#" class="footer__social-l">
            <img src="data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTYuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgd2lkdGg9IjE2cHgiIGhlaWdodD0iMTZweCIgdmlld0JveD0iMCAwIDk2LjEyNCA5Ni4xMjMiIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDk2LjEyNCA5Ni4xMjM7IiB4bWw6c3BhY2U9InByZXNlcnZlIj4KPGc+Cgk8cGF0aCBkPSJNNzIuMDg5LDAuMDJMNTkuNjI0LDBDNDUuNjIsMCwzNi41Nyw5LjI4NSwzNi41NywyMy42NTZ2MTAuOTA3SDI0LjAzN2MtMS4wODMsMC0xLjk2LDAuODc4LTEuOTYsMS45NjF2MTUuODAzICAgYzAsMS4wODMsMC44NzgsMS45NiwxLjk2LDEuOTZoMTIuNTMzdjM5Ljg3NmMwLDEuMDgzLDAuODc3LDEuOTYsMS45NiwxLjk2aDE2LjM1MmMxLjA4MywwLDEuOTYtMC44NzgsMS45Ni0xLjk2VjU0LjI4N2gxNC42NTQgICBjMS4wODMsMCwxLjk2LTAuODc3LDEuOTYtMS45NmwwLjAwNi0xNS44MDNjMC0wLjUyLTAuMjA3LTEuMDE4LTAuNTc0LTEuMzg2Yy0wLjM2Ny0wLjM2OC0wLjg2Ny0wLjU3NS0xLjM4Ny0wLjU3NUg1Ni44NDJ2LTkuMjQ2ICAgYzAtNC40NDQsMS4wNTktNi43LDYuODQ4LTYuN2w4LjM5Ny0wLjAwM2MxLjA4MiwwLDEuOTU5LTAuODc4LDEuOTU5LTEuOTZWMS45OEM3NC4wNDYsMC44OTksNzMuMTcsMC4wMjIsNzIuMDg5LDAuMDJ6IiBmaWxsPSIjNzI5M2IzIi8+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPGc+CjwvZz4KPC9zdmc+Cg==" />
          </a>
          
           <a href="#" class="footer__social-l">
          <img src="data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTYuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgd2lkdGg9IjE2cHgiIGhlaWdodD0iMTZweCIgdmlld0JveD0iMCAwIDQzOC41MzMgNDM4LjUzMyIgc3R5bGU9ImVuYWJsZS1iYWNrZ3JvdW5kOm5ldyAwIDAgNDM4LjUzMyA0MzguNTMzOyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSI+CjxnPgoJPHBhdGggZD0iTTQwOS4xMzMsMTA5LjIwM2MtMTkuNjA4LTMzLjU5Mi00Ni4yMDUtNjAuMTg5LTc5Ljc5OC03OS43OTZDMjk1LjczNiw5LjgwMSwyNTkuMDU4LDAsMjE5LjI3MywwICAgYy0zOS43ODEsMC03Ni40Nyw5LjgwMS0xMTAuMDYzLDI5LjQwN2MtMzMuNTk1LDE5LjYwNC02MC4xOTIsNDYuMjAxLTc5LjgsNzkuNzk2QzkuODAxLDE0Mi44LDAsMTc5LjQ4OSwwLDIxOS4yNjcgICBjMCwzOS43OCw5LjgwNCw3Ni40NjMsMjkuNDA3LDExMC4wNjJjMTkuNjA3LDMzLjU5Miw0Ni4yMDQsNjAuMTg5LDc5Ljc5OSw3OS43OThjMzMuNTk3LDE5LjYwNSw3MC4yODMsMjkuNDA3LDExMC4wNjMsMjkuNDA3ICAgczc2LjQ3LTkuODAyLDExMC4wNjUtMjkuNDA3YzMzLjU5My0xOS42MDIsNjAuMTg5LTQ2LjIwNiw3OS43OTUtNzkuNzk4YzE5LjYwMy0zMy41OTYsMjkuNDAzLTcwLjI4NCwyOS40MDMtMTEwLjA2MiAgIEM0MzguNTMzLDE3OS40ODUsNDI4LjczMiwxNDIuNzk1LDQwOS4xMzMsMTA5LjIwM3ogTTIxOS4yNywzMS45NzdjNDcuMjAxLDAsODguNDEsMTUuNjA3LDEyMy42MjEsNDYuODJsLTMuNTY5LDQuOTkzICAgYy0xLjQyNywyLjAwMi00Ljk5Niw1Ljg1Mi0xMC43MDQsMTEuNTY1Yy01LjcwOSw1LjcwOC0xMS45NDMsMTEuMTM2LTE4LjY5OSwxNi4yNzRjLTYuNzYyLDUuMTQtMTUuOTQsMTAuOTkyLTI3LjU1NSwxNy41NTkgICBjLTExLjYxMSw2LjU2Ny0yMy45ODIsMTIuMzI4LTM3LjExNywxNy4yNzZjLTIxLjg4Ny00MC4zNTUtNDUuMjk2LTc2LjcwOS03MC4yMzEtMTA5LjA2NCAgIEMxOTAuMDU1LDMzLjc4NCwyMDQuODA1LDMxLjk3NywyMTkuMjcsMzEuOTc3eiBNNzIuNTI0LDEwMy4wNmMxOC4yNzEtMjMuMDI2LDQwLjUzNy00MC43Myw2Ni44MDYtNTMuMSAgIGMyMy42MDEsMzEuNDA1LDQ2LjgyLDY3LjM4MSw2OS42NjIsMTA3LjkyMWMtNTcuODYyLDE1LjIyNy0xMTUuNTMyLDIyLjg0MS0xNzMuMDE0LDIyLjgzOCAgIEM0Mi4wNzIsMTUxLjk4LDU0LjI1MywxMjYuMDkxLDcyLjUyNCwxMDMuMDZ6IE00NC41NCwyODYuNzk0Yy04LjM3Ni0yMS40MTItMTIuNTYzLTQzLjkyMy0xMi41NjMtNjcuNTI3ICAgYzAtMi42NjYsMC4wOTgtNC42NjUsMC4yODYtNS45OTZjNjguOTA1LDAsMTMyLjk1NS04Ljg0OCwxOTIuMTQ5LTI2LjU1M2M2LjA5MiwxMS44LDExLjEzNiwyMi4zNjQsMTUuMTMzLDMxLjY5MyAgIGMtMC43NzEsMC4zOC0xLjk5OSwwLjgwNi0zLjcxMywxLjI4M2MtMS43MTksMC40NzYtMi45NTMsMC44MDYtMy43MjEsMC45OTlsLTEwLjU2MSwzLjcxMSAgIGMtNy4yMzYsMi42NjYtMTYuNzA4LDcuMjM1LTI4LjQwOSwxMy43MDNjLTExLjcwNCw2LjQ3OC0yNC4xMjMsMTQuMTgyLTM3LjI1NywyMy4xM2MtMTMuMTM0LDguOTQ5LTI2LjY5NiwyMC43OTctNDAuNjg0LDM1LjU1MyAgIGMtMTMuOTksMTQuNzUtMjUuNzQzLDMwLjU5MS0zNS4yNiw0Ny41M0M2NC43MTMsMzI3LjM4MSw1Mi45MTQsMzA4LjIsNDQuNTQsMjg2Ljc5NHogTTIxOS4yNyw0MDYuNTYgICBjLTQ0LjU0LDAtODQuMzItMTQuMjc3LTExOS4zNDMtNDIuODI1bDQuMjgzLDMuMTQyYzYuNjYxLTE0LjY2LDE2LjQ2Mi0yOC43NDYsMjkuNDA4LTQyLjI1NyAgIGMxMi45NDQtMTMuNTExLDI1LjQxLTI0LjQxMywzNy40MDEtMzIuNjk1YzExLjk5MS04LjI3NCwyNS4wMjgtMTYuMDc3LDM5LjExNS0yMy40MTRjMTQuMDg0LTcuMzIzLDIzLjY5MS0xMS45OTEsMjguODM1LTEzLjk4MyAgIGM1LjE0LTEuOTk4LDkuMjMzLTMuNTcyLDEyLjI3OC00LjcxNmwwLjU2OC0wLjI4N2gwLjU3NWMxOC42NDcsNDguOTE2LDMxLjk3Nyw5Ni4zMTMsMzkuOTY4LDE0Mi4xODQgICBDMjY4Ljc1Niw0MDEuNjExLDI0NC4zOTcsNDA2LjU1NywyMTkuMjcsNDA2LjU2eiBNMzc2Ljg3NiwzMjAuNDc5Yy0xNC4wODYsMjEuNzk2LTMxLjY5NiwzOS44MzQtNTIuODE3LDU0LjEwNCAgIGMtNy44MS00My43NzYtMTkuOTg1LTg4LjQxNS0zNi41NDktMTMzLjkwMmMzNy44NzctNS45MDcsNzYuOC0zLjE0MiwxMTYuNzcxLDguMjc0ICAgQzQwMC4wOTIsMjc0Ljg0MSwzOTAuOTU1LDI5OC42ODcsMzc2Ljg3NiwzMjAuNDc5eiBNNDAzLjcwNiwyMTYuNjk4Yy0xLjkwMy0wLjM3OC00LjI4NS0wLjgxLTcuMTM5LTEuMjgzICAgYy0yLjg1NC0wLjQ3My02LjMzMS0xLjA0Ny0xMC40MjQtMS43MTNjLTQuMDg3LTAuNjY2LTguNjYyLTEuMjgzLTEzLjcwMi0xLjg1NWMtNS4wNDUtMC41NzEtMTAuNDIxLTEuMDkzLTE2LjEzNi0xLjU2OSAgIGMtNS43MDgtMC40NzgtMTEuOC0wLjg1NS0xOC4yNjgtMS4xNDNjLTYuNDc5LTAuMjg0LTEzLjA0Mi0wLjQyOC0xOS43MDUtMC40MjhjLTYuNjU2LDAtMTMuNjU3LDAuMTkzLTIwLjk4MSwwLjU3MSAgIGMtNy4zMjYsMC4zNzUtMTQuNDE0LDEuMDQ5LTIxLjI2NSwxLjk5OWMtMC41NzUtMC45NTMtMS4yODctMi41MjQtMi4xNDMtNC43MTRjLTAuODU1LTIuMTg3LTEuNDc5LTMuODU1LTEuODQ4LTQuOTk3ICAgYy0zLjYyMS03Ljk5NC03LjgxLTE3LjAzNi0xMi41NzMtMjcuMTIxYzEzLjEzNC01LjMzMywyNS42NTItMTEuNDY5LDM3LjU1NS0xOC40MThjMTEuODkyLTYuOTQ5LDIxLjQwMi0xMy4xMzEsMjguNTQ0LTE4LjU1NSAgIGM3LjEzOS01LjQzLDEzLjg5NS0xMS4xODgsMjAuMjctMTcuMjc3YzYuMzc5LTYuMDksMTAuNTEzLTEwLjMyMywxMi40MjMtMTIuNzAzYzEuOTA2LTIuMzg0LDMuNzEzLTQuNzE0LDUuNDI0LTYuOTk1bDAuMjg3LTAuMjg4ICAgYzI3Ljc4OCwzMy44OCw0MS45NzQsNzIuODk3LDQyLjUzOCwxMTcuMDU5TDQwMy43MDYsMjE2LjY5OHoiIGZpbGw9IiM3MjkzYjMiLz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8L3N2Zz4K" />
          </a>
          
          <a href="" class="footer__social-l">
            <img src="data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTYuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iQ2FwYV8xIiB4PSIwcHgiIHk9IjBweCIgd2lkdGg9IjE2cHgiIGhlaWdodD0iMTZweCIgdmlld0JveD0iMCAwIDQzMC4xMTcgNDMwLjExNyIgc3R5bGU9ImVuYWJsZS1iYWNrZ3JvdW5kOm5ldyAwIDAgNDMwLjExNyA0MzAuMTE3OyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSI+CjxnPgoJPHBhdGggaWQ9IkxpbmtlZEluIiBkPSJNNDMwLjExNywyNjEuNTQzVjQyMC41NmgtOTIuMTg4VjI3Mi4xOTNjMC0zNy4yNzEtMTMuMzM0LTYyLjcwNy00Ni43MDMtNjIuNzA3ICAgYy0yNS40NzMsMC00MC42MzIsMTcuMTQyLTQ3LjMwMSwzMy43MjRjLTIuNDMyLDUuOTI4LTMuMDU4LDE0LjE3OS0zLjA1OCwyMi40NzdWNDIwLjU2aC05Mi4yMTljMCwwLDEuMjQyLTI1MS4yODUsMC0yNzcuMzJoOTIuMjEgICB2MzkuMzA5Yy0wLjE4NywwLjI5NC0wLjQzLDAuNjExLTAuNjA2LDAuODk2aDAuNjA2di0wLjg5NmMxMi4yNTEtMTguODY5LDM0LjEzLTQ1LjgyNCw4My4xMDItNDUuODI0ICAgQzM4NC42MzMsMTM2LjcyNCw0MzAuMTE3LDE3Ni4zNjEsNDMwLjExNywyNjEuNTQzeiBNNTIuMTgzLDkuNTU4QzIwLjYzNSw5LjU1OCwwLDMwLjI1MSwwLDU3LjQ2MyAgIGMwLDI2LjYxOSwyMC4wMzgsNDcuOTQsNTAuOTU5LDQ3Ljk0aDAuNjE2YzMyLjE1OSwwLDUyLjE1OS0yMS4zMTcsNTIuMTU5LTQ3Ljk0QzEwMy4xMjgsMzAuMjUxLDgzLjczNCw5LjU1OCw1Mi4xODMsOS41NTh6ICAgIE01LjQ3Nyw0MjAuNTZoOTIuMTg0di0yNzcuMzJINS40NzdWNDIwLjU2eiIgZmlsbD0iIzcyOTNiMyIvPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+Cjwvc3ZnPgo=" />
          </a>
        </div>
      </div>
    </div>
  </div>
</footer>
</form>
</body>
</html>