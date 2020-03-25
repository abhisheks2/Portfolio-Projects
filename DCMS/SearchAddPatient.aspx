<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="SearchAddPatient.aspx.cs" Inherits="DCMS.SearchAddPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 500px; margin: 0 auto; margin-top: 75px; background-color: dodgerblue">
        <tr style="width: 500px; height: 50px">
            <td class="text-right">
                <asp:Label ID="Label1" runat="server" Text="Patient Email"></asp:Label>
            </td>
            <td class="text-right">
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                
            </td>
            <td class="text-left ml-0 pl-0">
                <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"/>
            </td>
        </tr>
        <tr style="width: 500px; height: 50px">
            <td>
                <asp:Button ID="add" runat="server" Text="Add New Patient"
                    OnClick="add_Click" />
            </td>
            <td style="width: 250px">
                <asp:Button ID="Back" runat="server" Text="Back" Width="82px"
                    OnClick="Back_Click" />
            </td>
            <td>
                <asp:Button ID="list" runat="server" Text="Patient List"
                    OnClick="list_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Italic="true" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
