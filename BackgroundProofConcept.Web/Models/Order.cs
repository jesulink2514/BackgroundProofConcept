using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundProofConcept.Web.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Client { get; set; }
        public double Amount { get; set; }
    }
}