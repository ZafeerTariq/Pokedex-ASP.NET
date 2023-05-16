<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoveInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.MoveInfoPage" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="~/src/css/MoveInfoPage.css" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h1><%= Helper.firstCharToUpper(localMove.name) %></h1>
			<hr />
			<div class = "info">
				<div class = "move-info">
					<h2>Move Info</h2>
					<div class = "move-info-2">
						<div class = "move-info-template">
							<p class = "template-text">Type</p>
							<p class = "template-text">Power</p>
							<p class = "template-text">Accuracy</p>
							<p class = "template-text">pp</p>
							<p class = "template-text">Priority</p>
							<p class = "template-text">Effect Chance</p>
						</div>
						<div class = "move-info-data">
							<a class = "<%= "type-button type-" + localMove.type.name %>" href = "<%= ResolveUrl("../screens/TypeInfoPage.aspx") + "?name=" + localMove.type.name %>">
								<%= Helper.firstCharToUpper(localMove.type.name) %>
							</a>
							<% if (localMove.power == null) { %>
								<p>None</p>
							<% } else { %>
								<p><%= localMove.power %></p>
							<% } %>
							<% if (localMove.power == null) { %>
								<p>None</p>
							<% } else { %>
								<p><%= localMove.accuracy %></p>
							<% } %>
							<p><%= localMove.pp %></p>
							<p><%= localMove.priority %></p>
							<% if (localMove.effectChance == null) { %>
								<p>None</p>
							<% } else { %>
								<p><%= localMove.effectChance %></p>
							<% } %>
						</div>
					</div>
				</div>

				<hr />

				<div class = "move-effects">
					<h2>Effect</h2>
					<% if (localMove.effectChance != null) { %>
						<p class = "effect-description"><%= localMove.effectDescription %></p>
					<% } else { %>
						<p class = "effect-description">Move has no additional special effects.</p>
					<% } %>
					<h2>Description</h2>
					<p class = "effect-description"><%= localMove.description %></p>
				</div>
			</div>

			<hr />

			<h2 style = "text-align: center">Learnt By Pokemon</h2>
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
		</div>
	</form>
</body>
</html>
