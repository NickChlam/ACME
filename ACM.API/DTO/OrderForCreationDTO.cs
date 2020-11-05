using System;
using System.Collections.Generic;
using ACM.BL;

namespace ACM.API.DTO
{
    public class OrderForCreationDTO
    {
       
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        public int ShippingAddressId { get; set; }
    }
}