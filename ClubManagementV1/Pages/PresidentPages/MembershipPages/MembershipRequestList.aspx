<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/PresidentPages/PresidentMaster.Master" AutoEventWireup="true" CodeBehind="MembershipRequestList.aspx.cs" Inherits="ClubManagementV1.Pages.PresidentPages.MembershipPages.MembershipRequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h4>Events List  </h4> <i id="iThreshold" runat="server"></i> <br/>
    <asp:Repeater ID="MemReqRep" ItemType="ClubManagementV1.Models.MembershipRequest" SelectMethod="GetMemReqs" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr style="background: CornflowerBlue; color: White;">
                    <th>Club Title</th>
                    <th>Student Name</th>
                    <th>Accept Membership</th>
                    <th>Deny Membership</th>
                    
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Club.ClubName %></td>
                <td><%# Item.Student.StudentName %></td>
                <td><a href="MembershipRequestAccept.aspx?studentID=<%#Item.Student.StudentID %>"  class="btn btn-success">Accept Request</a> </td>
                <td><a href="MembershipRequestDeny.aspx?studentID=<%#Item.Student.StudentID %>"  class="btn btn-danger">Deny Request</a> </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
