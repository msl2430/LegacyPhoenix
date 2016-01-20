<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IRFManifest.aspx.vb" Inherits="IRFManifest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .grid
        {
        	font-family: Palatino Linotype, Garamond, Serif;
	        font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:SqlDataSource ID="SQLData" runat="server"  
            ConnectionString="Data Source=PHOENIX_SQL\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password" 
            ProviderName="System.Data.SqlClient" 
            SelectCommand="SELECT [CaseNumber], [LastName], [FirstName], [Received], [Change] FROM [MasterIRF] ORDER BY [CaseNumber]"   >     
        </asp:SqlDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grid_Manifest" runat="server" 
    AutoGenerateColumns="False" DataSourceID="SQLData" CellPadding="5" 
    CssClass="grid">
                    <RowStyle BackColor="#D9D9D9" />
                    <Columns>
                        <asp:TemplateField HeaderText="Case Number">
                            <ItemTemplate>
                                <asp:Label ID="lbl_CaseNumber" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_LastName" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="lbl_FirstName" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Received">
                            <ItemTemplate>
                                <div style="text-align: center;">
                                    <asp:CheckBox ID="chk_Received" runat="server" AutoPostBack="False" 
                                OnCheckedChanged="ChkChanged_Received" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Change">
                            <ItemTemplate>
                                <div style="text-align: center;">
                                    <asp:CheckBox ID="chk_YesChange" runat="server"  AutoPostBack="False" 
                                OnCheckedChanged="ChkChanged_Change" Text="Yes" />
                                    &nbsp;&nbsp;
                                    <asp:CheckBox ID="chk_NoChange" runat="server"  AutoPostBack="False" 
                                OnCheckedChanged="ChkChanged_Change" Text="No" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <div style="text-align: center; width: 75px;">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="grid" 
                                     OnClick="Submit" UseSubmitBehavior="true" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#410401" ForeColor="#B6A79E" />
                    <AlternatingRowStyle BackColor="#E3E3E3" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
