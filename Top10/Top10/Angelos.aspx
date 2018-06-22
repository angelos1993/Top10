<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Angelos.aspx.cs" Inherits="Top10.Angelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" ID="BtnGeneratePasswordsForAllUsers" OnClick="BtnGeneratePasswordsForAllUsers_OnClick" />
</asp:Content>