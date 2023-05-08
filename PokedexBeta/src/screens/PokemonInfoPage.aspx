<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokemonInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.PokemonInfoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h1><%= localPokemon.name %></h1>
		</div>
	</form>
</body>
</html>
