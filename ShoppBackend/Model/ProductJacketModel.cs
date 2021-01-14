using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class ProductJacketModel
    {
        public int JacketModelId { get; set; }
        public int ProductId { get; set; }

        public virtual JacketModel JacketModel { get; set; }
        public virtual Product Product { get; set; }
    }
}
