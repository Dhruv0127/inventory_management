<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="inventory_management.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card-container {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(18rem, 1fr));
            gap: 1rem;
        }

        .card {
            display: flex;
            flex-direction: column;
            border: 1px solid #ccc;
            border-radius: 4px;
            overflow: hidden;
        }

        .card-image {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: white;
        }

        .card-image img {
            max-width: 100%;
            max-height: 100%;
            object-fit: contain;
        }

        .card-description {
            max-height: 8rem; /* Adjust this value based on your design */
            overflow: auto;
            padding: 0.5rem;
        }

        .card-foooter{
            margin-top: auto;
            padding: 0 1rem 1rem 1rem;
        }

        .input-group {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
         .card-description::-webkit-scrollbar {
        width: 10px; /* Set the width of the scrollbar */
    }

    .card-description::-webkit-scrollbar-thumb {
        background-color: #c0c0c0; /* Scrollbar thumb color */
        border-radius: 5px; /* Rounded corners for the thumb */
    }

    .card-description::-webkit-scrollbar-thumb:hover {
        background-color: #a0a0a0; /* Scrollbar thumb color on hover */
    }
    </style>
    
    <!-- OnItemCommand="RepeaterOfHomepage_ItemCommand"!-->
    <div class="card-container">
        <asp:Repeater ID="RepeaterOfHomepage" runat="server" OnItemCommand="RepeaterOfHomepage_ItemCommand">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <div class="card-image">
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="150px" Height="150px" />
                    </div>
                    <div class="card-body" style="padding-bottom:5px">
                        <div class="row">
                            <div class="col">
                                <h5 class="card-title" style="font-weight:700;text-transform:capitalize;color:midnightblue"><%# Eval("ItemName") %></h5>
                            </div>
                            <div class="col-auto">
                                <h6 class="float-end" style="color:green;">$<%# Eval("Price") %></h6>
                            </div>
                        </div>
                        <div class="card-description">
                            <p><%# Eval("description") %></p>
                        </div>
                            <p>Total Quantity: <strong style="color:darkgreen"><%# Eval("Quantity") %></strong></p>
                    </div>
                    <div class="card-foooter">
                        <div class="input-group">
                            <asp:DropDownList class="form-select" ID="QuantityDropDown" runat="server">
                                <asp:ListItem Text="Choose Quantity..." Value="" />
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                            </asp:DropDownList>
                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Add to cart" CommandName="AddToCart" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>




