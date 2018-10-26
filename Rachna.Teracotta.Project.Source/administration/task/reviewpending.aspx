<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="reviewpending.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.task.reviewpending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">
        <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px">
            <h3>Items Pending for Review
            </h3>
            <p>
                Please review the items and approve that, selected items will be set to active status. Later items will be enable for approver. Then approver can publish the items. Only pubished items will be displayed in Front End.
            </p>
        </div>

        <div class="padding-md">
            <div class="panel panel-default table-responsive">
                <asp:GridView ID="grdReviewPending" runat="server" class="table" AutoGenerateColumns="False" Width="100%">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <label class="label-checkbox">
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                     <span class="custom-checkbox"></span>
                                </label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Id">
                            <ItemTemplate>
                                <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("Product_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Product_Title" HeaderText="Product Title" />
                    </Columns>
                    <EmptyDataTemplate>
                        No Items Pending for Review
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCCCC" />

                    <HeaderStyle BackColor="Black" ForeColor="White" Font-Bold="True"></HeaderStyle>
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <br />
                <asp:Button ID="btnGetSelected" runat="server" class="btn btn-primary" Text="Complete Review" OnClick="btnGetSelected_Click"/>
            </div>
            <!-- /panel -->
        </div>
        <!-- /.padding-md -->
    </div>
</asp:Content>
