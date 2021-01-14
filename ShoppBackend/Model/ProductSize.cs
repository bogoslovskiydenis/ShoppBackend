using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class ProductSize
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int? Number { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
