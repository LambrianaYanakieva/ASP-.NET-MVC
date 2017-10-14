using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Context.Save.Contracts;

namespace TaskManager.Data.Common.Context.Save
{
    public class SaveContext : ISaveContext
    {
        private readonly DbContext context;

        public SaveContext(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
