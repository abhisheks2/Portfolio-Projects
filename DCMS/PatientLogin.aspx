﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderMaster.Master" AutoEventWireup="true" CodeBehind="PatientLogin.aspx.cs" Inherits="DCMS.PatientLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="table-responsive">
            <table class="table table-borderless">
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label2" Font-Bold="true" Font-Size="Large" runat="server" Text="Please sign in"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbEmail" placeholder="Email" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbID" placeholder="Patient ID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-info" ID="Log" runat="server" Text="Login" OnClick="Log_Click" />
                    </td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
                <tr class="mt-md-5 mb-md-5">
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

