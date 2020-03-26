<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DCMS.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dental Clinic Management System</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Styles/CustomStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script src="Scripts/CustomScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <%--Header--%>
        <div class="container-fluid bg-dark" id="logoHead">
            <div class="row font-italic" id="logoRow">
                <div class="col-12 col-md-3">
                    <%--<asp:Image ID="logoImg" src="Image/logo.png" runat="server" />--%>
                    <asp:ImageButton ID="logoImg" ImageUrl="Image/logo.png" OnClick="logoImg_Click" runat="server" />
                </div>
                <div class="col-12 col-md-6">
                    <asp:Label ID="logoTxt" runat="server" Text="Smile Dental Practice"></asp:Label>
                </div>
                <div class="col-12 col-md-3 text-right">
                    <asp:ImageButton ID="facebookImg" CssClass="rounded-circle logoContact" ImageUrl="~/Image/facebook.png" OnClientClick="window.open('https://www.facebook.com/abhishek.srivastava.9235','_blank')" runat="server" />
                    <asp:ImageButton ID="twitterImg" CssClass="logoContact" ImageUrl="~/Image/TLogo.png" OnClientClick="window.open('https://twitter.com/Abhishe15459723?s=03','_blank')" runat="server" />
                    <asp:ImageButton ID="googleMapsImg" CssClass="logoContact" ImageUrl="~/Image/GMlogo.png" OnClientClick="window.open('https://goo.gl/maps/oQDPULh6Ex5XdPe67','_blank')" runat="server" />
                </div>
            </div>
        </div>
        <%--Body--%>
        <div class="container-fluid bodyBG">
            <div class="col-sm-12 pt-2 pt-md-3 pb-md-2">
                <asp:Button ID="btnAdmin" CssClass="btnHome" runat="server" Text="Admin (without login)" OnClick="btnAdmin_Click" />
                <asp:Button ID="btnAdmin1" CssClass="btnHome" runat="server" Text="Admin (via login screen)" OnClick="btnAdmin1_Click" />
            </div>
            <div class="col-sm-12 pt-2 pt-md-3 pb-md-2">
                <asp:Button ID="btnDentist" CssClass="btnHome" runat="server" Text="Dentist (without login)" OnClick="btnDentist_Click" />
                <asp:Button ID="btnDentist1" CssClass="btnHome" runat="server" Text="Dentist (via login screen)" OnClick="btnDentist1_Click" />
            </div>
            <div class="col-sm-12 pt-2 pt-md-3 pb-md-2">
                <asp:Button ID="btnDefaultPatient" runat="server" CssClass="btnHome" Text="Patient (without login)" OnClick="btnDefaultPatient_Click" />
                <asp:Button ID="btnPatientAccess" runat="server" CssClass="btnHome" Text="Patient (via login screen)" OnClick="btnPatientAccess_Click" />
            </div>
            <div class="col-sm-12 pt-2 pt-md-3 pb-md-2">
                <asp:Button ID="btnNewPatient" runat="server" CssClass="btnHome" Text="New Patient" OnClick="btnNewPatient_Click" />
            </div>
            <div class="col-sm-12 pt-md-5 pb-md-5"></div>
            <div class="col-sm-12 pt-md-5 pb-md-5"></div>
        </div>
    </form>
</body>
</html>
