using System;
using System.Collections.Generic;

#nullable disable

namespace Log_Implementataions.Models
{
    public partial class ProductOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
