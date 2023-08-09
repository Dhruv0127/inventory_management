<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="inventory_management.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css-js/StyleSheet1.css" rel="stylesheet" />
    <div class="regcontainer">
        <div class="left-column">
            <div class="about-us">
                <br />
                <h2>About Us</h2>
                <p>
                    Welcome to our registration platform. We strive to provide a
                    seamless and user-friendly experience for all our users.
                </p>
                <br />
                <br />
                <br />
            </div>
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
            <reg>Register</reg>
            <div class="form-group">
                <asp:TextBox type="text" ID="username" runat="server" class="textbox" placeholder="Enter Username" Required="true" Width="1977px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox type="email" ID="email" runat="server" class="textbox" placeholder="Enter Email" Required="true" Width="1827px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox type="password" ID="password" runat="server" class="textbox" TextMode="Password" placeholder="Enter Password" Required="true" Width="2007px"></asp:TextBox>
            </div>
            <div class="form-group">
                <maingen ID="lblDateOfBirth"> Date of birth</maingen>
                <asp:TextBox type="date" ID="dateOfBirth" runat="server" class="textbox" placeholder="Date of Birth" Required="true" Width="2031px"></asp:TextBox>
            </div>
                <div>
                    <asp:Button class="register-button"  ID="Button1" runat="server" OnClick="btnRegister_Click" Text="Button" />
                </div>
            <div class="form-group">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

