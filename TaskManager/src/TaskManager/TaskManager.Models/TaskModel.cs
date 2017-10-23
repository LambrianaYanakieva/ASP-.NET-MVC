using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Base;

namespace TaskManager.Models
{
    public class TaskModel : BaseModel<int>
    {
        public TaskModel()
        {
          
        }

        public TaskModel(string title, string description)
        {
            this.Title = title;
            this.Content = description;
          
        }

        public string Title { get; set; }

        public string Content { get; set; }                                        
    }
}
