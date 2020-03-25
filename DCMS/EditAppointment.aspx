<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMasterPage.Master" AutoEventWireup="true" CodeBehind="EditAppointment.aspx.cs" Inherits="DCMS.EditAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid d-flex text-center justify-content-center">
        <div class="row">
            <div class="col-12 pt-5">
                <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="False" BackColor="WhiteSmoke" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" DataKeyNames="appointmentID" OnRowCommand="gvAppointments_RowCommand" OnRowDataBound="gvAppointments_RowDataBound" OnSelectedIndexChanged="gvAppointments_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="SkyBlue" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbEdit" CommandArgument='<%# Eval("appointmentID") %>' CommandName="EditRow" runat="server">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lbDelete" CommandArgument='<%# Eval("appointmentID") %>' CommandName="DeleteRow" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("appointmentID") %>' CommandName="UpdateRow" runat="server">Update</asp:LinkButton>
                                <asp:LinkButton ID="lbCancel" CommandArgument='<%# Eval("appointmentID") %>' CommandName="CancelUpdate" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appointment ID" InsertVisible="False" SortExpression="appointmentID">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("appointmentID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("appointmentID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Patient ID" SortExpression="id">
                            <EditItemTemplate>
                                <asp:Label ID="lblPID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" SortExpression="date">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="name">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlDoctor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time" SortExpression="time">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlTime" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex=row text-center justify-content-center">
        <div class="row mt-3">
            <div class="col-12">
                <asp:Button CssClass="btn btn-info" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex-row text-center justify-content-center">
        <div class="row mt-3">
            <div class="col-12">
                <asp:Label ID="lblMessage" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
