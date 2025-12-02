using System;

namespace DemoModuleWebForms.Models
{
    public class DemoItem
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
