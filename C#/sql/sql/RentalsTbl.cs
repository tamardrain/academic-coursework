using System;
using System.Collections.Generic;

namespace sql;

public partial class RentalsTbl
{
    public short RentalNum { get; set; }

    public short? CustId { get; set; }

    public short? CarId { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public int? Km { get; set; }

    public virtual CarsTbl? Car { get; set; }

    public virtual CustomerTbl? Cust { get; set; }
}
