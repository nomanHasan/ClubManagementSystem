<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StudentPages/StudentMaster.Master" AutoEventWireup="true" CodeBehind="ClubDetails.aspx.cs" Inherits="ClubManagementV1.Pages.StudentPages.ClubPages.ClubDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="jumbotron">
        <h3>Club Name </h3>&nbsp;<h1 id="dataClubName" runat="server"></h1><br />
        <b>Club Description : </b>&nbsp;<p id="dataClubDetails" runat="server"></p>
        <b>Club Created on : </b>&nbsp; <i id="dataDate" runat="server"></i>
        <br />
    </div>
    <b>Club Presidents : </b>&nbsp;
        <table class="table">
            <thead>
                <tr>
                    <td>Presidents</td>
                </tr>
            </thead>
            <tbody id="presidents" runat="server">
            </tbody>
        </table>
    <b>Club Events : </b>&nbsp;
        <table class="table">
            <thead>
                <tr>
                    <td>Event Name</td>
                    <td>Event Time</td>
                    <td>Event Venue</td>
                </tr>
            </thead>
            <tbody id="events" runat="server">
            </tbody>
        </table>

    

</asp:Content>
