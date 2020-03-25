<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="AddTreatment.aspx.cs" Inherits="DCMS.AddTreatment" %>

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
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Cost"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCost" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="tbCost" runat="server" Display="Dynamic" Text="*" ErrorMessage="Cost is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12 mt-1">
            <table class="table-responsive w-25 mx-auto">
                <tr>
                    <td>
                        <asp:Button CssClass="btn-primary" ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12 mt-4">
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" Font-Bold="true" Font-Italic="true" DisplayMode="List" runat="server" />
            <asp:Label ID="lblMessage" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
