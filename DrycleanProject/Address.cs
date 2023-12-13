using System;
using System.Collections.Generic;

namespace DrycleanProject;

public partial class Address
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
