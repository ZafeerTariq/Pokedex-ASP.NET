<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PokedexBeta.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    h1 {
        text-align : center
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Complete Pokedex</h1>
            <asp:Button ID = "button1" CssClass = "buttonCSS" runat = "server" Text = "Load Growth Rates" OnClick = "Load_Growth_Rate" />
            <br />
            <asp:Button ID = "button2" CssClass = "buttonCSS" runat = "server" Text = "Load Types" OnClick = "Load_Types" />
            <br />
            <asp:Button ID = "button3" CssClass = "buttonCSS" runat = "server" Text = "Load Pokemon" OnClick = "Load_Pokemon" />
            <br />
            <asp:Label ID = "label1" runat = "server" Text = ""/>
        </div>
    </form>
</body>
</html>
