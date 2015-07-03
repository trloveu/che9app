<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEdit.aspx.cs" Inherits="CHE9000NEW.WSB.TestEdit" %> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title>
    <link href="../CSSJS/style.css" rel="stylesheet" type="text/css" /> 
    <script src="../CSSJS/PageScript.js" type="text/javascript"></script>
</head><body style="margin:0px;text-align:center;" ><form id="frmThis" runat="server">
<div style="width:100%; margin:0 auto; overflow:hidden; "  class="TDTitle">用户查询查看</div>
<!----------------------------------------------------------------------------------------->
<table cellspacing="1" cellpadding="5" width="100%" border="1" style="border-collapse:collapse;" id="tabEdit" runat="server" visible="false">
    <tr><td class="TDTitleW">定单编号：</td><td><asp:Label ID="txtEORDERNO" runat="server" /></td>
        <td class="TDTitleW">品牌车系：</td><td></td></tr> 
    <tr><td class="TDTitleW">申请图片：</td><td colspan="3"></td> </tr> 
    <tr><td class="TDTitleW">受理图片：</td><td colspan="3"></td></tr> 
    <tr><td colspan="4" align="center" id="trEditOpt" runat="server">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btnStyle" OnClick="btn_Click" CommandName="保存" /> &nbsp;&nbsp; 
            <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btnStyle" OnClick="btn_Click" CommandName="关闭" />
        </td></tr>
</table> 
<!----------------------------------------------------------------------------------------->
</form></body></html> 