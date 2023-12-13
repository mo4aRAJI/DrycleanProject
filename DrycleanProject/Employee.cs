using System;
using System.Collections.Generic;

namespace DrycleanProject;

public partial class Employee
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public short Experience { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
