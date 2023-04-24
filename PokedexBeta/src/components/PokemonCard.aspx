<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokemonCard.aspx.cs" Inherits="PokedexBeta.src.components.PokmonCard" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="../css/pokemon-card.css" />
    <title></title>
</head>
<body>
    <div class = "pokemon-card">
		<img id = "imgBox" class = "pokemon-image" src = "" runat = "server" />
		<a class = "pokemon-name" runat = "server"><%=localPokemon.name  %></a>
		<a class = "pokemon-type pokemon-type--grass" runat = "server"><%=localPokemon.type1.name%></a>
		<a class = "pokemon-type pokemon-type--poison" runat = "server"><%=localPokemon.type2.name%></a>
	</div>
</body>
</html>