<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="HelloWorld.HelloWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="EnterNameBtn" runat="server" Text="Show Greeting and ExecutingAssembly" OnClick="EnterNameBtn_Click" />
        </div>
        <p>
            <asp:Label ID="ExecutingAssemblyLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </p>
       
    </form>
</body>
</html>
