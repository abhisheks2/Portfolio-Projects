<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="DentalHistory.aspx.cs" Inherits="DCMS.DentalHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid d-flex flex-column">
        <div class="row">
            <div class="col-12 mt-2">
                <asp:DropDownList id="ddlPatient" BackColor="SkyBlue" Width="200px" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPatient_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-12 mt-2">
                <asp:GridView id="gvPatientHistory" runat="server" HorizontalAlign="Center" BackColor="WhiteSmoke" BorderColor="DodgerBlue" BorderWidth="2px" CellPadding="4" GridLines="None" ForeColor="Black" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="SkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="treatmentname" HeaderText="Treatment" />
                        <asp:BoundField DataField="dID" HeaderText="Doctor" />
                        <asp:BoundField DataField="tooth" HeaderText="Tooth Number" />
                        <asp:BoundField DataField="date" HeaderText="Treatment Date" />
                    </Columns>
                    <HeaderStyle BackColor="DodgerBlue" Font-Bold="True" />
                </asp:GridView>
            </div>
            <div class="col-12 mt-2">
                <asp:TextBox ID="txtMedInfo" Width="300px" BackColor="SkyBlue" runat="server" Enabled="False" Rows="5" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="container-fluid d-flex flex-column">
        <div class="row mt-2">
            <div class="col-12">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Italic="true"></asp:Label>
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
