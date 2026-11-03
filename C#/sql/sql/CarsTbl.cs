using System;
using System.Collections.Generic;

namespace sql;

public partial class CarsTbl
{
    public short CarId { get; set; }

    public string? Company { get; set; }

    public string? Model { get; set; }

    public short? Seats { get; set; }

    public decimal? PricePerMonth { get; set; }

    public decimal? PricePerKm { get; set; }

    public virtual ICollection<RentalsTbl> RentalsTbls { get; set; } = new List<RentalsTbl>();
}
