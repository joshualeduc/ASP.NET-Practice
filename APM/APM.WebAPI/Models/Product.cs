﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Code is required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Product Code min length is 6 characters")]
        public string ProductCode { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required", AllowEmptyStrings = false)]
        [MinLength(4, ErrorMessage = "Product Name min length is 5 characters")]
        [MaxLength(12, ErrorMessage = "Product name max length is 11 characters")]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}