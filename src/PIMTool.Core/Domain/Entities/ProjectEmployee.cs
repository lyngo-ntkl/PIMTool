using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIMTool.Core.Domain.Entities;

public class ProjectEmployee
{
    [Column(TypeName = "numeric(19, 0)")]
    public decimal ProjectId { get; set; }
    [Column(TypeName = "numeric(19, 0)")]
    public decimal EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public virtual Employee? Employee { get; set; }
    [ForeignKey(nameof(ProjectId))]
    public virtual Project? Project { get; set; }
}
