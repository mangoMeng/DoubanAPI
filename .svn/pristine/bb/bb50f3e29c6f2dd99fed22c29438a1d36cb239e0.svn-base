<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DoubanAPI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Top250" />
            <br />
            <br />
            <asp:Image ID="Image2" runat="server" />
        </div>
        <div>
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# GetDataItem() %>' />
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div>
            <ul>
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href='<%# "Detailes.aspx?mid=" +Eval("id") %>' target="_blank"><%# Eval("title") %></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </form>
</body>
</html>
