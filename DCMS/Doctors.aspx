<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="DCMS.Doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt-1 mt-md-3">
        <div class="table-responsive col-12 mt-1 mt-md-5">
            <asp:GridView ID="Docs" HorizontalAlign="Center" runat="server" BackColor="WhiteSmoke" OnRowDataBound="Docs_RowDataBound" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="SkyBlue" />
                <Columns>
                    <asp:BoundField DataField="docID" HeaderText="Doctor ID" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="salary" HeaderText="Salary" />
                    <asp:BoundField DataField="available" HeaderText="Is Available?" />
                </Columns>
                <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
            </asp:GridView>
        </div>
    </div>
    <div class="col-12 offset-md-5">
        <table class="table-responsive">
            <tr>
                <td>
                    <asp:Button CssClass="btn btn-primary" ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
                </td>
                <td>
                    <asp:Button CssClass="btn btn-primary" ID="Add" runat="server" Text="Add" OnClick="Add_Click" />
                </td>
                <td>
                    <asp:Button CssClass="btn btn-primary" ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
