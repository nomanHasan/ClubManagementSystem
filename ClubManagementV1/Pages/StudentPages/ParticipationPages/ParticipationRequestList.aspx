<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StudentPages/StudentMaster.Master" AutoEventWireup="true" CodeBehind="ParticipationRequestList.aspx.cs" Inherits="ClubManagementV1.Pages.StudentPages.ParticipationPages.ParticipationRequestList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Requests For Participation</h1>
    <div class="list-group">
        <asp:Repeater ItemType="ClubManagementV1.Models.ParticipationRequest" SelectMethod="GetPartRequests" runat="server">

            <ItemTemplate>
                <div class="list-group-item ">
                    <h4><%# Item.Event.EventName%></h4>
                    <p>Club ID: <%# Item.Event.EventID%></p>
                    <i>Event Venue : <%#Item.Event.EventVenue %></i>
                    <i>Event Time : <%#Item.Event.EventTime %></i>
                    <a class="btn btn-danger" href="../ParticipationPages/ParticipationRequestDelete.aspx?EventID=<%#Item.Event.EventID%>">Delete Request Participation</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
