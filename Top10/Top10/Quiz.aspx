<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Top10.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="client/js/script-quiz.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image runat="server" ID="ImgTop" CssClass="col img-seperator" ImageUrl="client/images/top.png" />
    <div runat="server" ID="DivBeforeStartDate" class="alert alert-info text-center">
        <h1 class="text-center">ستبدأ اللعبة يوم <asp:Literal runat="server" ID="LtrStartDate" /> ، انتظرونا</h1>
    </div>
    <div runat="server" ID="DivAfterEndDate" class="alert alert-info text-center">
        <h1 class="text-center">لقد إنتهت اللعبة يوم <asp:Literal runat="server" ID="LtrEndDate" /> ، ترقبوا النتيجة</h1>
    </div>
    <div runat="server" ID="DivUserHadAnsweredToday" class="alert alert-info text-center">
        <h1 class="text-center">لقد قمت بالإجابة عن الأسئلة المتاحة لك اليوم .. نلقاك غذاً مع أسئلة جديدة</h1>
    </div>
    <div runat="server" ID="DivUserTimeoutToday" class="alert alert-info text-center">
        <h1 class="text-center">لقد إنتهي الوقت المتاح لك للإجابة لهذا اليوم .. نلقاك غذاً مع أسئلة جديدة</h1>
    </div>
    <div runat="server" id="DivNewQuiz">
        <div id="divStartGame" class="text-center">
            <p class="text-center">تعليمات ...</p>
            <button type="button" class="btn btn-lg btn-success" onclick="startGame();">إبدأ اللعبة&nbsp;<i class="far fa-play-circle"></i></button>
        </div>
        <asp:Repeater runat="server" ID="RepQuestions" ItemType="Top10.DAL.Model.Question">
            <ItemTemplate>
                <div class="card row d-none" id="divQuestion<%# Container.ItemIndex + 1 %>">
                    <h3 class="card-header text-center">
                        السؤال رقم <%# Container.ItemIndex + 1 %>&nbsp;-&nbsp;<small>(<%# Item.Mark %> درجات)</small>
                    </h3>
                    <div class="card-body justify-content-center">
                        <div class="card-title">
                            <h1 class="form-group"><%# Item.Text %>؟</h1>
                        </div>
                        <div class="row justify-content-center justify-content-sm-start">
                            <button type="button" class="btn btn-outline-info btn-lg col-md-7 col-sm-10 col-11" data-question="<%# Item.Id %>" onclick="choose(this);" data-answer="A"><%# Item.ChoiceA %></button>
                            <button type="button" class="btn btn-outline-info btn-lg col-md-7 col-sm-10 col-11" data-question="<%# Item.Id %>" onclick="choose(this);" data-answer="B"><%# Item.ChoiceB %></button>
                            <button type="button" class="btn btn-outline-info btn-lg col-md-7 col-sm-10 col-11" data-question="<%# Item.Id %>" onclick="choose(this);" data-answer="C"><%# Item.ChoiceC %></button>
                            <button type="button" class="btn btn-outline-info btn-lg col-md-7 col-sm-10 col-11" data-question="<%# Item.Id %>" onclick="choose(this);" data-answer="D"><%# Item.ChoiceD %></button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div id="divButtons" class="d-none">
            <div class="row m-1 justify-content-center">
                <button type="button" class="btn btn-secondary btn-lg col-md-3 col-5 m-1" onclick="showNextOrPreviousQuestion('P');">&#9755; السؤال السابق</button>
                <button type="button" class="btn btn-secondary btn-lg col-md-3 col-5 m-1" onclick="showNextOrPreviousQuestion('N');">السؤال التالي &#9754;</button>
            </div>
            <div class="row m-1 justify-content-center">
                <asp:Button runat="server" ID="BtnSubmitAnswers" CssClass="btn btn-secondary btn-lg col-md-5 col-9" Text="إرسال الإجابات" OnClick="BtnSubmitAnswers_OnClick" />
            </div>
        </div>
    </div>
    <asp:Image runat="server" ID="ImgBottom" CssClass="col img-seperator" ImageUrl="client/images/bottom.png" />
    <asp:HiddenField runat="server" ID="HfTimer" />
    <input type="hidden" id="hfCurrentQuestion" value="1" />
    <asp:HiddenField runat="server" ID="HfQuestion1Answer" />
    <asp:HiddenField runat="server" ID="HfQuestion2Answer" />
    <asp:HiddenField runat="server" ID="HfQuestion3Answer" />
    <button type="button" class="timer-div btn btn-lg btn-success d-none">
        الوقت المتبقي <span class="badge badge-light" id="spnTimer"></span>
    </button>
</asp:Content>