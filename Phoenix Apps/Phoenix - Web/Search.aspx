<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" title="Phoenix - Client Information Search - PCBSS" EnableEventValidation="false" EnableViewState="true" %>
<asp:Content ID="SearchHeader" ContentPlaceHolderID="content_Header" Runat="Server">
        <asp:Image ID="img_Header" runat="server" ImageUrl="img/headline_Search_beta.jpg" />
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="content_Main" Runat="Server">
<%--<div class="container">--%>
        <div class="clear"><span></span></div>   
        <div class="clear"><span></span></div> 
        <br />
        <asp:Panel ID="panel_Search" runat="server" cssclass="searchpanel">                
            <table>
                <tr>
                    <td align="left" colspan="2" style="text-align: center">
                        <asp:Label ID="lbl_Search" runat="server" CssClass="searchlabel" Text="Search Information" Font-Bold="True" Font-Underline="True" Font-Size="Medium"  />
                    </td>
                </tr>
                <tr>
                    <td style="width:54%; height: 26px;" align="right">
                        <asp:Label ID="Label1" runat="server" CssClass="searchlabel" Text="Social Security Number:"
                            Width="100%"></asp:Label></td>
                    <td style="width:88%; height: 26px;" align="left">
                        <asp:TextBox ID="txt_SSN" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 54%; height: 26px" align="right">
                        <asp:Label ID="Label2" runat="server" CssClass="searchlabel" Text="First Name:"
                            Width="100%"></asp:Label></td>
                    <td style="width: 88%; height: 26px" align="left">
                        <asp:TextBox ID="txt_FirstName" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 54%; height: 26px">
                        <asp:Label ID="Label3" runat="server" CssClass="searchlabel" Text="Last Name:"
                            Width="100%"></asp:Label></td>
                    <td align="left" style="width: 88%; height: 26px">
                        <asp:TextBox ID="txt_LastName" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 54%; height: 22px">
                        <asp:Label ID="Label4" runat="server" CssClass="searchlabel" Font-Italic="False"
                            Text="Supervisor:" Width="100%"></asp:Label>
                    </td>
                    <td align="left" style="width: 88%; height: 22px">
                        <asp:DropDownList ID="drop_Supervisor" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 54%; height: 25px">
                        <asp:Label ID="Label5" runat="server" CssClass="searchlabel" Text="Worker:"
                            Width="100%"></asp:Label></td>
                    <td align="left" style="width: 88%; height: 25px">
                        <asp:DropDownList ID="drop_Worker" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 54%; height: 25px"></td>
                    <td align="left" style="width: 88%; height: 25px">
                        <asp:Button ID="btn_Search" runat="server" Text="Find Cases" Width="150px" CssClass="button" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="text-align: right">
                        <asp:Label ID="lbl_Note" runat="server" CssClass="searchlabel" Text="<br />*Please enter data  in some or all fields to retrieve cases." Width="100%" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="update_Results" runat="server">
        <ContentTemplate>
            <asp:ListBox ID="list_Results" runat="server" CssClass="resultpanel" AutoPostBack="True" />
            <div class="clear"><span></span></div>
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" Width="150px" CssClass="submitbutton" Enabled="False" OnClick="btn_Submit_Click" />
            <asp:Label ID="lbl_NoCase" runat="server" CssClass="searchlabel" 
                style="color:Red; font-weight: bold; float: right; margin-right: 25px;" Text="No Cases Found" Visible="false" 
                Width="175px" />
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_Search" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
<%--</div>--%>   
<%--<ajaxToolkit:DropShadowExtender ID="shadow_Search" runat="server" TargetControlID="panel_Search" TrackPosition="True" />--%>
<ajaxToolkit:CascadingDropDown ID="cascade_Supervisor" runat="server" Category="Supervisor"
    ServiceMethod="SetSupervisor"
    ServicePath="SupervisorWorkerList.asmx" 
    TargetControlID="drop_Supervisor" 
    LoadingText="Loading..." 
    PromptText="Select A Supervisor" 
/>
<ajaxToolkit:CascadingDropDown ID="cascade_Worker" runat="server" Category="Worker"
    ParentControlID="drop_Supervisor"
    ServiceMethod="SetWorker" 
    ServicePath="SupervisorWorkerList.asmx" 
    TargetControlID="drop_Worker" 
    LoadingText="Loading..." 
    PromptText="Select A Worker"
/>        
<ajaxToolkit:MaskedEditExtender ID="maskededit_SSN" runat="server" 
    Mask="999-99-9999"
    TargetControlID="txt_SSN" 
    MaskType="Number" 
    AutoComplete="False" 
/>
<ajaxToolkit:MaskedEditValidator ID="maskedvalid_SSN" runat="server" 
    ControlExtender="maskededit_SSN"
    ControlToValidate="txt_SSN" 
    ErrorMessage="maskedvalid_SSN" 
    InvalidValueMessage="<b>Format Error</b><br/> Invalid Social Security Number!"
    ValidationExpression="\d{9}" 
    Display="None" CssClass="errormessage" 
/>
<ajaxToolkit:ValidatorCalloutExtender ID="validcallout_SSN" runat="server" TargetControlID="maskedvalid_SSN" />
<asp:RegularExpressionValidator ID="regex_FirstName" runat="server" 
    ControlToValidate="txt_FirstName"
    Display="None" 
    ErrorMessage="<b>Format Error</b><br/>First Name must be at least 3 characters!"
    ValidationExpression="^\w\w\w+"
/>
<ajaxToolkit:ValidatorCalloutExtender ID="validcallout_FirstName" runat="server" TargetControlID="regex_FirstName" />
<asp:RegularExpressionValidator ID="regex_LastName" runat="server" 
    ControlToValidate="txt_LastName"
    Display="None" 
    ErrorMessage="<b>Format Error</b><br/>Last Name must be at least 3 characters!"
    ValidationExpression="^\w\w\w+" 
 />
 <ajaxToolkit:ValidatorCalloutExtender ID="validcallout_LastName" runat="server" TargetControlID="regex_LastName" />
</asp:Content>

