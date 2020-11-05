using System;
using Acme.Common;


namespace ACM.BL
{
    public class Product
    {
        public Product()
        {
            
        }
        public int ProductId { get; private set; }
        public string Description { get; set; }
        private string _productName;
        public string ProductName 
        { 
            get 
            { 
                
                return _productName.InsertSpace();
            }   
            set 
            {
                _productName = StringHandler.InsertSpaces(value); 
            }
        }
        public decimal? CurrentPrice { get; set; }

        public override string ToString() => ProductName;

    }
}