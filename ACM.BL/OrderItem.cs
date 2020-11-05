using System;

namespace ACM.BL
{
    public class OrderItem
    {

        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? PurchasePrice { get; set;}
        public int OrderId {get; set;}
        
    
    }
}