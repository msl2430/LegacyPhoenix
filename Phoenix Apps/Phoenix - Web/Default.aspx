<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Phoenix - PCBSS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_Header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_Main" Runat="Server">
<div class="bodycontainer">
    <div class="welcomeblock"><asp:Image ID="img_Welocme" runat="server" ImageUrl="img/welcomeblock.gif" /></div>
    <asp:Image ID="img_Logo" runat="server" ImageUrl="img/PCBSSLogo.gif" CssClass="logo" />
    <br /><br />
    <div style="clear: both;"></div>
    <asp:Panel ID="panel_Reports" runat="server" class="navpanel">
        <div class="navheadline">Reports</div>
        <div class="navbody">
            <dl>
                <%--<dt><asp:Image ID="img_arrow1" runat="server" ImageUrl="img/arrow.gif" />&nbsp;<a href="#">Daily Recertifications</a></dt>
                    <dd>Food Stamp Recertifications that were processed from mailed client letter.</dd>--%>
                <dt><asp:Image ID="img_arrow2" runat="server" ImageUrl="img/arrow.gif" />&nbsp;<a href="IMPs.aspx">IMPs / TRE Results</a></dt>
                    <dd>Daily processing results of IMPs /TREs.</dd>
                <dt><asp:Image ID="img_arrow3" runat="server" ImageUrl="img/arrow.gif" />&nbsp;<a href="Search.aspx">Individual Client Data</a></dt>
                    <dd>Search of individual client data forms from database.</dd>
               <%-- <dt><asp:Image ID="img_arrow4" runat="server" ImageUrl="img/arrow.gif" />&nbsp;<a href="SignaturePage.aspx">30 Day Pending Cases</a></dt>
                    <dd>Cases 30 days past since FAMIS processing was requested by worker.</dd>--%>
            </dl>
        </div>
    </asp:Panel>
    <asp:Panel ID="panel_Forms" runat="server" class="navpanel">
        <div class="navheadline">Forms</div>
        <div class="navbody">
            <dl>
                 <dt><asp:Image ID="Image4" runat="server" ImageUrl="img/arrow.gif" />&nbsp;<a href="LookUp.aspx">Client Data Submission</a></dt>
                    <dd>Submit a client to have his/her information retrieved. (i.e. Wages, FAMIS, UIB, DABS, SSI, Child Support) </dd>
                 <dt><asp:Image ID="Image1" runat="server" ImageUrl="img/arrow.gif" />&nbsp;<a href="IRF.aspx">IRF Monthly Manifest</a></dt>
                    <dd>Manifest of IRF letters mailed to clients this month.</dd>
            </dl>
        </div>
    </asp:Panel>
</div>
</asp:Content>

