<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FavouritesPage.aspx.cs" Inherits="PokedexBeta.src.screens.FavouritesPage" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/src/css/FavouritesPage.css" />
	<link rel="stylesheet" href="~/src/css/pokemon-card.css" />
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
            <h1>Favourites</h1>
            <hr />
            <%
                if (Pokedex.loggedIn) {
                    foreach (Pokemon poke in pokemon) {
                        HttpContext.Current.Items["localPokemon"] = poke;
                        Server.Execute("~/src/components/PokemonCard.aspx");
                    }
                }
                else { %>
                    <h2>You need to LogIn first</h2>
            <%    }
            %>
            <hr />
        </div>
    </form>
</body>
</html>
