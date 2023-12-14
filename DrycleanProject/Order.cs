using System;
using System.Collections.Generic;

namespace DrycleanProject;

public partial class Order
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public long Passport { get; set; }

    public short AddressId { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = null!;

    public int Cost { get; set; } 

    public virtual Address Address { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Client PassportNavigation { get; set; } = null!;
}
