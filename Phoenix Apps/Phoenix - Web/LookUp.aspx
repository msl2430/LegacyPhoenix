<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LookUp.aspx.vb" Inherits="LookupTest" title="Phoenix - Client Look Up Submission - PCBSS" %>
<asp:Content ID="LookupHeader" ContentPlaceHolderID="content_Header" Runat="Server">
    <asp:Image ID="img_Header" runat="server" ImageUrl="img/headline_beta.jpg" />
</asp:Content>
<asp:Content ID="LookupEntry" ContentPlaceHolderID="content_Main" Runat="Server">
    <asp:Label ID="lbl_CaseSubmitted" runat="server" Text=" " CssClass="submittedlabel" Visible="false" />&nbsp;
    <asp:Panel ID="panel_Form" runat="server" CssClass="panel">
        <table class="table" border="0">
            <tr>
                <td style="width:90%; height:26px;" colspan="4" align="center"><asp:Label ID="lbl_Search" runat="server" CssClass="searchlabel" Text="Client Information Entry" Font-Bold="True" Font-Underline="True" Font-Size="Medium"  /></td>
            </tr>
            <tr>
                <td style="width:22%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_SSN" runat="server" CssClass="formlabel" Text="Social Security:" /></td>
                <td style="width:28%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_SSN" runat="server" Width="150px" TabIndex="1" /></td>
                <td style="width:15%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_Address" runat="server" CssClass="formlabel" Text="Address:" /></td>
                <td style="width:35%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_Address1" runat="server" MaxLength="20" TabIndex="6" /><br /><asp:TextBox ID="txt_Address2" runat="server" MaxLength="20" TabIndex="7" /></td>
            </tr>
            <tr>
                <td style="width:22%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_FirstName" runat="server" CssClass="formlabel" Text="First Name:" /></td>
                <td style="width:28%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_FirstName" runat="server" MaxLength="20" TabIndex="1" /></td>
                <td style="width:15%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_City" runat="server" CssClass="formlabel" Text="City:" /></td>
                <td style="width:35%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_City" runat="server" MaxLength="18" TabIndex="8" /></td>
            </tr>
            <tr>
                <td style="width:22%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_LastName" runat="server" CssClass="formlabel" Text="Last Name:" /></td>
                <td style="width:28%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_LastName" runat="server" MaxLength="12" TabIndex="2" /></td>
                <td style="width:15%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_State" runat="server" CssClass="formlabel" Text="State:" /></td>
                <td style="width:35%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_State" runat="server" MaxLength="2" Width="25px" TabIndex="9" /></td>
            </tr>
            <tr>
                <td style="width:22%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_Sex" runat="server" CssClass="formlabel" Text="Sex:" /></td>
                <td style="width:28%; height: 26px;" align="left" valign="top">
                    <asp:DropDownList ID="drop_Sex" runat="server" TabIndex="4">
                        <asp:ListItem> </asp:ListItem>
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:15%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_Zip" runat="server" CssClass="formlabel" Text="Zip:" /></td>
                <td style="width:35%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_ZipCode" runat="server" MaxLength="9" Width="80px" TabIndex="10" /></td>
            </tr>
            <tr>
                <td style="width:22%; height: 26px;" align="right" valign="top"><asp:Label ID="lbl_DateOfBirth" runat="server" CssClass="formlabel" Text="Date of Birth:" /></td>
                <td style="width:28%; height: 26px;" align="left" valign="top"><asp:TextBox ID="txt_DateOfBirth" runat="server" MaxLength="10" Width="80px" TabIndex="5" /></td>
                <td style="width:15%; height: 26px;" align="right" valign="top">&nbsp;</td>
                <td style="width:35%; height: 26px;" align="left" valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90%; height: 26px;" align="center" colspan="4"><asp:Button ID="btn_Submit" runat="server" text="Submit" width="125px" CausesValidation="False" TabIndex="11" />
                    <br /><asp:Label ID="lbl_Error" runat="server" CssClass="errorlabel" Text="   " Width="225px" />
                </td>
            </tr>
        </table>
        </asp:Panel>
        <br />
        <ajaxToolkit:MaskedEditExtender ID="masked_SSN" runat="server" Mask="999-99-9999" MaskType="Number" TargetControlID="txt_SSN" />
        <ajaxToolkit:MaskedEditExtender ID="masked_DOB" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_DateOfBirth" />
        <asp:RequiredFieldValidator ID="req_SSN" runat="server" ControlToValidate="txt_SSN" Display="None" ErrorMessage="RequiredFieldValidator" />
        <%--<asp:RequiredFieldValidator ID="req_FirstName" runat="server" ControlToValidate="txt_FirstName" Display="None" ErrorMessage="RequiredFieldValidator" />
        <asp:RequiredFieldValidator ID="req_LastName" runat="server" ControlToValidate="txt_LastName" Display="None" ErrorMessage="RequiredFieldValidator" />
        <asp:RequiredFieldValidator ID="req_DateOfBirth" runat="server" ControlToValidate="txt_DateOfBirth" Display="None" ErrorMessage="RequiredFieldValidator" />
        <asp:RequiredFieldValidator ID="req_Address1" runat="server" ControlToValidate="txt_Address1" Display="None" ErrorMessage="RequiredFieldValidator" />
        <asp:RequiredFieldValidator ID="req_City" runat="server" ControlToValidate="txt_City" Display="None" ErrorMessage="RequiredFieldValidator" />
        <asp:RequiredFieldValidator ID="req_State" runat="server" ControlToValidate="txt_State" Display="None" ErrorMessage="RequiredFieldValidator" />
        <asp:RequiredFieldValidator ID="req_ZipCode" runat="server" ControlToValidate="txt_ZipCode" Display="None" ErrorMessage="RequiredFieldValidator" />--%>
        <%--<ajaxToolkit:DropShadowExtender ID="shadow_Search" runat="server" TargetControlID="panel_Form" TrackPosition="True" />--%>
</asp:Content>

