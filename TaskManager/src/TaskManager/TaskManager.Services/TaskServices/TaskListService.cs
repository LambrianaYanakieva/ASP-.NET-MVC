using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Context.Save.Contracts;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;

namespace TaskManager.Services.TaskServices
{
    public class TaskListService
    {
        private IDbRepository<TaskModel> taskRepo;
        private IPrincipal identity;
        private ISaveContext saveContext;

        public TaskListService(IDbRepository<TaskModel> taskRepo, IPrincipal identity
            ,ISaveContext saveContext)
        {
            this.taskRepo = taskRepo;
            this.identity = identity;
            this.saveContext = saveContext; 
        }

        public IQueryable<TaskModel> GetAll()
        {
            return this.taskRepo.All().Where(m => m.User.Email.ToLower() ==
            this.identity.Identity.Name.ToLower());
        }

        public void AddTask(TaskModel model)
        {
            this.taskRepo.Add(model);
            this.saveContext.Commit();
        }
    }
}
