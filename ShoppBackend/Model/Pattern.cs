using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class Pattern
    {
        public Pattern()
        {
            ProductPatterns = new HashSet<ProductPattern>();
        }

        public int PatternId { get; set; }
        public string PatternName { get; set; }

        public virtual ICollection<ProductPattern> ProductPatterns { get; set; }
    }
}
