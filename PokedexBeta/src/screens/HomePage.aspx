<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PokedexBeta.WebForm1" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="~/src/css/pokemon-card.css" />
	<title></title>
<style>
	h1 {
		text-align : center
	}
	form {
		text-align: center;
		font-size: 25px;
	}
	.typesList {
		border: 3px solid #0B2463;
		border-radius: 5px;
		padding: 3px;
		margin: 10px;
        text-align: center;
		width: 80px;
		height: 35px;
    }
</style>
</head>
<body>
	<div>
		<h1>Complete Pokedex</h1>
		<hr />
		<form id = "form1" runat = "server">
			<p style = "display: inline">Type:</p>
			<asp:DropDownList onchange="this.form.submit()" ID = "typeList" class = "typesList" runat = "server"></asp:DropDownList>
		</form>
		<%
			string type = typeList.SelectedValue;
			if (type == "All") { 
				for (int i = 0; i < pokemon.Count(); i++) {
					if (pokemon[i].pokedexID < 10000) {
						HttpContext.Current.Items["localPokemon"] = pokemon[i];
						Server.Execute("~/src/components/PokemonCard.aspx");
					}
					else
						break;
				}
			}
			else {
				for (int i = 0; i < pokemon.Count(); i++) {
					if (pokemon[i].pokedexID < 10000) {
						bool insert = false;
						foreach (PokemonType localType in pokemon[i].types) {
							if (localType.name == type) { 
								insert = true;
								break;
							}
							else 
								insert = false;
                        }
						if (insert) { 
							HttpContext.Current.Items["localPokemon"] = pokemon[i];
							Server.Execute("~/src/components/PokemonCard.aspx");
						}
					}
					else
						break;
				}
			}
		%>
	</div>
</body>
</html>
