using System;
using System.Collections.Generic;

namespace SoniaGhandiAPI.DataLayer;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public int? DepartmentId { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Department? Department { get; set; }
}
