<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="inventory_management.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <div class="row">
                <div class="col-md-4">
                        <asp:Repeater ID="Repeater1" runat="server" >
                        <ItemTemplate>   
                            <div class="card">
                                <asp:Image ID="Image2" runat="server" ImageUrl = <%# Eval("ImagePath") %>/>
                                <div class="card-body d-flex justify-content-between">
                                    <div>
                                        <h5><%# Eval("ItemName") %></h5>
                                    </div>
                                    <div class="quan">
                                        <h6><%# Eval("Quantity") %></h6>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
       
         



                    
                </div>
            </div>
        </div>
</asp:Content>
