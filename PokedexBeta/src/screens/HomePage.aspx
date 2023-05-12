<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PokedexBeta.WebForm1" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="~/src/css/HomePage.css" />
	<link rel="stylesheet" href="~/src/css/pokemon-card.css" />
	<title></title>
<style>
</style>
</head>
<body>
	<div>
		<form id = "form1" runat = "server">
		<div class = "header">
			<h1>Complete Pokedex</h1>
			<% if (Pokedex.loggedIn) { %>
				<p class = "welcomeText">Welcome <%= PokedexUser.username %></p>
				<asp:Button CssClass = "loginButton" runat = "server" Text = "Log Out" OnClick = "Logout_Click" />
			<% } %>
			<% else { %>
					<div class = "headerButtons">
						<a class = "loginButton" href = "<%= ResolveUrl("../screens/LoginPage.aspx") %>">Login</a>
						<a class = "loginButton" href = "<%= ResolveUrl("../screens/RegistrationPage.aspx") %>">Register</a>
					</div>
			<% } %>
		</div>
		<hr />
			<p style = "display: inline; font-size: 25px;">Type:</p>
			<asp:DropDownList onchange="this.form.submit()" ID = "typeList" class = "typesList" runat = "server"></asp:DropDownList>
		</form>
		<%
			string type = typeList.SelectedValue;
			if (type == "All") { 
				for (int i = 0; i < Pokedex.allPokemon.Count(); i++) {
					if (Pokedex.allPokemon[i].pokedexID < 10000) {
						HttpContext.Current.Items["localPokemon"] = Pokedex.allPokemon[i];
						Server.Execute("~/src/components/PokemonCard.aspx");
					}
					else
						break;
				}
			}
			else {
				for (int i = 0; i < Pokedex.allPokemon.Count(); i++) {
					if (Pokedex.allPokemon[i].pokedexID < 10000) {
						bool insert = false;
						foreach (PokemonType localType in Pokedex.allPokemon[i].types) {
							if (localType.name == type) { 
								insert = true;
								break;
							}
							else 
								insert = false;
						}
						if (insert) { 
							HttpContext.Current.Items["localPokemon"] =  Pokedex.allPokemon[i];
							Server.Execute("~/src/components/PokemonCard.aspx");
						}
					}
					else
						break;
				}
			}
		%>
	</div>
</body>
</html>
