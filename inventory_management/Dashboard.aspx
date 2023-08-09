<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="inventory_management.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="css-js/dashboard.css" rel="stylesheet" />
    
    <div class="container">
            <div class="row">
                
                       <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-4 col-sm-6 mb-4 item-container">
                                <div class="card" style="background-color:none">
                                    <div class="card-image">
                                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="150px" Height="150px" />
                                    </div>
                                    <div class="d-flex justify-content-between" style="padding-bottom: 0;" >
                                        <div class="p-2 w-100 bd-highlight">
                                            <h5><%# Eval("ItemName") %></h5>
                                        </div>
                                        <div class="d-flex justify-content-end"  style="background-color:#f2f2f2 ; margin-right:10px; padding:0;border:1px solid #d3d3d3;border-radius:8px;max-height:30px">
                                            <asp:Button ID="btnDecrease" style="border:1px solid #f2f2f2;background-color:#f2f2f2; border-radius: 8px; width:20px; margin:0;padding:0;" CssClass="btn btn-light" runat="server" Text="-" OnClick="btnDecrease_Click" CommandArgument='<%# Container.ItemIndex %>' />
                                            <div class="align-items-center" style="display: flex; justify-content: center; align-items: center;">
                                                <h6 style="margin: 10px;"> <%# Eval("Quantity") %> </h6>
                                            </div>
                                            <asp:Button ID="btnIncrease" style="border:1px solid #f2f2f2; background-color:#f2f2f2; border-radius: 8px; width:20px; margin:0;padding:0" CssClass="btn btn-light" runat="server" Text="+" OnClick="btnIncrease_Click" CommandArgument='<%# Container.ItemIndex %>' />
                                        </div>
                                    <br />
                                        

                                    </div>
                                        <div class="mian-row">
                                            <asp:Button CssClass="first-btn" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CommandArgument='<%# Container.ItemIndex %>'/>
                                            <asp:Button CssClass="second-btn" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Container.ItemIndex %>'/>
                                        </div>
                                

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
    <asp:Button ID="Button1" runat="server" Text="Add New Item" OnClick="Button1_Click" />
</asp:Content>
