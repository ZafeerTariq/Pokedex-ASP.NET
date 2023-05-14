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
			<div class = "heading">
				<h1>Complete Pokedex</h1>
				<% if (Pokedex.loggedIn) { %>
					<p class = "welcomeText">Welcome <%= PokedexUser.username %></p>
					<asp:Button CssClass = "loginButton" runat = "server" Text = "Log Out" OnClick = "Logout_Click" />
				<% } %>
				<% else { %>
						<div class = "headingButtons">
							<a class = "loginButton" href = "<%= ResolveUrl("../screens/LoginPage.aspx") %>">Login</a>
							<a class = "loginButton" href = "<%= ResolveUrl("../screens/RegistrationPage.aspx") %>">Register</a>
						</div>
				<% } %>
			</div>
			<hr />
			<p style = "display: inline; font-size: 25px;">Type:</p>
			<asp:DropDownList onchange="this.form.submit()" ID = "typeList" class = "typesList" runat = "server"></asp:DropDownList>
			<header>
				<p>ID</p>
				<p>Name</p>
				<p>Type</p>
				<p>Total</p>
				<p>HP</p>
				<p>Attack</p>
				<p>Defence</p>
				<p>Speed</p>
				<p>Sp_Attack</p>
				<p>Sp_Defence</p>
			</header>
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

	<script>
		stickyElem = document.querySelector("header");
     
		/* Gets the amount of height
		of the element from the
		viewport and adds the
		pageYOffset to get the height
		relative to the page */
		currStickyPos = stickyElem.getBoundingClientRect().top + window.pageYOffset;
		window.onscroll = function() {
         
			/* Check if the current Y offset
			is greater than the position of
			the element */
			if(window.pageYOffset > currStickyPos) {
				stickyElem.style.position = "fixed";
				stickyElem.style.top = "0";
			} else {
				stickyElem.style.position = "relative";
				stickyElem.style.top = "initial";
			}
		}
    </script>

</body>
</html>
