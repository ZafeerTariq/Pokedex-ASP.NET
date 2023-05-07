﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokemonCard.aspx.cs" Inherits="PokedexBeta.src.components.PokmonCard" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<title></title>
</head>
<body>
	<div>
		<a style = "text-decoration: none; color: black;" href = "../screens/PokemonInfoPage.aspx" class = "pokemon-card">
			<img id = "imgBox" class = "pokemon-image" src = "" runat = "server" />
			<p class = "pokemon-id" runat = "server"><%= localPokemon.pokedexID %></p>
			<p class = "pokemon-name" runat = "server"><%= localPokemon.name %></p>
			<% foreach (PokemonType type in localPokemon.types) { %>
				<p class = "<%= "pokemon-type pokemon-type--" + type.name %>"><%= type.name %></p>
			<% } %>
		</a>
	</div>
</body>
</html>