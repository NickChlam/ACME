using System;
using System.Collections.Generic;
using Acme.Common;

namespace ACM.BL
{
    public class Order 
    {
      
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        public int ShippingAddressId { get; set; }


       
    }
}