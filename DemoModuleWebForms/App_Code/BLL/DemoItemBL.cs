using System.Collections.Generic;
using DemoModuleWebForms.Models;
using DemoModuleWebForms.DAL;

namespace DemoModuleWebForms.BLL
{
    public class DemoItemBL
    {
        private readonly DemoItemDAL _dal = new DemoItemDAL();

        public IList<DemoItem> GetAllItems()
        {
            return _dal.GetAllItems();
        }

        public void AddItem(string title, string description)
        {
            _dal.InsertItem(title, description);
        }

        public void UpdateItem(int id, string title, string description)
        {
            _dal.UpdateItem(id, title, description);
        }

        public void DeleteItem(int id)
        {
            _dal.DeleteItem(id);
        }
    }
}
