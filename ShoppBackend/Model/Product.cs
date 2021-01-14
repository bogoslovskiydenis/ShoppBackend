using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class Product
    {
        public Product()
        {
            ProductColours = new HashSet<ProductColour>();
            ProductFabrics = new HashSet<ProductFabric>();
            ProductImages = new HashSet<ProductImage>();
            ProductJacketModels = new HashSet<ProductJacketModel>();
            ProductPatterns = new HashSet<ProductPattern>();
            ProductSizes = new HashSet<ProductSize>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductDescription { get; set; }
        public double? ProductOldPrice { get; set; }
        public double? ProductNewPrice { get; set; }
        public bool? ProductIsSale { get; set; }
        public string ProductSaleText { get; set; }
        public string ProductSubText { get; set; }
        public int? ProductOrderNumber { get; set; }
        public DateTime? ProductCreateDate { get; set; }
        public string ProductCode { get; set; }
        public int? SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<ProductColour> ProductColours { get; set; }
        public virtual ICollection<ProductFabric> ProductFabrics { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductJacketModel> ProductJacketModels { get; set; }
        public virtual ICollection<ProductPattern> ProductPatterns { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
