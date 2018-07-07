<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Top10.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="client/js/script-index.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" ID="DivLogIn" class="row justify-content-center">
        <div class="col-md-6 col-12">
            <div class="card row">
                <h4 class="card-header text-center">تسجيل الدخول</h4>
                <div class="card-body">
                    <div class="form-group justify-content-center row">
                        <div class="alert alert-info">إذا كنت من مخدومين خدمة ثانوي وليس لديك معلومات الدخول، من فضلك تواصل مع خادمك</div>
                    </div>
                    <div class="form-group justify-content-center row">
                        <asp:Label runat="server" ID="LblErrorMsg" Visible="False" CssClass="alert alert-danger" role="alert" />
                    </div>
                    <div class="form-group">
                        <%-- ReSharper disable once Html.IdNotResolved --%>
                        <label for="TxtUsername">اسم المستخدم</label>
                        <asp:TextBox runat="server" ID="TxtUsername" class="form-control" />
                    </div>
                    <div class="form-group">
                        <%-- ReSharper disable once Html.IdNotResolved --%>
                        <label for="TxtPassword">الرقم السري</label>
                        <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:LinkButton runat="server" ID="BtnLogin" OnClick="BtnLogin_OnClick" CssClass="form-control btn btn-info" OnClientClick="return validateLogin();">
                            تسجيل الدخول&nbsp;<i class="fas fa-sign-in-alt"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div runat="server" ID="DivAlreadyLoggedIn" Visible="False" class="alert alert-danger text-center">
        <h1 class="text-center">لقد قمت بتسجيل الدخول من قبل</h1>
    </div>
</asp:Content>