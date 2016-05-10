<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClubAdd.aspx.cs" Inherits="ClubManagementV1.Pages.AdminPages.ClubPages.ClubAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    
    <label>Club Name</label><input type="text" class="form-control" id="txtClubName" runat="server" />
    <label>Club Details</label><input type="text" class="form-control" id="txtClubDetails" runat="server" />

    <asp:Button id="btnAddClub" runat="server" class="btn btn-default" Text="Create A Club" OnClick="btnAddClub_Click" ></asp:Button>


    <h5 id="message" runat="server"></h5>

</asp:Content>
