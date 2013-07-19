<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AellaData.AellaData" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
           <%= DateTime.Now.ToString() %> 
        </div>
        <div style="float:left">
            Raw
            <asp:GridView runat="server" ID="Camscores" AutoGenerateColumns="true" EnableViewState="false" />
        </div>
        <div style="float:left; margin-left:2em">
            Grouped
            <asp:GridView runat="server" ID="CamscoresGrouped" EnableViewState="false" />
        </div>
    </div>
    </form>
</body>
</html>
