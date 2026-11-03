using System;
using System.Collections.Generic;

namespace sql;

public partial class EmployeePayTbl
{
    public string EmpId { get; set; } = null!;

    public short Position { get; set; }

    public DateOnly? HireDate { get; set; }

    public short? Salary { get; set; }

    public short? Bonus { get; set; }

    public virtual EmployeeTbl Emp { get; set; } = null!;
}
