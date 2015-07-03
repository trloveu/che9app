<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestList.aspx.cs" Inherits="CHE9000NEW.WSB.TestList" %> 
<%@ Register Src="../WSB/PageDgList.ascx" TagName="PageDgList"  TagPrefix="ucPage" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title>
    <link href="../CSSJS/style.css" rel="stylesheet" type="text/css" />
    <script src="../CSSJS/CalendarTime.js" type="text/javascript"></script>
    <script src="../CSSJS/PageScript.js" type="text/javascript"></script>
</head><body style="margin:0px;text-align:center;" ><form id="frmThis" runat="server"><div style="width:1000px;">
<!----------------------------------------------------------------------------------------->
<div style="width:100%; margin:0 auto; overflow:hidden; "  class="TDTitle">用户查询审核</div>
<!----------------------------------------------------------------------------------------->
<table cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr><td class="TDHeaders">查询定单:</td><td><asp:TextBox ID="txtQORDERNO" runat="server" CssClass="input_box" /></td> 
        <td class="TDHeaders">申请用户:</td><td><asp:TextBox ID="txtQQUERYUSER" runat="server" CssClass="input_box" /></td> 
        <td class="TDHeaders">申请日期:</td><td><asp:TextBox ID="txtQCREATETIMEB" runat="server" CssClass="input_box" onfocus="SelectDate(this,this,false)" /></td> 
        <td class="TDHeaders">到:</td><td><asp:TextBox ID="txtQCREATETIMEE" runat="server" CssClass="input_box" onfocus="SelectDate(this,this,false)" /></td>  
        <td style="width:100%" /></tr> 
    <tr><td class="TDHeaders">当前状态:</td><td><asp:DropDownList ID="ddlQORDERSTATE" runat="server" /></td> 
        <td class="TDHeaders">受理用户:</td><td><asp:TextBox ID="txtQCASEUSER" runat="server" CssClass="input_box" /></td> 
        <td class="TDHeaders">佣金金额:</td><td><asp:TextBox ID="txtQORDERSHAREB" runat="server" CssClass="input_box" onkeyup="ClearNoNumM(this)" /></td> 
        <td class="TDHeaders">到:</td><td><asp:TextBox ID="txtQORDERSHAREE" runat="server" CssClass="input_box" onkeyup="ClearNoNumM(this)"  /></td> 
        <td><asp:Button ID="btnQuery" Text="查询" CommandName="查询" CssClass="btnStyle" OnClick="btn_Click" runat="server"/> </td>
        </tr> 
</table>
<!----------------------------------------------------------------------------------------->
<ucPage:PageDgList ID="pgShow" runat="server" /> 
<asp:GridView ID="dgList" runat="server" Width="100%"  AutoGenerateColumns="False" DataKeyNames="ORDERID,ORDERSTATE" 
        OnSorting="dgList_Sorting" AllowSorting="true">
    <HeaderStyle CssClass="Gv_HeaderStyle" /><RowStyle CssClass="Gv_RowStyle" /><AlternatingRowStyle CssClass="Gv_AlternateStyle" />
    <Columns>  
        <asp:TemplateField><ItemStyle Width="30px" HorizontalAlign="Center"  /><ItemTemplate>
            <asp:CheckBox ID="chkSelect" runat="server" KEYID='<%#Eval("ORDERID")%>' /></ItemTemplate>
            <HeaderTemplate><input id="chkAllSelect" type="checkbox" onclick="CheckedAll(this);" /></HeaderTemplate>
        </asp:TemplateField>
           
        <asp:BoundField DataField="ORDERNO" HeaderText="订单编号" SortExpression="ORDERNO" ItemStyle-HorizontalAlign="Center" />  
        <asp:BoundField DataField="ORDERSTATENAME" HeaderText="状态" SortExpression="ORDERSTATENAME" ItemStyle-HorizontalAlign="Center" />    
        <asp:BoundField DataField="CARTYPE" HeaderText="品牌" SortExpression="CARTYPE" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="CLASSNAME" HeaderText="车系" SortExpression="CLASSNAME" ItemStyle-HorizontalAlign="Center" />  
        <asp:BoundField DataField="ORDERGOLD" HeaderText="查询价格" SortExpression="ORDERGOLD" ItemStyle-HorizontalAlign="Center" />  
        <asp:BoundField DataField="ORDERSHARE" HeaderText="查询佣金" SortExpression="ORDERSHARE" ItemStyle-HorizontalAlign="Center" />   
        <asp:BoundField DataField="QUERYUSER" HeaderText="申请用户" SortExpression="QUERYUSER" ItemStyle-HorizontalAlign="Center" />   
        <asp:BoundField DataField="CREATETIME" HeaderText="申请时间" SortExpression="CREATETIME" ItemStyle-HorizontalAlign="Center" />   
        <asp:BoundField DataField="CASEUSER" HeaderText="受理用户" SortExpression="CASEUSER" ItemStyle-HorizontalAlign="Center" />   
        <asp:BoundField DataField="CASETIME" HeaderText="受理时间" SortExpression="CASETIME" ItemStyle-HorizontalAlign="Center" />   

        <asp:TemplateField><ItemStyle HorizontalAlign="Center" />
            <HeaderTemplate><asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtn_Click" CommandName="添加"  Text="点此添加" /></HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="LinkLook" runat="server" OnClick="lbtn_Click" CommandArgument='<%#Eval("ORDERID")%>'  CommandName="查看"  Text="查看" />
                <asp:LinkButton ID="lbtnAduit1" runat="server" OnClick="lbtn_Click" CommandArgument='<%#Eval("ORDERID")%>' Enabled="false"
                    CommandName="申请审核"  Text="申请审核" />
                <asp:LinkButton ID="lbtnAduit2" runat="server" OnClick="lbtn_Click" CommandArgument='<%#Eval("ORDERID")%>' Enabled="false"
                    CommandName="受理审核" Text="申请审核"  />
            </ItemTemplate>
        </asp:TemplateField>   
    </Columns>
</asp:GridView>  
<!----------------------------------------------------------------------------------------->
</div></form></body></html> 