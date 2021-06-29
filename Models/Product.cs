using System;
using System.Collections.Generic;

#nullable disable

namespace Log_Implementataions.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ProdDescriptions { get; set; }
        public string ProdCategory { get; set; }
    }
}
