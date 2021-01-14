using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class ProductImage
    {
        public int ImgId { get; set; }
        public string ImgUrl { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
