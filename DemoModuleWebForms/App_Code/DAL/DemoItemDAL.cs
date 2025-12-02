using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DemoModuleWebForms.Models;

namespace DemoModuleWebForms.DAL
{
    public class DemoItemDAL
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DemoDb"].ConnectionString;

        public IList<DemoItem> GetAllItems()
        {
            var items = new List<DemoItem>();

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(
                       "SELECT ItemID, Title, Description, CreatedOn FROM DemoItems",
                       conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new DemoItem
                        {
                            ItemID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            CreatedOn = reader.GetDateTime(3)
                        });
                    }
                }
            }

            return items;
        }

        public void InsertItem(string title, string description)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(
                       "INSERT INTO DemoItems(Title, Description, CreatedOn) " +
                       "VALUES(@Title, @Description, GETDATE())",
                       conn))
            {
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateItem(int id, string title, string description)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(
                       "UPDATE DemoItems SET Title=@Title, Description=@Description " +
                       "WHERE ItemID=@Id",
                       conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteItem(int id)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(
                       "DELETE FROM DemoItems WHERE ItemID=@Id",
                       conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
