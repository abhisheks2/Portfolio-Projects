<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="DCMS.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:500px;margin:0 auto;margin-top:25px;background-color:dodgerblue">
    <tr style="width:500px;height:50px">
        <td style="width:250px">
            <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
        </td>
        <td style="width:250px">
            <asp:DropDownList ID="ddlRole" Width="180px" Height="30px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                <asp:ListItem>Please select a role</asp:ListItem>
                <asp:ListItem>admin</asp:ListItem>
                <asp:ListItem>doctor</asp:ListItem>
                <asp:ListItem>staff</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr style="width:500px;height:50px">
        <td style="width:250px">
            <asp:Label ID="lblDoctor" runat="server" Text="Doctor ID"></asp:Label>
        </td>
        <td style="width:250px">
            <asp:DropDownList ID="ddlDoctor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged"></asp:DropDownList>
        </td>
    </tr>
    <tr style="width:500px;height:50px">
        <td style="width:250px">
            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        </td>
        <td style="width:250px">
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr style="width:500px;height:50px">
        <td style="width:250px">
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        </td>
        <td style="width:250px">
            <asp:TextBox ID="Pass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr style="width:500px;height:50px">
        <td style="width:250px">
            <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
        </td>
        <td style="width:250px">
            <asp:TextBox ID="CPass" runat="server" TextMode=Password></asp:TextBox>
        </td>
    </tr>
    <tr style="width:500px;height:50px">
        <td style="width:250px">
            <asp:Button ID="Confirm" runat="server" Text="Confirm" 
                onclick="Confirm_Click" />
        </td>
        <td style="width:250px">
            <asp:Button ID="Back" runat="server" Text="Back" onclick="Back_Click" />
        </td>
    </tr>
    <tr style="width:500px;height:50px">
        <td colspan="2">
            <asp:Label ID="lblMessage" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
