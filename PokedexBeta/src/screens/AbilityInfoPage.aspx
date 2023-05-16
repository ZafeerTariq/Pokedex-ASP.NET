<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbilityInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.AbilityInfoPage" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/src/css/AbilityInfoPage.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<header>
				<a class = "header-buttons" href = "HomePage.aspx">Return Home</a>
				<a class = "header-buttons" href = "FavouritesPage.aspx">Favourites List</a>
				<% if (Pokedex.loggedIn) { %>
					<asp:Button CssClass = "header-buttons" runat = "server" Text = "Log Out" OnClick = "Logout_Click" />
				<% } %>
		</header>
        
		<h1><%= Helper.firstCharToUpper(localAbility.name) %></h1>
        <hr />
        <h2>Description :</h2>
        <p class = "description"><%= localAbility.description %></p>
		<br />
        <h2 style= "text-align: center;">Pokemon With <%= Helper.firstCharToUpper(localAbility.name) %></h2>
        <div class = "pokemon-list">
				<% foreach (Pokemon poke in pokemon) { %>
					<div class = "pokemon-card">
						<img src = "<%= poke.imageURL %>"/>
						<div>
							<a class = "pokemon-card-text" href = "<%= ResolveUrl("../screens/PokemonInfoPage.aspx") + "?id=" + poke.id %>">
								<%= Helper.firstCharToUpper(poke.name) %>
							</a>
							<div class = "types">
								<% foreach (PokemonType type in poke.types) { %>
									<a class = "pokemon-card-text" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name %>">
										<%= Helper.firstCharToUpper(type.name) %>
									</a>
								<% } %>
							</div>
						</div>
					</div>
				<% } %>
			</div>
    </form>
</body>
</html>
