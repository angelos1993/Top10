<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Top10.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" ID="BtnGeneratePasswordsForAllUsers" OnClick="BtnGeneratePasswordsForAllUsers_OnClick" Text="Generate Passwords For All Users" />
    <br />
    <hr />
    <br />
    <asp:DropDownList runat="server" ID="DdlUsers"/>
    <asp:Button runat="server" ID="BtnGeneratePasswordForUser" OnClick="BtnGeneratePasswordForUser_OnClick" Text="Generate Password" />
    <asp:Button runat="server" ID="BtnCurrentPasswordForUser" OnClick="BtnCurrentPasswordForUser_OnClick" Text="Get Current Password" />
    <asp:Label runat="server" ID="LblUserPassword" Visible="False" />
    <br />
    <hr />
    <br />
</asp:Content>
