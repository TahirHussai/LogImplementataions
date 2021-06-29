using System;
using System.Collections.Generic;

#nullable disable

namespace Log_Implementataions.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
