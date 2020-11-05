using System;

namespace ACM.BL.repo
{
    public class ProductRepository : RepoBase
    {
        public Product Retrieve(int id)
        {
           var product = new Product();

           if(id == 2)
           {
               product.ProductName = "Flower";
               product.Description = "This is a description";
               product.CurrentPrice = 15.96M;
           }
           Object myObject = new Object();
           
           return product;
        }
        // public bool Save(Product product)
        // {
        //     var success = true;

        //     if (product.HasChanges)
        //     {
        //         if (product.IsValid)
        //         {
        //             if( product.IsNew)
        //             {
        //                 // Call insert proc
        //             }
        //             else
        //             {
        //                 // Call update Stored Proc
        //             }
        //         }
        //         else
        //         {
        //             success = false;
        //         }
        //     }
        //     return success;
        // }
    }
}