<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Top10.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" ID="DivBeforeStartDate">
        the game will start on: <asp:Literal runat="server" ID="LtrStartDate" />
    </div>
    <div runat="server" ID="DivAfterEndDate">
        the game ended on: <asp:Literal runat="server" ID="LtrEndDate" />
    </div>
    <div runat="server" ID="DivUserHadAnsweredToday">
        you have answered the today's questions
    </div>
    <div runat="server" ID="DivUserTimeoutToday">
        the time ended for today, please tyr again tomorrow
    </div>
    <div runat="server" ID="DivNewQuiz">
        DivNewQuiz
    </div>
</asp:Content>
