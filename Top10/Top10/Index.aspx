<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Top10.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox runat="server" ID="TxtUsername" />
    <br />
    <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" />
    <br />
    <asp:Button runat="server" ID="BtnLogin" Text="تسجيل الدخول" OnClick="BtnLogin_OnClick" />
</asp:Content>