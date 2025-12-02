<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoItems.aspx.cs"
    Inherits="DemoModuleWebForms.DemoItems"
    MasterPageFile="~/Site.Master"
    Title="Demo Items" %>
<asp:Content ID="Content1"
             ContentPlaceHolderID="MainContent"
             runat="server">

    <div class="container mt-5">

        <h2 class="mb-4">Demo Items</h2>

        <!-- INSERT FORM -->
        <div class="card p-3 mb-4">
            <div class="mb-3">
                <label>Title</label>
                <asp:TextBox ID="txtTitle"
                             CssClass="form-control"
                             runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
              <div class="mb-3">
    <label>Title</label>

    <asp:TextBox ID="TextBox1"
                 CssClass="form-control"
                 runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfvTitle"
        runat="server"
        ControlToValidate="txtTitle"
        ErrorMessage="Title is required"
        CssClass="text-danger"
        Display="Dynamic" />
</div>

        </div>

        <!-- GRIDVIEW -->
        <asp:GridView ID="GridView1"
    runat="server"
    CssClass="table table-striped table-bordered"
    AutoGenerateColumns="False"
    DataKeyNames="ItemID"
    OnRowEditing="GridView1_RowEditing"
    OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="CreatedOn" HeaderText="Created On" />
                <asp:CommandField ShowEditButton="True"
                                  ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
