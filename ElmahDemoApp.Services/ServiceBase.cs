using ElmahDemoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmahDemoApp.Services
{
    public abstract class ServiceBase
    {
        protected IDataContext Context { get; private set; }

        internal ServiceBase(IDataContext context)
        {
            Context = context;
        }
    }
}
