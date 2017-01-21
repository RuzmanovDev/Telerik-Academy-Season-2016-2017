<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="Web_Controls.TicTacToe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="winner" runat="server"></h1>
    <asp:Table ID="Field" runat="server" Height="103px" Width="130px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button0" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Button1" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell><asp:TableCell>
                <asp:Button ID="Button2" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button3" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Button4" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell><asp:TableCell>
                <asp:Button ID="Button5" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button6" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Button7" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell><asp:TableCell>
                <asp:Button ID="Button8" runat="server" Text=" " CssClass="btn btn-default" OnClick="Button0_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
