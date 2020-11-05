using System;

namespace ACM.BL.repo
{
    public class OrderRepository : RepoBase
    {
        public Order Retreive(int OrderId)
        {
            var order = new Order();

            
            if(order.OrderId == 2){
                order.OrderDate = DateTime.Now; 
            }

            return order;
            
        }

       

    }
}