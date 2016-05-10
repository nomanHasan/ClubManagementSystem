<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Club.Master" AutoEventWireup="true" CodeBehind="RegistrationSuccesful.aspx.cs" Inherits="ClubManagementV1.Pages.RegistrationSuccesful" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="panel panel-default text-center">
        <div class="panel-title">
            <h3> Your Registration was successful !</h3>
        </div>
        <div class="panel-body">
            <a class="btn btn-success" href="Login.aspx" >Click Here</a> To Login to the System.
        </div>
    </div>
</asp:Content>
