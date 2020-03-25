<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="PatientPayments.aspx.cs" Inherits="DCMS.PatientPayments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid d-flex flex-column">
        <div class="row">
            <div class="col-12 mt-2">
                <asp:DropDownList id="ddlPatient" BackColor="SkyBlue" Width="200px" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPatient_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-12 mt-2">
                <asp:GridView id="gvPatientHistory" runat="server" DataKeyNames="tID" OnRowCommand="gvPatientHistory_RowCommand" HorizontalAlign="Center" BackColor="WhiteSmoke" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="SkyBlue" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ReceivePayment" CommandArgument='<%# Eval("tID") %>'>ReceivePayment</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="treatmentname" HeaderText="Treatment" />
                        <asp:BoundField DataField="tID" HeaderText="Treatment ID" />
                        <asp:BoundField DataField="dID" HeaderText="Doctor" />
                        <asp:BoundField DataField="tooth" HeaderText="Tooth Number" />
                        <asp:BoundField DataField="date" HeaderText="Treatment Date" />
                        <asp:BoundField DataField="cost" HeaderText="Treatment Cost" />
                        <asp:BoundField DataField="paid" HeaderText="Paid to date" />
                    </Columns>
                    <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex-column">
        <div class="row mt-2">
            <div class="col-12">
                <asp:Label ID="lblMessageGV" runat="server" Font-Bold="true" Font-Italic="true"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex-column">
        <div class="row mt-2">
            <div class="col-12">
                <asp:Label ID="lblMessageDV" runat="server" Font-Bold="true" Font-Italic="true"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex-column">
        <div class="row mt-3">
            <div class="col-12">
                <asp:DetailsView ID="dvReceivePayment" HorizontalAlign="Center" DataKeyNames="tID" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateRows="False" AutoGenerateEditButton="True" OnItemUpdating="dvReceivePayment_ItemUpdating" OnModeChanging="dvReceivePayment_ModeChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="DodgerBlue" />
                    <EditRowStyle BackColor="SkyBlue" />
                    <FieldHeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="tName" HeaderText="Treatment" ReadOnly="true" />
                        <asp:BoundField DataField="tID" HeaderText="Treatment ID" ReadOnly="true" />
                        <asp:BoundField DataField="cost" HeaderText="Treatment Cost" ReadOnly="true" />
                        <asp:BoundField DataField="paid" HeaderText="Paid to date" ReadOnly="false" />
                    </Fields>
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="SkyBlue" />
                </asp:DetailsView>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex-column">
        <div class="row mt-2">
            <div class="col-12">
                <asp:Button CssClass="btn btn-primary" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>
