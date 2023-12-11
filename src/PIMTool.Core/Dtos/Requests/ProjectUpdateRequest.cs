using PIMTool.Core.Domain.Enums;
using PIMTool.Core.Dtos.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace PIMTool.Dtos.Requests
{
    public class ProjectUpdateRequest
    {
        public decimal? GroupId { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Customer { get; set; }
        public ProjectStatus? Status { get; set; }
        [DateEarlierThan(nameof(EndDate))]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Version { get; set; }
        public decimal[]? Members { get; set; }
    }
}
