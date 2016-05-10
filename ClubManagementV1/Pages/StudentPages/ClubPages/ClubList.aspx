<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StudentPages/StudentMaster.Master" AutoEventWireup="true" CodeBehind="ClubList.aspx.cs" Inherits="ClubManagementV1.Pages.StudentPages.ClubPages.ClubList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Clubs Of AIUB</h1>
    <div class="list-group">
        <asp:Repeater ItemType="ClubManagementV1.Models.Club" SelectMethod="GetClubs" runat="server">

            <ItemTemplate>
                <a class="list-group-item " href="ClubDetails.aspx?ClubID=<%#Item.ClubID %>">
                    <h4><%# Item.ClubName %></h4>
                    <p>Club ID: <%# Item.ClubID %></p>
                    <a class="btn btn-success" href="../MembershipPages/MembershipRequestAdd.aspx?ClubID=<%#Item.ClubID %>">Request Membership</a>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
