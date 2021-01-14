using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class Colour
    {
        public Colour()
        {
            ProductColours = new HashSet<ProductColour>();
        }

        public int ColourId { get; set; }
        public string ColourName { get; set; }

        public virtual ICollection<ProductColour> ProductColours { get; set; }
    }
}
