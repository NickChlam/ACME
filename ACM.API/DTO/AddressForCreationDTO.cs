using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ACM.API.DTO
{
    public class AddressForCreationDTO  
    {   
        [Required]
        [MinLength(5, ErrorMessage = "Value for {0} must be great than {1}")]
        [StringLength(20, ErrorMessage = "Value for {0} must be between {1}.")]
        public string Street1 { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Value for {0} must be great than {1}")]
        [StringLength(20, ErrorMessage = "Value for {0} must be between {1}.")]
        public string Street2 { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Value for {0} must be great than {1}")]
        [StringLength(20, ErrorMessage = "Value for {0} must be between {1}.")]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(15)]
        public string State { get; set; }
        
        [Required]
        [MinLength(5)]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(20)]
        public string Country { get; set; }
        [Required]
        [Range(1,2)]
        public int AddressType { get; set; }
        

       
    }
}