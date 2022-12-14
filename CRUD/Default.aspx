﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table cellpadding="2" cellspacing="3" style="width: 100%; border-style: solid; border-width: 1px; font-family: 'Segoe UI'; font-size: 16px; font-weight: bold; line-height: 32px; vertical-align: middle; text-align: left; text-indent: 10px; border-collapse: separate; height: 100%;">
        <tr>
            <td style="width: 163px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 163px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvMain" runat="server" style="width: 90%; border-style: solid; border-width: 1px; font-family: 'Segoe UI'; font-size: 12px; font-weight: bold; line-height: normal; vertical-align: middle; text-align: left; text-indent: 10px; border-collapse: separate; height: 100%;" HorizontalAlign="Left" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvMain_SelectedIndexChanged" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowCancelingEdit="gvMain_RowCancelingEdit" OnRowDataBound="gvMain_RowDataBound" OnRowDeleting="gvMain_RowDeleting" OnRowEditing="gvMain_RowEditing" OnRowUpdating="gvMain_RowUpdating" AllowPaging="True" OnPageIndexChanged="gvMain_PageIndexChanged" OnPageIndexChanging="gvMain_PageIndexChanging" PageSize="15">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 163px"></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 163px; height: 68px">
                <asp:Button ID="btnDelete" runat="server" Height="40px" OnClick="btnDelete_Click" Text="Delete" Width="100px" />
            </td>
            <td style="height: 68px">
                <asp:Button ID="btnInverse" runat="server" Height="40px" OnClick="btnInverse_Click" Text="Inverse" Width="120px" />
            </td>
            <td style="height: 68px"></td>
        </tr>
    </table>

</asp:Content>
