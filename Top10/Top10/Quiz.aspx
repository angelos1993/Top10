<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Top10.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="client/js/script-quiz.js"></script>
    <link href="client/css/animate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image runat="server" ID="ImgTop" CssClass="col img-seperator" ImageUrl="client/images/top.png" />
    <div runat="server" ID="DivBeforeStartDate" class="alert alert-info text-center">
        <h1 class="text-center">ستبدأ اللعبة يوم <asp:Literal runat="server" ID="LtrStartDate" /> ، انتظرونا</h1>
    </div>
    <div runat="server" ID="DivAfterEndDate" class="alert alert-info text-center">
        <h1 class="text-center">لقد إنتهت اللعبة يوم <asp:Literal runat="server" ID="LtrEndDate" /> ، ترقبوا النتيجة</h1>
    </div>
    <div runat="server" id="DivUserHadAnsweredToday">
        <div class="alert alert-info text-center">
            <h1 class="text-center">لقد قمت بالإجابة عن الأسئلة المتاحة لك اليوم .. نلقاك غداً مع أسئلة جديدة</h1>
        </div>
        <div runat="server" ID="DivCongratsImage" class="row justify-content-center">
            <img class="col-10" src="client/images/Congrats.jpg" height="400px" />
            <asp:HyperLink runat="server" ID="BtnShare" Target="_blank" CssClass="col-md-5 col-12 m-1 btn btn-primary">
                شارك نتيجتك مع صحابك ع الفيسبوك&nbsp;<i class="fab fa-facebook-square"></i>
            </asp:HyperLink>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-8 col-12">
                <asp:Repeater runat="server" ID="RepTodaysQuestionsAnswers" ItemType="Top10.DAL.VMs.TodaysQuestionsVm">
                    <ItemTemplate>
                        <ul class="list-unstyled">
                            <li>
                                <span class="badge badge-warning"><%# Container.ItemIndex + 1 %></span>
                                <ul>
                                    <li>
                                        <strong>السؤال: </strong><%# Item.Question %>&nbsp;<mark>(<%# Item.Mark %>&nbsp;درجات)</mark>
                                    </li>
                                    <li>
                                        <strong>الإجابة الصحيحة: </strong><%# Item.TrueAnswer %>
                                    </li>
                                    <li>
                                        <strong>إجابتك: </strong><%# Item.UserAnswer %>&nbsp;
                                        <i runat="server" visible="<%# Item.IsTrue %>" class="fas fa-check-circle text-success"></i>
                                        <i runat="server" visible="<%# !Item.IsTrue %>" class="fas fa-times-circle text-danger"></i>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-4 col-10">
                <div class="card">
                    <h5 class="card-header text-center">درجة اليوم</h5>
                    <div class="card-body justify-content-center">
                        <div runat="server" ID="DivTodaysGrade" class="text-center">20 / 20</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div runat="server" ID="DivUserTimeoutToday" class="alert alert-info text-center">
        <h1 class="text-center">لقد إنتهي الوقت المتاح لك للإجابة لهذا اليوم .. نلقاك غداً مع أسئلة جديدة</h1>
    </div>
    <div runat="server" id="DivNewQuiz">
        <div id="divStartGame" class="text-center">
            <h1 class="text-center">تعليمات ...</h1>
            <ul class="font-normal" style="font-family: AdvertisingBold;">
                <li>اللعبة من إعداد وتصميم خدمة المرحلة الثانوية بمير، من خلال متخصصين.</li>
                <li>الفترة المتاحة للعبة من الفترة 7/7 إلى 2018/7/17 فقط</li>
                <li>لكل مخدوم لعبة خاصة به باسمه ورقمه السري، يتم الحصول على الرقم السري من خادم الفصل.</li>
                <li>في حالة أي مشكلة خاصة بالرقم السري، يتم الرجوع للخادم لإعطاء رقم سري جديد.</li>
                <li>كل يوم متاح لك 3 أسئلة على 3 مستويات يتم اجابتهم خلال الوقت المحدد على الشاشة (90 ثانية) في أي وقت خلال اليوم. مجموع درجات الأسئلة الثلاث (20 درجة)</li>
                <li>الجوائز في نهاية المرحلة الثانية من الصيف لأول 10 فائزين.</li>
                <li>الأسئلة متنوعة في كافة المجالات، وتم توزيعها بطريقة عشوائية من خلال الكمبيوتر.</li>
                <li> استفسار أو تعليق، تواصل معنا من خلال زر "قول رأيك" الموجود علي يسار الشاشة، وسوف نرد عليك في أقرب فرصة.</li>
                <li>أذكر الخدمة في صلواتك</li>
            </ul>
            <button type="button" class="btn btn-lg btn-success" onclick="startGame();">إبدأ اللعبة&nbsp;<i class="far fa-play-circle"></i></button>
        </div>
        <asp:Repeater runat="server" ID="RepQuestions" ItemType="Top10.DAL.Model.Question">
            <ItemTemplate>
                <div class="card row d-none" id="divQuestion<%# Container.ItemIndex + 1 %>">
                    <h3 class="card-header text-center">
                        السؤال رقم <%# Container.ItemIndex + 1 %>&nbsp;<small>(<%# Item.Mark %> درجات)</small>
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