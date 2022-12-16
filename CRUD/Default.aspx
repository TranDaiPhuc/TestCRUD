<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<head runat="server">
    <title> CRUD </title>
</head>
<body>
<form id="form1" runat="server">
        <div align="center">
            <table border="1" cellspacing="0" cellpadding="0" style="border-color: blue">
                <tr>
                    <td style="text-align: center; font-weight: bold; font-size: 24px;"> CRUD
                    </td>
                </tr>
                <tr>
                    <td>                        
                <asp:GridView ID="gvMain" runat="server"  CellPadding="3" 
                    style="width: 1900px; border-style: solid; border-width: 1px; 
                    font-family: 'Segoe UI'; font-size: 12px; font-weight: bold; 
                    line-height: normal; vertical-align: middle; text-align: left; text-indent: 10px; 
                    border-collapse: separate; height: 100%;" HorizontalAlign="Left" 
                    OnSelectedIndexChanged="gvMain_SelectedIndexChanged" 
                    OnRowCancelingEdit="gvMain_RowCancelingEdit" 
                    OnRowDataBound="gvMain_RowDataBound" 
                    OnRowDeleting="gvMain_RowDeleting" 
                    OnRowEditing="gvMain_RowEditing" 
                    OnRowUpdating="gvMain_RowUpdating" 
                    AllowPaging="True" 
                    OnPageIndexChanged="gvMain_PageIndexChanged" 
                    OnPageIndexChanging="gvMain_PageIndexChanging" 
                    ShowHeaderWhenEmpty="True" 
                    PageSize="15" ShowFooter="True" 
                    AutoGenerateColumns="False" 
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" OnRowCommand="gvMain_RowCommand">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                    <Columns>
                        <asp:TemplateField HeaderText=" " HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="btnSelect" runat="server" CausesValidation="false" Text="Select" CommandName="Select"></asp:LinkButton>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" Text="Update" CommandName="Update"></asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" CausesValidation="false" Text="Add" CommandName="Add"></asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PO" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                            <ControlStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblPO" runat="server" Text='<%# Eval("PO") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbPO" runat="server" Text='<%# Eval("PO") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbPO_Footer" runat="server" Width="150px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                            <ControlStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Label ID="lblModel_Name" runat="server" Text='<%# Eval("Model_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbModel_Name" runat="server" Text='<%# Eval("Model_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbModel_Name_Footer" runat="server" Width="200px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model Number" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ControlStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblModel_Number" runat="server" Text='<%# Eval("Model_Number") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbModel_Number" runat="server" Text='<%# Eval("Model_Number") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbModel_Number_Footer" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Article" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ControlStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblArticle" runat="server" Text='<%# Eval("Article") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbArticle" runat="server" Text='<%# Eval("Article") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbArticle_Footer" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ControlStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbQuantity_Footer" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lean" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ControlStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblLean" runat="server" Text='<%# Eval("Lean") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbLean" runat="server" Text='<%# Eval("Lean") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbLean_Footer" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Planned Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ControlStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblPlanned_Date" runat="server" Text='<%# Eval("Planned_Date") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbPlanned_Date" runat="server" Text='<%# Eval("Planned_Date") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbPlanned_Date_Footer" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CRD" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ControlStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblCRD" runat="server" Text='<%# Eval("CRD") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbCRD" runat="server" Text='<%# Eval("CRD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbCRD_Footer" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PD" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ControlStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblPD" runat="server" Text='<%# Eval("PD") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbPD" runat="server" Text='<%# Eval("PD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbPD_Footer" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                            <ControlStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbCountry" runat="server" Text='<%# Eval("Country") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbCountry_Footer" runat="server" Width="150px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Onhand" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="300px">
                            <ControlStyle Width="300px" />
                            <ItemTemplate>
                                <asp:Label ID="lblOnhand" runat="server" Text='<%# Eval("Onhand") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ttbOnhand" runat="server" Text='<%# Eval("Onhand") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ttbOnhand_Footer" runat="server" Width="300px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
                </tr>
                <tr>
                    <td style="width: 1000px; height: 68px">
                        <asp:Button ID="btnDelete" runat="server" Height="40px" OnClick="btnDelete_Click" Text="Delete" Width="120px" />
                        <asp:Button ID="btnInverse" runat="server" Height="40px" OnClick="btnInverse_Click" Text="Inverse" Width="120px" />
                        <asp:Button ID="btnClear" runat="server" Height="40px" OnClick="btnClear_Click" Text="Clear" Width="120px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>