using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class ProductFabric
    {
        public int FabricId { get; set; }
        public int ProductId { get; set; }

        public virtual Fabric Fabric { get; set; }
        public virtual Product Product { get; set; }
    }
}
