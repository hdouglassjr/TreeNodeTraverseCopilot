<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="TreeNodeTraverseCopilot.MainPage" %>
<%@ Register TagPrefix="uc" TagName="PanelDisplay" Src="~/UserControls/PanelsDisplay.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc:PanelDisplay runat="server" />
        </div>
    </form>
</body>
</html>
