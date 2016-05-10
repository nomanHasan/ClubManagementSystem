<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PresidentList.aspx.cs" Inherits="ClubManagementV1.Pages.AdminPages.PresidentPages.PresidentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h4>All President  </h4>
    <asp:Repeater ID="presidentRep" ItemType="ClubManagementV1.Models.President" SelectMethod="GetPresidents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Student ID</th>
                    <th>Student Name</th>
                    <th>Club Name</th>
                    <th>Designation</th>
                    <th>Username</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Student.StudentID %></td>
                <td><%# Item.Student.StudentName%></td>
                <td><%# Item.Club.ClubName %></td>
                <td><%# Item.Account.Role %></td>
                <td><%# Item.Account.Username %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
