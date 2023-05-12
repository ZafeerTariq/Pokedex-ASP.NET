<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.TypeInfoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="~/src/css/TypeInfoPage.css" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h1><%= localType.name %></h1>
		</div>
	</form>
</body>
</html>
