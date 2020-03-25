<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="ShowPatientDetails.aspx.cs" Inherits="DCMS.ShowPatientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt-4 ml-5">
        <div class="col-12 col-md-4 pt-2 pb-2 bg-primary">
            <table class="table-responsive">
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbID" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label9" runat="server" Text="Birth Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbDOB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label3" runat="server" Text="Contact No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbContactNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label4" runat="server" Text="Age"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label5" runat="server" Text="Sex"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbSex" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label6" runat="server" Text="Marital Status"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbMaritalStatus" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-right">
                        <asp:Label ID="Label7" runat="server" Text="Occupation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbOccupation" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12 col-md-7 pt-2 pb-2 bg-primary">
            <table class="table-responsive">
                <tr>
                    <td>
                        <h4>Medical History</h4>
                        <textarea id="MedInfo" cols="75" rows="10" runat="server"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12 offset-3 mt-2">
            <table class="table-responsive">
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="History" runat="server" Text="History" OnClick="History_Click" />
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

