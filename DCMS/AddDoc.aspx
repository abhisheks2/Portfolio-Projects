<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="AddDoc.aspx.cs" Inherits="DCMS.AddDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt-1 mt-md-5">
        <div class="col-12">
            <table class="table-responsive bg-primary text-white w-25 mt-1 mt-md-5 mx-auto pt-3 pb-3 pl-3">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="tbName" runat="server" Display="Dynamic" Text="*" ErrorMessage="Name is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Salary"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbSalary" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="tbSalary" runat="server" Display="Dynamic" Text="*" ErrorMessage="Salary is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12">
            <table class="table-responsive w-25 mx-auto">
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="False" />
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12 mt-4">
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" Font-Bold="true" Font-Italic="true" DisplayMode="List" runat="server" />
        </div>
    </div>
</asp:Content>
