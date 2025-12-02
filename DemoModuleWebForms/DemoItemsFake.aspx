<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoItemsFake.aspx.cs" Inherits="DemoModuleWebForms.DemoItemsFake" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Demo Items (Working Version)</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Demo Items (Working Demo)</h2>

        <p>
            Title:
            <asp:TextBox ID="txtTitle" runat="server" />
            <br /><br />

            Description:
            <asp:TextBox ID="txtDescription" runat="server" />
            <br /><br />

            <asp:Button ID="btnAdd" Text="Add Item" runat="server" OnClick="btnAdd_Click" />
        </p>

        <hr />

        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False"
            DataKeyNames="ItemID"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting">

            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
