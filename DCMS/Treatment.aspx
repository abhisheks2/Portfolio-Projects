<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="Treatment.aspx.cs" Inherits="DCMS.Treatment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-1 mt-md-2">
        <div class="table-responsive col-12 mt-1 mt-md-2">
            <asp:GridView ID="gvTreatment" HorizontalAlign="Center" runat="server" OnRowDataBound="gvTreatment_RowDataBound" BackColor="WhiteSmoke" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="SkyBlue" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Treatment Name" />
                    <asp:BoundField DataField="cost" HeaderText="Treatment Cost" DataFormatString="{0:c}" />
                </Columns>
                <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
            </asp:GridView>
        </div>
    </div>
    <div class="col-12 offset-md-2">
        <table class="table-responsive w-50 mx-auto">
            <tr>
                <td>
                    <asp:Button CssClass="btn-primary" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                </td>
                <td>
                    <asp:Button CssClass="btn-primary" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </td>
                <td>
                    <asp:Button CssClass="btn-primary" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="panelAdd" runat="server">
        <div class="row mt-1 mt-md-3">
            <div class="col-12">
                <table class="table-responsive bg-primary text-white w-25 mt-1 mt-md-2 mx-auto pt-3 pb-3 pl-3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtAddName" runat="server" Display="Dynamic" Text="*" ErrorMessage="Name is required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Cost"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddCost" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtAddCost" runat="server" Display="Dynamic" Text="*" ErrorMessage="Cost is required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-12 mt-1">
                <table class="table-responsive w-25 mx-auto">
                    <tr>
                        <td>
                            <asp:Button CssClass="btn-primary" ID="btnAddBack" runat="server" Text="Back" OnClick="btnAddBack_Click" CausesValidation="False" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn-primary" ID="btnAddConfirm" runat="server" Text="Confirm" OnClick="btnAddConfirm_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelUpdate" runat="server">
        <div class="row mt-1 mt-md-3">
            <div class="col-12">
                <table class="table-responsive bg-primary text-white w-25 mt-1 mt-md-2 mx-auto pt-3 pb-3 pl-3">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="w-75" ID="ddlUpdName" DataTextField="name" DataValueField="name" runat="server" OnSelectedIndexChanged="ddlUpdName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Cost"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="w-75" ID="txtUpdCost" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtUpdCost" runat="server" Display="Dynamic" Text="*" ErrorMessage="Cost is required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-12 mt-1">
                <table class="table-responsive w-25 mx-auto">
                    <tr>
                        <td>
                            <asp:Button CssClass="btn-primary" ID="btnUpdBack" runat="server" Text="Back" OnClick="btnUpdBack_Click" CausesValidation="False" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn-primary" ID="btnUpdFetch" runat="server" Text="Fetch" OnClick="btnUpdFetch_Click" CausesValidation="false" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn-primary" ID="btnUpdConfirm" runat="server" Text="Confirm" OnClick="btnUpdConfirm_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <div class="row mt-2">
        <div class="col-12">
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" Font-Bold="true" Font-Italic="true" DisplayMode="List" runat="server" />
            <asp:Label ID="lblMessage" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
