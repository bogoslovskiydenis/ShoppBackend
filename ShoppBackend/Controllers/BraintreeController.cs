using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BraintreeController : ControllerBase
    {
        BraintreeGateway gateway;

        public BraintreeController ()
        {
            gateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "bs5n6ydb5zcrst2q",
                PublicKey = "6cqjkjjsyhc9k5qw",
                PrivateKey = "7628feb648960493fe88fd18fab2e1bd"
            };
        }
        // GET: api/<BraintreeController>
        [HttpGet]
        [Authorize]
        public string Get()
        {
            //return token
            var clientToken = gateway.ClientToken.Generate();
            return clientToken;
        }

        

        // POST api/<BraintreeController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] BraintreeModel value)
        {
            var nonce = value.nonce;
            var amount = value.amount;
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(amount),
                PaymentMethodNonce = nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };
            var result = gateway.Transaction.Sale(request);
            if (result.Target.ProcessorResponseText.Equals("Approved"))
                return Ok(result);
            else
                return NotFound();
        }

        
    }
}
