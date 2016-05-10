<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="ClubManagementV1.Pages.AdminPages.StudentPages.StudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h4>All Student  </h4>
    <asp:Repeater ID="studentRep" ItemType="ClubManagementV1.Models.Student" SelectMethod="GetStudents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Student ID</th>
                    <th>Student Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Username</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.StudentID %></td>
                <td><%# Item.StudentName%></td>
                <td><%# Item.StudentEmail %></td>
                <td><%# Item.StudentPhone %></td>
                <td><%# Item.Account.Username %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
