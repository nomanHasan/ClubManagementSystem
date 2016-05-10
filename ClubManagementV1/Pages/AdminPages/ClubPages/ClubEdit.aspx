<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClubEdit.aspx.cs" Inherits="ClubManagementV1.Pages.AdminPages.ClubPages.ClubEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="well">
        <label class="control-label col-sm-2" for="txtClubName">Club Name</label>
        <div class="col-sm-10">
            <input type="text" class="form-control" id="txtClubName" runat="server"  />
        </div>
        <br />
        <label class="control-label col-sm-2" for="txtClubDetails">Club Description </label>
        <div class="col-sm-10">
            <input type="text" class="form-control" id="txtClubDetails" runat="server"   />
        </div>
        <br />

        <label class="control-label col-sm-2" for="dateClubCreated">Date Created </label>
        <div class="col-sm-10">
            <input type="text" runat="server" class="form-control" id="dateClubCreated" />
        </div>
        <br />

        <asp:Button runat="server" ID="updateButton" Text="Update Club" CssClass="btn btn-success" OnClick="updateButton_Click" />

    </div>
    <b>Club Presidents : </b>&nbsp;
    <asp:Repeater ID="presidentRep" ItemType="ClubManagementV1.Models.Student" SelectMethod="GetPresidents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Name</th>
                    <th>StudentID</th>
                    <th>Options</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.StudentName %></td>
                <td><%# Item.StudentID %></td>
                <td><a class="btn btn-danger" href="../PresidentPages/PresidentDelete.aspx?studentID=<%#Item.StudentID %>&clubID=<%# Request.QueryString["clubID"] %>">Remove Presidency </a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


    <b>Club Members : </b>&nbsp;
    <asp:Repeater ID="Repeater1" ItemType="ClubManagementV1.Models.Student" SelectMethod="GetStudents" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Name</th>
                    <th>Student ID</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Presidency</th>
                    <th>Membership</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.StudentName %></td>
                <td><%# Item.StudentID %></td>
                <td><%# Item.StudentEmail %></td>
                <td><%# Item.StudentPhone %></td>

                <td><a class="btn btn-success" href="../PresidentPages/PresidentAdd.aspx?studentID=<%#Item.StudentID %>&clubID=<%# Request.QueryString["clubID"] %>">Make President</a></td>
                <td><a class="btn btn-danger" href="../MembershipPages/MembershipDelete.aspx?studentID=<%#Item.StudentID %>">Discard Membership</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
