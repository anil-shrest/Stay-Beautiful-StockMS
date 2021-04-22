<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="StayBeautifulSMS.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to Design Login & Registration Form Transition</title>
	<meta charset="UTF-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" type="text/css" href="Content/login.css"/>
  <link href="https://fonts.googleapis.com/css?family=Nunito:400,600,700,800&display=swap" rel="stylesheet"/>
</head>
<body>
  <div class="cont">
    <div class="form sign-in">
      <h2>Sign In</h2>
        <form id="signin_form" runat="server">
      <label>
        <span>Email Address</span>
        <input id="txtEmail" type="email" name="email" runat="server"/>
      </label>
      <label>
        <span>Password</span>
        <input id="txtPassword" type="password" name="password" runat="server"/>
      </label>
      <button class="submit" id="btnSignIn" runat="server" onserverclick="btnSignIn_ServerClick" type="button">Sign In</button>
   <p class="forgot-pass">Forgot Password ?</p>

      <div class="social-media">
        <ul>
          <li><img src="Assets/facebook.png"/></li>
          <li><img src="Assets/twitter.png"/></li>
          <li><img src="Assets/linkedin.png"/></li>
          <li><img src="Assets/instagram.png"/></li>
        </ul>
      </div>
    </div>

    <div class="sub-cont">
      <div class="img">
        <div class="img-text m-up">
          <h2>New here?</h2>
          <p>Sign up and discover great amount of new opportunities!</p>
        </div>
        <div class="img-text m-in">
          <h2>One of us?</h2>
          <p>If you already has an account, just sign in. We've missed you!</p>
        </div>
        <div class="img-btn">
          <span class="m-up">Sign Up</span>
          <span class="m-in">Sign In</span>
        </div>
      </div>
      <div class="form sign-up">
        <h2>Sign Up</h2>
        <label>
          <span>Name</span>
          <input type="text" id="txtSignUpName" runat="server"/>
        </label>
          <label>
          <span>Address</span>
          <input type="text" id="txtSignUpAddress" runat="server"/>
        </label>
          <label>
          <span>Contact</span>
          <input type="text" id="txtSignUpContact" runat="server"/>
        </label>
          <label>
          <span>Username</span>
          <input type="text" id="txtSignUpUsername" runat="server"/>
        </label>
        <label>
          <span>Email</span>
          <input type="email" id="txtSignUpEmail" runat="server"/>
        </label>
        <label>
          <span>Password</span>
          <input type="password" id="txtSignUpPassword1" runat="server"/>
        </label>
        <label>
          <span>Confirm Password</span>
          <input type="password" id="txtSignUpPassword2" runat="server"/>
        </label>
        <button type="button" id="signupBtn" runat="server" onclass="submit" onserverclick="signupBtn_ServerClick">Sign Up Now</button>
              </form>
      </div>
    </div>
  </div>
<script type="text/javascript" src="Scripts/login.js"></script>
</body>
</html>
