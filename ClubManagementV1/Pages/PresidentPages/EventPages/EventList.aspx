<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/PresidentPages/PresidentMaster.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="ClubManagementV1.Pages.PresidentPages.EventPages.EventList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    
    <h4>Events List  </h4> <i id="iThreshold" runat="server"></i> <br/>
    <asp:Repeater ID="eventRep" ItemType="ClubManagementV1.Models.Event" SelectMethod="GetEvents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Eevnt Title</th>
                    <th>Event ID</th>
                    <th>Event Time</th>
                    <th>Event Organizer</th>
                    <th>Event Venue</th>
                    <th>Event Request</th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.EventName %></td>
                <td><%# Item.EventID %></td>
                <td><%# Item.EventName %></td>
                <td><%# Item.EventClub.ClubName %></td>
                <td><%# Item.EventVenue %></td>
                <td><a class="btn btn-success" href="../ParticipationPages/ParticipationRequestAdd.aspx?eventID=<%#Item.EventID %>" >Request To Participate</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
