<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="Web_Controls.RandomNumbers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <label>First Number</label>
    <asp:TextBox
        ID="LowerBoundTextBox"
        runat="server"
        CssClass="form-control"
        TextMode="Number"
        Width="300">
    </asp:TextBox>
    <label>Second Number</label>
    <asp:TextBox
        ID="UpperBoundTextBox"
        runat="server"
        CssClass="form-control"
        TextMode="Number"
        Width="300">
    </asp:TextBox>
    <asp:Button
        ID="GenerateRandomNumberBtn"
        runat="server"
        Text="GenerateRandomNumber"
        CssClass="btn btn-default" OnClick="GenerateRandomNumberBtn_Click" />
    <br />
    <label>Result: </label>
    <asp:Literal ID="Result" runat="server"></asp:Literal>

</asp:Content>
