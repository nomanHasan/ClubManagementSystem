<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Club.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="ClubManagementV1.Pages.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="panel panel-danger">
        <div class="panel-heading">
            <h3 class="panel-title">DO You want to Logout ?</h3>
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
