<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register_page.aspx.cs" Inherits="REGISTER.register_page" %>

<!DOCTYPE html>
<head runat="server">
    <title></title>
    <meta charset="utf-8">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfUserID" runat="server" />
    <table>
        <tr>
            <td>
                <asp:Label Text="First Name" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Last Name" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Contact" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtContact" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Gender" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        

        <%--start--%> 

        <tr>
            <td>
                <asp:Label Text="Birth day" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownListdate_year" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <%--<asp:ListItem Value="31"></asp:ListItem>--%>
                </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="DropDownListdate_month" runat="server">
                    <asp:ListItem Value="فروردین"></asp:ListItem>
                    <%--<asp:ListItem Value="31"></asp:ListItem>--%>
                    <asp:ListItem Value="اردیبهشت"></asp:ListItem>
                    <asp:ListItem Value="خرداد"></asp:ListItem>
                    <asp:ListItem Value="تیر"></asp:ListItem>
                    <asp:ListItem Value="مرداد"></asp:ListItem>
                    <asp:ListItem Value="شهریور"></asp:ListItem>
                    <asp:ListItem Value="مهر"></asp:ListItem>
                    <asp:ListItem Value="آبان"></asp:ListItem>
                    <asp:ListItem Value="آذر"></asp:ListItem>
                    <asp:ListItem Value="دی"></asp:ListItem>
                    <asp:ListItem Value="بهمن"></asp:ListItem>
                    <asp:ListItem Value="اسفند"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListdate_day" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <%--<asp:ListItem Value="31"></asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>

        <%--end--%>
        <tr>
            <td>
                <asp:Label Text="Address" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="REGISTER" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="LIST" ID="editbtn" runat="server" OnClick="editbtn_Click"  />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
