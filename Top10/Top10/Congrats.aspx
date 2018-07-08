<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Congrats.aspx.cs" Inherits="Top10.Congrats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal runat="server" ID="LtrTitle" /></title>
    <link href="client/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container">
    <form id="form1" runat="server" class="row justify-content-center">
        <asp:Image runat="server" ID="ImgCongrats" ImageUrl="client/images/Congrats.jpg" CssClass="col" height="400px" />
        <asp:Image runat="server" ID="ImgSemiCongrats" ImageUrl="client/images/SemiCongrats.jpg" CssClass="col" height="400px" />
        <div class="alert alert-success text-center">
            <h1 class="text-center">
                <asp:Literal runat="server" ID="LtrTxt" /></h1>
        </div>
        <a href="Quiz.aspx" class="btn btn-lg btn-success m-1">لبدء لعبة جديدة إضغط هنا</a>
    </form>
</body>
</html>