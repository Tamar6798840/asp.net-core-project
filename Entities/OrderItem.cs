using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrderItem
{
    public int ProdId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public int OrderItemId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Prod { get; set; } = null!;
}
