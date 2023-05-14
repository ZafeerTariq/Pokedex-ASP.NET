<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokemonCard.aspx.cs" Inherits="PokedexBeta.src.components.PokmonCard" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<title></title>
</head>
<body>
	<div>
		<a style = "text-decoration: none; color: black;"
			href = "<%= ResolveUrl("../screens/PokemonInfoPage.aspx") + "?id=" + localPokemon.id%>"
			class = "pokemon-card">
			<img id = "imgBox" class = "pokemon-image" src = "" runat = "server" />
			<div class = "pokedex-info">
				<p class = "pokemon-id" runat = "server"><%= localPokemon.pokedexID %></p>
				<p class = "pokemon-name" runat = "server"><%= Helper.firstCharToUpper(localPokemon.name) %></p>
				<% foreach (PokemonType type in localPokemon.types) { %>
					<p class = "<%= "pokemon-type pokemon-type--" + type.name %>"><%= Helper.firstCharToUpper(type.name) %></p>
				<% } %>
			</div>
			<div class = "stats">
				<p class = "stats-text"><%= localPokemon.getStatTotal() %></p>
				<p class = "stats-text"><%= localPokemon.hp %></p>
				<p class = "stats-text"><%= localPokemon.attack %></p>
				<p class = "stats-text"><%= localPokemon.defence %></p>
				<p class = "stats-text"><%= localPokemon.speed %></p>
				<p class = "stats-text"><%= localPokemon.sp_attack %></p>
				<p class = "stats-text"><%= localPokemon.sp_defence %></p>
			</div>
		</a>
	</div>
</body>
</html>