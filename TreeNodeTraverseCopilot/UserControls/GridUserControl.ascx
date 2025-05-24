<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridUserControl.ascx.vb" Inherits="TreeNodeTraverseCopilot.GridUserControl" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category">
            <ItemTemplate>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Text="A" Value="A" />
                    <asp:ListItem Text="B" Value="B" />
                    <asp:ListItem Text="C" Value="C" />
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<p>
    <asp:Button runat="server" ID="btnSearch" Text="Search" />
</p>
