using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImg { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
