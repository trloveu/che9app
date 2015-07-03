<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageDgList.ascx.cs" Inherits="CHE9000NEW.WSB.PageDgList" %>
<table cellspacing="0" cellpadding="0"  border="0" style="height:30px" id="tabPage" runat="server" >
    <tr><td>
            <asp:LinkButton id="lBtnPgFirst" runat="server" Text="|<" ForeColor="Blue" style="font-size:11px;color:Blue;" OnClick="lBtnPgFirst_Click"  />&nbsp; 
            <asp:LinkButton id="lBtnPgPervi" runat="server" Text="<<" ForeColor="Blue" style="font-size:11px;color:Blue;" OnClick="lBtnPgPervi_Click"  />
            <asp:LinkButton id="lBtnPgCurr" runat="server" Text="请点查询按钮" ForeColor="Red" style="font-size:11px;"  />
            <asp:LinkButton id="lBtnPgCurrRowCount" runat="server" Text="" ForeColor="Red" style="font-size:11px;"  />
            <asp:LinkButton id="lBtnPgNext" runat="server" Text=">>" ForeColor="Blue" style="font-size:11px;color:Blue;" OnClick="lBtnPgNext_Click"  />&nbsp; 
            <asp:LinkButton id="lBtnPgLast" runat="server" Text=">|" ForeColor="Blue" style="font-size:11px;color:Blue;" OnClick="lBtnPgLast_Click"  /> 
             <asp:TextBox ID="tbPage" runat="server" BorderStyle="Groove" Width="15px"></asp:TextBox>
            <font style="font-size:11px;color:Blue;">页</font>
            <asp:LinkButton id="lBtnPgGo" runat="server" Text="GO" ForeColor="Blue" style="font-size:11px" OnClick="lBtnPgGo_Click"  /> 
                &nbsp;&nbsp;
            <asp:Label ID = "lblPageCurr" runat="server" Text="0" Visible="false" /> 
            <asp:Label ID = "lblPageCount" runat="server" Text="0" Visible="false"/>
            <asp:Label ID = "lblPackName" runat="server" Text="" Visible="false"/>

            <asp:LinkButton id="lBtnExpAll" runat="server" Text="导出" ForeColor="Blue"   
                 style="font-size:11px" OnClick="lBtnExpAll_Click" ToolTip="请使用Excle2003或WPS"  /> 
    </td></tr>
</table> 