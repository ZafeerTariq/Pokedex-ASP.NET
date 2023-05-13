<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokemonInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.info" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="~/src/css/PokemonInfoPage.css"/>
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h1><%= Helper.firstCharToUpper(localPokemon.name) %></h1>
			<hr />
			<div class = "container">
				<img src = "<%= localPokemon.imageURL %>" alt="UNABLE TO LOAD PIC" />
				<div class = "info-container">

					<div class = "pokedex-data-container">
						<h2>Pokedex data</h2>
						<div class = "pokedex-data-template">
							<div class = "template">
								<p>Pokedex No</p>
								<p class = "type-text">Type</p>
								<p>Height</p>
								<p>Weight</p>
								<p>Abilities</p>
							</div>
							<div>
								<p><%= localPokemon.pokedexID %></p>
								<div class = "types-container">
									<% foreach (PokemonType type in localPokemon.types) { %>
										<a class = "<%= "type-button type-" + type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + type.name%>">
											<%= Helper.firstCharToUpper(type.name) %>
										</a>
									<% } %>
								</div>
								<p><%= localPokemon.height %></p>
								<p><%= localPokemon.weight %></p>
								<div class = "ability-container">
									<% foreach (PokemonAbility ability in localPokemon.abilities) { %>
										<% if (ability.isHidden) { %>
											<a class = "ability-button" href = "<%= ResolveUrl("../screens/AbilityInfoPage.aspx") + "?name=" + ability.ability.name %>">
												<%= Helper.firstCharToUpper(ability.ability.name) + "(Hidden)"%>
											</a>
										<% } else { %>
											<a class = "ability-button" href = "<%= ResolveUrl("../screens/AbilityInfoPage.aspx") + "?name=" + ability.ability.name %>">
												<%= Helper.firstCharToUpper(ability.ability.name) %>
											</a>
										<% } %>
									<% } %>
								</div>
							</div>
						</div>
					</div>

					<hr />

					<div class = "training-data-container">
						<h2>Training</h2>
						<div class = "training-data-template">
							<div class = "template">
								<p>Catch Rate</p>
								<p>Growth Rate</p>
								<p>Base Happiness</p>
								<p>Base Experience</p>
								<p>Egg Cycles</p>
							</div>
							<div>
								<p><%= localPokemon.catchRate %></p>
								<p><%= localPokemon.growthRate.name %></p>
								<p><%= localPokemon.baseHappiness %></p>
								<p><%= localPokemon.baseExperience %></p>
								<p><%= localPokemon.eggCycles %></p>
							</div>
						</div>
					</div>
				</div>
			</div>

			<br />
			
			<div class = "some-container">
				<div>
					<h2>Base Stats</h2>
					<div class = "stats-container">
						<div class = "template">
							<p> Attack = <%= localPokemon.attack %></p>
							<p> HP : <%= localPokemon.hp %></p>
							<p> Defence = <%= localPokemon.defence %></p>
							<p> Speed : <%= localPokemon.speed %></p>
							<p> Sp. Attack = <%= localPokemon.sp_attack %></p>
							<p> Sp. Defence = <%= localPokemon.sp_defence %></p>
						</div>
						<div class = "progress-continer">
							<progress value="<%= localPokemon.attack %>" max="190"></progress>
							<progress value="<%= localPokemon.hp %>" max="255"></progress>
							<progress value="<%= localPokemon.defence %>" max="250"></progress>
							<progress value="<%= localPokemon.speed %>" max="200"></progress>
							<progress value="<%= localPokemon.sp_attack %>" max="194"></progress>
							<progress value="<%= localPokemon.sp_defence %>" max="250"></progress>
						</div>
					</div>
				</div>

				<hr />

				<div>
					<h2>Pokedex Entry</h2>
					<p><%= localPokemon.pokedexEntry %></p>
				</div>
			</div>

			<br />

		<div class = "evolution-chain">
				<h2>Evolution Chain</h2>
<%--				<% for (int i = 0; i < localPokemon.evolvesFrom.Count(); i++) { %>
					<p><%= localPokemon.evolvesFromTriggers[i].Replace('_', ' ') %></p>
					<p><%= Helper.firstCharToUpper(localPokemon.evolvesFrom[i].name) %></p>
				<% } %>
				<% for (int i = 0; i < localPokemon.evolvesTo.Count(); i++) { %>
					<p><%= localPokemon.evolvesToTriggers[i].Replace('_', ' ') %></p>
					<p><%= Helper.firstCharToUpper(localPokemon.evolvesTo[i].name) %></p>
				<% } %>--%>
		</div>

			<br />

			<h2>Moves Learnt</h2>
				<div class = "moves-table">
					<div>
						<h3>Level Up</h3>
						<div class = "level-up-move-info">
							<h4>Level</h4>
							<h4>Name</h4>
							<h4>Type</h4>
							<% foreach (PokemonMove move in localPokemon.moves) { %>
								<% if (move.learnMethod == "level-up") { %>
									<p><%= move.learnAtLevel %></p>
									<p><%= Helper.firstCharToUpper(move.move.name) %></p>
									<a class = "<%= "type-button-moves type-" + move.move.type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + move.move.type.name%>">
										<%= Helper.firstCharToUpper(move.move.type.name) %>
									</a>
								<% } %>
							<% } %>
						</div>
					</div>
					<hr />
					<div>
						<h3>Machine</h3>
						<div class = "machine-move-info">
							<h4>Name</h4>
							<h4>Type</h4>
							<% foreach (PokemonMove move in localPokemon.moves) { %>
								<% if (move.learnMethod == "machine") { %>
									<p><%= Helper.firstCharToUpper(move.move.name) %></p>
									<a class = "<%= "type-button-moves type-" + move.move.type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + move.move.type.name%>">
										<%= Helper.firstCharToUpper(move.move.type.name) %>
									</a>
								<% } %>
							<% } %>
						</div>
					</div>
					<hr />
					<div>
						<h3>Egg Moves</h3>
						<div class = "machine-move-info">
							<h4>Name</h4>
							<h4>Type</h4>
							<% foreach (PokemonMove move in localPokemon.moves) { %>
								<% if (move.learnMethod == "egg") { %>
									<p><%= Helper.firstCharToUpper(move.move.name) %></p>
									<a class = "<%= "type-button-moves type-" + move.move.type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + move.move.type.name%>">
										<%= Helper.firstCharToUpper(move.move.type.name) %>
									</a>
								<% } %>
							<% } %>
						</div>
					</div>
				</div>

		</div>
	</form>
</body>
</html>
