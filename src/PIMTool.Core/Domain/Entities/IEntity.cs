using System.ComponentModel.DataAnnotations.Schema;

namespace PIMTool.Core.Domain.Entities;

public interface IEntity
{
    [Column(TypeName = "numeric(19, 0)")]
    public decimal Id { get; set; }
}