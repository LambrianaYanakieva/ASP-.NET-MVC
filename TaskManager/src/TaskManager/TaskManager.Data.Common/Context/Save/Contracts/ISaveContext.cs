using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Common.Context.Save.Contracts
{
    public interface ISaveContext
    {
        void Commit();
    }
}
