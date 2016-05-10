<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Club.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ClubManagementV1.Pages.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:ValidationSummary runat="server" headertext="There were errors on the page:" />

    <div class="well-lg"> 
        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtStudentName"
            ErrorMessage="Student Name is required.">*
        </asp:RequiredFieldValidator>
        <br />
        <label class="control-label col-sm-2" for="txtStudentName">Student Name</label> &nbsp;
        <div class="col-sm-10">
            <input type="text" class="form-control" id="txtStudentName" runat="server" />
        </div>
        <br />

        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtEmail"
            ErrorMessage="Student Email is required.">*
        </asp:RequiredFieldValidator>
        <label class="control-label col-sm-2" for="txtEmail">Email</label>&nbsp;
        <div class="col-sm-10">
            <input type="text" class="form-control" id="txtEmail" runat="server" />
        </div>
        <br />


        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtPhone"
            ErrorMessage="Student Phone is required.">
            *</asp:RequiredFieldValidator>
        <label class="control-label col-sm-2" for="txtPhone">Phone No</label>&nbsp;
        <div class="col-sm-10">
            <input type="text" runat="server" class="form-control" id="txtPhone" />
        </div>
        <br />


        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtUsername"
            ErrorMessage="Student Phone is required.">
                *</asp:RequiredFieldValidator>
        <label class="control-label col-sm-2" for="txtUsername">Username </label>&nbsp;
        <div class="col-sm-10">
            <asp:TextBox type="text" runat="server" class="form-control" ID="txtUsername" /> <asp:Button ID="check" runat="server" CssClass="btn btn-danger col-sm-12" OnClick="check_Click" Text="Check Availability"></asp:Button>
        </div>
        <br />


        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtPassword"
            ErrorMessage="Password is required.">
                *</asp:RequiredFieldValidator>
        <label class="control-label col-sm-2" for="txtPassword">Password</label>&nbsp;
        <div class="col-sm-10">
            <input type="password" runat="server" class="form-control" id="txtPassword" />
        </div>
        <br />

        <asp:CompareValidator runat="server"
            ControlToValidate="txtRePassword"
            ControlToCompare="txtPassword" 
            ErrorMessage="Passwords do not match." />

        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="txtRePassword"
            ErrorMessage="Re entry of Password is required.">
                *</asp:RequiredFieldValidator>
        <label class="control-label col-sm-2" for="txtRePassword">Password</label>&nbsp;
        <div class="col-sm-10">
            <input type="password" runat="server" class="form-control" id="txtRePassword" />

            <br />

            <asp:CheckBox runat="server" ID="agreeCheckBox" Text="I Iagree to the Rules and Regulation of AIUB Club Access" CssClass="checkbox" />

            <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="btn btn-success" OnClick="btnRegister_Click" />
            

        </div>
    </div>


</asp:Content>
