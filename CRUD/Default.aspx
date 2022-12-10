<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table cellpadding="2" cellspacing="3" style="width: 100%; border-style: solid; border-width: 1px; font-family: 'Segoe UI'; font-size: 12px; font-weight: bold; line-height: 32px; vertical-align: middle; text-align: left; text-indent: 10px; border-collapse: separate; height: 100%;">
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">&nbsp;</td>
            <td class="modal-sm" style="width: 315px">&nbsp;</td>
            <td style="width: 190px; text-align: center;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label1" runat="server" Text="PO Information"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">&nbsp;</td>
            <td style="width: 190px; text-align: center;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label2" runat="server" Text="PO"></asp:Label>
            </td>
            <td style="height: 27px; width: 315px">
                <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td rowspan="3" style="width: 190px; text-align: center;">
                <asp:Button ID="Button1" runat="server" Height="48px" Text="Add" Width="160px" OnClick="Button1_Click" />
            </td>
            <td colspan="3" rowspan="11">
                <asp:GridView ID="GridView1" runat="server" style="width: 100%; border-style: solid; border-width: 1px; font-family: 'Segoe UI'; font-size: 12px; font-weight: bold; line-height: normal; vertical-align: middle; text-align: left; text-indent: 10px; border-collapse: separate; height: 100%;" HorizontalAlign="Left" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label3" runat="server" Text="Model Name"></asp:Label>
            </td>
            <td style="height: 27px; width: 315px">
                <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label4" runat="server" Text="Model Number"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label5" runat="server" Text="Article"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td rowspan="3" style="width: 190px; text-align: center;">
                <asp:Button ID="Button2" runat="server" Height="48px" Text="Save" Width="160px" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label6" runat="server" Text="Order Quantity"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox5" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label7" runat="server" Text="Lean"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox6" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label8" runat="server" Text="Planned Date"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox7" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td rowspan="3" style="width: 190px; text-align: center;">
                <asp:Button ID="Button3" runat="server" Height="48px" Text="Delete" Width="160px" OnClick="Button3_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label9" runat="server" Text="CRD"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox8" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label10" runat="server" Text="PD"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox9" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label11" runat="server" Text="Country"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px">
                <asp:TextBox ID="TextBox10" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td rowspan="3" style="width: 190px; text-align: center;">
                <asp:Button ID="Button4" runat="server" Height="48px" Text="Reload" Width="160px" OnClick="Button4_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">
                <asp:Label ID="Label12" runat="server" Text="Onhand"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 315px; height: 27px">
                <asp:TextBox ID="TextBox11" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px; text-align: left; text-indent: 10px;">&nbsp;</td>
            <td class="modal-sm" style="width: 315px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
