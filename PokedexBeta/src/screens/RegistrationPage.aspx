<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="PokedexBeta.src.screens.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>  
	<form id="form1" runat="server">  
		<div>
			<h1>Register</h1>
			<table class="auto-style1">  
				<tr>  
					<td>First Name :</td>  
					<td>  
						<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
					</td>  
					<td>Last Name :</td>  
					<td>  
						<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>  
					</td> 
					<td>Username :</td>  
					<td>  
						<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>  
					</td> 
  
			   </tr>  
				<tr>  
					<td>Password</td>  
					 <td> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>  
				</tr>  
				<tr>  
					<td>Confirm Password</td>  
					<td>  
						<asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>  
					</td>  
					<td>Address :</td>  
					<td>  
						<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>  
					</td> 
					<td>Phone :</td>  
					<td>  
						<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>  
					</td> 
				</tr>  
				<tr>  
				</tr>  
				<tr>  
					<td>Gender</td>  
					<td>  
						<asp:RadioButtonList ID="RadioButtonList1" runat="server">  
							<asp:ListItem>Male</asp:ListItem>  
							<asp:ListItem>Female</asp:ListItem>  
						</asp:RadioButtonList>  
					</td>  
			   </tr>  
				<tr>  
					<td>Gmail</td>  
					<td>  
						<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  
					</td>  
				</tr>  
				<tr>  
					<td>  
						<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
					</td>  
				</tr>  
			</table>  
		</div>  
	</form>  
</body>  
</html>
