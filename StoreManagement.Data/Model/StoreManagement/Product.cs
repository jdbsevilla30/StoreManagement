using System;
using System.Collections.Generic;

namespace StoreManagement.Data.Model.StoreManagement;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public bool? IsAvailable { get; set; }

    public string? Image { get; set; }
}
