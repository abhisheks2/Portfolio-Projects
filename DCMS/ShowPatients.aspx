<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="ShowPatients.aspx.cs" Inherits="DCMS.ShowPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView CssClass="mt-3" ID="Patients" HorizontalAlign="Center" runat="server" BackColor="WhiteSmoke" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" AutoGenerateColumns="False"
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="SkyBlue" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Patient ID" />
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="contactNo" HeaderText="Contact" />
            <asp:BoundField DataField="dob" DataFormatString="{0:d}" HeaderText="Date of Birth" />
            <asp:BoundField DataField="address" HeaderText="Address" />
        </Columns>
        <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
    </asp:GridView>

    <table style="width:500px;margin:0 auto;margin-top:auto">
        <tr style="width:250px;height:50px">
            <td>
                <asp:Button CssClass="btn btn-primary" ID="Back" runat="server" Text="Back" onclick="Back_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
