<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Top10.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager" />
    <div id="accordion">
        <div class="card">
            <div class="card-header">
                <a class="card-link" data-toggle="collapse" href="#collapseOne">
                    إستعلام عن مخدوم / تعديل بيانات مخدوم
                </a>
            </div>
            <div id="collapseOne" class="collapse" data-parent="#accordion">
                <div class="card-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-inline">
                                <asp:DropDownList runat="server" ID="DdlUserTypes" CssClass="form-control col-md-3 ml-1" OnSelectedIndexChanged="DdlUserTypes_OnSelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="0" Text="كل المخدومين" Selected="True" />
                                    <asp:ListItem Value="1" Text="أولي أولاد" />
                                    <asp:ListItem Value="2" Text="أولي بنات" />
                                    <asp:ListItem Value="3" Text="ثانية أولاد" />
                                    <asp:ListItem Value="4" Text="ثانية بنات" />
                                    <asp:ListItem Value="5" Text="ثالثة أولاد" />
                                    <asp:ListItem Value="6" Text="ثالثة بنات" />
                                </asp:DropDownList>
                                <asp:DropDownList runat="server" ID="DdlUsers" CssClass="form-control col-md-3 ml-1" />
                                <asp:Button runat="server" ID="BtnCurrentUserInfo" CssClass="btn btn-secondary col-md-2 ml-1" OnClick="BtnCurrentUserInfo_OnClick" Text="معلومات عن المخدوم" />
                                <asp:Button runat="server" ID="BtnGeneratePasswordForUser" CssClass="btn btn-secondary col-md-2 ml-1" OnClick="BtnGeneratePasswordForUser_OnClick" Text="إنشاء رقم سري جديد" />
                                <div class="form-group justify-content-center align-items-center">
                                    <asp:Label runat="server" ID="LblUserInfo" Visible="False" CssClass="alert alert-info" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                <a class="card-link" data-toggle="collapse" href="#collapseTwo">
                    درجات المخدومين
                </a>
            </div>
            <div id="collapseTwo" class="collapse" data-parent="#accordion">
                <div class="card-body">
                    Lorem ipsum..
                </div>
            </div>
        </div>
    </div>

    <asp:Button runat="server" ID="BtnGeneratePasswordsForAllUsers" OnClick="BtnGeneratePasswordsForAllUsers_OnClick" Text="Generate Passwords For All Users" />

</asp:Content>