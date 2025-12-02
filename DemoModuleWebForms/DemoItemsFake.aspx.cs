using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoModuleWebForms
{
    public partial class DemoItemsFake : Page
    {
        private static List<DemoItem> items = new List<DemoItem>
        {
            new DemoItem { ItemID = 1, Title = "Sample Item", Description = "This is a demo.", CreatedOn = DateTime.Now }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            GridView1.DataSource = items;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int newId = items.Count + 1;

            items.Add(new DemoItem
            {
                ItemID = newId,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                CreatedOn = DateTime.Now
            });

            txtTitle.Text = "";
            txtDescription.Text = "";

            BindGrid();
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

            var item = items.Find(x => x.ItemID == id);
            if (item != null)
            {
                item.Title = title;
                item.Description = description;
            }

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)GridView1.DataKeys[e.RowIndex].Value;
            items.RemoveAll(x => x.ItemID == id);

            BindGrid();
        }
    }

    public class DemoItem
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
