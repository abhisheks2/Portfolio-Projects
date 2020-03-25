<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateDoctors.aspx.cs" Inherits="DCMS.UpdateDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt-1 mt-md-5">
        <div class="col-12 mt-1 mt-md-5">
            <table class="table-responsive bg-primary text-white w-25 mx-auto pt-3 pb-3 pl-3">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="w-100 ml-2" ID="ddlDocID" DataTextField="DocID" DataValueField="DocID" OnSelectedIndexChanged="ddlDocID_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" CssClass="ml-2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Salary"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="ml-2" ID="tbSalary" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Avaliable"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox CssClass="ml-2" ID="cbxAvailable" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="col-12 mt-1">
                <table class="table-responsive w-25 mx-auto">
                    <tr>
                        <td>
                            <asp:Button CssClass="btn btn-primary" ID="Back" runat="server" Text="Back" OnClick="Back_Click" CausesValidation="False" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-primary" ID="Fetch" runat="server" Text="Fetch" OnClick="Fetch_Click" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-primary" ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-12 mt-3">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>