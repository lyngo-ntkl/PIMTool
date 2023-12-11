using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace PIMTool.Dtos.Response;

public class ProjectResponse
{
    public decimal Id { get; set; }
    public decimal GroupId { get; set; }
    public decimal ProjectNumber { get; set; }
    public string Name { get; set; } = null!;
    public string Customer { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Version { get; set; }
    public IEnumerable<decimal>? Members { get; set; }
}