using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Web.Models.Task
{
    public class TaskViewModel
    {
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(120, MinimumLength = 5)]
        public string Content { get; set; }
    }
}