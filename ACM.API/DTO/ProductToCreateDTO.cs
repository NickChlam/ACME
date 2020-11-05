using System.ComponentModel.DataAnnotations;
using Acme.Common;

namespace ACM.API.DTO
{
    public class ProductToCreateDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
       
        public string Description { get; set; }
        [Required]
        [Range(.01, 100000)]
        public decimal? CurrentPrice { get; set; }
        private string _productName;
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
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
        
    }
}