<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_page.aspx.cs" Inherits="REGISTER.search_page" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <style type="text/css">
        .auto-style1 {
            margin-top: 43px;
        }
        .auto-style2 {
            margin-top: 49px;
        }
        .auto-style3 {
            margin-left: 21px;
        }
        .auto-style4 {
            margin-left: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="label_fn" runat="server" Text="FirstName"></asp:Label>
            <asp:TextBox ID="search_first" runat="server" CssClass="auto-style3" Width="150px"></asp:TextBox>
            &nbsp;
            <asp:Label ID="label_ln" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="search_last" runat="server" CssClass="auto-style4" Width="150px"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button Text="SEARCH" ID="searchbtn" runat="server" Width="100px" CssClass="auto-style1" OnClick="searchbtn_Click" />

            <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID"
                ShowHeaderWhenEmpty="true"
                OnRowEditing="gvPhoneBook_RowEditing" OnRowDeleting="gvPhoneBook_RowDeleting"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="gvPhoneBook_SelectedIndexChanged" CssClass="auto-style2">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Contact") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Gender") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Birth year">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("date_year") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Birth month">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("date_month") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Birth Day">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("date_day") %>' runat="server" />
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Address") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="EDIT">
                        <ItemTemplate>
                            <asp:Button Text="EDIT" ID="editbtn" runat="server" CommandName="EDIT" ToolTip="EDIT" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DELETE">
                        <ItemTemplate>
                            <asp:Button Text="DELETE" ID="deletebtn" runat="server" CommandName="DELETE" ToolTip="DELETE" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <tr>
                <td></td>
                <td>
                    <asp:Button Text="LIST" ID="listbtn" runat="server" Height="57px" Width="238px" CssClass="auto-style1" OnClick="listbtn_Click" />
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button Text="Register" ID="Button1" runat="server" Height="57px" OnClick="registerbtn_Click" Width="238px" CssClass="auto-style1" />
                </td>
            </tr>
 
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
