<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="DCMS.Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 500px; margin: 0 auto; margin-top: 25px; background-color: dodgerblue">
        <tr style="width: 500px; height: 50px">
            <td style="width: 250px">
                <asp:Label ID="Label1" runat="server" Text="Previous Password"></asp:Label>
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="PASS" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="width: 500px; height: 50px">
            <td style="width: 250px">
                <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="Newpass" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="width: 500px; height: 50px">
            <td style="width: 250px">
                <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="ConfirmPass" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="width: 500px; height: 50px">
            <td style="width: 250px">
                <asp:Button ID="Confirm" runat="server" Text="Complete"
                    OnClick="Confirm_Click" />
            </td>
            <td style="width: 250px">
                <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
            </td>
        </tr>
        <tr style="width: 500px; height: 50px">
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" Text="" Font-Bold="true" Font-Italic="true"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

