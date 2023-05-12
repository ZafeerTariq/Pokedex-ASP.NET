<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokemonInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.PokemonInfoPage" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<link rel="stylesheet" type="text/css" href="~/src/css/PokemonInfoPage.css"/>
	<title></title>
	<style>
	</style>
</head>
<body>
	<form id="form1" runat="server">
		<h1><%= Helper.firstCharToUpper(localPokemon.name) %></h1>
		<img src = "<%= localPokemon.imageURL %>" alt="UNABLE TO LOAD PIC" />
		<br />
		<div class = "card">
			<div class = "pokedexInfoContainer">
				<h3>Pokedex data</h3>
				<div class = "templateContainer">
					<p class = "template"> Pokedex No. </p>
					<p class = "values" runat = "server"> <%= localPokemon.pokedexID %></p>
					
					<p class = "template"> Types </p>
					<div class = "<%= "typeContainer" + localPokemon.types.Count().ToString() %>">
						<% foreach (PokemonType type in localPokemon.types) { %>
							<a style = "text-decoration: none; color: black;"
							href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
								<p class = "type"><%= Helper.firstCharToUpper(type.name) %></p>
							</a>
						<% } %>
					</div>
					
					<p class = "template"> Height </p>
					<p class = "values" runat = "server"> <%= localPokemon.height %> meters </p>
					
					<p class = "template"> Weight </p>
					<p class = "values" runat = "server"> <%= localPokemon.weight %> kg </p> 
					
					<p class = "template"> Abilities </p>
					<div>
					<% foreach (PokemonAbility abil in localPokemon.abilities) { %>
						<a style = "text-decoration: none; color: black;"
						href = "<%= ResolveUrl("../screens/AbilityInfoPage.aspx") + "?name=" + abil.ability.name%>">
							<p class = "type"> <%= Helper.firstCharToUpper(abil.ability.name) %>
							<% if (abil.isHidden) { %>
								(Hidden)
							<% } %>
							</p>

						</a>
					<% } %>	
					</div>
				</div>			
			</div>
			<hr />
			<div class = "pokedexInfoContainer">
				<h3> Training </h3>
				<div class = "templateContainer">
					<p class = "template">Catch Rate</p>
					<p class = "values"> <%= localPokemon.catchRate %> </p>

					<p class = "template">Growth Rate</p>
					<p class = "values"> <%= localPokemon.growthRate.name %> </p>

					<p class = "template">Base Happiness</p>
					<p class = "values"> <%= localPokemon.baseHappiness %> </p>

					<p class = "template">Base Experience</p>
					<p class = "values"> <%= localPokemon.baseExperience %> </p>

					<p class = "template">Egg Cycles</p>
					<p class = "values"> <%= localPokemon.eggCycles %> </p>
				</div>
			</div>
		</div>

		<br />
		<br />
		<hr />
		
		<progress value="<%= localPokemon.attack %>" max="190"></progress>
		<h2> Attack = <%= localPokemon.attack %></h2>

		<progress value="<%= localPokemon.hp %>" max="255"></progress>
		<h2> HP : <%= localPokemon.hp %></h2>
			
		<progress value="<%= localPokemon.defence %>" max="250"></progress>
		<h2> Defence = <%= localPokemon.defence %></h2>

		<progress value="<%= localPokemon.speed %>" max="200"></progress>
		<h2> Speed : <%= localPokemon.speed %></h2>
			
		<progress value="<%= localPokemon.sp_attack %>" max="194"></progress>
		<h2> Sp. Attack = <%= localPokemon.sp_attack %></h2>

		<progress value="<%= localPokemon.sp_defence %>" max="250"></progress>
		<h2> Sp. Defence = <%= localPokemon.sp_defence %></h2>
	</form>
</body>
</html>
