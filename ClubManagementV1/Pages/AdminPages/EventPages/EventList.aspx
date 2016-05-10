<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="ClubManagementV1.Pages.AdminPages.EventPages.EventList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="btn-group ">
        <asp:Button type="button" class="btn btn-primary" id="lastMonth" runat="server" Text="Last Month" OnClick="lastMonth_Click"/>
        <asp:Button type="button" class="btn btn-primary" id="last3Month" runat="server" Text="Last 3 Months" OnClick="last3Month_Click"/>
        <asp:Button type="button" class="btn btn-primary" id="last6Month" runat="server" Text="Last 6 Months" OnClick="last6Month_Click"/>
        <asp:Button type="button" class="btn btn-primary" id="lastYear" runat="server" Text="Last Year" OnClick="lastYear_Click"/>
        <asp:Button type="button" class="btn btn-primary" id="last2Year" runat="server" Text="Last 2 Years" OnClick="last2Year_Click"/>
        <asp:Button type="button" class="btn btn-primary" id="last5Year" runat="server" Text="Last 5 Years" OnClick="last5Year_Click"/>
        <asp:Button type="button" class="btn btn-primary" id="lastLongAgo" runat="server" Text="Long Ago" OnClick="lastLongAgo_Click"/>
    </div>
    <br />


    <h4>All Events  </h4> <i id="iThreshold" runat="server"></i> <br/>
    <asp:Repeater ID="eventRep" ItemType="ClubManagementV1.Models.Event" SelectMethod="GetEvents" runat="server">
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
