using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class Fabric
    {
        public Fabric()
        {
            ProductFabrics = new HashSet<ProductFabric>();
        }

        public int FabricId { get; set; }
        public string FabricName { get; set; }

        public virtual ICollection<ProductFabric> ProductFabrics { get; set; }
    }
}
