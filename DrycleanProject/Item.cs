using System;
using System.Collections.Generic;

namespace DrycleanProject;

public partial class Item
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public string Clothtype { get; set; } = null!;

    public string Fabrictype { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
