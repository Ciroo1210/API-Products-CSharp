using System;
using System.Collections.Generic;

namespace ProductsAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? NameProduct { get; set; }

    public int? Price { get; set; }

    public string? DescriptionProduct { get; set; }
}
