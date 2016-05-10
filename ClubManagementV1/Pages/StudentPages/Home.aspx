<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StudentPages/StudentMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClubManagementV1.Pages.StudentPages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <h2> Students Associated Club</h2>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    <h2> Students Associated Events</h2>
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>

    <h2 id="spro" runat="server"> Student Profile</h2>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
        DataKeyNames="studentID" OnRowCancelingEdit="GridView3_RowCancelingEdit"
        OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
        OnRowUpdating="GridView3_RowUpdating">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="StudentName" HeaderText="NAME" />
            <asp:BoundField DataField="Email" HeaderText="EMAIL" />
            <asp:BoundField DataField="Phone" HeaderText="PHONE" />
            <asp:CommandField HeaderText="OPTIONS" ShowDeleteButton="True"
                ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
