<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="PokedexBeta.src.screens.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/src/css/RegistrationPage.css" />
    <title></title>
</head>
<body background ="../images/signup.png" style = "background-size: 100%">  
    <form id="form1" runat="server">  
        <div>  
            <table class="auto-style1">  
                <tr>  
                    <td>  
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="firstname" placeholder="Firstname"></asp:TextBox>
                    </td>  
                    
                    <td>  
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="lastname" placeholder="Lastname"></asp:TextBox>  
                    </td> 
                    <td>  
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="username" placeholder="Username"></asp:TextBox>  
                    </td> 

  
               </tr>  
                <tr>  
                    
                     <td> <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="password" placeholder="Password"></asp:TextBox></td>  
                </tr>  
                <tr>  
                   <td>  
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="confirmpassword" placeholder="Confirm Password"></asp:TextBox>  
                    </td>  
                   
                    <td>  
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="address" placeholder ="Address"></asp:TextBox>  
                    </td>
                    <td>  
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="phone" placeholder="Contact Number"></asp:TextBox>  
                    </td> 
                </tr>  
                <tr>  
                </tr>  
                <tr> 
                    <td class ="genderlbl">Gender</td>
                    <td>  
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="gender" placehoder ="Gender">  
                            <asp:ListItem>Male</asp:ListItem>  
                            <asp:ListItem>Female</asp:ListItem>  
                        </asp:RadioButtonList>  
                    </td>  
               </tr>  
                <tr>  
                   <td>  
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="mail" placeholder="Mail"></asp:TextBox>  
                    </td>  
                </tr>  
               <tr>  
                    <td>  
                        <asp:Label ID ="label1" runat="server" CssClass="auth"></asp:Label>
                        <asp:button id="button1" runat="server" text="Sign Up" onclick="Button1_Click" CssClass="button"/>
                    </td>  
                </tr> 
            </table>  
        </div>  
    </form>  
</body>  
</html>
