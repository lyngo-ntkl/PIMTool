using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMTool.Core.Domain.Entities;

public class Employee: IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public decimal Id { get; set; }
    [Column(TypeName = "char(3)")]
    public string Visa { get; set; } = null!;
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;
    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }
    [Column(TypeName = "numeric(10, 0)")]
    public decimal Version { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}
