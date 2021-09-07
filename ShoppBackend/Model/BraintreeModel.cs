using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppBackend.Model
{
    public class BraintreeModel
    {
        public double amount { get; set; }
        public string nonce { get; set; }
    }
}
