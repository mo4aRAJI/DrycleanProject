using System;
using System.Collections.Generic;

namespace DrycleanProject;

public partial class Client
{
    public long Passport { get; set; }

    public string Fullname { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public short? Discount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
