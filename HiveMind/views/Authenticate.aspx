<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authenticate.aspx.cs" Inherits="HiveMind.View.Login" %>

<%--<%@ Register Src="../user-defined-control/ToastNotification.ascx" TagName="ToastNotification" TagPrefix="uc1" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>HiveMind</title>

    <%--Fonts--%>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Ubuntu:wght@300;400;500;700&display=swap" rel="stylesheet" />

    <%--Stylesheet--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/color.css"%>" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/utils.css"%>" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/main.css"%>" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/pages/Login.css"%>" />

    <%--Scripts--%>
    <%--bootstrap--%>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-Fy6S3B9q64WdZWQUiU+q4/2Lc9npb8tCaSX9FK7E8HnRr0Jz8D6OP9dO5Vg3Q9ct" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server" class="login-page h-min-100-vh row w-100 m-0 p-0">
        <asp:PlaceHolder ID="ToastHolder" runat="server"></asp:PlaceHolder>
        <div class="content-panel col-12 col-lg-6 px-0 px-md-5 py-5 d-flex justify-content-between flex-column">
            <header class="px-3 px-md-0">
                <span id="logo" class="h1 font-weight-bold"><span>Hive</span>Mind</span>
            </header>

            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="LogInView" runat="server">
                    <main>
                        <div class="welcome-banner container d-flex flex-column mt-2 mb-5">
                            <h3 class="h2 d-inline mb-0 mt-5 pb-0 text-center">Welcome Back</h3>
                            <p class="d-inline-block text-center">Please Enter Your Details</p>
                        </div>
                        <div class="container mt-0 mb-5 w-lg-75">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailValidator" runat="server" ErrorMessage="Please enter your email" ControlToValidate="Email" ForeColor="Red" Display="Dynamic" ValidationGroup="LogInValidator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="EmailPatternValidator" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="Email" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="LogInValidator"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="Please enter your password" ControlToValidate="Password" ForeColor="Red" Display="Dynamic" ValidationGroup="LogInValidator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="PasswordPatternValidator" runat="server" ErrorMessage="Password must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters" ControlToValidate="Password" ForeColor="Red" Display="Dynamic" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$" ValidationGroup="LogInValidator"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group d-flex justify-content-between flex-column flex-md-row">
                                <div class="d-flex align-items-center">
                                    <asp:CheckBox ID="RememberMe" runat="server" CssClass="m-0 p-0" />
                                    <label class="cust-checkbox-label m-0 pl-2" for="RememberMe">Remember me</label>
                                </div>
                                <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Forgot Password?" CssClass="cust-btn-link cust-txt-primary font-weight-bold" OnCommand="InternalPageChangeCommand" CommandName="pageNumber" CommandArgument="2" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="LogInButton" runat="server" Text="Log In" CssClass="btn btn-block cust-btn-primary" ValidationGroup="LogInValidator" OnClick="LogInEventHandler" />
                            </div>
                            <div class="form-group d-flex justify-content-center">
                                Don't Have Account?
                                <asp:Button ID="AuthenticateSignUp" runat="server" EnableTheming="True" Text="Sign Up" CssClass="cust-btn-link cust-txt-primary font-weight-bold" OnCommand="InternalPageChangeCommand" CommandName="pageNumber" CommandArgument="1" />
                            </div>
                        </div>
                    </main>
                </asp:View>
                <asp:View ID="RegisterView" runat="server">
                    <main>
                        <div class="join-us-banner container d-flex flex-column mt-2 mb-5">
                            <h3 class="h2 d-inline mb-0 mt-5 pb-0 text-center">Join Us Today!</h3>
                            <p class="d-inline-block text-center">Sign Up to connect with 13000+ active communities thoughout the globe</p>
                        </div>
                        <div class="container mt-0 mb-5 w-lg-75">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:TextBox ID="RegisterName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredRegisterName" runat="server" ErrorMessage="Please enter your name" ControlToValidate="RegisterName" ForeColor="Red" Display="Dynamic" ValidationGroup="SignUpValidator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RequiredRegisterNamePatternValidator" runat="server" ErrorMessage="Not a valid name" ControlToValidate="RegisterName" ForeColor="Red" Display="Dynamic" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="SignUpValidator"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="RegisterEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredRegisterEmail" runat="server" ErrorMessage="Please enter an email" ControlToValidate="RegisterEmail" ForeColor="Red" Display="Dynamic" ValidationGroup="SignUpValidator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegisterEmailPatternValidator" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="RegisterEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SignUpValidator"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Create Password</label>
                                <asp:TextBox ID="RegisterPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredRegisterPassword" runat="server" ErrorMessage="Please enter a password" ControlToValidate="RegisterPassword" ForeColor="Red" Display="Dynamic" ValidationGroup="SignUpValidator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegisterPasswordPatternValidator" runat="server" ErrorMessage="Password must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters" ControlToValidate="RegisterPassword" ForeColor="Red" Display="Dynamic" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$" ValidationGroup="SignUpValidator"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Confirm Password</label>
                                <asp:TextBox ID="RegisterConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredRegisterConfirmPassword" runat="server" ErrorMessage="Please re-enter password" ControlToValidate="RegisterConfirmPassword" ForeColor="Red" Display="Dynamic" ValidationGroup="SignUpValidator"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="RegisterConfirmPasswordEqualPasswordValidator" runat="server" ErrorMessage="Password and Confirm Password are not Equal" ForeColor="Red" ControlToValidate="RegisterConfirmPassword" ControlToCompare="RegisterPassword" Display="Dynamic" ValidationGroup="SignUpValidator"></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" CssClass="btn btn-block cust-btn-primary" ValidationGroup="SignUpValidator" OnClick="SignUpEventHandler" />
                            </div>
                            <div class="form-group d-flex justify-content-center">
                                Already have an account?
                                <asp:Button ID="RegisterLogIn" runat="server" EnableTheming="True" Text="Log In" CssClass="cust-btn-link cust-txt-primary font-weight-bold" OnCommand="InternalPageChangeCommand" CommandName="pageNumber" CommandArgument="0" />
                            </div>
                        </div>
                    </main>
                </asp:View>
                <asp:View ID="ForgotPassword" runat="server">
                    <main>
                        <div class="forgot-password-banner container d-flex flex-column mt-2 mb-5">
                            <h3 class="h2 d-inline mb-0 mt-5 pb-0 text-center">Forgot Password?</h3>
                            <p class="d-inline-block text-center">Enter your Email. A link will be sent to your Email for Password Reset</p>
                        </div>
                        <div class="container mt-0 mb-5 w-lg-75">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="ForgotEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredForgotEmail" runat="server" ErrorMessage="Please enter an email" ControlToValidate="ForgotEmail" ForeColor="Red" Display="Dynamic" ValidationGroup="ForgotPasswordValidator"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="ForgotEmailPatternValidator" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="ForgotEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ForgotPasswordValidator"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="GenerateEmail" runat="server" Text="Generate Email" CssClass="btn btn-block cust-btn-primary" ValidationGroup="ForgotPasswordValidator" OnClick="GeneratePasswordChangeEmail_Click" />
                            </div>
                            <div class="text-center font-weight-bold">
                                or
                            </div>
                            <div class="form-group d-flex justify-content-center my-3">
                                Already have an account?
                                <asp:Button ID="ForgotLogIn" runat="server" EnableTheming="True" Text="Log In" CssClass="cust-btn-link cust-txt-primary font-weight-bold" OnCommand="InternalPageChangeCommand" CommandName="pageNumber" CommandArgument="0" />
                            </div>
                            <div class="form-group d-flex justify-content-center">
                                Don't Have Account?
                                <asp:Button ID="ForgotSignUp" runat="server" EnableTheming="True" Text="Sign Up" CssClass="cust-btn-link cust-txt-primary font-weight-bold" OnCommand="InternalPageChangeCommand" CommandName="pageNumber" CommandArgument="1" />
                            </div>
                        </div>
                    </main>
                </asp:View>
            </asp:MultiView>
            <footer class="px-3 px-md-0">
                <div>Privacy Policy</div>
            </footer>
        </div>
        <aside class="image-banner d-none  d-lg-block col-lg-6 p-0" style="background-image: url('<%=Request.ApplicationPath+"/asset/image/malik-skydsgaard-Bx_wZNbWT98-unsplash.jpg"%>');">
            <div class="image-banner-overlay"></div>
        </aside>
    </form>
    <script type="text/javascript" src="<%=Request.ApplicationPath+"/asset/javascript/master.js"%>"></script>
</body>
</html>
