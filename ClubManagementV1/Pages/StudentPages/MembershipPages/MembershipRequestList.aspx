<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StudentPages/StudentMaster.Master" AutoEventWireup="true" CodeBehind="MembershipRequestList.aspx.cs" Inherits="ClubManagementV1.Pages.StudentPages.MembershipPages.MembershipRequestList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Requests For Membership</h1>
    <div class="list-group">
        <asp:Repeater ItemType="ClubManagementV1.Models.MembershipRequest" SelectMethod="GetMemRequests" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <tr style="background: CornflowerBlue; color: White;">
                        <th>Club Name</th>
                        <th>Club ID</th>
                        <th>Delete Request</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <h4><%# Item.Club.ClubName %></h4>
                </td>
                <td>
                    <p>Club ID: <%# Item.Club.ClubID %></p>
                </td>
                <td><a class="btn btn-danger" href="../MembershipPages/MembershipRequestDelete.aspx?ClubID=<%#Item.Club.ClubID %>">Delete Request Membership</a></td>

            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
