<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="inventory_management.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
            <h2>Add Item to Inventory</h2>
            <div class="card" style="width: 18rem;">
               <img class="card-img-top" src="imageof.png" alt="Card image cap">
               <div class="card-body">
                   <h5 class="card-title">Card title</h5>
                   <h5 class="50">Card tail</h5>
               </div>
            </div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblImage" runat="server" Text="Image Path:"></asp:Label>
            <asp:TextBox ID="txtImagePath" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblItemName" runat="server" Text="Item Name:"></asp:Label>
            <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <br />
            Total Price: <asp:Label ID="lblTotalPrice" runat="server" Text='<%# CalculateTotalPrice(Eval("Quantity"), Eval("Price")) %>'></asp:Label><br />
            <asp:Button ID="btnAddItem" class="btn btn-outline-primary" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
            <asp:Button ID="btnEdit" class="btn btn-outline-primary" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("ItemID") %>' />
            <asp:Button ID="btnDelete" class="btn btn-outline-primary" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ItemID") %>' />
            <asp:Button ID="btnShowDB" class="btn btn-outline-primary" runat="server" Text="View" OnClick="btnShowDB_Click" />
         <asp:Label ID="errorlbl" runat="server"></asp:Label>
         <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
</asp:Content>
