<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Top10.Top" %>
<%@Register tagPrefix="UC" tagName="Top" src="Top.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <UC:Top runat="server" ID="UcTop" IsAdmin="False" />
</asp:Content>