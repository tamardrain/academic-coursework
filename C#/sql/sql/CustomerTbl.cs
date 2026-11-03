using System;
using System.Collections.Generic;

namespace sql;

public partial class CustomerTbl
{
    public short CustId { get; set; }

    public string? CustName { get; set; }

    public string? CustAddress { get; set; }

    public string? CustCity { get; set; }

    public string CustPhone { get; set; } = null!;

    public string? CustFax { get; set; }

    public string? EmpId { get; set; }

    public virtual EmployeeTbl? Emp { get; set; }

    public virtual ICollection<RentalsTbl> RentalsTbls { get; set; } = new List<RentalsTbl>();
}
