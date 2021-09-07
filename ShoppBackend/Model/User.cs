using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class User
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double? Credit { get; set; }
    }
}
