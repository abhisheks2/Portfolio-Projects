<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="TreatmentPlanning.aspx.cs" Inherits="DCMS.TreatmentPlanning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid d-flex flex-column text-left align-content-end">
        <div class="row mt-5">
            <div class="col-12 offset-md-3">
                <table class="table-responsive bg-primary pt-2 pl-2 pb-2" style="width:350px;color:white">
                    <tr>
                        <td>
                            <asp:Label ID="lblDoctor" runat="server" Text="Doctor"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDoctor" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPatient" runat="server" Text="Patient"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPatient" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTreatment" runat="server" Text="Treatment"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTreatment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTreatment_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCost" runat="server" Text="Cost"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCost" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTooth" runat="server" Text="Tooth"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTooth" runat="server">
                                <asp:ListItem>UR-1</asp:ListItem><asp:ListItem>UR-2</asp:ListItem><asp:ListItem>UR-3</asp:ListItem><asp:ListItem>UR-4</asp:ListItem>
                                <asp:ListItem>UR-5</asp:ListItem><asp:ListItem>UR-6</asp:ListItem><asp:ListItem>UR-7</asp:ListItem><asp:ListItem>UR-8</asp:ListItem>
                                <asp:ListItem>UL-1</asp:ListItem><asp:ListItem>UL-2</asp:ListItem><asp:ListItem>UL-3</asp:ListItem><asp:ListItem>UL-4</asp:ListItem>
                                <asp:ListItem>UL-5</asp:ListItem><asp:ListItem>UL-6</asp:ListItem><asp:ListItem>UL-7</asp:ListItem><asp:ListItem>UL-8</asp:ListItem>
                                <asp:ListItem>LR-1</asp:ListItem><asp:ListItem>LR-2</asp:ListItem><asp:ListItem>LR-3</asp:ListItem><asp:ListItem>LR-4</asp:ListItem>
                                <asp:ListItem>LR-5</asp:ListItem><asp:ListItem>LR-6</asp:ListItem><asp:ListItem>LR-7</asp:ListItem><asp:ListItem>LR-8</asp:ListItem>
                                <asp:ListItem>LL-1</asp:ListItem><asp:ListItem>LL-2</asp:ListItem><asp:ListItem>LL-3</asp:ListItem><asp:ListItem>LL-4</asp:ListItem>
                                <asp:ListItem>LL-5</asp:ListItem><asp:ListItem>LL-6</asp:ListItem><asp:ListItem>LL-7</asp:ListItem><asp:ListItem>LL-8</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex justify-content-around">
        <div class="row mt-2">
            <div class="col-12">
                <asp:Button CssClass="btn btn-primary" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button CssClass="btn btn-primary" ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex text-center justify-content-center">
        <div class="row mt-2">
            <div class="col-12">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Italic="true" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
