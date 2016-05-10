<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StudentPages/StudentMaster.Master" AutoEventWireup="true" CodeBehind="MyEvents.aspx.cs" Inherits="ClubManagementV1.Pages.StudentPages.EventPages.MyEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h4>My Participated Events  </h4>
    <asp:Repeater ID="eventRep" ItemType="ClubManagementV1.Models.Event" SelectMethod="GetMyEvents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Eevnt Title</th>
                    <th>Event ID</th>
                    <th>Event Time</th>
                    <th>Event Organizer</th>
                    <th>Event Venue</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.EventName %></td>
                <td><%# Item.EventID %></td>
                <td><%# Item.EventTime %></td>
                <td><%# Item.EventClub.ClubName %></td>
                <td><%# Item.EventVenue %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
