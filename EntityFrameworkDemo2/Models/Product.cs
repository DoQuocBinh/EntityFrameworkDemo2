using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDemo2.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}
