<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Web_Controls.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form">
        <label>First name</label>
        <asp:TextBox
            ID="FirstNameTextBox"
            runat="server"
            CssClass="form-control"
            Width="300"
            TextMode="SingleLine"></asp:TextBox>
        <label>Last name</label>
        <asp:TextBox
            ID="LastNameTextBox"
            runat="server"
            CssClass="form-control"
            Width="300"
            TextMode="SingleLine"></asp:TextBox>
        <label>Faculty Number</label>
        <asp:TextBox
            ID="FacultyNumberTextBox"
            runat="server"
            CssClass="form-control"
            Width="280"
            TextMode="Number"></asp:TextBox>
        <label>University</label>
        <asp:DropDownList
            ID="UniversityDropDownList"
            runat="server"
            CssClass="form-control"
            Width="280">
            <asp:ListItem Text="UNWE" />
            <asp:ListItem Text="TU" />
            <asp:ListItem Text="FMI" />
            <asp:ListItem Text="NBU" />
        </asp:DropDownList>
        <label>Specialty</label>
        <asp:DropDownList
            ID="SpecialtyDropDownList"
            runat="server"
            CssClass="form-control"
            Width="280">
            <asp:ListItem Text="Computer Schience" />
            <asp:ListItem Text="Economics" />
            <asp:ListItem Text="Software Engeneering" />
            <asp:ListItem Text="KST" />
        </asp:DropDownList>
        <label>List of courses</label>
        <asp:CheckBoxList
            ID="CoursesCheckBox"
            runat="server"
            Widht="300">
            <asp:ListItem Text="Programming101" />
            <asp:ListItem Text="Economics101" />
            <asp:ListItem Text="MacroEconomics" />
            <asp:ListItem Text="OOP" />
            <asp:ListItem Text="DSA" />
            <asp:ListItem Text="Computers acrchitecture" />
        </asp:CheckBoxList>
        <asp:Button
            ID="SubmitBtn"
            runat="server"
            Text="Submit"
            CssClass="btn btn-default" OnClick="SubmitBtn_Click" />
    </div>
    <asp:PlaceHolder ID="StudentInfoPlaceHolder" runat="server"></asp:PlaceHolder>
</asp:Content>
