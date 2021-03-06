﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Top10.Admin" %>
<%@Register tagPrefix="UC" tagName="Top" src="Top.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy" />
    <div id="accordion">
        <div class="card">
            <a class="card-header" data-toggle="collapse" href="#collapseOne">
                إستعلام عن مخدوم / تعديل بيانات مخدوم
            </a>
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
                                <button type="button" class="btn btn-secondary col-md-2 ml-1" data-toggle="modal" data-target="#passwordModal">إنشاء رقم سري جديد</button>
                                <div class="modal fade" id="passwordModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">تأكيد</h5>
                                            </div>
                                            <div class="modal-body">
                                                هل انت متأكد من انك تريد إنشاء رقم سري جديد لهذا المخدوم؟
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button runat="server" ID="BtnGeneratePasswordForUser" CssClass="btn btn-primary col-md-2 ml-1" OnClick="BtnGeneratePasswordForUser_OnClick" Text="نعم" OnClientClick="$('#passwordModal').modal('hide')" />
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">لا</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center mt-1">
                                <div class="row alert alert-success" runat="server" ID="DivPasswordCreatedSuccessfully" Visible="False">تم إنشاء رقم سري جديد بنجاح !</div>
                            </div>
                            <div class="row justify-content-center">
                                <table class="col-md-8 col-12 table table-hover table-bordered" runat="server" id="TblUserInfo" visible="False">
                                    <tr>
                                        <td><strong>الاسم</strong></td>
                                        <td>
                                            <asp:Literal runat="server" ID="LtrUserArabicName" /></td>
                                    </tr>
                                    <tr>
                                        <td><strong>اسم المستخدم</strong></td>
                                        <td>
                                            <asp:Literal runat="server" ID="LtrUserEnglishName" /></td>
                                    </tr>
                                    <tr>
                                        <td><strong>الرقم السري</strong></td>
                                        <td>
                                            <asp:Literal runat="server" ID="LtrUserPassword" /></td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="card">
            <a class="card-header" data-toggle="collapse" href="#collapseTwo">
                درجات المخدومين
            </a>
            <div id="collapseTwo" class="collapse" data-parent="#accordion">
                <div class="card-body">
                    <UC:Top runat="server" ID="UcTop" IsAdmin="True" />
                </div>
            </div>
        </div>
        <div class="card">
            <a class="card-header" data-toggle="collapse" href="#collapseThree">
                آراء ومشاكل واقتراحات المخدومين
            </a>
            <div id="collapseThree" class="collapse" data-parent="#accordion">
                <div class="card-body">
                    <div class="alert alert-info text-center" runat="server" ID="DivNoFeedbacks">لا توجد بيانات للعرض</div>
                    <div runat="server" id="DivFeedbacks">
                        <table class="table table-hover">
                            <thead class="bg-light">
                                <tr class="row">
                                    <td class="text-center col-4"><strong>اسم المخدوم</strong></td>
                                    <td class="text-center col-8"><strong>الرسالة</strong></td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepFeedbacks" ItemType="Top10.DAL.VMs.FeedbackVm">
                                    <ItemTemplate>
                                        <tr class="row">
                                            <td class="text-center col-4"><%# Item.Username %></td>
                                            <td class="text-center col-8"><%# Item.Message %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>