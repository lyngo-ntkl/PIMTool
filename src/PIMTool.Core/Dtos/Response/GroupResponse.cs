using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PIMTool.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Core.Dtos.Response
{
    public class GroupResponse
    {
        public decimal Id { get; set; }
        public decimal Version { get; set; }
        public EmployeeResponse GroupLeader { get; set; }
    }
}
