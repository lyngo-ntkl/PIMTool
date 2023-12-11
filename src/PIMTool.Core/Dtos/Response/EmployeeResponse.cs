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
    public class EmployeeResponse
    {
        public decimal Id { get; set; }
        public string Visa { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Version { get; set; }
    }
}
