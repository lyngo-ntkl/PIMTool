using PIMTool.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Core.Dtos.Requests
{
    public class ProjectFilterRequest
    {
        [Description("Project number, customer, name")]
        public string? GlobalFilter { get; set; }
        public ProjectStatus? Status { get; set; }
    }
}
