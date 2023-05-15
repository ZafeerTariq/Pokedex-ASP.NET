<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbilityInfoPage.aspx.cs" Inherits="PokedexBeta.src.screens.AbilityInfoPage" %>
<%@ Import Namespace = "PokedexBeta.src.models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/src/css/AbilityInfoPage.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1> <%= Helper.firstCharToUpper(localAbility.name) %> </h1>
        <hr />
        <br  />
        <h2> Description : </h2>
        <div class = "descriptionContainer">
            <h2> <%= localAbility.description %></h2>
            <br  />
        </div>
        <hr />
        <br />
    </form>
</body>
</html>
