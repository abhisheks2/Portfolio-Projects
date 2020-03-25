<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMasterPage.Master" AutoEventWireup="true" CodeBehind="GetAppointment.aspx.cs" Inherits="DCMS.GetAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row pt-3" id="bodyBG2" style="height:550px">
        <table class="table-responsive col-12">
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" Font-Bold="true" Text="Date"></asp:Label>
                </td>
                <td>

                    <asp:DropDownList ID="ddlDate" runat="server" Width="200px" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"
                        OnTextChanged="ddlDate_SelectedIndexChanged" Font-Bold="true" BackColor="SkyBlue" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDoctor" runat="server" Font-Bold="true" Text="Doctor"></asp:Label>
                </td>
                <td>

                    <asp:DropDownList ID="ddlDoctor" runat="server" Width="200px" DataTextField="Name" DataValueField="Name"
                        OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged" Font-Bold="true" BackColor="SkyBlue"
                        OnTextChanged="ddlDoctor_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTime" Font-Bold="true" runat="server" Text="Time"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTime" DataTextField="time" Width="200px" DataValueField="time" Font-Bold="true" BackColor="SkyBlue" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Back" BorderColor="#66FFFF"
                        BorderStyle="Groove" OnClick="Button2_Click" />
                    <asp:Button ID="Ok" runat="server" Text="OK" BorderColor="#66FFFF"
                        BorderStyle="Groove" OnClick="Ok_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Italic="true" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

