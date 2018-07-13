<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="Top10.Top1" %>

<div class="alert alert-info text-center" runat="server" ID="DivNoTopUsers">لا توجد بيانات للعرض</div>
<div runat="server" ID="DivTopUsers">
    <table class="table table-hover">
        <thead class="bg-light">
        <tr class="row">
            <td class="text-center col-3">#</td>
            <td class="text-center col-6"><strong>اسم المخدوم</strong></td>
            <td class="text-center col-3"><strong>الدرجة</strong></td>
        </tr>
        </thead>
        <tbody>
        <asp:Repeater runat="server" ID="RepTopUsers" ItemType="Top10.DAL.VMs.TopUserVm">
            <ItemTemplate>
                <tr class="row">
                    <td class="text-center col-3"><%# Container.ItemIndex + 1 %></td>
                    <td class="text-center col-6"><%# Item.Username %></td>
                    <td class="text-center col-3"><%# Item.TotalGrades %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </tbody>
    </table>
</div>