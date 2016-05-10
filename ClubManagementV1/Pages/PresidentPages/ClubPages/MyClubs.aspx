<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/PresidentPages/PresidentMaster.Master" AutoEventWireup="true" CodeBehind="MyClubs.aspx.cs" Inherits="ClubManagementV1.Pages.PresidentPages.ClubPages.MyClubs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>My Clubs</h1>
    <div class="list-group">
        <asp:Repeater ItemType="ClubManagementV1.Models.Club" SelectMethod="GetMyClubs" runat="server">
            <ItemTemplate>
                <div class="list-group-item ">
                    <a href="ClubDetails.aspx?ClubID=<%#Item.ClubID %>">
                        <h4><%# Item.ClubName %></h4>
                        <p>Club ID: <%# Item.ClubID %></p>
                        <a  class="btn btn-danger" href="../MembershipPages/MembershipDelete.aspx?clubID=<%#Item.ClubID%>">Leave Club</a>
                    </a>
                    
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
