<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PokedexBeta.WebForm1" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="src/css/pokemon-card.css" />
	<title></title>
<style>
	h1 {
		text-align : center
	}
</style>
</head>
<body>
	<div>
		<h1>Complete Pokedex</h1>
		<hr />
		<%
            for (int i = 0; i < pokemon.Count(); i++) {
                if (pokemon[i].pokedexID < 10000) {
                    HttpContext.Current.Items["localPokemon"] = pokemon[i];
                    Server.Execute("~/src/components/PokemonCard.aspx");
                }
                else
                    break;
            }
		%>
	</div>
</body>
</html>
