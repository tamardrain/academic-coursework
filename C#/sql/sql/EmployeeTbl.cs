using System;
using System.Collections.Generic;

namespace sql;

public partial class EmployeeTbl
{
    public string EmpId { get; set; } = null!;

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public int? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public virtual ICollection<CustomerTbl> CustomerTbls { get; set; } = new List<CustomerTbl>();

    public virtual ICollection<EmployeePayTbl> EmployeePayTbls { get; set; } = new List<EmployeePayTbl>();
}
