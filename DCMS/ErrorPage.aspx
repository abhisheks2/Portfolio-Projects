<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderMaster.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="DCMS.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <asp:Label runat="server" Font-Bold="true" ForeColor="Red" Font-Size="XX-Large" Text="Something went wrong, please try again later or contact abhisheks2@gmail.com"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
