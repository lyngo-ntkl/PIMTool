using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PIMTool.Core.Domain.Enums;
using PIMTool.Core.Dtos.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMTool.Dtos.Requests
{
    public class ProjectCreateRequest
    {
        [Required]
        public decimal GroupId { get; set; }
        [Required]
        public decimal ProjectNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Customer { get; set; }
        [Required]
        [DateEarlierThan(nameof(EndDate))]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public decimal[] Members { get; set; }
    }
}
