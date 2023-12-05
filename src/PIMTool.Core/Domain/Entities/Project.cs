using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMTool.Core.Domain.Entities
{
    public class Project : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        [Column(TypeName = "numeric(19, 0)")]
        public decimal GroupId { get; set; }
        [Column(TypeName = "numeric(4, 0)")]
        public decimal ProjectNumber { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;
        [Column(TypeName = "nvarchar(50)")]
        public string Customer { get; set; } = null!;
        [Column(TypeName = "char(3)")]
        public string Status { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "numeric(10, 0)")]
        public decimal Version { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group? Group { get; set; }
    }
}