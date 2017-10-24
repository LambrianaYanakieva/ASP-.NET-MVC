using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Web.Areas.Administration.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<TaskModel> tasks { get; set; }
    }
}