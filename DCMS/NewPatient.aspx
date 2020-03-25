<%@ Page Title="" Language="C#" MasterPageFile="~/DCMSMasterPage.Master" AutoEventWireup="true" CodeBehind="NewPatient.aspx.cs" Inherits="DCMS.NewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt-4 ml-4 mr-4">
        <div class="col-12 col-md-4 pt-2 pb-2 bg-primary">
            <table class="table-responsive">
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                            ErrorMessage="Name is required" Display="Dynamic" Text="*" ControlToValidate="tbName">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                            ErrorMessage="Email is required" Display="Dynamic" Text="*" ControlToValidate="tbEmail">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail"
                            runat="server" ErrorMessage="Invalid Email Format" Display="Dynamic"
                            ControlToValidate="tbEmail" ForeColor="Red"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Text="*">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Birth Date"></asp:Label>
                    </td>
                    <td>
                        <input type="date" runat="server" id="tbDOB" style="width:207px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                            ErrorMessage="Birth Date is required" Display="Dynamic" Text="*" ControlToValidate="tbDOB">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbAdress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                            ErrorMessage="Address is required" Display="Dynamic" Text="*" ControlToValidate="tbAdress">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Contact No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbContactNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Age"></asp:Label>
                    </td>
                    <td>
                        <input type="number" id="tbAge" runat="server" style="width:207px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                            ErrorMessage="Age is required" Display="Dynamic" Text="*" ControlToValidate="tbAge">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Sex"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSex" runat="server" Width="207px">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Marial Status"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="207px">
                            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                            <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                            <asp:ListItem Text="Divorced" Value="Divorced"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Occupation"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOccupation" runat="server" Width="207px">
                            <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
                            <asp:ListItem Text="Business" Value="Business"></asp:ListItem>
                            <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                            <asp:ListItem Text="Unemployed" Value="Umemployed"></asp:ListItem>
                            <asp:ListItem Text="Pensioner" Value="Pensioner"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Allergic to"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbAllergicTo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Medicine"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbMedicine" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="text-right">
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Sensitivity To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbSensitivityTo" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-12 col-md-4 pl-0 pt-2 pb-2 bg-primary">
            <table class="table-responsive">
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbBadCondition" runat="server" Text="Bad Condition" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbGumBleeds" runat="server" Text="Gum Bleeds" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbToothLoose" runat="server" Text="Tooth Loose" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbChestPain" runat="server" Text="Chest pain" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbGumDisease" runat="server" Text="Gum Disease" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbBadBreath" runat="server" Text="Bad Breath" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbJawpain" runat="server" Text="Jaw Pain" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbBleedingTend" runat="server" Text="Bleeding Tend" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbHepatitis" runat="server" Text="Hepatitis" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbHighBP" runat="server" Text="High BP" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbDiabetes" runat="server" Text="Diabetes" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbKidneyDisease" runat="server" Text="Kidney Disease" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbHeartTrouble" runat="server" Text="Heart Trouble" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbLiverDisease" runat="server" Text="Liver Disease" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbLungDisease" runat="server" Text="Lung Disease" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbAsthma" runat="server" Text="Asthma" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbRheumatic" runat="server" Text="Rheumatic" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbAIDS" runat="server" Text="AIDS" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:CheckBox ID="cbAnemia" runat="server" Text="Anemia" />
                    </td>
                    <td class="text-left">
                        <asp:CheckBox ID="cbPregnant" runat="server" Text="Pregnant" />
                    </td>
                </tr>
                <tr>
                    <td class="text-left">
                        <asp:Button ID="Add" runat="server" Text="ADD" Width="129px"
                            OnClick="Add_Click" />
                    </td>
                    <td class="text-left">
                        <asp:Button ID="Back" runat="server" Text="Back" Width="129px" CausesValidation="false"
                            OnClick="Back_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="col-12 text-left">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="Larger" ShowSummary="true" DisplayMode="List" />
    </div>
    <div class="row text-center">
        <asp:Label ID="lblMessage" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

