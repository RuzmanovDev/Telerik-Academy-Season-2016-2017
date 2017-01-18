<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumatoraspx.aspx.cs" Inherits="SimpleWebFormsSumator.Sumatoraspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="FirstNumber" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="SecondNumber" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SumBtn" runat="server" Text="Sum" OnClick="SumBtn_Click" />
        </p>
        <p>
            <asp:Label ID="Result" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
