<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Top10.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6 col-12">
            <div class="card row">
                <div class="card-body">
                    <h4 class="card-title">تسجيل الدخول</h4>
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
                        <asp:Button runat="server" ID="BtnLogin" Text="تسجيل الدخول" OnClick="BtnLogin_OnClick" CssClass="form-control btn btn-primary" OnClientClick="return validateLogin();" />
                    </div>
                    <div class="form-group justify-content-center row">
                        <asp:Label runat="server" ID="LblErrorMsg" Visible="False" CssClass="alert alert-danger" role="alert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>