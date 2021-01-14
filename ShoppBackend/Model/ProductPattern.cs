using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class ProductPattern
    {
        public int PatternId { get; set; }
        public int ProductId { get; set; }

        public virtual Pattern Pattern { get; set; }
        public virtual Product Product { get; set; }
    }
}
