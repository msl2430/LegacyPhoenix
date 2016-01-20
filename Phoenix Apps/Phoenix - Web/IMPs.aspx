<%@ Page Language="VB" MasterPageFile="~/SubMasterPage.master" AutoEventWireup="false" CodeFile="IMPs.aspx.vb" Inherits="IMPs" title="Phoenix - IMP / TRE Report - PCBSS" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="content_Header" runat="server">
    <asp:Image ID="img_Header" runat="server" ImageUrl="img/headline_IMPs.jpg" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="content_Main" runat="server">
    <br />
    <div class="datemenu">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Label ID="lbl_DateSelect" runat="server" Text="Select a date" /><br />
        <asp:DropDownList ID="drop_Month" runat="server" Width="110px" 
            AutoPostBack="True" />    
        <asp:DropDownList ID="drop_Day" runat="server" Width="45px" 
            AutoPostBack="True" />
        <asp:DropDownList ID="drop_Year" runat="server" Width="70px" 
            AutoPostBack="True" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="drop_Day" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
    </div>   
</asp:Content>

<asp:Content ID="ContentFrame" ContentPlaceHolderID="content_Frame" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <iframe id="frames_IMPS" width="100%" height="780px" src="<% =FrameSRC %>"></iframe>
    </ContentTemplate></asp:UpdatePanel>
   
</asp:Content>


