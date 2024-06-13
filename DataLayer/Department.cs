using System;
using System.Collections.Generic;

namespace SoniaGhandiAPI.DataLayer;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? TestOk { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
