using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int ProdId { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public double Price { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
