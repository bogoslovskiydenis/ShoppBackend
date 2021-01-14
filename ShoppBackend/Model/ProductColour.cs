using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class ProductColour
    {
        public int ColourId { get; set; }
        public int ProductId { get; set; }

        public virtual Colour Colour { get; set; }
        public virtual Product Product { get; set; }
    }
}
