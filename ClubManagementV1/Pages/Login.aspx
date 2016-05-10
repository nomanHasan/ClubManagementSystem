<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Club.Master" CodeBehind="Login.aspx.cs" Inherits="ClubManagementV1.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="jumbotron" style="background-image:url('../Content/Images/mountainLake.jpg'); background-size:cover" />">
        <div class="panel panel-primary">
            <div class="panel-heading"><h4>Login to Access the Club Management</h4></div>
            <div class="panel-body "><asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtUserName"
            ErrorMessage="User Name is required.">*
        </asp:RequiredFieldValidator>
        <br />
        <label class="control-label col-sm-2" for="txtUserName">UserName</label> &nbsp;
        <div class="col-sm-10">
            <input type="text" class="form-control" id="txtUserName" runat="server" />
        </div>
        <br />

        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtPassword"
            ErrorMessage="Student Email is required.">*
        </asp:RequiredFieldValidator>
        <label class="control-label col-sm-2" for="txtPassword">Password</label>&nbsp;
        <div class="col-sm-10">
            <input type="password" class="form-control" id="txtPassword" runat="server" />
        </div>
        <br />
                <asp:Button ID="loginButton" runat="server" class="btn btn-success" Text="Login" OnClick="loginButton_Click"/>

            </div>
        </div>

        <a href="Registration.aspx" class="btn btn-primary text-center">Create a New Account</a>
    </div>
    
</asp:Content>
