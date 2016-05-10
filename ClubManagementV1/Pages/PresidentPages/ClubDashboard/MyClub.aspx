<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/PresidentPages/PresidentMaster.Master" AutoEventWireup="true" CodeBehind="MyClub.aspx.cs" Inherits="ClubManagementV1.Pages.PresidentPages.ClubDashboard.MyClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="jumbotron">
        <h3>Club Name </h3>&nbsp;<h1 id="dataClubName" runat="server"></h1><br />
        <b>Club Description : </b>&nbsp;<p id="dataClubDetails" runat="server"></p>
        <b>Club Created on : </b>&nbsp; <i id="dataDate" runat="server"></i>
        <br />
        <a id="manageMemRequest" runat="server" class="btn btn-primary">Manage Membership Requests</a>
        <a id="managePartRequest" runat="server" class="btn btn-primary">Manage Event Participation Requests</a>
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

    
    <a href="../MembershipPages/MembershipRequestList.aspx"></a>

    <b>Club Members : </b>&nbsp;
    <asp:Repeater ID="Repeater1" ItemType="ClubManagementV1.Models.Student" SelectMethod="GetStudents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Name</th>
                    <th>Student ID</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Membership</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.StudentName %></td>
                <td><%# Item.StudentID %></td>
                <td><%# Item.StudentEmail %></td>
                <td><%# Item.StudentPhone %></td>

                <td><a class="btn btn-danger" href="../MembershipPages/MembershipDelete.aspx?studentID=<%#Item.StudentID %>">Discard Membership</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
