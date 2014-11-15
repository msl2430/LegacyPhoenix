<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="load-csv.aspx.cs" Inherits="IRF.load_csv" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #divLeft { float: left; width: 400px; margin-left: 20px; }
        #divRight { float: left; width: 500px;} 
        h2 { font-family: Calibri !important; font-size: 12pt !important; }
        .buttons 
        {
        	outline: none;
        	margin: 0 4px 0 0;
        	padding: .4em 1em;
        	text-decoration: none !important;
        	cursor: pointer; 
        	position: relative;
        	text-align: center;

        }    
        fieldset { width: 300px; font-family: Calibri !important; font-size: 11pt !important; padding: 10px;}
        legend { font-family: Calibri !important; font-size: 12pt !important; } 
        #fileCSV { margin-top: 8px; } 
        #btnUploadFile { margin-top: 10px; }
        #divError { font-family: Calibri !important; font-size: 10pt !important; width: 250px; margin-top: 5px; }
        #divError p { margin: 5px; }
        #divSuccess { font-family: Calibri !important; font-size: 10pt !important; width: 250px; margin-top: 5px; color: Green; }
        #divSuccess p { margin: 5px; }
        .PrimRow { background-color: #eaeaea; text-align: center;}
        .AltRow { background-color: #gbgbgb; text-align: center; } 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divMain">
        <div id="divLeft">
            <fieldset>
                <legend><strong>File Selection</strong></legend>
                <label>Please select a CSV file to upload:</label><br />
                <asp:FileUpload ID="fileCSV" runat="server" /><br />
                <div id="divSuccess" class="ui-state-highlight ui-corner-all" runat="server" visible="false" style="border-color: Green;">
                    <table>
                        <tr>
                            <td><span class="ui-icon ui-icon-check"></span></td>
                            <td><p><strong><label id="lblSuccessMsg" runat="server"></label></strong></p></td>
                        </tr>
                    </table>
                </div>
                <div id="divError" class="ui-state-error ui-corner-all" runat="server" visible="false">
                    <table>
                        <tr>
                            <td><span class="ui-icon ui-icon-alert"></span></td>
                            <td><p><strong><label id="lblErrorMsg" runat="server"></label></strong></p></td>
                        </tr>
                    </table>
                </div>
                <asp:Button ID="btnUploadFile" runat="server" Text="Upload" onclick="btnUploadFile_Click" class="buttons ui-state-default ui-corner-all" />
            </fieldset>            
            <br /><br />
            <h2>IRF Cases In Queue (<%= QueuedCases %> <%= (QueuedCases == 1)? "case" : "cases" %>):</h2>
            <asp:GridView ID="grvQueue" runat="server" Width="325px" Font-Names="Calibri" Font-Size="Medium" AutoGenerateColumns="false">
                <RowStyle CssClass="PrimRow" />
                <AlternatingRowStyle CssClass="AltRow" />
                <Columns>
                    <asp:BoundField HeaderText="Case Number" DataField="Case Number" />
                    <asp:BoundField HeaderText="Added" DataField="Added" />
                </Columns>
            </asp:GridView>
        </div>
        <div id="divRight">
            <h2>IRF Cases Processed Today (<%= ProcessedCases %> <%= (ProcessedCases == 1)? "case" : "cases" %>):</h2>
            <asp:GridView ID="grvProcessed" runat="server" Width="450px" Font-Names="Calibri" Font-Size="Medium" AutoGenerateColumns="false">
                <RowStyle CssClass="PrimRow" />
                <AlternatingRowStyle CssClass="AltRow" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Case Number" DataField="Case Number" />
                    <asp:BoundField HeaderText="Time" DataField="Time" />
                    <asp:BoundField HeaderText="Result" DataField="Result" />                      
                    <asp:BoundField HeaderText="Reason" DataField="Reason" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("input.buttons").hover(
                function () { $(this).addClass("ui-state-hover"); },
                function () { $(this).removeClass("ui-state-hover"); }
            );
        });
    </script>
</asp:Content>
