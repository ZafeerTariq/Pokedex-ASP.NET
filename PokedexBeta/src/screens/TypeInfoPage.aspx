<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.TypeInfoPage" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="~/src/css/TypeInfoPage.css" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<header>
				<a class = "header-buttons" href = "HomePage.aspx">Return Home</a>
				<a class = "header-buttons" href = "FavouritesPage.aspx">Favourites List</a>
				<% if (Pokedex.loggedIn) { %>
					<asp:Button CssClass = "header-buttons" runat = "server" Text = "Log Out" OnClick = "Logout_Click" />
				<% } %>
			</header>
			<div class = "<%= "type-" + localType.name%>">
				<h1>
					<%= Helper.firstCharToUpper(localType.name) %>
				</h1>
			</div>
			<hr />
			<br />
			<div class = "stat-summary">
				<div class = "stat-summary-item">
					<span class = "stat-summary-count"><%= numberOfPokemon %></span>
					<br />
					<%= Helper.firstCharToUpper(localType.name) + "-type Pokemon "%>
				</div>
				<div class = "stat-summary-item">
					<span class = "stat-summary-count"><%= numberOfMoves %></span>
					<br />
					<%= Helper.firstCharToUpper(localType.name) + "-type Moves "%>
				</div>
			</div>

			<div class = "relations-grid">
				<div class = "grid-item">
					<h2>Atack Relations With Other Types</h2>
					<p class = "text">Super Effective On</p>
					<% foreach (PokemonType type in superEffectiveAttack) { %>
						<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
							<%= Helper.firstCharToUpper(type.name) %>
						</a>
					<% } %>

					<p class = "text">Not Very Effective On</p>
					<% foreach (PokemonType type in notVeryEffectiveAttack) { %>
						<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
							<%= Helper.firstCharToUpper(type.name) %>
						</a>
					<% } %>
					
					<p class = "text">No Effect On</p>
					<% foreach (PokemonType type in noEffectAttack) { %>
						<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
							<%= Helper.firstCharToUpper(type.name) %>
						</a>
					<% } %>
				</div>

				<div class = "grid-item">
					<h2>Defence Relations With Other Types</h2>	
					<p class = "text">Super Effective From</p>
					<% foreach (PokemonType type in superEffectiveDefence) { %>
						<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
							<%= Helper.firstCharToUpper(type.name) %>
						</a>
					<% } %>

					<p class = "text">Not Very Effective From</p>
					<% foreach (PokemonType type in notVeryEffectiveDefence) { %>
						<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
							<%= Helper.firstCharToUpper(type.name) %>
						</a>
					<% } %>
					
					<p class = "text">No Effect From</p>
					<% foreach (PokemonType type in noEffectDefence) { %>
						<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
							<%= Helper.firstCharToUpper(type.name) %>
						</a>
					<% } %>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
