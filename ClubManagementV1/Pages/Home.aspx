<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Club.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClubManagementV1.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="jumbotron">
        <h1>AIUB Club Management System</h1>
        <div class="panel panel-default">
            <div class="panel-heading">Managing Clubs</div>
            <div class="panel-body ">Admins can create Clubs, Edit every aspect of it</div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">Login System</div>
            <div class="panel-body ">Admins, Presidents and Students can Login and access the System</div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">Account Management</div>
            <div class="panel-body ">All User of the system can manage their account.</div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">Event Management</div>
            <div class="panel-body ">This system also provides all the necessary options for proper event management.</div>
        </div>
    </div>
</asp:Content>
