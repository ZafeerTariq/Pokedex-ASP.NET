<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PokedexBeta.src.screens.LockScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/src/css/LoginPage.css" />
    <style type="text/css">  
        .auto-style1 {  
            width: 100%;  
        }  
    </style>
</head>  

<asp:Label ID="Label4" runat="server" Font-Size="X-Large" CssClass="auth"></asp:Label> 

<body background = "../images/login.png" style="background-size: 100%">  
    <form id="form1" runat="server">  
    <div>  
      
        <table class="auto-style1">               
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label2" runat="server" CssClass="userlbl" text ="Username"></asp:Label>  
                </td>  
                
                <td style="text-align: center">  
                    <asp:TextBox ID="TextBox1" CssClass="usernamefield" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label3" runat="server" Text="Password" CssClass="pwdlbl"></asp:Label>  
                </td>  
                <td style="text-align: center"> 
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td> </td>  
                
                <td style="text-align: center">  
                    <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Button1_Click" Text="Log In" CssClass="button1"/>  
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="X-Large" TextMode="Password" CssClass="password" Text="Password"></asp:TextBox> 
                    <asp:Button ID="Button2" runat="server" BorderStyle="None" Font-Size="X-Large" Text="Register"  OnClick="Button2_Click" CssClass="button2"/>
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td> </td>  
                <td> 
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
        </table>  
      
    </div>  
    </form>  
</body>  
</html>
