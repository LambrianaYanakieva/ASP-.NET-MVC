using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services.TaskServices.Contracts
{
    public interface ITaskService
    {
        IQueryable<TaskModel> GetAll();

        void AddTask(TaskModel model);

        string GetUsername();
    }
}
