<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Top10.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image runat="server" ID="ImgTop" CssClass="col img-seperator" ImageUrl="client/images/top.png" />
    <div runat="server" ID="DivBeforeStartDate" class="alert alert-info text-center">
        ستبدأ اللعبة يوم <asp:Literal runat="server" ID="LtrStartDate" /> ، انتظرونا
    </div>
    <div runat="server" ID="DivAfterEndDate" class="alert alert-info text-center">
        لقد إنتهت اللعبة يوم <asp:Literal runat="server" ID="LtrEndDate" /> ، ترقبوا النتيجة
    </div>
    <div runat="server" ID="DivUserHadAnsweredToday" class="alert alert-info text-center">
        لقد قمت بالإجابة عن الأسئلة المتاحة لك اليوم .. نلقاك غذاً مع أسئلة جديدة
    </div>
    <div runat="server" ID="DivUserTimeoutToday" class="alert alert-info text-center">
        لقد إنتهي الوقت المتاح لك للإجابة لهذا اليوم .. نلقاك غذاً مع أسئلة جديدة
    </div>
    <div runat="server" ID="DivNewQuiz">
        DivNewQuiz
    </div>
    <asp:Image runat="server" ID="ImgBottom" CssClass="col img-seperator" ImageUrl="client/images/bottom.png" />
</asp:Content>