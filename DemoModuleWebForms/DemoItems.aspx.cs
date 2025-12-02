using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoModuleWebForms.BLL;
using DemoModuleWebForms.Models;

namespace DemoModuleWebForms
{
    public partial class DemoItems : Page
    {
        private readonly DemoItemBL _bl = new DemoItemBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            GridView1.DataSource = _bl.GetAllItems();
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _bl.AddItem(txtTitle.Text, txtDescription.Text);
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)GridView1.DataKeys[e.RowIndex].Value;
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string title = ((TextBox)row.Cells[1].Controls[0]).Text;
            string description = ((TextBox)row.Cells[2].Controls[0]).Text;

            try
            {
                _bl.UpdateItem(id, title, description);
                GridView1.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)GridView1.DataKeys[e.RowIndex].Value;
            _bl.DeleteItem(id);
            BindGrid();
        }
    }
}
