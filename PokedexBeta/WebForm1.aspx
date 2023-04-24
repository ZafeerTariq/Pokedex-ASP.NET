<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PokedexBeta.WebForm1" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
<style>
	h1 {
		text-align : center
	}
	.pokemon-card {
		display: flex;
		align-items: center;
		background-color: #ffffff;
		border: 3px solid #0B2463;
		border-radius: 5px;
		padding: 10px;
		width: 1265px;
		height: 86px;
		position: relative;
		margin: 0 auto;
	}
	.pokemon-image {
		display: block;
		width: 89px;
		height: 85px;
		float: left;
		margin-right: 10px;
	}
	.pokemon-name {
		display: flex;
		align-items: center;
		font-size: 26px;
		border: 2px solid;
		border-radius: 5px;
		padding: 3px;
	}
	.pokemon-type {
		display: flex;
		align-items: center;
		font-size: 26px;
		border: 2px solid;
		border-radius: 5px;
		padding: 3px;
		margin-left: 5px;
	}
	.pokemon-type--grass {
		background-color: #339246
	}
	.pokemon-type--poison {
		background-color: #861e7a
	}
	.pokemon-stats {
		list-style: none;
		margin: 0;
		padding: 0;
		display: flex;
		justify-content: space-between;
	}
	.pokemon-stat {
		background-color: #eee;
		border: 1px solid #ccc;
		border-radius: 5px;
		padding: 5px;
		text-align: center;
		width: 30%;
	}
</style>
</head>
<body>
	<%
        HttpContext.Current.Items["localPokemon"] = pokemon[0];
	%>
	<div>
		<h1>Complete Pokedex</h1>
		<hr />
		<% Server.Execute("~/src/components/PokemonCard.aspx"); %>
	</div>
</body>
</html>
