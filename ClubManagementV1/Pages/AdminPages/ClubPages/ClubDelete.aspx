<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClubDelete.aspx.cs" Inherits="ClubManagementV1.Pages.AdminPages.ClubPages.ClubDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="jumbotron">
        <h3>Club Name </h3>
        &nbsp;<h1 id="dataClubName" runat="server"></h1>
        <br />
        <b>Club Description : </b>&nbsp;<p id="dataClubDetails" runat="server"></p>
        <b>Club Created on : </b>&nbsp; <i id="dataDate" runat="server"></i>
        <br />
    </div>
    <div class="panel panel-danger">
        <div class="panel-heading">
            <h3 class="panel-title">Do You want to Close this Club ?</h3>
        </div>
        <div class="panel-body">
            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                <div class="btn-group" role="group">
                    <asp:Button id="yesButton" runat="server" Text="YES" class="btn btn-default" OnClick="yesButton_Click" ></asp:Button>
                    <asp:Button ID="noButton" runat="server" Text="NO" class="btn btn-default" OnClick="noButton_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
