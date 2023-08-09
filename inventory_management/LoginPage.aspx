<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="inventory_management.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css-js/StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

    <link href="css-js/style.css" rel="stylesheet" />
    <div class="regcontainer" style="width:530px">
        <div class="left-column">
           
            <div class="login-section">
                <br />
                <br />
                <h2>Login with Social Media</h2>
                
                <br />
                <div class="social-buttons">
                    <button class="google-button">
                        <img class="google-logo" src="../images/glogo.png" alt="Google Logo" />
                        Login with Google
                    </button>
                    <button class="fb-button">
                        <img class="fb-logo" src="../images/fblogo.png" alt="Facebook Logo" />
                        Login with Facebook
                    </button>
                </div>
            </div>
        </div>
        <div class="registration-form">
            <reg>Login</reg>
           
            <div class="form-group">
                <asp:TextBox type="email" ID="email" runat="server" class="textbox" placeholder="Enter Email" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox type="password" ID="password" runat="server" class="textbox" TextMode="Password" placeholder="Enter Password" Required="true"></asp:TextBox>
            </div>
            
           
           
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" CssClass="register-button" Text="Login" OnClick="Button1_Click"  />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            </div>
            <asp:Label ID="errorMessage" runat="server" CssClass="error-message" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </div>
        </div>
    </form>
</body>
</html>
