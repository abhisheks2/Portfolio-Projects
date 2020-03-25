<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="DCMS.MedicineCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView CssClass="mt-5" ID="Inventory" HorizontalAlign="Center" runat="server" OnRowDataBound="Inventory_RowDataBound" BackColor="WhiteSmoke" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" AutoGenerateColumns="False"
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="SkyBlue" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Item ID" />
                    <asp:BoundField DataField="Name" HeaderText="Item Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                </Columns>
                <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
    </asp:GridView>

    <table style="width:500px;margin:0 auto;margin-top:5px">
        <tr>
            <td>
                <asp:Button ID="Back" runat="server" Text="Back" BorderColor="DodgerBlue" onclick="Back_Click" />
            </td>
            <td>
                <asp:Button ID="Update" runat="server" Text="Update" BorderColor="DodgerBlue" onclick="Update_Click" />
            </td>
            <td>
                <asp:Button ID="Add" runat="server" Text="Add" BorderColor="DodgerBlue" onclick="Add_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
