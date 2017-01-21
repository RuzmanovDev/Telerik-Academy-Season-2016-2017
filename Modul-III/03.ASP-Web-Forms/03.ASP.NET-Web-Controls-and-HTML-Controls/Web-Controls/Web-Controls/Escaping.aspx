<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" validateRequest="false"  AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="Web_Controls.Escaping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <label>Enter some text</label>
    <asp:TextBox
        ID="TextBox"
        runat="server"
        CssClass="form-control"
        Width="300">
    </asp:TextBox>
    <asp:Button
        ID="EnterTextBtn"
        runat="server"
        Text="EnterText"
        CssClass="btn btn-default" OnClick="EnterTextBtn_Click" />
    <br />
    <label>This is the output</label>
    <asp:Literal ID="ResultLiteral"
        runat="server"
        Mode="Encode"></asp:Literal>
</asp:Content>
