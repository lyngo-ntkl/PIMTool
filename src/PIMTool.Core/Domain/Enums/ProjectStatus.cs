using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Core.Domain.Enums
{
    public enum ProjectStatus
    {
        [Description("New")]
        NEW,
        [Description("Planned")]
        PLA,
        [Description("In progress")]
        INP,
        [Description("Finished")]
        FIN
    }
}
