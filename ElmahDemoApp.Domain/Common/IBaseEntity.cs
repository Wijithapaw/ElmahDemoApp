using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmahDemoApp.Domain.Common
{
    public interface IBaseEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedDateUtc { get; set; }

        string LastUpdatedBy { get; set; }

        DateTime LastUpdatedDateUtc { get; set; }
    }
}
