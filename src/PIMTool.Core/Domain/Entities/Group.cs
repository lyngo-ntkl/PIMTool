using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMTool.Core.Domain.Entities;

public class Group: IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public decimal Id { get; set; }
    [Column(TypeName = "numeric(19, 0)")]
    public decimal GroupLeaderId { get; set; }
    [Column(TypeName = "numeric(10, 0)")]
    public decimal Version { get; set; }

    [ForeignKey(nameof(GroupLeaderId))]
    public virtual Employee? GroupLeader { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
